using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using System.Linq;

namespace Assessments.Frontend.Web.Infrastructure
{
    public static class Extensions
    {
        public static string JoinAnd<T>(this IEnumerable<T> values, string separator, string lastSeparator = null)
        {
            if (values == null)
                throw new ArgumentNullException(nameof(values));
            
            if (separator == null)
                throw new ArgumentNullException(nameof(separator));

            var sb = new StringBuilder();

            using var enumerator = values.GetEnumerator();
            if (enumerator.MoveNext())
                sb.Append(enumerator.Current);

            var objectIsSet = false;
            object obj = null;

            if (enumerator.MoveNext())
            {
                obj = enumerator.Current;
                objectIsSet = true;
            }

            while (enumerator.MoveNext())
            {
                sb.Append(separator);
                sb.Append(obj);
                obj = enumerator.Current;
                objectIsSet = true;
            }

            if (!objectIsSet) 
                return sb.ToString();
            
            sb.Append(lastSeparator ?? separator);
            sb.Append(obj);

            return sb.ToString();
        }
        
        public static RouteValueDictionary ToRouteValues(this QueryString queryString, object obj)
        {
            var valueCollection = HttpUtility.ParseQueryString(queryString.ToString());

            var values = new RouteValueDictionary(obj);

            foreach (string key in valueCollection)
            {
                if (key != null && !values.ContainsKey(key)) values[key] = valueCollection[key];
            }

            return values;
        }

        public static string RemoveParameters(this QueryString queryString, IEnumerable<string> parameters)
        {
            var nameValueCollection = HttpUtility.ParseQueryString(queryString.ToString());

            foreach (var element in nameValueCollection.AllKeys.Where(parameters.Contains))
                nameValueCollection.Remove(element);

            return $"?{nameValueCollection}";
        }
    }
}
