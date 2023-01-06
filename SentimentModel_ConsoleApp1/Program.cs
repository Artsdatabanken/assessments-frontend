using CsvHelper;
using CsvHelper.Configuration;
using SentimentModel_ConsoleApp1;
using System.Globalization;

using (var reader = new StreamReader("C:\\temp\\ml\\ml_only_raw.csv", System.Text.Encoding.GetEncoding("iso-8859-1")))
using (var writer = new StreamWriter("C:\\temp\\ml\\ml_only_raw_new.csv", false, System.Text.Encoding.UTF8))
using (var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    var csvWriter = new CsvWriter(writer, CultureInfo.InvariantCulture);
    var records = csvReader.GetRecords<Headers>();
    var hitCount = 0;
    var progressCount = 0;
    var actualProgress = 0.0;
    var resultList = new List<bool>();

    var recordsList = new List<string>();
    foreach (var line in records)
    {
        recordsList.Add(line.Column);
    }

    var recordsLength = recordsList.Count;
    Console.WriteLine($"\nProgress {progressCount} av {recordsLength}: 0.0 %");

    for (var i = 0; i < recordsList.Count; i++)
    {
        SentimentModel.ModelInput sampleData = new SentimentModel.ModelInput()
        {
            Sånn_ting = recordsList[i],
        };
        //Make a single prediction on the sample data and print results
        var predictionResult = SentimentModel.Predict(sampleData);
        if (predictionResult.PredictedLabel)
        {
            hitCount += 1;
            //Console.WriteLine($"{sampleData.Sånn_ting} - {predictionResult.PredictedLabel} \n");
        }
        resultList.Add(predictionResult.PredictedLabel);
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
    for (var i = 0; i < resultList.Count; i++)
    {
        var record = new Headers { Column = recordsList[i], Result = resultList[i].ToString() };
        csvWriter.WriteRecord(record);
        csvWriter.NextRecord();
    }
}


public class Headers
{
    public string Column { get; set; }

    public string Result { get; set; }
}

public class FooMap : ClassMap<Headers>
{
    public FooMap()
    {
        //Map(m => m.Column).Index(0).Name("Column");
        Map(m => m.Result).Index(1).Name("Result");
    }
}



//Console.WriteLine("=============== End of process, hit any key to finish ===============");
//Console.ReadKey();



//Console.WriteLine("Using model to make single prediction -- Comparing actual _0_1 with predicted _0_1 from sample data...\n\n");


//Console.WriteLine($"Sånn_ting: {@"Dyrøya, Berg. \ Beitebakke i berg."}");


//Console.WriteLine($"\n\nPredicted _0_1: {predictionResult.PredictedLabel}\n\n");
