using OpenQA.Selenium;
using SteamTestFrame.BaseEntities;
using SteamTestFrame.Core;

namespace SteamTestFrame.Pages
{
    public class MainPage : BasePage
    {
        private readonly By _installBtnBy = By.ClassName("header_instllsteam_btn_content");

        public MainPage(BrowserService browserService) : base(browserService, "")
        {
        }

        protected override By GetCorrectPageOpenedIndicatorElLocator() => _installBtnBy;

        public IWebElement GetInstallBtn() => BrowserService.GetDriver().FindElement(_installBtnBy);
    }
}