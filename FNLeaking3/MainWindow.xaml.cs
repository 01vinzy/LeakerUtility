using FNLeaking.Windows;
using Newtonsoft.Json.Linq;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Windows;


namespace FNLeaking
{
    public partial class MainWindow : Window
    {
        readonly WebClient wc = new WebClient();

        protected void GithubButton_Click_5(object sender, RoutedEventArgs e)
        {
            Process.Start("https://github.com/PeQuLeaks");
        }

        protected void TwitterButton_Click_4(object sender, RoutedEventArgs e)
        {
            Process.Start("https://twitter.com/PeQuLeaks");
        }
        protected void AesKeyButton_Click_3(object sender, RoutedEventArgs e)
        {
            WebClient Client = new WebClient();
            Client.DownloadFile("https://fortniteassistant.xyz/api/aes/txt", "Aes.txt");
            DownloadedBox downloadedbox = new DownloadedBox();
            downloadedbox.Show();
        }

        protected void NewMapButton_Click_2(object sender, RoutedEventArgs e)
        {
            WebClient Client = new WebClient();
            Client.DownloadFile("https://media.fortniteapi.io/images/map.png?showPOI=false&lang=eng", "Map.png");
            DownloadedBox downloadedbox = new DownloadedBox();
            downloadedbox.Show();
        }
        
        protected void NewCosmeticsButton_Click_1(object sender, RoutedEventArgs e)
        {
            WebClient Client = new WebClient();
            Client.DownloadFile("https://fortniteassistant.xyz/api/leaks/", "Cosmetics.png");
            DownloadedBox downloadedbox = new DownloadedBox();
            downloadedbox.Show();
        }

        private void BRNewsButton_Click_3(object sender, RoutedEventArgs e)
        {
            var data = new WebClient().DownloadString("https://fortnite-api.com/v2/news/br");
            var json = JObject.Parse(data)["data"]["image"].ToString();
            new WebClient().DownloadFile(json, "news.gif");
            DownloadedBox downloadedbox = new DownloadedBox();
            downloadedbox.Show();
        }

        private void ShopSectionsButton_Click_2(object sender, RoutedEventArgs e)
        {
            var data = new WebClient().DownloadString("https://benbotfn.tk/api/v1/calendar");
            var json = JObject.Parse(data)["data"]["sectionStoreEnds"].ToString();
            File.WriteAllText(json, "ShopSections.json");
            DownloadedBox downloadedbox = new DownloadedBox();
            downloadedbox.Show();
        }
    }
}


