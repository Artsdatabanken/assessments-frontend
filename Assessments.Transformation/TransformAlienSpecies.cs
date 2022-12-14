using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Assessments.Mapping.AlienSpecies.Model;
using Assessments.Mapping.AlienSpecies.Profiles;
using Assessments.Mapping.AlienSpecies.Source;
using Assessments.Shared.Helpers;
using Assessments.Transformation.Database.Fab4;
using Assessments.Transformation.Helpers;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShellProgressBar;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace Assessments.Transformation
{
    public class TransformAlienSpecies
    {
        private static Fab4Context _dbContext;

        public static async Task TransformDataModels(IConfigurationRoot configuration, bool upload)
        {
            await SetupDatabaseContext(configuration);

            Progress.ProgressBar = new ProgressBar(100, "Henter vurderinger", new ProgressBarOptions
            {
                DisplayTimeInRealTime = false,
                EnableTaskBarProgress = true
            });

            var excludedExpertGroups = new List<string> { "Testedyr", "Ikke-marine invertebrater" };

            var databaseAssessments = _dbContext.Assessments.AsNoTracking()
                .Where(x => (bool) !x.IsDeleted && !excludedExpertGroups.Contains(x.Expertgroup));

            var totalCount = await databaseAssessments.CountAsync();

            Progress.ProgressBar.Tick(0, $"Transformerer {totalCount:N0} vurderinger");
            Progress.ProgressBar.MaxTicks = totalCount;

            var sourceItems = new List<FA4>();
            var targetItems = new List<AlienSpeciesAssessment2023>();
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<AlienSpeciesAssessment2023Profile>()).CreateMapper();

            foreach (var assessment in databaseAssessments)
            {
                var fa4 = JsonSerializer.Deserialize<FA4>(assessment.Doc);

                if (fa4 == null)
                    continue;

                // ekskluderer vurderinger som ligger under horisontskanning eller ikke har kategori
                if (fa4.HorizonDoScanning || string.IsNullOrEmpty(fa4.Category))
                {
                    Progress.ProgressBar.Tick();
                    continue;
                }

                // ekskluderer vurderinger som er "ikke fremmed" i 2023 og 2018
                if (fa4.AlienSpeciesCategory == "NotAlienSpecie" && fa4.PreviousAssessments.FirstOrDefault(x => x.RevisionYear == 2018) is { MainCategory: "NotApplicable", MainSubCategory: "notAlienSpecie" })
                {
                    Progress.ProgressBar.Tick();
                    continue;
                }

                fa4.Id = assessment.Id;
                sourceItems.Add(fa4);

                var transformedAssessment = mapper.Map<AlienSpeciesAssessment2023>(fa4);
                targetItems.Add(transformedAssessment);

                Progress.ProgressBar.Tick();
            }

            Progress.ProgressBar.Message = "Serialiserer og lagrer filer (tar litt tid)";

            var files = new Dictionary<string, string>
            {
                {
                    DataFilenames.AlienSpecies2023, JsonSerializer.Serialize(targetItems)
                },
                {
                    DataFilenames.AlienSpecies2023Temp, JsonSerializer.Serialize(sourceItems)
                }
            };

            foreach (var (key, value) in files)
            {
                await File.WriteAllTextAsync(Path.Combine(configuration.GetValue<string>("FilesFolder"), key), value);

                if (upload)
                    await Storage.Upload(configuration, key, value);
            }

            Progress.ProgressBar.Message = $"Transformering fullført, {sourceItems.Count} vurderinger ble lagret";
            Progress.ProgressBar.Dispose();
        }

        private static async Task SetupDatabaseContext(IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Fab4");

            if (string.IsNullOrEmpty(connectionString))
                throw new Exception("ConnectionStrings:Fab4 (app secret) mangler");

            var optionsBuilder = new DbContextOptionsBuilder<Fab4Context>().UseSqlServer(connectionString);
            _dbContext = new Fab4Context(optionsBuilder.Options);

            if (!await _dbContext.Database.CanConnectAsync())
                throw new Exception("Kan ikke koble til databasen");
        }
    }
}