using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SteamTestFrame.Core;
using static OpenQA.Selenium.Support.UI.ExpectedConditions;

namespace SteamTestFrame.Utils
{
    public class Waiter
    {
        private readonly BrowserService _browserService;
        private readonly WebDriverWait _wait;

        public Waiter(BrowserService browserService, int timeOutSeconds)
        {
            _browserService = browserService;
            _wait = new WebDriverWait(browserService.GetDriver(), TimeSpan.FromSeconds(timeOutSeconds));
        }

        public Waiter(BrowserService browserService) : this(browserService, PropertyReader.GetTimeOut())
        {

        }

        public IWebElement WaitForVisibility(By by) => _wait.Until(ElementIsVisible(by));

        public void FluentlyWaitForFileExistence(string filePath, int pollingInterval = 1)
        {
            var fluentWait = new DefaultWait<IWebDriver>(_browserService.GetDriver())
            {
                Timeout = TimeSpan.FromSeconds(_wait.Timeout.TotalSeconds),
                PollingInterval = TimeSpan.FromSeconds(pollingInterval),
                Message = "File does not exist"
            };
            fluentWait.IgnoreExceptionTypes(typeof(NoSuchElementException));

            fluentWait.Until(_ => File.Exists(filePath));
        }
    }
}