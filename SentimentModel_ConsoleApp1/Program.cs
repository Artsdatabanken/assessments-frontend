using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;
using SentimentModel_ConsoleApp1;

var baseDir = "C:\\temp\\ml\\";
var fileName = "originalfilToConvert.xlsx";

if (fileName.Contains("xls"))
{
    // convert file to csv
    var convertedFileName = "convertedFile.csv";
    if (FileConverter.ConvertExcelToCsv(baseDir, fileName, convertedFileName))
        fileName = convertedFileName;
}

var recordsList = CsvFileHandler.ReadFile(baseDir, fileName);
if (recordsList == null)
    return;

var sanitizedRecordsList = Sanitation.Sanitize(recordsList);

CsvFileHandler.WriteFile(baseDir, "sanitized_" + fileName, sanitizedRecordsList);


public class Headers
{
    public string? RENr { get; set; }
    public string? Nr { get; set; }
    public string? N { get; set; }
    public string? Institusj { get; set; }
    public string? CatNr { get; set; }
    public string? Type { get; set; }
    public string? AntId { get; set; }
    public string? SumQ { get; set; }
    public string? REKo { get; set; }
    public string? RE_Navn { get; set; }
    public string? Korr { get; set; }
    public string? Forkastet { get; set; }
    public string? Årsak { get; set; }
    public string? X_2km { get; set; }
    public string? Y_2Km { get; set; }
    public string? PrKl { get; set; }
    public string? Fy { get; set; }
    public string? KoNr { get; set; }
    public string? Kommune { get; set; }
    [Name("Samkopiert lokalitet \\ økologi / kvantitet")]
    public string? Samkopiert { get; set; }
    public string? YYYY { get; set; }
    public string? MM { get; set; }
    public string? DD { get; set; }
    public string? Collector { get; set; }
    public string? X33 { get; set; }
    public string? Y33 { get; set; }
    public string? X2km_33 { get; set; }
    public string? Y2km_33 { get; set; }
    public string? CoorPrec { get; set; }
    public string? KoTreff { get; set; }
    public string? ScientificName { get; set; }
    public string? ScientificNameAuthor { get; set; }
    public string? IdentificationPrecision { get; set; }
    public string? IdentifiedBy { get; set; }
    public string? Datasett_Kode { get; set; }
    public string? Id { get; set; }
    public string? URL { get; set; }
}

public class FooMap : ClassMap<Headers>
{
    public FooMap()
    {
        Map(m => m.Samkopiert).Index(19).Name("Samkopiert lokalitet \\ økologi / kvantitet");
    }
}
