using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Assessments.Transformation.Helpers;
using Microsoft.Extensions.Configuration;

namespace Assessments.Transformation
{
    internal class Program
    {
        private static async Task Main()
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddUserSecrets<Program>()
                .Build();
            
            Console.Clear();
            Console.CursorVisible = false;

            var dataFolder = configuration.GetValue<string>("FilesFolder");

            if (string.IsNullOrEmpty(dataFolder))
                throw new Exception("Innstilling for 'FilesFolder' mangler");

            if (!Directory.Exists(dataFolder))
                Directory.CreateDirectory(dataFolder);

            var menuItems = new List<string>
            {
                "Rødlista 2021 - til filer lokalt",
                "Rødlista 2021 - last opp i Azure",
                "Fremmedartslista 2023 - til filer lokalt",
                "Fremmedartslista 2023 - last opp i Azure",
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
                    case "Avslutt":
                        Environment.Exit(0);
                        break;
                }
            }
        }
    }
}
