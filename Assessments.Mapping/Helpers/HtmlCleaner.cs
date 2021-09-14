using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Assessments.Mapping.Helpers
{
    public class HtmlCleaner
    {
        private class TagAttribute
        {
            public string Name { get; set; }
            public string Value { get; set; }

            public TagAttribute()
            {
            }

            public TagAttribute(string name, string value)
            {
                Name = name;
                Value = value;
            }

            public static bool IsValidForTag(TagAttribute att, AcceptableTag tag)
            {
                bool result = false;

                if (tag.AcceptableAttributes.Contains(att.Name))
                {
                    result = true;
                }

                return result;
            }

            public string ValueAsEncodedUrl()
            {
                return System.Web.HttpUtility.UrlEncode(Value);
            }

            public string ValueAsEncodedHtml()
            {
                return System.Web.HttpUtility.HtmlEncode(Value);
            }
        }

        private class AcceptableTag
        {
            public string Tagname { get; set; }
            public List<string> AcceptableAttributes { get; set; }
            public bool SelfClosing { get; set; }
            public AcceptableTag()
            {
                AcceptableAttributes = new List<string>();
            }

            public AcceptableTag(string name, bool selfclosing, params string[] attributes)
            {
                Tagname = name;
                SelfClosing = selfclosing;
                AcceptableAttributes = new List<string>();
                foreach (string att in attributes)
                {
                    AcceptableAttributes.Add(att);
                }
            }
        }

        private static Dictionary<string, AcceptableTag> acceptedTags = null;
        private static Dictionary<string, AcceptableTag> __AcceptedTags()
        {
            Dictionary<string, AcceptableTag> result = new Dictionary<string, AcceptableTag>();

            // self closing tags
            result.Add("br", new AcceptableTag("br", true, "id", "class"));
            result.Add("hr", new AcceptableTag("hr", true, "id", "class"));
            result.Add("img", new AcceptableTag("img", true, "id", "class", "src", "alt"));

            result.Add("b", new AcceptableTag("b", false, "id", "class"));
            result.Add("i", new AcceptableTag("i", false, "id", "class"));
            result.Add("u", new AcceptableTag("u", false, "id", "class"));
            result.Add("em", new AcceptableTag("em", false, "id", "class"));
            result.Add("strong", new AcceptableTag("strong", false, "id", "class"));
            result.Add("p", new AcceptableTag("p", false, "id", "class"));
            result.Add("div", new AcceptableTag("div", false, "id", "class"));
            result.Add("span", new AcceptableTag("span", false, "id", "class"));
            result.Add("h1", new AcceptableTag("h1", false, "id", "class"));
            result.Add("h2", new AcceptableTag("h2", false, "id", "class"));
            result.Add("h3", new AcceptableTag("h3", false, "id", "class"));
            result.Add("h4", new AcceptableTag("h4", false, "id", "class"));
            result.Add("h5", new AcceptableTag("h5", false, "id", "class"));
            result.Add("h6", new AcceptableTag("h6", false, "id", "class"));
            result.Add("a", new AcceptableTag("a", false, "id", "class", "href", "target", "title", "name"));
            result.Add("strike", new AcceptableTag("strike", false, "id", "class"));
            result.Add("ul", new AcceptableTag("ul", false, "id", "class"));
            result.Add("ol", new AcceptableTag("ol", false, "id", "class"));
            result.Add("li", new AcceptableTag("li", false, "id", "class"));
            result.Add("pre", new AcceptableTag("pre", false, "id", "class"));
            result.Add("blockquote", new AcceptableTag("blockquote", false, "id", "class"));
            result.Add("address", new AcceptableTag("address", false, "id", "class"));
            result.Add("sup", new AcceptableTag("sup", false, "id", "class"));
            result.Add("sub", new AcceptableTag("sub", false, "id", "class"));

            return result;
        }

        private static Dictionary<string, AcceptableTag> __AcceptedTagsTerse()
        {
            Dictionary<string, AcceptableTag> result = new Dictionary<string, AcceptableTag>();

            // self closing tags
            result.Add("br", new AcceptableTag("br", true));
            //            result.Add("hr", new AcceptableTag("hr", true));
            result.Add("img", new AcceptableTag("img", true, "src", "alt"));

            result.Add("b", new AcceptableTag("b", false));
            result.Add("i", new AcceptableTag("i", false));
            result.Add("u", new AcceptableTag("u", false));
            result.Add("em", new AcceptableTag("em", false));
            result.Add("strong", new AcceptableTag("strong", false));
            result.Add("p", new AcceptableTag("p", false));
            //            result.Add("div", new AcceptableTag("div", false));
            //result.Add("span", new AcceptableTag("span", false));
            //result.Add("h1", new AcceptableTag("h1", false));
            //result.Add("h2", new AcceptableTag("h2", false));
            //result.Add("h3", new AcceptableTag("h3", false));
            //result.Add("h4", new AcceptableTag("h4", false));
            //result.Add("h5", new AcceptableTag("h5", false));
            //result.Add("h6", new AcceptableTag("h6", false));
            //result.Add("a", new AcceptableTag("a", false, "href", "target", "title", "name"));
            result.Add("strike", new AcceptableTag("strike", false));
            result.Add("ul", new AcceptableTag("ul", false));
            result.Add("ol", new AcceptableTag("ol", false));
            result.Add("li", new AcceptableTag("li", false));
            result.Add("pre", new AcceptableTag("pre", false));
            result.Add("blockquote", new AcceptableTag("blockquote", false));
            result.Add("address", new AcceptableTag("address", false));
            result.Add("sup", new AcceptableTag("sup", false));
            result.Add("sub", new AcceptableTag("sub", false));

            return result;
        }

        private static Queue<string> Tokenize(string input)
        {
            Queue<string> result = new Queue<string>();

            bool in_tag = false;
            StringBuilder sb = new StringBuilder();

            foreach (char c in input.ToCharArray())
            {

                if (in_tag == false)
                {
                    if (c == '<')
                    {
                        // starting html tag 
                        // dump any plaintext
                        if (sb.ToString().Length > 0)
                        {
                            result.Enqueue(sb.ToString());
                        }
                        sb = new StringBuilder();
                        in_tag = true;
                        sb.Append(c);
                    }
                    else
                    {
                        // plain text only
                        sb.Append(c);
                    }
                }
                else
                {
                    // searching for ending char
                    if (c == '>')
                    {
                        sb.Append(c);
                        if (sb.ToString().Length > 0)
                        {
                            result.Enqueue(sb.ToString());
                        }
                        sb = new StringBuilder();
                        in_tag = false;
                    }
                    else
                    {
                        sb.Append(c);
                    }
                }
            }

            if (sb.ToString().Length > 0)
            {
                result.Enqueue(sb.ToString());
            }
            return result;
        }

        private static Queue<string> ProcessTags(Queue<string> tokens)
        {
            bool parsingTag = false;
            Queue<string> subqueue = new Queue<string>();
            Queue<string> resultqueue = new Queue<string>();
            string startToken = string.Empty;




            while (tokens.Count > 0)
            {
                string currentToken = tokens.Dequeue();

                if (parsingTag)
                {
                    if (IsClosingTag(currentToken, ParseTagName(startToken)))
                    {
                        // Yes, this tag closed the starting tag
                        resultqueue.Enqueue(RebuildOpenTag(startToken));
                        var sq = ProcessTags(subqueue);
                        while (sq.Count() > 0)
                        {
                            resultqueue.Enqueue(sq.Dequeue());
                        }
                        resultqueue.Enqueue(CloseOpenTag(ParseTagName(startToken)));

                        // reset everything since the tag is parsed below
                        parsingTag = false;
                        startToken = "";
                        subqueue = new Queue<string>();

                    }
                    else
                    {
                        // Nope, no closing yet, just enqueue the token
                        subqueue.Enqueue(currentToken);
                    }
                }
                else
                {
                    // we're not parsing, check for a tag start
                    if (currentToken.StartsWith("<"))
                    {
                        if (IsAcceptedTag(currentToken))
                        {
                            parsingTag = true;

                            if (IsSelfClosed(currentToken))
                            {
                                // Tag is self closed, just parse it
                                resultqueue.Enqueue(RebuildClosedTag(currentToken));
                                parsingTag = false; // Added 2009-04-08
                            }
                            else
                            {
                                // store the starting token for later parsing
                                startToken = currentToken;
                            }
                        }
                        else
                        {
                            // not an accepted tag, just encode the sucker
                            resultqueue.Enqueue(EnsureHtmlEncode(currentToken));
                        }
                    }
                    else
                    {
                        // not starting a tag, just dump the encoded output
                        resultqueue.Enqueue(EnsureHtmlEncode(currentToken));
                    }
                }
            }


            if (parsingTag)
            {
                if (startToken.Length > 0)
                {
                    resultqueue.Enqueue(EnsureHtmlEncode(startToken));
                }
            }

            // if the subque has items in it because we didn't find a closing tag, dump them encoded
            if (subqueue.Count > 0)
            {
                while (subqueue.Count > 0)
                {
                    string subqueuetoken = subqueue.Dequeue();
                    resultqueue.Enqueue(EnsureHtmlEncode(subqueuetoken));
                }
            }

            return resultqueue;
        }

        private static string CloseOpenTag(string tagName)
        {
            return "</" + tagName + ">";
        }

        private static string RebuildOpenTag(string startToken)
        {
            string tagName = ParseTagName(startToken);
            return "<" + tagName + ParseAttributes(startToken) + ">";
        }

        private static bool IsClosingTag(string currentToken, string forTagName)
        {
            if (currentToken == "</" + forTagName + ">" ||
                currentToken == "</ " + forTagName + ">")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private static string RebuildClosedTag(string currentToken)
        {
            string result = string.Empty;

            if (IsAcceptedTag(currentToken))
            {
                result = "<" + ParseTagName(currentToken) + ParseAttributes(currentToken) + "/>";
            }
            else
            {
                result = EnsureHtmlEncode(currentToken);
            }

            return result;
        }

        private static string ParseAttributes(string currentToken)
        {
            StringBuilder sb = new StringBuilder();

            string tagname = ParseTagName(currentToken);

            AcceptableTag foundTag = null;
            if (acceptedTags.TryGetValue(tagname, out foundTag))
            {
                List<TagAttribute> atts = ParseAttributeList(currentToken, foundTag);

                if (atts.Count > 0)
                {
                    foreach (TagAttribute t in atts)
                    {
                        sb.Append(" ");
                        sb.Append(t.Name + "=\"");
                        if (t.Name == "href" || t.Name == "src")
                        {
                            //sb.Append(t.Value);
                            try
                            {
                                Uri url = null;

                                if (t.Value.StartsWith("/"))
                                {
                                    url = new Uri("http://localhost" + t.Value);
                                    sb.Append(url.PathAndQuery);
                                }
                                else
                                {
                                    url = new Uri(t.Value);
                                    sb.Append(url.ToString());
                                }
                            }
                            catch
                            {
                                sb.Append("  ");
                            }

                        }
                        else
                        {
                            sb.Append(t.ValueAsEncodedHtml());
                        }
                        sb.Append("\"");
                    }
                }
            }

            return sb.ToString();
        }

        private static List<TagAttribute> ParseAttributeList(string input, AcceptableTag tag)
        {
            string temp = input.Substring(tag.Tagname.Length + 1, input.Length - (tag.Tagname.Length + 2));
            if (temp.EndsWith("/"))
                temp = temp.TrimEnd('/');
            temp = temp.Trim();

            List<TagAttribute> result = new List<TagAttribute>();

            bool isParsingAttribute = false;
            bool isParsingAttributeValue = false;

            TagAttribute currentAttribute = null;

            // loop through all characters, splitting of attributes
            char[] characters = temp.ToCharArray();
            for (int i = 0; i < temp.Length; i++)
            {
                char current = temp[i];

                if (isParsingAttribute)
                {
                    if (isParsingAttributeValue)
                    {
                        // append the current character
                        currentAttribute.Value += current;

                        // check to see if we're done with the attribute
                        if (currentAttribute.Value.Length >= 2)
                        {
                            if (currentAttribute.Value.EndsWith("\""))
                            {
                                isParsingAttributeValue = false;
                                isParsingAttribute = false;
                                if (TagAttribute.IsValidForTag(currentAttribute, tag))
                                {
                                    currentAttribute.Value = currentAttribute.Value.TrimStart('"');
                                    currentAttribute.Value = currentAttribute.Value.TrimEnd('"');

                                    if (currentAttribute.Name == "src" || currentAttribute.Name == "href")
                                    {
                                        if (currentAttribute.Value.IndexOf("javascript", StringComparison.InvariantCultureIgnoreCase) > -1)
                                        {
                                            currentAttribute.Value = currentAttribute.Value.ToLowerInvariant().Replace("javascript", "");
                                        }

                                        if (currentAttribute.Value.IndexOf("vbscript", StringComparison.InvariantCultureIgnoreCase) > -1)
                                        {
                                            currentAttribute.Value = currentAttribute.Value.ToLowerInvariant().Replace("vbscript", "");
                                        }

                                    }

                                    result.Add(currentAttribute);
                                }
                                currentAttribute = null;
                            }
                        }
                    }
                    else
                    {
                        // we're not parsing the value yet so check for "="
                        if (current == '=')
                        {
                            // skip this charater but enable attribute value parsing;
                            isParsingAttributeValue = true;
                        }
                        else
                        {
                            currentAttribute.Name += current;
                        }
                    }
                }
                else
                {
                    // not parsing right now, check to see if we need to start
                    if (!char.IsWhiteSpace(current))
                    {
                        // not white space so let's start our attribute name
                        currentAttribute = new TagAttribute(current.ToString(), "");
                        isParsingAttribute = true;
                    }

                }

            }

            return result;
        }

        private static bool IsSelfClosed(string currentToken)
        {
            AcceptableTag foundTag = null;
            if (acceptedTags.TryGetValue(ParseTagName(currentToken), out foundTag))
            {
                // Found a matching tag.
                if (foundTag.SelfClosing && (currentToken.EndsWith("/>") || currentToken == "<br>"))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool IsAcceptedTag(string currentToken)
        {
            AcceptableTag foundTag = null;
            if (acceptedTags.TryGetValue(ParseTagName(currentToken), out foundTag))
            {
                // simple check to make sure tag is closed
                if (currentToken.EndsWith(">") || currentToken.EndsWith("/>"))
                {
                    return true;
                }
            }

            return false;
        }

        private static string ParseTagName(string tag)
        {
            string result = string.Empty;

            string temp = tag.TrimStart('<');
            temp = temp.TrimEnd('>');
            if (temp.EndsWith("/")) temp = temp.TrimEnd('/');

            // temp is now a raw tag without open/close brackets
            string[] parts = temp.Split(' ');
            if (parts != null)
            {
                if (parts.Count() > 0)
                {
                    result = parts[0];
                }
            }

            return result;
        }

        private static bool lookLikeTag(string possibleTag)
        {
            string s = possibleTag.Trim();
            if (!s.StartsWith("<") || !s.EndsWith(">") || s.Length < 3)
                return false;
            char firstchar = s.Substring(1, 1)[0];
            if (firstchar == '/')
                return true;
            if (char.IsLetter(firstchar))
                return true;
            return false;
        }

        /// <summary>
        /// Prepare string for encoding. (avoid double encoding)
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private static string replaceEscaped(string s)
        {
            if (s == null) return null;
            s = s.Replace("&nbsp;", " ");
            s = s.Replace("&amp;", "&");
            s = s.Replace("&gt;", ">");
            s = s.Replace("&lt;", "<");
            s = s.Replace("&quot;", "\"");
            s = System.Text.RegularExpressions.Regex.Replace(s, @"\s+", " ");  // remove repeating spaces
            return s;
        }

        private static string EnsureHtmlEncode(string s, bool removeThingsThatLookLikeTags = true)
        {
            string result = String.IsNullOrEmpty(s) || (removeThingsThatLookLikeTags && lookLikeTag(s))
                ? ""
                : System.Web.HttpUtility.HtmlEncode(replaceEscaped(s));
            return result;
        }

        public static string RemoveHtmlComments(string html)
        {
            var sc = new List<string>();
            sc.Add(@"<!--(\w|\W)+?-->");
            foreach (string s in sc)
            {
                html = Regex.Replace(html, s, "", RegexOptions.IgnoreCase);
            }
            return html;
        }

        public static string HtmlDecode(string s)
        {
            // justy proxies the System.web function, for easier reference (in external projects e.g.)
            //return System.Web.HttpUtility.HtmlDecode(s);
            return System.Net.WebUtility.HtmlDecode(s);
        }

        public static Queue<string> removeDuplicateBrs(Queue<string> q)
        {
            Queue<string> rq = new Queue<string>();
            var previousIsBr = false;
            while (q.Count() > 0)
            {
                var current = q.Dequeue();
                if (current == "<br/>")
                {
                    if (!previousIsBr)
                    {
                        rq.Enqueue(current);
                    }
                    previousIsBr = true;
                }
                else
                {
                    rq.Enqueue(current);
                    previousIsBr = false;
                }
            }
            return rq;
        }


        // This method html encodes the input string but
        // allows certain safe HTML tags by 
        // rewriting them with safe attribute tags
        //
        // b,i,u,em,strong,p,div,span,h1-h6,a,strike
        // ul,ol,li,hr,pre,blockquote,address,br
        // img,sup,sub
        //        
        public static string MakeHtmlSafe(string input, bool terse = true)
        {
            acceptedTags = terse ? __AcceptedTagsTerse() : __AcceptedTags();

            string result = string.Empty;
            if (input == null)
            {
                return null;
            }

            Queue<string> tokens = Tokenize(input);
            var q1 = ProcessTags(tokens);

            var q = removeDuplicateBrs(q1);



            StringBuilder sb = new StringBuilder();
            while (q.Count() > 0)
            {
                sb.Append(q.Dequeue());
            }

            result = sb.ToString().Trim();
            if (result.Contains("&"))
            {
                result = WebUtility.HtmlDecode(result.Replace("&nbsp;", " ").Replace("&amp;", "&"));
            }

            return result;
        }

    }
}
