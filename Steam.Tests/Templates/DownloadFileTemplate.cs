using System.IO;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using SteamTestFrame.BaseEntities;
using SteamTestFrame.Core;

namespace Steam.Tests.Templates
{
    public abstract class DownloadFileTemplate : BaseTest
    {
        protected static readonly string PathToFile = Path.GetFullPath(Path.Combine("Resources", "Downloads"));

        [SetUp]
        public void SetUpDriver()
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddUserProfilePreference("download.default_directory", PathToFile);
            chromeOptions.AddUserProfilePreference("disable-popup-blocking", "true");
            chromeOptions.AddUserProfilePreference("download.prompt_for_download", false);
            chromeOptions.AddUserProfilePreference("safebrowsing.enabled", true);
            chromeOptions.AddArguments("--disable-infobars");
            chromeOptions.AddArguments("--incognito");
            chromeOptions.AddArguments("--safebrowsing-disable-download-protection");
            chromeOptions.AddArguments("safebrowsing-disable-extension-blacklist");
            var driver = new ChromeDriver(chromeOptions);
            BrowserService = new BrowserService(driver);
        }

        [TearDown]
        public void TearDownDriver() => DisposeDriver();
    }
}