using System;
using System.IO;
using System.Threading;

namespace SteamTestFrame.Utils
{
    public static class FileHelper
    {
        public static bool VerifyFileExists(string filePath, uint timeoutSeconds = 60, uint pollingIntervalSeconds = 1)
        {
            do
            {
                if (File.Exists(filePath)) return true;
                Thread.Sleep(TimeSpan.FromSeconds(pollingIntervalSeconds));
                timeoutSeconds -= pollingIntervalSeconds;
            } while (timeoutSeconds > 0);

            return false;
        }

        public static void DeleteFile(string filePath) => File.Delete(filePath);
    }
}