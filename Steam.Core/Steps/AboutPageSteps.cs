using SteamTestFrame.BaseEntities;
using SteamTestFrame.Core;
using SteamTestFrame.Enums;
using SteamTestFrame.Pages;

namespace SteamTestFrame.Steps
{
    public class AboutPageSteps : BaseStep<AboutPage>
    {
        public AboutPageSteps(BrowserService browserService, bool openPageByUrl) : base(browserService, openPageByUrl)
        {
        }

        public void DownloadInstaller(Platform platform) => Page.GetInstallerBtn(platform).Click();
    }
}