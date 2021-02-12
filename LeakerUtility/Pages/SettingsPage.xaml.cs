using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using ModernWpf.Controls.Primitives;
using Microsoft.WindowsAPICodePack.Dialogs;

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

            foreach (var control in GridPanel.Children)
            {
                switch (control.GetType().Name)
                {
                    case "TextBox":
                        var textBox = (TextBox)control;
                        ControlHelper.SetHeader(textBox, App.LocalizedStrings.Where(x => x.Key == textBox.Name + "HeaderText")?.FirstOrDefault().Value);
                        break;
                    case "TextBlock":
                        var textBlock = (TextBlock)control;
                        textBlock.Text = App.LocalizedStrings.Where(x => x.Key == textBlock.Name + "Text")?.FirstOrDefault().Value;
                        break;
                    case "CheckBox":
                        var checkBox = (CheckBox)control;
                        checkBox.Content = App.LocalizedStrings.Where(x => x.Key == checkBox.Name + "Text")?.FirstOrDefault().Value;
                        break;
                    case "Button":
                        var button = (Button)control;
                        if (!string.IsNullOrEmpty(button.Name))
                            button.Content = App.LocalizedStrings.Where(x => x.Key == button.Name + "Text")?.FirstOrDefault().Value;
                        break;
                }
            }

            App.ConfigService.LoadConfig();
            var config = App.ConfigService.Config;
            
            ExportPathTextBox.Text = config.ExportPath;
            ExportJsonDataCheckBox.IsChecked = config.ExportJsonData;
            POINamesOnMapCheckBox.IsChecked = config.ShowMapPOINames;
        }

        private void BrowseButton_Click(object sender, RoutedEventArgs e)
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

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            var config = App.ConfigService.Config;

            Directory.CreateDirectory(ExportPathTextBox.Text);

            config.ExportPath = ExportPathTextBox.Text;
            config.ExportJsonData = (bool)ExportJsonDataCheckBox.IsChecked;
            config.ShowMapPOINames = (bool)POINamesOnMapCheckBox.IsChecked;

            App.ConfigService.SaveConfig(config);
        }
    }
}
