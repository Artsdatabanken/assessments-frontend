using SentimentModel_ConsoleApp1;

var baseDir = System.AppContext.BaseDirectory ; //"C:\\temp\\ml\\";
var fileName = "Sambucus racemosa.csv";
var prependString = "sanitized_";
var convertedFileName = "convertedFile.csv";
var targettingFields = new List<string>() { "Samkopiert lokalitet \\ økologi / kvantitet" };
var replaceWith = "**Innholdet er skjult av personvernhensyn. Vennligst ta kontakt med Artsdatabanken for mer info.**";
var overWrite = true;

// If overWrite is set to false, check if the new sanitized file exists already
var existingPath = baseDir + prependString + convertedFileName;
var fileExists = File.Exists(existingPath);
if (!overWrite && fileExists)
    return;

if (fileName.Contains("xls"))
{
    // convert file to csv
    if (FileConverter.ConvertExcelToCsv(baseDir, fileName, convertedFileName))
        fileName = convertedFileName;
}

var recordsList = CsvFileHandler.ReadFile(baseDir, fileName);
if (recordsList == null)
    return;

var sanitizedRecordsList = Sanitation.Sanitize(recordsList, targettingFields, replaceWith);

CsvFileHandler.WriteFile(baseDir, prependString + fileName, sanitizedRecordsList);
