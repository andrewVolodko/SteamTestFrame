using System.Collections.Generic;
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
    public class DownloadInstallerFile : DownloadFileTemplate
    {
        private Platform _platform;
        private string _filePath;

        [SetUp]
        public void SetFilePath()
        {
            _platform = (Platform)TestContext.CurrentContext.Test.Arguments[0];
            _filePath = Path.Combine(PathToFile, PropertyReader.GetInstallerFileName(_platform));
        }

        [Test]
        [TestCaseSource(nameof(GetAllPlatforms))]
        public void VerifyCorrectInstallerFileDownloaded(Platform platform)
        {
            new MainPageSteps(BrowserService, true)
                .OpenAboutPage()
                .DownloadInstaller(_platform, PathToFile);

            var fileExists = FileHelper.VerifyFileExists(_filePath, 10);

            Assert.True(fileExists, $"{_platform} installation file was not found.");
        }

        [TearDown]
        public void RemoveFile() => FileHelper.DeleteFile(_filePath);


        private static IEnumerable<Platform> GetAllPlatforms()
        {
            yield return Platform.Linux;
            yield return Platform.Mac;
            yield return Platform.Windows;
        }
    }
}