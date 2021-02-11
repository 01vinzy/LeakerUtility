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
        }

        private void GitHubLabel_MouseDown(object sender, MouseButtonEventArgs e)
            => Process.Start("https://github.com/PeQuLeaks");

        private void TwitterLabel_MouseDown(object sender, MouseButtonEventArgs e)
            => Process.Start("https://twitter.com/intent/follow?screen_name=PeQuLeaks");
    }
}
