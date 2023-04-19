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

namespace TRPO.Pages
{
    /// <summary>
    /// Логика взаимодействия для PageAccountingOfGoods.xaml
    /// </summary>
    public partial class PageAccountingOfGoods : Page
    {
        public PageAccountingOfGoods()
        {
            InitializeComponent();
            AccountingOfGoodsDataGrid.ItemsSource = App.GetProduct;
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void DataGridRowButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.MainFrame.Navigate(new AddEditPage((product)AccountingOfGoodsDataGrid.SelectedItem));
        }
    }
}
