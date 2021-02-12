using System;
using System.IO;
using Newtonsoft.Json;
using LeakerUtility.Models;

namespace LeakerUtility.Services
{
    /// <summary>
    /// Service interface for storing configuration.
    /// </summary>
    public interface IConfigService
    {
        Configuration Config { get; set; }

        void LoadConfig();

        void SaveConfig(Configuration config);
    }

    /// <summary>
    /// Service for storing configuration.
    /// </summary>
    public class ConfigService : IConfigService
    {
        public Configuration Config { get; set; }

        public ConfigService() { }

        /// <summary>
        /// Load the configuration from disk.
        /// </summary>
        public void LoadConfig()
        {
            var programDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "LeakerUtility");
            var configPath = Path.Combine(programDataPath, "Config.dat");

            Directory.CreateDirectory(programDataPath);

            if (!File.Exists(configPath))
                File.WriteAllText(configPath, JsonConvert.SerializeObject(new Configuration()));

            Config = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(configPath));
        }

        /// <summary>
        /// Save the configuration to disk.
        /// </summary>
        public void SaveConfig(Configuration configuration)
        {
            var programDataPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), "LeakerUtility");
            var configPath = Path.Combine(programDataPath, "Config.dat");

            Config = configuration;

            File.WriteAllText(configPath, JsonConvert.SerializeObject(Config));
        }
    }
}