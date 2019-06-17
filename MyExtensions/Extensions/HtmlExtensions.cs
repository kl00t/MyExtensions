namespace MyExtensions.Extensions
{
    public static class HtmlExtensions
    {
        /// <summary>
        /// Converts a string to a link.
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