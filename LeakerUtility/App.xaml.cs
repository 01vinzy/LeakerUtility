using System.IO;
using System.Windows;
using Newtonsoft.Json;
using System.Reflection;
using System.Globalization;
using LeakerUtility.Services;
using System.Collections.Generic;
using System.Linq;

namespace LeakerUtility
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static IConfigService ConfigService { get; private set; }
        public static Dictionary<string, string> LocalizedStrings { get; set; }

        public App()
        {
            ConfigService = new ConfigService();
            ConfigService.LoadConfig();

            var config = ConfigService.Config;
            var assembly = Assembly.GetExecutingAssembly();
            try
            {
                Directory.CreateDirectory(config.ExportPath);

                if (!string.IsNullOrEmpty(config.Language))
                {
                    var culture = CultureInfo.GetCultures(CultureTypes.NeutralCultures).Where(x => x.DisplayName == config.Language)?.FirstOrDefault();
                    using (var stream = assembly.GetManifestResourceStream($"LeakerUtility.Resources.Localization.{culture.Name}.json"))
                    using (var reader = new StreamReader(stream))
                    {
                        var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd());
                        LocalizedStrings = data;
                    }
                }
                else
                {
                    if (CultureInfo.CurrentCulture.IsNeutralCulture)
                    {
                        using (var stream = assembly.GetManifestResourceStream($"LeakerUtility.Resources.Localization.{CultureInfo.CurrentCulture.Name}.json"))
                        using (var reader = new StreamReader(stream))
                        {
                            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd());
                            LocalizedStrings = data;
                        }
                    }
                    else
                    {
                        using (var stream = assembly.GetManifestResourceStream($"LeakerUtility.Resources.Localization.{CultureInfo.CurrentCulture.Name.Split('-')[0]}.json"))
                        using (var reader = new StreamReader(stream))
                        {
                            var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd());
                            LocalizedStrings = data;
                        }
                    }
                }                
            }
            catch
            {
                using (var stream = assembly.GetManifestResourceStream($"LeakerUtility.Resources.Localization.en.json"))
                using (var reader = new StreamReader(stream))
                {
                    var data = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd());
                    LocalizedStrings = data;
                }
            }
        }
    }
}