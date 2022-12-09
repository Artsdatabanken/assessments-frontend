using CsvHelper;
using CsvHelper.Configuration;
using SentimentModel_ConsoleApp1;
using System.Globalization;
using (var reader = new StreamReader("C:\\temp\\ml_only_raw.csv"))
using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
{
    var records = csv.GetRecords<Headers>();
    var hitCount = 0;
    var progressCount = 0;
    var recordsLength = 202383;
    var actualProgress = 0.0;
    var resultList = new List<bool>();

    Console.WriteLine($"\nProgress {progressCount} av {recordsLength}: 0.0 %");

    foreach (var line in records)
    {
        SentimentModel.ModelInput sampleData = new SentimentModel.ModelInput()
        {
            Sånn_ting = line.Column,
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
            Console.WriteLine($"\nProgress {progressCount} av {recordsLength}: {actualProgress}%");
        }
    }
    Console.WriteLine($"Number of hits: {hitCount}");
}

using (var writer = new StreamWriter("C:\\temp\\ml_only_raw.csv"))
using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
{
    var resultList = new List<bool>();

    csv.WriteHeader<Headers>();
    csv.NextRecord();
    foreach (var value in resultList)
    {
        csv.WriteRecord(value);
        csv.NextRecord();
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
