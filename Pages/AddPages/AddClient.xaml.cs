using AquaTherm.Base;
using System.Runtime.Remoting.Contexts;
using System.Text.RegularExpressions;
using System.Windows;

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
            //try
            //{
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
                    Телефон = EncryptionHelper.EncryptPreserve(phoneInput),
                    Email = EncryptionHelper.EncryptPreserve(emailInput),
                };

                OdbConnectHelper.entobj.Клиенты.Add(client);

                // Пример обработки исключения для отладки
                try
                {
                    OdbConnectHelper.entobj.SaveChanges();
                }
                catch (System.Data.Entity.Validation.DbEntityValidationException ex)
                {
                    string errors = "";
                    foreach (var entityErrors in ex.EntityValidationErrors)
                    {
                        foreach (var error in entityErrors.ValidationErrors)
                        {
                            errors += $"Свойство: {error.PropertyName}, Ошибка: {error.ErrorMessage}\n";
                            System.Diagnostics.Debug.WriteLine($"Свойство: {error.PropertyName}, Ошибка: {error.ErrorMessage}");
                        }
                    }
                    MessageBox.Show("Ошибка сохранения:\n" + errors, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return; // Прерываем выполнение, если сохранение не прошло
                }

                MessageBox.Show("Успешно", "Добавление клиента", MessageBoxButton.OK, MessageBoxImage.Information);
                this.Close();
            }
        }
        //catch (Exception ex)
        //{
        //    MessageBox.Show("Произошла ошибка:\n" + ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
        //}

    }
}

