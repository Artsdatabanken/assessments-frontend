using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace Assessments.Shared.Helpers
{
    public static class Extensions
    {
        public static string DisplayName(this MemberInfo property)
        {
            var attribute = property.GetCustomAttributes(typeof(DisplayNameAttribute), true).Cast<DisplayNameAttribute>().Single();
           
            return attribute.DisplayName;
        }

        private static T GetAttribute<T>(this Enum value) where T : Attribute
        {
            var type = value.GetType();
            var memberInfo = type.GetMember(value.ToString());
            var attributes = memberInfo[0].GetCustomAttributes(typeof(T), false);
            
            if (attributes.Length > 0)	
                return (T) attributes[0];

            return null;
        }

        public static string Description(this Enum value)
        {
            var attribute = value.GetAttribute<DescriptionAttribute>();
            return attribute == null ? value.ToString() : attribute.Description;
        }

        public static string DisplayName(this Enum value)
        {
            var attribute = value.GetAttribute<DisplayAttribute>();
            return attribute == null ? value.ToString() : attribute.Name;
        }

        public static IEnumerable<T> ToEnumerable<T>(this IEnumerable<string> array)
        {
            return array.Where(c => Enum.IsDefined(typeof(T), c)).Select(a => (T) Enum.Parse(typeof(T), a));
        }

        public static string StripHtml(this string input)
        {
            if (string.IsNullOrEmpty(input)) 
                return string.Empty;

            var htmlDocument = new HtmlDocument();
            htmlDocument.LoadHtml(input);

            return htmlDocument.DocumentNode.InnerText;
        }

        public static string StripUnwantedHtml(this string input)
        {
            if (string.IsNullOrEmpty(input)) 
                return string.Empty;

            var document = new HtmlDocument();
            document.LoadHtml(input);

            var acceptableTags = new[] { "p", "i", "b" };
            var nodes = new Queue<HtmlNode>(document.DocumentNode.SelectNodes("./*|./text()"));
            
            while (nodes.Count > 0)
            {
                var node = nodes.Dequeue();
                var parentNode = node.ParentNode;

                if (acceptableTags.Contains(node.Name) || node.Name == "#text")
                    continue;

                var childNodes = node.SelectNodes("./*|./text()");

                if (childNodes != null)
                {
                    foreach (var child in childNodes)
                    {
                        nodes.Enqueue(child);
                        parentNode.InsertBefore(child, node);
                    }
                }

                parentNode.RemoveChild(node);
            }

            return document.DocumentNode.InnerHtml;
        }

        public static string RemoveExcessWhitepace(this string input) => Regex.Replace(input, @"\s+", " ");

        public static string GetInitials(this string value) => string.Concat(value.RemoveExcessWhitepace()
                .Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(x => x.Length >= 1 && char.IsLetter(x[0]))
                .Select(x => char.ToUpper(x[0])));
    }
}