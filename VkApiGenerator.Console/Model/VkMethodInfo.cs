using System;
using HtmlAgilityPack;

namespace VkApiGenerator.Console.Model
{
    /// <summary>
    /// Информация о методе на сайте Вконтакте
    /// </summary>
    public class VkMethodInfo
    {
        /// <summary>
        /// Описание метода
        /// </summary>
        public string Description { get; set; }

        public static VkMethodInfo Parse(HtmlDocument html)
        {
            throw new NotImplementedException();
        }

        internal static string GetDesctiption(HtmlDocument html)
        {
            throw new NotImplementedException();
        }
    }
}