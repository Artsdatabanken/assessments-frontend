using System.Collections.Generic;
using System.Text.Json.Serialization;
using System;

namespace Assessments.Frontend.Web.Infrastructure.Api
{
    public class PaginatedResults<T>
    {
        public class PaginationInformation
        {
            public int PageNumber { get; set; } = 1;

            public int PageSize { get; set; } = 100;

            public int TotalPageCount { get; set; }

            public int RecordCount { get; set; }

            public long TotalRecordCount { get; set; }
        }

        [JsonPropertyName("paginationInformation")]
        public PaginationInformation Information { get; set; }

        public List<T> Data { get; set; }

        public PaginatedResults(IEnumerable<T> items, int pageNumber, int pageSize, long totalRecordCount)
        {
            Data = new List<T>(items);

            Information = new PaginationInformation
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                RecordCount = Data.Count,
                TotalPageCount = totalRecordCount > 0 ? (int)Math.Ceiling(totalRecordCount / (double)pageSize) : 0,
                TotalRecordCount = totalRecordCount
            };
        }
    }
}
