using System;
using System.Linq;
using System.Reflection;
using System.Globalization;
using ModernWpf.Controls.Primitives;
using Microsoft.WindowsAPICodePack.Dialogs;
using System.IO;

namespace LeakerUtility.Pages
{
    /// <summary>
    /// Interaction logic for SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage
    {
        public SettingsPage()
        {
            InitializeComponent();

            var header = ControlHelper.GetHeader(ExportPathTextBox);

            ExportingHeader.Text = App.LocalizedStrings.Where(x => x.Key == "ExportingHeader")?.FirstOrDefault().Value;
            header = App.LocalizedStrings.Where(x => x.Key == "JsonExportPathTextBox")?.FirstOrDefault().Value;
            ExportJsonDataCheckBox.Content = App.LocalizedStrings.Where(x => x.Key == "ExportJsonDataLabel")?.FirstOrDefault().Value;
            ShowPOINamesOnMapCheckBox.Content = App.LocalizedStrings.Where(x => x.Key == "POINamesOnMapLabel")?.FirstOrDefault().Value;
            SaveButton.Content = App.LocalizedStrings.Where(x => x.Key == "SaveButtonText")?.FirstOrDefault().Value;

            App.ConfigService.LoadConfig();
            var config = App.ConfigService.Config;
            
            ExportPathTextBox.Text = config.ExportPath;
            ExportJsonDataCheckBox.IsChecked = config.ExportJsonData;
            ShowPOINamesOnMapCheckBox.IsChecked = config.ShowMapPOINames;
        }

        private void BrowseButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var dialog = new CommonOpenFileDialog
            {
                Title = "Select Export Path",
                IsFolderPicker = true,
                DefaultDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)
            };

            CommonFileDialogResult result = dialog.ShowDialog();

            if (result == CommonFileDialogResult.Ok)
            {
                var config = App.ConfigService.Config;

                config.ExportPath = dialog.FileName;
                ExportPathTextBox.Text = dialog.FileName;
                
                App.ConfigService.SaveConfig(config);
            }
        }

        private void SaveButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var config = App.ConfigService.Config;

            Directory.CreateDirectory(ExportPathTextBox.Text);

            config.ExportPath = ExportPathTextBox.Text;
            config.ExportJsonData = (bool)ExportJsonDataCheckBox.IsChecked;
            config.ShowMapPOINames = (bool)ShowPOINamesOnMapCheckBox.IsChecked;

            App.ConfigService.SaveConfig(config);
        }
    }
}
