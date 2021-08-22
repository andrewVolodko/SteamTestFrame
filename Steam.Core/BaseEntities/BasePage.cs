using System;
using NUnit.Framework;
using OpenQA.Selenium;
using SteamTestFrame.Core;

namespace SteamTestFrame.BaseEntities
{
    public abstract class BasePage
    {
        protected readonly BrowserService BrowserService;
        private static readonly string _baseUrl = PropertyReader.GetBaseUrl();
        private readonly string _path;

        protected BasePage(BrowserService browserService, string path)
        {
            BrowserService = browserService;
            _path = path;
        }

        protected abstract By GetCorrectPageOpenedIndicatorElLocator();

        public void VerifyCorrectPageOpened()
        {
            try
            {
                BrowserService.GetWait().WaitForVisibility(GetCorrectPageOpenedIndicatorElLocator());
            }
            catch (Exception ex)
            {
                throw new AssertionException($"{GetType().Name} was not opened. Detailed message: {ex.Message}");
            }
        }

        public void Open()
        {
            try
            {
                if (_path != null)
                    BrowserService.GetDriver().Navigate().GoToUrl(_baseUrl + _path);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}