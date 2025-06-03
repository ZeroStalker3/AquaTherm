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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AquaTherm.Pages
{
    /// <summary>
    /// Логика взаимодействия для ReaderPages.xaml
    /// </summary>
    public partial class ReaderPages : Page
    {
        public ReaderPages()
        {
            InitializeComponent();
            GridView.ItemsSource = OdbConnectHelper.entobj.Счетчики.ToList();
        }

        private void addBtn_Click(object sender, RoutedEventArgs e)
        {
            AddReader addReader = new AddReader();
            addReader.ShowDialog();
        }

        private void printbtn_Click(object sender, RoutedEventArgs e)
        {
            PrintDialog printObj = new PrintDialog();
            if (printObj.ShowDialog() == true)
            {

                printObj.PrintVisual(GridView, "");
            }
            else
            {
                MessageBox.Show(
                    "Пользователь прервал печать",
                    "Уведомление",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error
                    );
                return;
            }
        }

        private void deletebtn_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Вы действительно хотите удалить запись?", "Уведомление", MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.No)
            {
                return;
            }
            else
            {
                try
                {
                    OdbConnectHelper.entobj.Счетчики.Remove(currentView);
                    OdbConnectHelper.entobj.SaveChanges();
                    GridView.ItemsSource = OdbConnectHelper.entobj.Счетчики.ToList();
                    MessageBox.Show("Успешно", "Удаление", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }

            }
        }

        public Счетчики currentView = new Счетчики();

        private void GridView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            currentView = GridView.CurrentCell.Item as Счетчики;
        }
    }
}
