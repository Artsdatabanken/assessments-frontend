using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Assessments.Transformation.Helpers;
using Microsoft.Extensions.Configuration;

namespace Assessments.Transformation
{
    internal class Program
    {
        /// <summary>
        /// Henter ekspertvurderinger, transformerer til datamodeller og lagrer som json lokalt eller i azure blobstorage
        /// </summary>
        private static async Task Main()
        {
            var configuration = new ConfigurationBuilder().AddUserSecrets<Program>().Build();

            Console.Clear();
            Console.CursorVisible = false;

            var menuItems = new List<string>
            {
                "Rødlista 2021 - transformer til filer lokalt",
                "Rødlista 2021 - transformer og last opp i Azure",
                "Avslutt"
            };

            while (true)
            {
                var item = Menu.Setup(menuItems);

                switch (item)
                {
                    case "Rødlista 2021 - transformer til filer lokalt":
                        await Species.TransformDataModels(configuration);
                        Environment.Exit(0);
                        break;
                    case "Rødlista 2021 - transformer og last opp i Azure":
                        await Species.TransformDataModels(configuration, upload: true);
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
