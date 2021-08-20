using SteamTestFrame.Core;

namespace SteamTestFrame.BaseEntities
{
    public abstract class BasePage
    {
        protected readonly BrowserService BrowserService;
        private static readonly string _baseUrl = PropertyReader.GetBaseUrl();
        private readonly string _path;

        protected BasePage(BrowserService browserService, string path)
        {
            BrowserService = browserService;
            _path = path;
        }


    }
}