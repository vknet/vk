using System.Diagnostics;
using System.Text;
using HtmlAgilityPack;
using VkApiGenerator.Console.Model;
using VkApiGenerator.Console.Utils;

namespace VkApiGenerator.Console
{
    class Program
    {
        public const string VkPrefix = "https://vk.com/dev/";

        static void Main(string[] args)
        {
            var browser = new HtmlWeb
            {
                AutoDetectEncoding = false,
                OverrideEncoding = Encoding.GetEncoding("Windows-1251")
            };

            HtmlDocument html = browser.Load(VkPrefix + "notes.get");

            var methodInfo = VkMethodInfo.Parse(html);
            System.Console.WriteLine(methodInfo.Description);

            foreach (var p in methodInfo.Params)
            {
                System.Console.WriteLine("{0} - {1}", p.Name, p.Description);
            }


            System.Console.WriteLine("done.");
        }
    }
}
