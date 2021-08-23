using NUnit.Framework;
using SteamTestFrame.BaseEntities;
using SteamTestFrame.Core;

namespace Steam.Tests.Templates
{
    public abstract class SetUpDriverInitTemplate : BaseTest
    {
        [SetUp]
        public void SetUpDriver() => BrowserService = new BrowserService();

        [TearDown]
        public void TearDownDriver() => DisposeDriver();
    }
}