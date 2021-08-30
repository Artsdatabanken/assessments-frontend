﻿using System.Collections.Generic;
using System.IO;
using System.Linq;
using Assessments.Mapping;
using Assessments.Mapping.Models.Species;
using Microsoft.AspNetCore.Http;

namespace Assessments.Frontend.Web.Infrastructure
{
    public static class Helpers
    {
        public static QueryParameters GetQueryParameters(this HttpContext context, Dictionary<string, string> parameters)
        {
            var dictionary = context.Request.Query.ToDictionary(d => d.Key, d => d.Value.ToString());

            foreach (var (key, value) in parameters)
            {
                if (dictionary.ContainsKey(key))
                    dictionary.Remove(key);

                dictionary.Add(key, value);
            }

            return new QueryParameters(dictionary);
        }

        public class QueryParameters : Dictionary<string, string>
        {
            public QueryParameters(IDictionary<string, string> dictionary) : base(dictionary) { }

            public QueryParameters WithRoute(string routeParam, string routeValue)
            {
                this[routeParam] = routeValue;

                return this;
            }
        }

        public static MemoryStream GenerateExcel(IEnumerable<SpeciesAssessment2021Export> assessments)
        {
            MemoryStream memoryStream;
            using (var workbook = new ClosedXML.Excel.XLWorkbook())
            {
                var worksheet = workbook.AddWorksheet();
                
                worksheet.Cell(1, 1).InsertTable(assessments);

                memoryStream = new MemoryStream();
                workbook.SaveAs(memoryStream);
            }

            memoryStream.Seek(0, SeekOrigin.Begin);

            return memoryStream;
        }
    }

    public static class Constants
    {
        public const string CacheFolder = "Cache";
            
        public const string AssessmentsMappingAssembly = "Assessments.Mapping";
            
        public class Filename
        {
            public const string Species2021 = "species-2021.json";
                                
            // filnavn for modeller lagret som "RL2019"
            public const string Species2021Temp = "species-2021-temp.json";
                                            
            public const string Species2015 = "species-2015.json";
                                            
            public const string Species2006 = "species-2006.json";
        }

    }
}