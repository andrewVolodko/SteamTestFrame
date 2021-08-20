using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace SteamTestFrame.Core
{
    public class BrowserService
    {
        private readonly IWebDriver _driver;

        public BrowserService()
        {
            var browserName = PropertyReader.GetBrowserName();
            this._driver = browserName switch
            {
                "chrome" => new ChromeDriver(),
                _ => throw new NoSuchElementException($"There is no browser with provided name: {browserName}")
            };
        }

        public IWebDriver GetDriver() => this._driver;
    }
}