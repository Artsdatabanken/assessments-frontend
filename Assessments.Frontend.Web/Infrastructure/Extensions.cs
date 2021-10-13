using System;
using System.Collections.Generic;
using System.Text;

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

        public static string ToCamelString(this Enum value){
            var text = value.ToString();
            
            return text.Substring(0,1).ToLowerInvariant() + text.Substring(1);
        }
    }
}
