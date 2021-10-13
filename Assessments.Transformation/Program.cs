using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Assessments.Mapping;
using Assessments.Mapping.Models.Source.Species;
using Assessments.Mapping.Models.Species;
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
    // henter vurderinger fra databasen for rødlista, transformerer og lagrer data som json på i azure blobstorage
    // NOTE: koden transformerer og lagrer datamodellen Rodliste2019 akkurat nå (slik at mapping til SpeciesAssessment2021 modellen gjøres "on-the-fly" ved kodeendringer). Dette kan/og bør gjøres om til å lagre som SpeciesAssessment2021 når all mapping er ferdig og man vil optimalisere oppstart (slippe å gjøre mapping så ofte)
    internal class Program
    {
        private static ProgressBar _progressBar;
        private static long _uploadFileSize;

        private static async Task Main()
        {
            var configuration = new ConfigurationBuilder().AddUserSecrets<Program>().Build();
            
            var blobConnectionString = configuration["ConnectionStrings:AzureBlobStorage"];

            if (string.IsNullOrEmpty(blobConnectionString))
                throw new Exception("ConnectionStrings:AzureBlobStorage (app secret) mangler");

            var blobContainer = new BlobContainerClient(blobConnectionString, "assessments");

            await blobContainer.CreateIfNotExistsAsync();

            var databaseConnectionString = configuration["ConnectionStrings:Rodliste2020"];

            if (string.IsNullOrEmpty(databaseConnectionString))
                throw new Exception("ConnectionStrings:Rodliste2020 (app secret) mangler");

            var optionsBuilder = new DbContextOptionsBuilder<Rodliste2020Context>().UseSqlServer(databaseConnectionString);
            var dbContext = new Rodliste2020Context(optionsBuilder.Options);

            if (!await dbContext.Database.CanConnectAsync())
                throw new Exception("Kan ikke koble til databasen");

            _progressBar = new ProgressBar(100, "Henter vurderinger", new ProgressBarOptions
            {
                DisplayTimeInRealTime = false,
                EnableTaskBarProgress = true
            });
            
            var databaseAssessments = dbContext.Assessments.AsNoTracking().Where(x => (bool)!x.IsDeleted && x.Expertgroup != "Testarter" && x.Expertgroup != "Moser (Svalbard)");

            var totalCount = await databaseAssessments.CountAsync();
            
            _progressBar.Tick(0, $"Transformerer {totalCount:N0} vurderinger");
            _progressBar.MaxTicks = totalCount;
            
            //var assessments = new List<SpeciesAssessment2021>();
            var mapper = new MapperConfiguration(cfg => cfg.AddProfile<SpeciesAssessment2021Profile>()).CreateMapper();

            var assessments = new List<Rodliste2019>();

            foreach (var item in databaseAssessments)
            {
                var deserializedAssessment = JsonConvert.DeserializeObject<Rodliste2019>(item.Doc);
                if (deserializedAssessment != null)
                {
                    deserializedAssessment.Id = item.Id.ToString(); // id fra databasen
                    
                    //assessments.Add(mapper.Map<SpeciesAssessment2021>(deserializedAssessment)); // 
                    assessments.Add(deserializedAssessment);
                }

                _progressBar.Tick();
            }

            _progressBar.Message = "Transformering fullført";

            // NOTE: filnavn er species-2021-temp.json for Rodliste2019 datamodell og species-2021.json for SpeciesAssessment2021
            // TODO: bruk Constants (som først må flyttes til Shared prosjektet) 

            // lagre til lokal fil
            //const string dataFolder = @"../../../Output/";
            //if (!Directory.Exists(dataFolder))
            //    Directory.CreateDirectory(dataFolder);
            //await File.WriteAllTextAsync(Path.Combine(dataFolder, "species-2021-temp.json"), JsonConvert.SerializeObject(assessments));

            _progressBar.Tick(0, "Laster opp vurderinger");
            _progressBar.MaxTicks = 100;

            var progressHandler = new Progress<long>();
            progressHandler.ProgressChanged += UploadProgressChanged;

            var bytesToUpload = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(assessments));
            _uploadFileSize = bytesToUpload.Length;

            await using (var stream = new MemoryStream(bytesToUpload))
                await blobContainer.GetBlobClient("species-2021-temp.json").UploadAsync(stream, progressHandler: progressHandler);

            _progressBar.Message = "Opplasting fullført";
            _progressBar.Dispose();
        }

        private static void UploadProgressChanged(object sender, long bytesUploaded) => _progressBar.Tick((int) GetProgressPercentage(_uploadFileSize, bytesUploaded), $"Laster opp vurderinger {ByteSize.FromBytes(bytesUploaded).MegaBytes:#} MB av {ByteSize.FromBytes(_uploadFileSize).MegaBytes:#} MB");

        private static double GetProgressPercentage(double totalSize, double currentSize) => currentSize / totalSize * 100;
    }
}
