using System;
using System.IO;
using System.Net;
using System.Linq;
using System.Windows;
using Newtonsoft.Json;
using System.Reflection;
using LeakerUtility.Models;
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
        private readonly WebClient _client;

        public HomePage()
        {
            _client = new WebClient();

            InitializeComponent();
            InitializeJsonDocument();

            AESDataButton.Content = App.LocalizedStrings.Where(x => x.Key == "AESDataButtonText")?.FirstOrDefault().Value;
            MapDataButton.Content = App.LocalizedStrings.Where(x => x.Key == "MapDataButtonText")?.FirstOrDefault().Value;
            NewCosmeticsDataButton.Content = App.LocalizedStrings.Where(x => x.Key == "NewCosmeticsDataButtonText")?.FirstOrDefault().Value;
            BRNewsDataButton.Content = App.LocalizedStrings.Where(x => x.Key == "BRNewsDataButtonText")?.FirstOrDefault().Value;
            ShopSectionsDataButton.Content = App.LocalizedStrings.Where(x => x.Key == "ShopSectionsDataButtonText")?.FirstOrDefault().Value;
        }

		public void InitializeJsonDocument()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LeakerUtility.Resources.Files.JsonFormatting.xshd"))
            using (var reader = new System.Xml.XmlTextReader(stream))
            {
                var highlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);

                JsonOutput.Document = new TextDocument();
                JsonOutput.SyntaxHighlighting = highlighting;
            }
        }

        private async void AESDataButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = await _client.DownloadStringTaskAsync("https://fortnite-api.com/v2/aes");
                var json = JsonConvert.DeserializeObject<FortniteAPIResponse<AES>>(data).Data;

                var jsonString = JsonConvert.SerializeObject(json, Formatting.Indented);

                File.WriteAllText("aes_data.json", jsonString);
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
                var data = await _client.DownloadStringTaskAsync("https://fortnite-api.com/v1/map");
                var json = JsonConvert.DeserializeObject<FortniteAPIResponse<Map>>(data).Data;

                var jsonString = JsonConvert.SerializeObject(json, Formatting.Indented);

                File.WriteAllText("map_data.json", jsonString);
                await _client.DownloadFileTaskAsync(json.Images.Blank, "map_image.png");
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
                var data = await _client.DownloadStringTaskAsync("https://fortnite-api.com/v2/cosmetics/br/new");
                var json = JsonConvert.DeserializeObject<FortniteAPIResponse<NewCosmetics>>(data).Data;

                var jsonString = JsonConvert.SerializeObject(json, Formatting.Indented);

                File.WriteAllText("new_cosmetics_data.json", jsonString);
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
                var data = await _client.DownloadStringTaskAsync("https://fortnite-api.com/v2/news/br");
                var json = JsonConvert.DeserializeObject<FortniteAPIResponse<News>>(data).Data;

                var jsonString = JsonConvert.SerializeObject(json, Formatting.Indented);

                File.WriteAllText("news_data.json", jsonString);
                await _client.DownloadFileTaskAsync(json.Image, "news_image.gif");
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
                var data = await _client.DownloadStringTaskAsync("https://benbotfn.tk/api/v1/calendar");
                var json = JsonConvert.DeserializeObject<Calendar>(data);

                var clientEvents = json.Channels.Where(x => x.Key == "client-events")?.FirstOrDefault().Value;
                var shopSections = clientEvents.States[0].State.sectionStoreEnds;

                var jsonString = JsonConvert.SerializeObject(shopSections, Formatting.Indented);

                File.WriteAllText("shop_sections_data.json", jsonString);
                JsonOutput.Document.Text = jsonString;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to export Shop Sections data.\nException Message: {ex.Message}", "Exception Occurred", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
