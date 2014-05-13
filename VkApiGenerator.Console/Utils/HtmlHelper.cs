using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace VkApiGenerator.Console.Utils
{
    public class HtmlHelper
    {
        /// <summary>
        /// Remove html comment from string
        /// </summary>
        /// <param name="html"></param>
        /// <returns></returns>
        [NotNull]
        public static string RemoveHtmlComment([NotNull]string html)
        {
            if (string.IsNullOrEmpty(html))
                return string.Empty;

            var r = new Regex("<!--(.*?)-->");

            return r.Replace(html, string.Empty);
        }
    }
}