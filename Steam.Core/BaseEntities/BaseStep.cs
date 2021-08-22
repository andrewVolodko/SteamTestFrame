using System;
using SteamTestFrame.Core;

namespace SteamTestFrame.BaseEntities
{
    public abstract class BaseStep<TPage> where TPage: BasePage
    {
        protected readonly BrowserService BrowserService;
        protected TPage Page;

        public BaseStep(BrowserService browserService, bool openPageByUrl)
        {
            BrowserService = browserService;
            GetPageInstance();

            if(openPageByUrl)
                Page.Open();

            Page.VerifyCorrectPageOpened();
        }

        public TPage GetPageInstance() => Page ??= (TPage) Activator.CreateInstance(typeof(TPage), BrowserService);

        public TPage OpenPage()
        {
            Page.Open();
            return (TPage) Activator.CreateInstance(typeof(TPage), BrowserService);
        }
    }
}