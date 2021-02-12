using System;
using System.IO;
using Newtonsoft.Json;

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

        public Configuration()
        {
            ExportPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "LeakerUtility");
            ExportJsonData = true;
            ShowMapPOINames = false;
        }
    }
}