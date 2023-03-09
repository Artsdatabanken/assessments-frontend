using SentimentModel_ConsoleApp1.Enums;

namespace SentimentModel_ConsoleApp1
{
    internal class Sanitation
    {
        internal static IEnumerable<dynamic> Sanitize(IEnumerable<dynamic> recordsList, DebugLevel debugLevel = DebugLevel.DefaultLogging)
        {
            var hitCount = 0;
            var progressCount = 0;
            var actualProgress = 0.0;
            var recordsLength = recordsList.ToList().Count;
            if (debugLevel == DebugLevel.VerboseLogging)
                Console.WriteLine($"Progress {progressCount} av {recordsLength}: 0.0 %");

            foreach (var record in recordsList)
            {
                var sampleData = new SentimentModel.ModelInput()
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

                if (debugLevel == DebugLevel.VerboseLogging)
                {
                    progressCount += 1;
                    var newProgress = Math.Floor((double)progressCount / recordsLength * 100) / 100;
                    if (newProgress != actualProgress)
                    {
                        actualProgress = newProgress;
                        if ((actualProgress * 100) % 10 == 0)
                            Console.WriteLine($"Progress {progressCount} av {recordsLength}: {actualProgress * 100}%");
                    }
                }
            }
            if (debugLevel != DebugLevel.NoLogging)
                Console.WriteLine($"\nNumber of sanitized fields: {hitCount}");

            return recordsList;
        }
    }
}
