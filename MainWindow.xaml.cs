using AquaTherm.Base;
using AquaTherm.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AquaTherm
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool isDarkTheme = false;

        public MainWindow()
        {
            InitializeComponent();
            FrameApp.frmobj = MainFrame;
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            loginPage.Show();
            this.Close();
        }

        private void btnClient_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmobj.Navigate(new ClientPages());
        }

        private void BtnReader_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmobj.Navigate(new ReaderPages());
        }

        private void BtnMeter_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmobj.Navigate(new MeterPages());
        }

        private void BtnPaiment_Click(object sender, RoutedEventArgs e)
        {
            FrameApp.frmobj.Navigate(new PaimentsPages());
        }

        private void BtnChangeTheme_Click(object sender, RoutedEventArgs e)
        {
            if (isDarkTheme)
            {
                ThemeManager.ApplyTheme("Light");
                isDarkTheme = false;

                BtnChangeTheme.Content = "🌙";
                BtnChangeTheme.Background = new SolidColorBrush(Colors.Black);
            }
            else
            {
                ThemeManager.ApplyTheme("Dark");
                isDarkTheme = true;

                BtnChangeTheme.Content = "☀️";
                BtnChangeTheme.Background = new SolidColorBrush(Colors.Transparent);
            }
        }
    }
}
