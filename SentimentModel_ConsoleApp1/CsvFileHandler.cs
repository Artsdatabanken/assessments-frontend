using CsvHelper;
using System.Globalization;

namespace SentimentModel_ConsoleApp1
{
    internal class CsvFileHandler
    {
        /// <summary>
        /// Reads the file and returns a list of lines
        /// </summary>
        /// <param name="basePath">The path to the file, including trailing slash</param>
        /// <param name="fileName">The name of the file itself</param>
        /// <returns></returns>
        internal static IEnumerable<dynamic>? ReadFile(string basePath, string fileName)
        {
            if (!fileName.EndsWith(".csv"))
                fileName += ".csv";

            try
            {
                var reader = new StreamReader(basePath + fileName, System.Text.Encoding.GetEncoding("iso-8859-1"));
                var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture);
                var records = csvReader.GetRecords<Headers>();
                var recordsList = new List<Headers>();

                foreach (var line in records)
                {
                    recordsList.Add(line);
                }
                reader.Close();
                return recordsList;
            }
            catch (Exception e)
            {
                Console.WriteLine($"\nUnable to read file {basePath + fileName}. Exception: {e}");
                return null;
            }
        }

        /// <summary>
        /// Write the provided list of lines to a csv file
        /// </summary>
        /// <param name="basePath">The path to the file, including trailing slash</param>
        /// <param name="fileName">The name of the file itself</param>
        /// <param name="lines">The list of lines to be written</param>
        /// <returns></returns>
        internal static bool WriteFile(string basePath, string fileName, IEnumerable<dynamic> lines)
        {
            if (!fileName.EndsWith(".csv"))
                fileName += ".csv";

            try
            {
                var writer = new StreamWriter(basePath + fileName, false, System.Text.Encoding.UTF8);
                var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);

                csvWriter.WriteHeader<Headers>();
                csvWriter.NextRecord();
                foreach (var line in lines)
                {
                    csvWriter.WriteRecord(line);
                    csvWriter.NextRecord();
                }
                writer.Close();
                Console.WriteLine($"\nFile written: {basePath + fileName}.");
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
