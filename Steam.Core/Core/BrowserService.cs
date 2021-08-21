using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SteamTestFrame.Utils;

namespace SteamTestFrame.Core
{
    public class BrowserService
    {
        private readonly IWebDriver _driver;

        public BrowserService()
        {
            var browserName = PropertyReader.GetBrowserName();
            _driver = browserName switch
            {
                "chrome" => new ChromeDriver(),
                _ => throw new NoSuchElementException($"There is no browser with provided name: {browserName}")
            };
        }

        public IWebDriver GetDriver() => _driver;

        public Waiter GetWait() => new Waiter(this);
        public Waiter GetWait(int timeOutInSeconds) => new Waiter(this, timeOutInSeconds);
    }
}