using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessments.Mapping;
using Assessments.Mapping.Models.Source.Species;
using Assessments.Mapping.Models.Species;
using Assessments.Shared.Helpers;
using Assessments.Transformation.Database.Rodliste2020;
using AutoMapper;
using Azure.Storage.Blobs;
using ByteSizeLib;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShellProgressBar;
using Microsoft.Extensions.Configuration;

namespace Assessments.Transformation
{
    // henter vurderinger fra rødlistedatabasen, transformerer til ulike datamodeller og lagrer som jsonfiler i azure blobstorage
    internal class Program
    {
        private static int _menuIndex;
        private static Rodliste2020Context _dbContext;
        private static ProgressBar _progressBar;
        private static long _uploadFileSize;
        private static BlobContainerClient _blobContainer;

        private static async Task Main()
        {
            var configuration = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

            var blobConnectionString = configuration["ConnectionStrings:AzureBlobStorage"];
            
            if (string.IsNullOrEmpty(blobConnectionString))
                throw new Exception("ConnectionStrings:AzureBlobStorage (app secret) mangler");

            _blobContainer = new BlobContainerClient(blobConnectionString, "assessments");

            await _blobContainer.CreateIfNotExistsAsync();

            var databaseConnectionString = configuration["ConnectionStrings:Rodliste2020"];
            
            if (string.IsNullOrEmpty(databaseConnectionString))
                throw new Exception("ConnectionStrings:Rodliste2020 (app secret) mangler");

            var optionsBuilder = new DbContextOptionsBuilder<Rodliste2020Context>().UseSqlServer(databaseConnectionString);
            _dbContext = new Rodliste2020Context(optionsBuilder.Options);

            if (!await _dbContext.Database.CanConnectAsync())
                throw new Exception("Kan ikke koble til databasen");

            Console.Clear();
            Console.CursorVisible = false;

            var menuItems = new List<string> { "Transformer til filer lokalt", "Transformer og last opp på Azure", "Avslutt" };

            while (true)
            {
                var item = CreateMenu(menuItems);

                switch (item)
                {
                    case "Transformer til filer lokalt":
                        await TransformDataModels();
                        Environment.Exit(0);
                        break;
                    case "Transformer og last opp på Azure":
                        await TransformDataModels(upload: true);
                        Environment.Exit(0);
                        break;
                    case "Avslutt":
                        Environment.Exit(0);
                        break;
                }
            }
        }

        private static async Task TransformDataModels(bool upload = false)
        {
            _progressBar = new ProgressBar(100, "Henter vurderinger", new ProgressBarOptions
            {
                DisplayTimeInRealTime = false,
                EnableTaskBarProgress = true
            });

            var databaseAssessments = _dbContext.Assessments.AsNoTracking().Where(x => (bool)!x.IsDeleted && x.Expertgroup != "Testarter" && x.Expertgroup != "Moser (Svalbard)");
            var totalCount = await databaseAssessments.CountAsync();

            _progressBar.Tick(0, $"Transformerer {totalCount:N0} vurderinger");
            _progressBar.MaxTicks = totalCount;

            var rodliste2019Assessments = new List<Rodliste2019>();
            var speciesAssessment2021Mapper = new MapperConfiguration(cfg => cfg.AddProfile<SpeciesAssessment2021Profile>()).CreateMapper();
            var speciesAssessment2021Assessments = new List<SpeciesAssessment2021>();

            foreach (var item in databaseAssessments)
            {
                var assessment = JsonConvert.DeserializeObject<Rodliste2019>(item.Doc);
                if (assessment != null)
                {
                    assessment.Id = item.Id.ToString(); // id fra databasen
                    speciesAssessment2021Assessments.Add(speciesAssessment2021Mapper.Map<SpeciesAssessment2021>(assessment));
                    rodliste2019Assessments.Add(assessment);
                }
                _progressBar.Tick();
            }
            
            _progressBar.Message = "Serialiserer og lagrer filer (tar litt tid)";
            
            var files = new Dictionary<string, string> {
                {DataFilenames.Species2021, JsonConvert.SerializeObject(speciesAssessment2021Assessments)}, 
                {DataFilenames.Species2021Temp, JsonConvert.SerializeObject(rodliste2019Assessments)}
            };
            
            const string dataFolder = @"../../../../Assessments.Frontend.Web/Cache/";
            
            if (!Directory.Exists(dataFolder))
                Directory.CreateDirectory(dataFolder);

            foreach (var (key, value) in files)
            {
                await File.WriteAllTextAsync(Path.Combine(dataFolder, key), value);

                if (!upload) 
                    continue;
                
                _progressBar.Tick(0, $"Laster opp {key}");
                _progressBar.MaxTicks = 100;

                var progressHandler = new Progress<long>();
                progressHandler.ProgressChanged += UploadProgressChanged;

                var bytesToUpload = Encoding.UTF8.GetBytes(value);
                _uploadFileSize = bytesToUpload.Length;

                await using var stream = new MemoryStream(bytesToUpload);
                await _blobContainer.GetBlobClient(key).UploadAsync(stream, progressHandler: progressHandler);
            }

            _progressBar.Message = "Transformering fullført";
            _progressBar.Dispose();
        }

        private static void UploadProgressChanged(object sender, long bytesUploaded) => _progressBar.Tick((int)GetProgressPercentage(_uploadFileSize, bytesUploaded), $"Laster opp vurderinger {ByteSize.FromBytes(bytesUploaded).MegaBytes:#} MB av {ByteSize.FromBytes(_uploadFileSize).MegaBytes:#} MB");

        private static double GetProgressPercentage(double totalSize, double currentSize) => currentSize / totalSize * 100;

        private static string CreateMenu(IReadOnlyList<string> items)
        {
            for (var i = 0; i < items.Count; i++)
            {
                if (i == _menuIndex)
                {
                    Console.BackgroundColor = ConsoleColor.Gray;
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine(items[i]);
                }
                else
                {
                    Console.WriteLine(items[i]);
                }
                Console.ResetColor();
            }

            var keyInfo = Console.ReadKey();

            switch (keyInfo)
            {
                case { Key: ConsoleKey.DownArrow } when _menuIndex == items.Count - 1:
                    break;
                case { Key: ConsoleKey.DownArrow }:
                    _menuIndex++;
                    break;
                case { Key: ConsoleKey.UpArrow } when _menuIndex <= 0:
                    break;
                case { Key: ConsoleKey.UpArrow }:
                    _menuIndex--;
                    break;
                case { Key: ConsoleKey.LeftArrow }:
                case { Key: ConsoleKey.RightArrow }:
                    Console.Clear();
                    break;
                case { Key: ConsoleKey.Enter }:
                    return items[_menuIndex];
                case { Key: ConsoleKey.Escape }:
                    Environment.Exit(0);
                    break;
                default:
                    return string.Empty;
            }

            Console.Clear();
            return string.Empty;
        }
    }
}
