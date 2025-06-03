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
    /// Логика взаимодействия для AddMeter.xaml
    /// </summary>
    public partial class AddMeter : Window
    {
        public AddMeter()
        {
            InitializeComponent();
            CmbRead.SelectedValuePath = "ID";
            CmbRead.DisplayMemberPath = "НомерСчетчика";
            CmbRead.ItemsSource = OdbConnectHelper.entobj.Счетчики.ToList();
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
                if (txbDate.SelectedDate >= DateTime.Today)
                {
                    MessageBox.Show("Дата не может быть в будущем.");
                    return;
                }
                else
                {
                    var Stats = new Base.ПоказанияСчетчиков
                    {
                        Показание = Convert.ToInt32(txbName.Text),
                        Дата = txbDate.SelectedDate,
                        idCounters = Convert.ToInt32(CmbRead.SelectedValue),
                    };

                    OdbConnectHelper.entobj.ПоказанияСчетчиков.Add(Stats);
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

        private void NumericTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}
