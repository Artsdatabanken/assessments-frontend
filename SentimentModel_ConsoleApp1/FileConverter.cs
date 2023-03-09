using ExcelDataReader;
using System.Text;

namespace SentimentModel_ConsoleApp1
{
    internal class FileConverter
    {
        public static bool ConvertExcelToCsv(string baseDirectory, string excelFilePath, string? csvFileName)
        {
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            Console.WriteLine($"\nOpening file {excelFilePath}...");

            using var stream = new FileStream(baseDirectory + excelFilePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            IExcelDataReader? reader = null;
            if (excelFilePath.EndsWith(".xls"))
            {
                reader = ExcelReaderFactory.CreateBinaryReader(stream);
            }
            else if (excelFilePath.EndsWith(".xlsx"))
            {
                reader = ExcelReaderFactory.CreateOpenXmlReader(stream);
            }
            if (reader == null)
                return false;

            var dataSet = reader.AsDataSet(new ExcelDataSetConfiguration()
            {
                ConfigureDataTable = (tableReader) => new ExcelDataTableConfiguration()
                {
                    UseHeaderRow = false
                }
            });
            var csvContent = string.Empty;
            var rowNumber = 0;

            while (rowNumber < dataSet.Tables[0].Rows.Count)
            {
                if (rowNumber % 1000 == 0)
                    Console.WriteLine($"\nConverting line {rowNumber} of {dataSet.Tables[0].Rows.Count}.");
                var arr = new List<string>();
                for (int i = 0; i < dataSet.Tables[0].Columns.Count; i++)
                {
                    var str = dataSet.Tables[0].Rows[rowNumber][i].ToString() ?? string.Empty;
                    //need to avoid single " characters in the string
                    if (str.Contains('"'))
                        str = str.Replace("\"", "\"\"");
                    // need to encapsulate strings containing comma
                    if (str.Contains(',') || str.Contains('"'))
                        str = $"\"{str}\"";
                    arr.Add(str);

                }
                rowNumber += 1;
                csvContent += string.Join(",", arr) + "\n";
            }

            var newFilePath = !string.IsNullOrEmpty(csvFileName) ? csvFileName : $"{excelFilePath.Split('.')[0]}.csv";
            var csv = new StreamWriter(baseDirectory + newFilePath, false, System.Text.Encoding.UTF8);
            Console.WriteLine($"\nWriting to file {baseDirectory + newFilePath}.");
            csv.Write(csvContent);
            Console.WriteLine($"\nFile written");
            csv.Close();
            return true;
        }
    }
}
