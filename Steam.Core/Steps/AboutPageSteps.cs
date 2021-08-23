using SteamTestFrame.BaseEntities;
using SteamTestFrame.Core;
using SteamTestFrame.Enums;
using SteamTestFrame.Pages;

namespace SteamTestFrame.Steps
{
    public class AboutPageSteps : BaseStep<AboutPage>
    {
        public AboutPageSteps(BrowserService browserService, bool openPageByUrl = false) : base(browserService, openPageByUrl)
        {
        }

        public AboutPageSteps DownloadInstaller(Platform platform, string path)
        {
            Page.GetInstallerBtn(platform).Click();
            return this;
        }
    }
}