using System;
using SteamTestFrame.Core;

namespace SteamTestFrame.BaseEntities
{
    public abstract class BaseStep<TPage> where TPage: BasePage
    {
        protected readonly BrowserService _browserService;
        protected TPage Page;

        public BaseStep(BrowserService browserService, bool openPageByUrl)
        {
            _browserService = browserService;
            GetPageInstance();

            if(openPageByUrl)
                Page.Open();

            Page.VerifyCorrectPageOpened();
        }

        public TPage GetPageInstance() => Page ??= (TPage) Activator.CreateInstance(typeof(TPage), _browserService);
    }
}