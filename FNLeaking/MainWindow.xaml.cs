using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows;
namespace FNLeaking
{
    public partial class MainWindow : Window
    {
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
            _ = System.Diagnostics.Process.Start("AutoAES.bat");
        }

        protected void NewMapButton_Click_2(object sender, RoutedEventArgs e)
        {
            _ = System.Diagnostics.Process.Start("newmap.bat");
        }

        protected void NewCosmeticsButton_Click_1(object sender, RoutedEventArgs e)
        {
            _ = System.Diagnostics.Process.Start("leakingtool.py");
        }
    }
}


