using SteamTestFrame.BaseEntities;
using SteamTestFrame.Core;
using SteamTestFrame.Pages;

namespace SteamTestFrame.Steps
{
    public class MainPageSteps : BaseStep<MainPage>
    {
        public MainPageSteps(BrowserService browserService, bool openPageByUrl) : base(browserService, openPageByUrl)
        {
        }

        public void OpenAboutPage()
        {
            Page.GetInstallBtn().Click();
        }
    }
}