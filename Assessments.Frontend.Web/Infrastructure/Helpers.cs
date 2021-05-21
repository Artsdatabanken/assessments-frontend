using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;

namespace Assessments.Frontend.Web.Infrastructure
{
    public static class Helpers
    {
        public static QueryParameters GetQueryParameters(this HttpContext context, Dictionary<string,string> parameters)
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
    }
}
