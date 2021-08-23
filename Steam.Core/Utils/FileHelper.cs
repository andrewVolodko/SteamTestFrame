using System;
using System.IO;
using System.Threading;

namespace SteamTestFrame.Utils
{
    public static class FileHelper
    {
        public static bool VerifyFileExists(string filePath, uint timeoutSeconds = 60, uint pollingIntervalSeconds = 1)
        {
            bool fileExists;
            do
            {
                fileExists = File.Exists(filePath);
                Thread.Sleep(TimeSpan.FromSeconds(pollingIntervalSeconds));
                timeoutSeconds -= pollingIntervalSeconds;
            } while (!fileExists && timeoutSeconds > 0);

            return fileExists;
        }

        public static void DeleteFile(string filePath) => File.Delete(filePath);
    }
}