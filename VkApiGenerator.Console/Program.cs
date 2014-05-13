using System.Diagnostics;
using System.Text;
using HtmlAgilityPack;
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

            HtmlNode methodDesc = html.DocumentNode.SelectSingleNode("//*[contains(@class, 'dev_method_desc')]");

            Debug.Assert(methodDesc != null);

            System.Console.WriteLine(HtmlHelper.RemoveHtmlComment(methodDesc.InnerText));

            HtmlNodeCollection sections = html.DocumentNode.SelectNodes("//div[@class='wk_header dev_block_header']");
            
            HtmlNode paramsSection = sections[0];
            System.Console.WriteLine("Section name: " + paramsSection.InnerText);
            HtmlNode div = paramsSection.ParentNode;
            HtmlNode table = div.SelectSingleNode("table");

            Debug.Assert(table != null);
            System.Console.WriteLine("table is not null");

            HtmlNodeCollection rows = table.SelectNodes("tr");
            foreach (HtmlNode row in rows)
            {
                //HtmlNode col = row.SelectSingleNode("//*[contains(@class, 'dev_param_name')]");
                HtmlNodeCollection columns = row.SelectNodes("td");
                System.Console.WriteLine(columns[0].InnerText);
            }

            System.Console.WriteLine("done.");
        }
    }
}
