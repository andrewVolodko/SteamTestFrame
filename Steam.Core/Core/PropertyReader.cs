using Newtonsoft.Json.Linq;
using SteamTestFrame.Enums;
using SteamTestFrame.Utils;

namespace SteamTestFrame.Core
{
    public static class PropertyReader
    {
        private static readonly JObject DataFile = JsonReader.GetJsonObjectFromJsonFile("Config.json");

        public static string GetBrowserName() => DataFile["browser"].ToString();

        public static string GetBaseUrl() => DataFile["baseUrl"].ToString();
        public static int GetTimeOut() => int.Parse(DataFile["timeout"].ToString());

        public static string GetInstallerFileName(Platform platform) =>
            DataFile["installerFilesNames"][platform.ToString().ToLower()].ToString();
    }
}