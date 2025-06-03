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
using System.Xml.Linq;

namespace AquaTherm.Pages.AddPages
{
    /// <summary>
    /// Логика взаимодействия для AddPaiments.xaml
    /// </summary>
    public partial class AddPaiments : Window
    {
        public AddPaiments()
        {
            InitializeComponent();
            cmbClient.SelectedValuePath = "ID";
            cmbClient.DisplayMemberPath = "Фамилия";
            cmbClient.ItemsSource = OdbConnectHelper.entobj.Клиенты.ToList();
        }

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txbDate.SelectedDate == null)
                {
                    MessageBox.Show("Пожалуйста, выберите дату.");
                    return;
                }
                else
                if (txbDate.SelectedDate > DateTime.Today)
                {
                    MessageBox.Show("Дата не может быть в будущем.");
                    return;
                }
                else
                {
                    var Stats = new Base.Платежи
                    {
                        idClient = Convert.ToInt32(cmbClient.SelectedValue),
                        Дата = txbDate.SelectedDate,
                        Сумма = Convert.ToInt32(txbPrice.Text),
                    };

                    OdbConnectHelper.entobj.Платежи.Add(Stats);
                    OdbConnectHelper.entobj.SaveChanges();
                    MessageBox.Show("Успешно");
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
