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
    /// Логика взаимодействия для AddReader.xaml
    /// </summary>
    public partial class AddReader : Window
    {
        public AddReader()
        {
            InitializeComponent();
            cmbType.SelectedValuePath = "ID";
            cmbType.DisplayMemberPath = "Название";
            cmbType.ItemsSource = OdbConnectHelper.entobj.ТипыСчетчиков.ToList();

            cmbClient.SelectedValuePath = "ID";
            cmbClient.DisplayMemberPath = "Фамилия";
            cmbClient.ItemsSource = OdbConnectHelper.entobj.Клиенты.ToList();
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
                    var Stats = new Base.Счетчики
                    {
                        НомерСчетчика = txbNum.Text,
                        idClient = Convert.ToInt32(cmbClient.SelectedValue),
                        idType = Convert.ToInt32(cmbType.SelectedValue),
                        ДатаУстановки = txbDate.SelectedDate,
                        Состояние = txbSost.Text,
                    };

                    OdbConnectHelper.entobj.Счетчики.Add(Stats);
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
