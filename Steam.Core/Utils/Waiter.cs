using System;
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
            _wait = new WebDriverWait(_browserService.GetDriver(), TimeSpan.FromSeconds(timeOutSeconds));
        }

        public Waiter(BrowserService browserService) : this(browserService, PropertyReader.GetTimeOut())
        {

        }

        public IWebElement WaitForVisibility(By by) => _wait.Until(ElementIsVisible(by));
    }
}