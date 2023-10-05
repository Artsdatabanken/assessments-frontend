using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Threading.Tasks;
using Assessments.Transformation.Helpers;
using Assessments.Shared.Options;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Raven.Abstractions.Data;
using Raven.Client.Document;
using Raven.Client;
using Assessments.Frontend.Web.Infrastructure;
using Assessments.Transformation;
using LazyCache;



Console.Clear();
Console.CursorVisible = false;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddUserSecrets<Program>()
    .Build();

var dataFolder = configuration.GetValue<string>("FilesFolder");

if (string.IsNullOrEmpty(dataFolder))
    throw new Exception("Innstilling for 'FilesFolder' mangler");

if (!Directory.Exists(dataFolder))
    Directory.CreateDirectory(dataFolder);

CultureInfo.DefaultThreadCurrentCulture = new CultureInfo("nb-NO");

var menuItems = new List<string>
            {
                "Rødlista 2021 - til filer lokalt",
                "Rødlista 2021 - last opp i Azure",
                "Fremmedartslista 2023 - til filer lokalt",
                "Fremmedartslista 2023 - last opp i Azure",
                "Fremmedartslista 2023 - last opp vedlegg til vurderinger til Azure",
                "Publiser dynamicProperties til TaxonApi",
                "Avslutt"
            };

while (true)
{
    var item = Menu.Setup(menuItems);

    switch (item)
    {
        case "Rødlista 2021 - til filer lokalt":
            await TransformRedlistSpecies.TransformDataModels(configuration);
            Environment.Exit(0);
            break;
        case "Rødlista 2021 - last opp i Azure":
            await TransformRedlistSpecies.TransformDataModels(configuration, upload: true);
            Environment.Exit(0);
            break;
        case "Fremmedartslista 2023 - til filer lokalt":
            await TransformAlienSpecies.TransformDataModels(configuration, upload: false);
            Environment.Exit(0);
            break;
        case "Fremmedartslista 2023 - last opp i Azure":
            await TransformAlienSpecies.TransformDataModels(configuration, upload: true);
            Environment.Exit(0);
            break;
        case "Fremmedartslista 2023 - last opp vedlegg til vurderinger til Azure":
            await TransformAlienSpecies.UploadAttachments(configuration, upload: true);
            Environment.Exit(0);
            break;
        case "Publiser dynamicProperties til TaxonApi":

            IAppCache appCache = new CachingService();
            var publishDynamicProperties = new PublishDynamicProperties(configuration);
            var dynamicProperties = await publishDynamicProperties.ImportAlienList2023();
            dynamicProperties.AddRange( await publishDynamicProperties.ImportRedlist2021() );

            Environment.Exit(0);
            break;
        case "Avslutt":
            Environment.Exit(0);
            break;
    }
}

namespace Assessments.Transformation
{

    //class Program
    //{
    //    private string test = "hello"; //this is never reached
    //}



    // The `DocumentStoreHolder` class holds a single Document Store instance.
    public class DocumentStoreHolder
    {
        private static Lazy<IDocumentStore> store = new Lazy<IDocumentStore>(CreateStore);

        public static IDocumentStore Store
        {
            get { return store.Value; }
        }

        private static IDocumentStore CreateStore()
        {
            IDocumentStore store = new DocumentStore()
            {
                ConnectionStringName = "DatabankRavenDB"
            }.Initialize();

            return store;
        }
    }
}
