﻿using SentimentModel_ConsoleApp1.Enums;

namespace SentimentModel_ConsoleApp1
{
    internal class Sanitation
    {
        internal static IEnumerable<dynamic> Sanitize(IEnumerable<dynamic> recordsEnumerable, List<string> targettingFields, string replaceWith, DebugLevel debugLevel = DebugLevel.DefaultLogging)
        {
            var hitCount = 0;
            var progressCount = 0;
            var actualProgress = 0.0;
            var recordsList = recordsEnumerable.ToArray();
            var recordsLength = recordsList.Length;
            
            if (debugLevel == DebugLevel.VerboseLogging)
                Console.WriteLine($"Progress {progressCount} av {recordsLength}: 0.0 %");

            // Add headers as first line

            for (var i = 0; i < recordsLength; i++)
            {
                // Need to cast to Dictionary to be able to get keys kontaining spaces
                IDictionary<string, object> recordDict = (IDictionary<string, object>)recordsList[i];
                foreach (var fieldName in targettingFields)
                {
                    try
                    {
                        var sanitizeString = recordDict[fieldName]?.ToString() ?? string.Empty;

                        if (string.IsNullOrWhiteSpace(sanitizeString)) continue;

                        var sampleData = new SentimentModel.ModelInput()
                        {
                            Tried = sanitizeString,
                        };
                        //Make a single prediction on the sample data
                        var predictionResult = SentimentModel.Predict(sampleData);
                        if (predictionResult.PredictedLabel)
                        {
                            hitCount += 1;
                            recordDict[fieldName] = replaceWith;
                        }
                    }
                    catch (Exception e)
                    {
                        if (debugLevel != DebugLevel.NoLogging)
                            Console.WriteLine($"\nUnable to find field for sanitation: {fieldName}. Exception: {e}");
                        break;
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
                    //recordsList[i] = recordDict; // trengs denne...
                }
            }
            if (debugLevel != DebugLevel.NoLogging)
                Console.WriteLine($"\nNumber of sanitized fields: {hitCount}");

            return recordsList;
        }
    }
}
