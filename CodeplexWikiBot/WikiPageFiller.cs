namespace CodeplexWikiBot
{
    using WatiN.Core;

    class WikiPageFiller
    {
        private readonly Browser _browser;

        public WikiPageFiller(Browser browser)
        {
            _browser = browser;
        }

        public void Fill(string url, string newText)
        {
            _browser.GoTo(url);
            _browser.TextField("inputText").TypeText(newText);
            _browser.Button("saveWikiButton").Click();
        }
    }
}