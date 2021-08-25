using System.IO;
using NUnit.Framework;
using Steam.Tests.Templates;
using SteamTestFrame.Core;
using SteamTestFrame.Enums;
using SteamTestFrame.Steps;
using SteamTestFrame.Utils;

namespace Steam.Tests.Tests
{
    [TestFixture]
    public class Testovy : DownloadFileTemplate
    {

        private const Platform Platform = SteamTestFrame.Enums.Platform.Linux;
        private static readonly string FilePath =
            Path.Combine(PathToFile, PropertyReader.GetInstallerFileName(Platform));

        [Test]
        public void test()
        {
            new MainPageSteps(BrowserService, true)
                .OpenAboutPage()
                .DownloadInstaller(Platform, PathToFile);

            var fileExists = FileHelper.VerifyFileExists(FilePath, 10);

            Assert.True(fileExists);
        }

        [TearDown]
        public void RemoveFile() => FileHelper.DeleteFile(FilePath);
    }
}