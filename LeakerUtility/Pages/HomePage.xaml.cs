using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Windows;
using System.Xml;
using ICSharpCode.AvalonEdit.Document;
using ICSharpCode.AvalonEdit.Highlighting;
using ICSharpCode.AvalonEdit.Highlighting.Xshd;
using LeakerUtility.Models;
using Newtonsoft.Json;

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
        }

		public void InitializeJsonDocument()
        {
            using (var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("LeakerUtility.Resources.Files.JsonFormatting.xshd"))
            using (var reader = new XmlTextReader(stream))
            {
                var highlighting = HighlightingLoader.Load(reader, HighlightingManager.Instance);

                JSONOutput.Document = new TextDocument();
                JSONOutput.SyntaxHighlighting = highlighting;
            }
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var data = await _client.DownloadStringTaskAsync("https://fortnite-api.com/v2/aes");
                var json = JsonConvert.DeserializeObject<FortniteAPIResponse<AES>>(data).Data;

                var jsonString = JsonConvert.SerializeObject(json, Newtonsoft.Json.Formatting.Indented);

                File.WriteAllText("aes_data.json", jsonString);
                JSONOutput.Document.Text = jsonString;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Failed to export AES data.\nException Message: {ex.Message}", "Exception Occurred", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
