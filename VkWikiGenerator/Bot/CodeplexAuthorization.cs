namespace VkWikiGenerator.Bot
{
    using WatiN.Core;

    internal class CodeplexAuthorization
    {
        public Browser Authorize(string login, string password)
        {
            Browser browser = new IE("https://www.codeplex.com/site/login");
            
            browser.GoTo("https://www.codeplex.com/site/login");
            browser.Link("CodePlexLogin").Click();
            browser.TextField("UserName").TypeText(login);
            browser.TextField("Password").TypeText(password);
            browser.Button("loginButton").Click();
            
            return browser;
        }
    }
}