using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Net;
using System.Windows;

namespace FNLeaking
{
    public partial class MainWindow : Window
    {
        WebClient wc = new WebClient();

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
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(FileDownloadComplete);
            Uri imageurl = new Uri("https://fortniteassistant.xyz/api/aes/txt");
            wc.DownloadFileAsync(imageurl, "aes.txt");
        }

        protected void NewMapButton_Click_2(object sender, RoutedEventArgs e)
        {
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(FileDownloadComplete);
            Uri imageurl = new Uri("https://media.fortniteapi.io/images/map.png?showPOI=false&lang=eng");
            wc.DownloadFileAsync(imageurl, "Map.png");
        }

        protected void NewCosmeticsButton_Click_1(object sender, RoutedEventArgs e)
        {
            wc.DownloadFileCompleted += new AsyncCompletedEventHandler(FileDownloadComplete);
            Uri imageurl = new Uri("https://fortniteassistant.xyz/api/leaks/");
            wc.DownloadFileAsync(imageurl, "leaks.png");
        }

        private void FileDownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Download Completed");
        }
    }
}


