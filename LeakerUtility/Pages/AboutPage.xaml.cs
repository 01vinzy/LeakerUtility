using System.Linq;
using System.Diagnostics;
using System.Windows.Input;

namespace LeakerUtility.Pages
{
    /// <summary>
    /// Interaction logic for ContactPage.xaml
    /// </summary>
    public partial class AboutPage
    {
        public AboutPage()
        {
            InitializeComponent();

            AboutTextBlock.Text = App.LocalizedStrings.Where(x => x.Key == "AboutTextBlock")?.FirstOrDefault().Value;
        }

        private void GitHubLabel_MouseDown(object sender, MouseButtonEventArgs e)
            => Process.Start("https://github.com/PeQuLeaks");

        private void YouTubeLabel_MouseDown(object sender, MouseButtonEventArgs e)
            => Process.Start("https://www.youtube.com/channel/UC7v7uQSq0DgI-xO3S34LRgA?sub_confirmation=1");

        private void TwitterLabel_MouseDown(object sender, MouseButtonEventArgs e)
            => Process.Start("https://twitter.com/intent/follow?screen_name=PeQuLeaks");
    }
}
