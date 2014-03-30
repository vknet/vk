namespace CodeplexWikiBot
{
    using System;
    using System.Configuration;

    internal class Program
    {
        [STAThread]
        private static void Main(string[] args)
        {
            try
            {
                if (args.Length != 2)
                {
                    Console.WriteLine("Parameters: url new_wiki_text");
                    return;
                }

                string login = ConfigurationManager.AppSettings["login"];
                string password = ConfigurationManager.AppSettings["password"];

                var browser = new CodeplexAuthorization().Authorize(login, password);

                var url = args[0];
                var newText = args[1];

                new WikiPageFiller(browser).Fill(url, newText);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}