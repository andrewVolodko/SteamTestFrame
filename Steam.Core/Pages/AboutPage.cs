
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

        public AboutPage(BrowserService browserService) : base(browserService, "/about")
        {
        }

        protected override By GetCorrectPageOpenedIndicatorElLocator() => AboutGreetingContainerBy;

        public IWebElement GetInstallerBtn(Platform platform)
        {
            var abtGreetingContainer = BrowserService.GetDriver().FindElement(AboutGreetingContainerBy);
            return platform switch
            {
                Platform.Mac => abtGreetingContainer.FindElement(By.PartialLinkText("steam.dmg")),
                Platform.Windows => abtGreetingContainer.FindElement(By.PartialLinkText("SteamSetup.exe")),
                Platform.Linux => abtGreetingContainer.FindElement(By.PartialLinkText("steam.deb")),
                _ => throw new ArgumentOutOfRangeException(nameof(platform), platform, null)
            };
        }
    }
}