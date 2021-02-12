using System.IO;
using Newtonsoft.Json;
using System.Reflection;

namespace LeakerUtility.Models
{
    public class Configuration
    {
        [JsonProperty("ExportPath")]
        public string ExportPath { get; set; }

        [JsonProperty("ExportJsonData")]
        public bool ExportJsonData { get; set; }

        [JsonProperty("MapPOINames")]
        public bool ShowMapPOINames { get; set; }

        [JsonProperty("Language")]
        public string Language { get; set; }

        public Configuration()
        {
            ExportPath = Path.Combine(Assembly.GetExecutingAssembly().Location, "LeakerUtility", "Exports");
            ExportJsonData = true;
            ShowMapPOINames = false;
            Language = "English";
        }
    }
}