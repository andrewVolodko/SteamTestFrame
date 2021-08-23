using System;
using OpenQA.Selenium;
using SteamTestFrame.BaseEntities;
using SteamTestFrame.Core;
using Platform = SteamTestFrame.Enums.Platform;

namespace SteamTestFrame.Pages
{
    public class AboutPage : BasePage
    {
        private static readonly By AboutGreetingContainerBy = By.Id("about_greeting");
        private const string InstallerLinkPartialXpath = ".//a[contains(@href, '{0}')]";

        public AboutPage(BrowserService browserService) : base(browserService, "/about")
        {
        }

        protected override By GetCorrectPageOpenedIndicatorElLocator() => AboutGreetingContainerBy;

        public IWebElement GetInstallerBtn(Platform platform) =>
            BrowserService.GetDriver().FindElement(AboutGreetingContainerBy)
                .FindElement(By.XPath(string.Format(InstallerLinkPartialXpath, PropertyReader.GetInstallerFileName(platform))));
    }
}