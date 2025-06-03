using AquaTherm.Base;
using AquaTherm.Pages.AddPages;
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
using System.Windows.Shapes;

namespace AquaTherm.Pages
{
    /// <summary>
    /// Логика взаимодействия для LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Window
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void BtnAuto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string login = txbLogin.Text;
                string password = PasswordHelper.Hash(txbPass.Password);

                var users = OdbConnectHelper.entobj.User
                    .FirstOrDefault(x => x.Login == login && x.Password == password);

                if (users != null)
                {
                    MainWindow mainwind = new MainWindow();
                    mainwind.Show();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Такого пользователя нет");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void BtnReg_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                RegUser regUser = new RegUser();
                regUser.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
