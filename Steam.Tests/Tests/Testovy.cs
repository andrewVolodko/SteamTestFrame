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
        private static readonly string FilePath =
            Path.Combine(PathToFile, PropertyReader.GetInstallerFileName(Platform.Mac));
        [Test]
        public void test()
        {
            new MainPageSteps(BrowserService, true)
                .OpenAboutPage()
                .DownloadInstaller(Platform.Mac, PathToFile);

            var fileExists = FileHelper.VerifyFileExists(FilePath);

            Assert.True(fileExists);
        }

        [TearDown]
        public void RemoveFile() => FileHelper.DeleteFile(FilePath);
    }
}