using OpenQA.Selenium;
using SteamTestFrame.BaseEntities;
using SteamTestFrame.Core;

namespace SteamTestFrame.Pages
{
    public class MainPage : BasePage
    {
        private static readonly By HomePageBannerBy = By.ClassName("home_page_col_wrapper");
        private static readonly By InstallBtnBy = By.ClassName("header_installsteam_btn_content");

        public MainPage(BrowserService browserService) : base(browserService)
        {
        }

        protected override By GetCorrectPageOpenedIndicatorElLocator() => HomePageBannerBy;

        public IWebElement GetInstallBtn() => BrowserService.GetDriver().FindElement(InstallBtnBy);
    }
}