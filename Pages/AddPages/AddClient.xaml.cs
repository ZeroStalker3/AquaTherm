using AquaTherm.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string phoneInput = txbPhone.Text.Trim();
                string emailInput = txbMail.Text.Trim();

                bool isPhoneValid = Regex.IsMatch(phoneInput, @"^\+7\s?\(?\d{3}\)?[\s-]?\d{3}[\s-]?\d{2}[\s-]?\d{2}$");
                bool isEmailValid = Regex.IsMatch(emailInput, @"^[\w\.-]+@[\w\.-]+\.\w{2,}$");

                if (!isPhoneValid || !isEmailValid)
                {
                    string errorMessage = "Ошибка ввода:\n";
                    if (!isPhoneValid) errorMessage += "- Некорректный номер телефона\n";
                    if (!isEmailValid) errorMessage += "- Некорректный email\n";

                    MessageBox.Show(errorMessage, "Ошибка валидации", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }
                else
                {
                    var client = new Base.Клиенты
                    {
                        Имя = txbName.Text.Trim(),
                        Фамилия = txbsecondName.Text.Trim(),
                        Адрес = txbdress.Text.Trim(),
                        Телефон = phoneInput,
                        Email = emailInput,
                    };

                    OdbConnectHelper.entobj.Клиенты.Add(client);
                    OdbConnectHelper.entobj.SaveChanges();

                    MessageBox.Show("Успешно", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Information);
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка:\n" + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }
    }
}
