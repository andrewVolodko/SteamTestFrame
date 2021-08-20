using System.IO;
using Newtonsoft.Json.Linq;

namespace SteamTestFrame.Utils
{
    public class JsonReader
    {
        public static JObject GetJsonObjectFromJsonFile(string fileName)
        {
            string fileString;
            using (var sw = new StreamReader(Path.Combine("Resources", fileName)))
            {
                try
                {
                    fileString = sw.ReadToEnd();
                    sw.Close();
                }
                catch (FileNotFoundException)
                {
                    throw new FileNotFoundException($"{fileName} file was NOT found.");
                }
            }
            return JObject.Parse(fileString);
        }
    }
}