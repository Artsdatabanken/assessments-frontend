using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using SentimentModel_ConsoleApp1;
using System.Globalization;

var baseDir = "C:\\temp\\ml\\";
var fileName = "originalfil.xlsx";

if (fileName.Contains("xls"))
{
    // convert file to csv
    var convertedFileName = "convertedFile.csv";
    if (FileConverter.ConvertExcelToCsv(baseDir, fileName, convertedFileName))
        fileName = convertedFileName;
}

using (var reader = new StreamReader(baseDir + fileName, System.Text.Encoding.GetEncoding("iso-8859-1")))
using (var writer = new StreamWriter(baseDir + "cleaned_" + fileName, false, System.Text.Encoding.UTF8))
using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
    var records = csvReader.GetRecords<Headers>();
    var hitCount = 0;
    var progressCount = 0;
    var actualProgress = 0.0;

    var recordsList = new List<Headers>();
    foreach (var line in records)
    {
        recordsList.Add(line);
    }

    var recordsLength = recordsList.Count;
    Console.WriteLine($"\nProgress {progressCount} av {recordsLength}: 0.0 %");

    foreach (var record in recordsList)
    {
        SentimentModel.ModelInput sampleData = new SentimentModel.ModelInput()
        {
            Tried = record.Samkopiert,
        };
        //Make a single prediction on the sample data and print results
        var predictionResult = SentimentModel.Predict(sampleData);
        if (predictionResult.PredictedLabel)
        {
            hitCount += 1;
            record.Samkopiert = "**Innholdet er skjult av personvernhensyn. Vennligst ta kontakt med Artsdatabanken for mer info.**";
        }
        progressCount += 1;
        var newProgress = Math.Floor((double)progressCount / recordsLength * 100) / 100;
        if (newProgress != actualProgress)
        {
            actualProgress = newProgress;
            Console.WriteLine($"\nProgress {progressCount} av {recordsLength}: {actualProgress * 100}%");
        }
    }
    Console.WriteLine($"Number of hits: {hitCount}");

    csvWriter.WriteHeader<Headers>();
    csvWriter.NextRecord();
    foreach (var record in recordsList)
    {
        csvWriter.WriteRecord(record);
        csvWriter.NextRecord();
    }
}


public class Headers
{
    public string RENr { get; set; }
    public string Nr { get; set; }
    public string N { get; set; }
    public string Institusj { get; set; }
    public string CatNr { get; set; }
    public string Type { get; set; }
    public string AntId { get; set; }
    public string SumQ { get; set; }
    public string REKo { get; set; }
    public string RE_Navn { get; set; }
    public string Korr { get; set; }
    public string Forkastet { get; set; }
    public string Årsak { get; set; }
    public string X_2km { get; set; }
    public string Y_2Km { get; set; }
    public string PrKl { get; set; }
    public string Fy { get; set; }
    public string KoNr { get; set; }
    public string Kommune { get; set; }
    [Name("Samkopiert lokalitet \\ økologi / kvantitet")]
    public string Samkopiert { get; set; }
    public string YYYY { get; set; }
    public string MM { get; set; }
    public string DD { get; set; }
    public string Collector { get; set; }
    public string X33 { get; set; }
    public string Y33 { get; set; }
    public string X2km_33 { get; set; }
    public string Y2km_33 { get; set; }
    public string CoorPrec { get; set; }
    public string KoTreff { get; set; }
    public string ScientificName { get; set; }
    public string ScientificNameAuthor { get; set; }
    public string IdentificationPrecision { get; set; }
    public string IdentifiedBy { get; set; }
    public string Datasett_Kode { get; set; }
    public string Id { get; set; }
    public string URL { get; set; }
}

public class FooMap : ClassMap<Headers>
{
    public FooMap()
    {
        Map(m => m.Samkopiert).Index(19).Name("Samkopiert lokalitet \\ økologi / kvantitet");
    }
}
