namespace VkWikiGenerator.Bot
{
    using System.Configuration;

    internal class WikiBot
    {
        public void Run(string url, string newText)
        {
            string login = ConfigurationManager.AppSettings["login"];
            string password = ConfigurationManager.AppSettings["password"];

            var browser = new CodeplexAuthorization().Authorize(login, password);

            new WikiPageFiller(browser).Fill(url, newText);
        }
    }
}