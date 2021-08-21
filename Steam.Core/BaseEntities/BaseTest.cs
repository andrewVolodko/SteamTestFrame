using SteamTestFrame.Core;

namespace SteamTestFrame.BaseEntities
{
    public abstract class BaseTest
    {
        public BrowserService BrowserService;

        protected void DisposeDriver()
        {
            BrowserService.GetDriver().Quit();
            BrowserService = null;
        }
    }
}