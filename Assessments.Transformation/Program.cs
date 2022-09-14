using System;
using System.Collections.Generic;
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
                        await TransformSpecies.TransformDataModels(configuration);
                        Environment.Exit(0);
                        break;
                    case "Rødlista 2021 - last opp i Azure":
                        await TransformSpecies.TransformDataModels(configuration, upload: true);
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
