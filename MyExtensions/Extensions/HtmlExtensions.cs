using System;
using System.Text;
using System.Web;

namespace MyExtensions.Extensions
{
    public static class HtmlExtensions
    {
        private const string _paraBreak = "\r\n\r\n";
        private const string _link = "<a href=\"{0}\">{1}</a>";
        private const string _linkNoFollow = "<a href=\"{0}\" rel=\"nofollow\">{1}</a>";

        /// <summary>
        /// Returns a copy of this string converted to HTML markup.
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static string ToHtml(this string s)
        {
            return ToHtml(s, false);
        }

        /// <summary>
        /// Returns a copy of this string converted to HTML markup.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="nofollow">If true, links are given "nofollow"
        /// attribute</param>
        public static string ToHtml(this string s, bool nofollow)
        {
            var sb = new StringBuilder();

            var pos = 0;
            while (pos < s.Length)
            {
                // Extract next paragraph
                var start = pos;
                pos = s.IndexOf(_paraBreak, start, StringComparison.Ordinal);
                if (pos < 0)
                    pos = s.Length;
                var para = s.Substring(start, pos - start).Trim();

                // Encode non-empty paragraph
                if (para.Length > 0) EncodeParagraph(para, sb, nofollow);

                // Skip over paragraph break
                pos += _paraBreak.Length;
            }

            // Return result
            return sb.ToString();
        }

        /// <summary>
        /// Encodes a single paragraph to HTML.
        /// </summary>
        /// <param name="s">Text to encode</param>
        /// <param name="sb">StringBuilder to write results</param>
        /// <param name="nofollow">If true, links are given "nofollow"
        /// attribute</param>
        private static void EncodeParagraph(string s, StringBuilder sb, bool nofollow)
        {
            // Start new paragraph
            sb.AppendLine("<p>");

            // HTML encode text
            s = HttpUtility.HtmlEncode(s);

            // Convert single newlines to <br>
            s = s?.Replace(Environment.NewLine, "<br />\r\n");

            // Encode any hyperlinks
            EncodeLinks(s, sb, nofollow);

            // Close paragraph
            sb.AppendLine("\r\n</p>");
        }

        /// <summary>
        /// Encodes [[URL]] and [[Text][URL]] links to HTML.
        /// </summary>
        /// <param name="s"></param>
        /// <param name="sb">StringBuilder to write results</param>
        /// <param name="nofollow">If true, links are given "nofollow"
        /// attribute</param>
        private static void EncodeLinks(string s, StringBuilder sb, bool nofollow)
        {
            // Parse and encode any hyperlinks
            var pos = 0;
            while (pos < s.Length)
            {
                // Look for next link
                var start = pos;
                pos = s.IndexOf("[[", pos, StringComparison.Ordinal);
                if (pos < 0)
                    pos = s.Length;
                // Copy text before link
                sb.Append(s.Substring(start, pos - start));
                if (pos < s.Length)
                {
                    string label, link;

                    start = pos + 2;
                    pos = s.IndexOf("]]", start, StringComparison.Ordinal);
                    if (pos < 0)
                        pos = s.Length;
                    label = s.Substring(start, pos - start);
                    var i = label.IndexOf("][", StringComparison.Ordinal);
                    if (i >= 0)
                    {
                        link = label.Substring(i + 2);
                        label = label.Substring(0, i);
                    }
                    else
                    {
                        link = label;
                    }

                    // Append link
                    sb.Append(String.Format(nofollow ? _linkNoFollow : _link, link, label));

                    // Skip over closing "]]"
                    pos += 2;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="url"></param>
        /// <param name="text"></param>
        /// <param name="openInNewWindow"></param>
        /// <returns></returns>
        public static string ToLink(this string url, string text, bool openInNewWindow = false)
        {
            return openInNewWindow ? $"<a href=\"{url}\" target=\"_blank\">{text}</a>" : $"<a href=\"{url}\">{text}</a>";
        }
    }
}