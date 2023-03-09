using CsvHelper;
using System.Globalization;

namespace SentimentModel_ConsoleApp1
{
    internal class CsvFileHandler
    {
        public static bool ReadFile()
        {
            return false;
        }

        public static bool WriteFile(string basePath, string fileName, IEnumerable<dynamic> lines)
        {
            try
            {

                var writer = new StreamWriter(basePath + "cleaned_" + fileName, false, System.Text.Encoding.UTF8);
                var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

                csvWriter.WriteHeader<Headers>();
                csvWriter.NextRecord();
                foreach (var line in lines)
                {
                    csvWriter.WriteRecord(line);
                    csvWriter.NextRecord();
                }
                writer.Close();
                Console.WriteLine($"\nFile written: {basePath + "cleaned_" + fileName}.");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nUnable to write file {basePath + fileName}. Exception: {e}");
                return false;
            }
        }
    }
}
