using ModernWpf.Controls.Primitives;
using System.Linq;

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
            POINamesOnMapImageCheckBox.Content = App.LocalizedStrings.Where(x => x.Key == "POINamesOnMapLabel")?.FirstOrDefault().Value;
            LanguageHeader.Text = App.LocalizedStrings.Where(x => x.Key == "LanguageHeader")?.FirstOrDefault().Value;
            SaveButton.Content = App.LocalizedStrings.Where(x => x.Key == "SaveButtonText")?.FirstOrDefault().Value;
        }
    }
}
