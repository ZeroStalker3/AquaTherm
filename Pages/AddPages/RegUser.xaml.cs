using AquaTherm.Base;
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

namespace AquaTherm.Pages.AddPages
{
    /// <summary>
    /// Interaction logic for RegUser.xaml
    /// </summary>
    public partial class RegUser : Window
    {
        public RegUser()
        {
            InitializeComponent();
        }

        private void BtnAuto_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txpPass.Password == txbPassRepeat.Password)
                {
                    string login = txbLogin.Text;
                    string password = txpPass.Password;
                    string hashedPassword = PasswordHelper.Hash(password);

                    var newUser = new User
                    {
                        Name = txbName.Text,
                        Login = login,
                        Password = hashedPassword
                    };

                    OdbConnectHelper.entobj.User.Add(newUser);
                    OdbConnectHelper.entobj.SaveChanges();

                    MessageBox.Show("Пользователь зарегистрирован");
                }
                else
                {
                    MessageBox.Show("Пароли не совпадают", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка:\n" + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                LoginPage regUser = new LoginPage();
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
