using SteamTestFrame.BaseEntities;
using SteamTestFrame.Core;
using SteamTestFrame.Pages;

namespace SteamTestFrame.Steps
{
    public class MainPageSteps : BaseStep<MainPage>
    {
        public MainPageSteps(BrowserService browserService, bool openPageByUrl = false) : base(browserService, openPageByUrl)
        {
        }

        public AboutPageSteps OpenAboutPage()
        {
            Page.GetInstallBtn().Click();
            return new AboutPageSteps(BrowserService);
        }
    }
}