using System.Text;
using HtmlAgilityPack;
using VkApiGenerator.Model;

namespace VkApiGenerator
{
    public class VkApiParser
    {
        public const string VkPrefix = "https://vk.com/dev/";

        private HtmlWeb _browser;
        public VkApiParser()
        {
            _browser = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding("Windows-1251")
            };
        }
        public VkMethodInfo Parse(string methodName)
        {
            HtmlDocument html = _browser.Load(VkPrefix + methodName);
            return VkMethodInfo.Parse(html);
        }
    }
}
