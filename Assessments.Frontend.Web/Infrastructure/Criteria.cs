using System.Collections.Generic;

namespace Assessments.Frontend.Web.Infrastructure
{
    public static class Criteria
    {
        public static string handleCCriteria(string current_element, string key)
        {
            if (key == "C")
            {
                // THIS IS ONLY RELEVANT FOR C2
                current_element = current_element.Replace("a(i,ii)", "a(i)a(ii)");
                current_element = current_element.Replace(")", ");");
                current_element = current_element.Replace(" ", "");
            }
            else
            {
                current_element = current_element.Replace(",", ";");
            }
            return current_element;
        }

        public static string removeOuterParenthesis(string wrapped)
        {
            if (wrapped.Length > 2)
            {
                if (wrapped.StartsWith("(") && wrapped.EndsWith(")"))
                {
                    return wrapped.Substring(1, wrapped.Length - 2);
                }
            }
            return wrapped;
        }

        public static string inString(string element, string bigstring)
        {
            if (bigstring.Contains(element))
            {
                return "active";
            }
            return "inactive";
        }

        public static string inList(string element, string[] bigstring)
        {
            foreach (string el in bigstring)
            {
                if (bigstring.Contains(element))
                {
                    return "active";
                }
            }
            return "inactive";
        }



    }
}