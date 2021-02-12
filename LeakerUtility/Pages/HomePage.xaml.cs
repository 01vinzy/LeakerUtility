using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Net.Http;
using Newtonsoft.Json;
using System.Reflection;
using LeakerUtility.Models;
using System.Threading.Tasks;
using LeakerUtility.Constants;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;

namespace LeakerUtility.Pages
{
    /// <summary>
    /// Interaction logic for HomePage.xaml
    /// </summary>
    public partial class HomePage
    {
        private readonly HttpClient _client;

        public HomePage()
        {
            _client = new HttpClient();

            InitializeComponent();
            InitializeJsonDocument();

            AESDataButton.Content = App.LocalizedStrings.Where(x => x.Key == "AESDataButtonText")?.FirstOrDefault().Value;
            MapDataButton.Content = App.LocalizedStrings.Where(x => x.Key == "MapDataButtonText")?.FirstOrDefault().Value;
            NewCosmeticsDataButton.Content = App.LocalizedStrings.Where(x => x.Key == "NewCosmeticsDataButtonText")?.FirstOrDefault().Value;
            BRNewsDataButton.Content = App.LocalizedStrings.Where(x => x.Key == "BRNewsDataButtonText")?.FirstOrDefault().Value;
            ShopSectionsDataButton.Content = App.LocalizedStrings.Where(x => x.Key == "ShopSectionsDataButtonText")?.FirstOrDefault().Value;

            App.ConfigService.LoadConfig();
        }

        private async void AESDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var config = App.ConfigService.Config;

                var json = await SendAPIRequest<FortniteAPIResponse<AES>>(FortniteAPI.AES_ENDPOINT);
                var jsonString = JsonConvert.SerializeObject(json.Data, Formatting.Indented);

                if (config.ExportJsonData && Directory.Exists(config.ExportPath))
                    File.WriteAllText(config.ExportPath + "\\aes_data.json", jsonString);

                JsonOutput.Document.Text = jsonString;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to export AES data.\nException Message: {ex.Message}", "Exception Occurred", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void MapDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var config = App.ConfigService.Config;

                var json = await SendAPIRequest<FortniteAPIResponse<Map>>(FortniteAPI.MAP_ENDPOINT);
                var jsonString = JsonConvert.SerializeObject(json.Data, Formatting.Indented);

                if (Directory.Exists(config.ExportPath))
                {
                    if (config.ExportJsonData)
                        File.WriteAllText(config.ExportPath + "\\map_data.json", jsonString);

                    if (config.ShowMapPOINames)
                        await DownloadImage(json.Data.Images.POIs, config.ExportPath + "\\map_image.png");
                    else
                        await DownloadImage(json.Data.Images.Blank, config.ExportPath + "\\map_image.png");
                }

                JsonOutput.Document.Text = jsonString;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to export Map data.\nException Message: {ex.Message}", "Exception Occurred", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void NewCosmeticsDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var config = App.ConfigService.Config;

                var json = await SendAPIRequest<FortniteAPIResponse<NewCosmetics>>(FortniteAPI.NEW_COSMETICS_ENDPOINT);
                var jsonString = JsonConvert.SerializeObject(json.Data, Formatting.Indented);

                if (config.ExportJsonData && Directory.Exists(config.ExportPath))
                    File.WriteAllText(config.ExportPath + "\\new_cosmetics_data.json", jsonString);

                JsonOutput.Document.Text = jsonString;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to export New Cosmetics data.\nException Message: {ex.Message}", "Exception Occurred", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void BRNewsDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var config = App.ConfigService.Config;

                var json = await SendAPIRequest<FortniteAPIResponse<News>>(FortniteAPI.BR_NEWS_ENDPOINT);
                var jsonString = JsonConvert.SerializeObject(json.Data, Formatting.Indented);

                if (config.ExportJsonData && Directory.Exists(config.ExportPath))
                    File.WriteAllText(config.ExportPath + "\\news_data.json", jsonString);

                await DownloadImage(json.Data.Image, config.ExportPath + "\\news_image.gif");
                JsonOutput.Document.Text = jsonString;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to export News data.\nException Message: {ex.Message}", "Exception Occurred", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async void ShopSectionsDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var config = App.ConfigService.Config;

                var json = await SendAPIRequest<Calendar>(BenbotFN.CALENDAR_ENDPOINT);

                var clientEvents = json.Channels.Where(x => x.Key == "client-events")?.FirstOrDefault().Value;
                var shopSections = clientEvents.States[0].State.sectionStoreEnds;

                var jsonString = JsonConvert.SerializeObject(shopSections, Formatting.Indented);

                if (config.ExportJsonData && Directory.Exists(config.ExportPath))
                    File.WriteAllText(config.ExportPath + "\\shop_sections_data.json", jsonString);

                JsonOutput.Document.Text = jsonString;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to export Shop Sections data.\nException Message: {ex.Message}", "Exception Occurred", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private async Task<T> SendAPIRequest<T>(string url)
        {
            var response = await _client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<T>(data);
        }

        private async Task DownloadImage(string url, string path)
        {
            var response = await _client.GetAsync(url);
            using (var fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                await response.Content.CopyToAsync(fileStream);
        }

        private void InitializeJsonDocument()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LeakerUtility.Resources.Files.JsonFormatting.xshd"))
            using (var reader = new System.Xml.XmlTextReader(stream))
            {
                var highlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);

                JsonOutput.Document = new TextDocument();
                JsonOutput.SyntaxHighlighting = highlighting;
            }
        }
    }
}
