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
    /// Логика взаимодействия для AddEditPage.xaml
    /// </summary>
    public partial class AddEditPage : Page
    {
        private static bool IsAddPage;
        public AddEditPage()
        {
            InitializeComponent();
            SupplierComboBox.ItemsSource = App.GetSupplier;
            ClassificationComboBox.ItemsSource = App.GetClassifications;
            IsAddPage= true;
        }
        public AddEditPage(product Product)
        {
            InitializeComponent();
            SupplierComboBox.ItemsSource = App.GetSupplier;
            ClassificationComboBox.ItemsSource = App.GetClassifications;
            IsAddPage = false;
            a(Product);
        }




        private void SupplierComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            supplier Supplier = (supplier)SupplierComboBox.SelectedItem;
            //MessageBox.Show("Sup"+SupplierComboBox.SelectedIndex.ToString());
        }

        private void ClassificationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            classification Classification = (classification)ClassificationComboBox.SelectedItem;
            //MessageBox.Show("Clas"+ClassificationComboBox.SelectedIndex.ToString());
        }
        public void a(product Product)
        {
            IdTextBox.Text = Product.product_id.ToString();
            NameTextBox.Text = Product.name.ToString();
            CountTextBox.Text = Product.count.ToString();
            PriceTextBox.Text = Product.price.ToString();
            LengthTextBox.Text = Product.length.ToString();
            WidthTextBox.Text = Product.width.ToString();
            HeigthTextBox.Text = Product.height.ToString();
            ClassificationComboBox.SelectedItem = Product.classification;
            SupplierComboBox.SelectedItem = Product.supplier;
        }

        public bool b()
        {
            if (string.IsNullOrEmpty(NameTextBox.Text) | string.IsNullOrEmpty(PriceTextBox.Text) | SupplierComboBox.SelectedIndex==-1 | ClassificationComboBox.SelectedIndex==-1)
            {
                MessageBox.Show("Заполните обязательные поля");
                return true;
            }
            try
            {
                int.Parse(PriceTextBox.Text);
                if (!string.IsNullOrEmpty(HeigthTextBox.Text))
                {
                    int.Parse(HeigthTextBox.Text);
                }
                if (!string.IsNullOrEmpty(LengthTextBox.Text))
                {
                    int.Parse(LengthTextBox.Text);
                }
                if (!string.IsNullOrEmpty(WidthTextBox.Text))
                {
                    int.Parse(WidthTextBox.Text);
                }
                if (!string.IsNullOrEmpty(CountTextBox.Text))
                {
                    int.Parse(CountTextBox.Text);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Неверный формат ввода");
                return true;
            }
                
            
            return false;
        }
        private void Save_Click(object sender, RoutedEventArgs e)
        {
            if (b())
            {
                return;
            }
            SkladBDEntitie skladBDEntitie = new SkladBDEntitie();
            if (IsAddPage)
            {
                skladBDEntitie.product.Add(new product() { name = NameTextBox.Text, count = string.IsNullOrEmpty(CountTextBox.Text)? new int() : int.Parse(CountTextBox.Text), price = int.Parse(PriceTextBox.Text), length = string.IsNullOrEmpty(LengthTextBox.Text)? new int() :int.Parse(LengthTextBox.Text), width =string.IsNullOrEmpty(WidthTextBox.Text)? new int() : int.Parse(WidthTextBox.Text), height = string.IsNullOrEmpty(HeigthTextBox.Text) ? new int() : int.Parse(HeigthTextBox.Text), classification_id=((classification)ClassificationComboBox.SelectedItem).classification_id, supplier_id = ((supplier)SupplierComboBox.SelectedItem).supplier_id });
                skladBDEntitie.SaveChanges();
                App.GetProduct = skladBDEntitie.product.ToList();
            }
            else
            {
                foreach (var item in skladBDEntitie.product)
                {
                    if (item.product_id == int.Parse(IdTextBox.Text))
                    {
                        item.name = NameTextBox.Text;
                        item.count = int.Parse(CountTextBox.Text);
                        item.price = int.Parse(PriceTextBox.Text);
                        item.length = int.Parse(LengthTextBox.Text);
                        item.width = int.Parse(WidthTextBox.Text);
                        item.height = int.Parse(HeigthTextBox.Text);
                        item.classification_id = ((classification)ClassificationComboBox.SelectedItem).classification_id;
                        item.supplier_id = ((supplier)SupplierComboBox.SelectedItem).supplier_id;
                    }
                }
            }
            skladBDEntitie.SaveChanges();
            App.GetProduct = skladBDEntitie.product.ToList();
            skladBDEntitie.Dispose();
            App.pageAccountingOfGoods.AccountingOfGoodsDataGrid.ItemsSource = App.GetProduct;
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.MainFrame.Navigate(App.pageAccountingOfGoods);
        }

        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.MainFrame.Navigate(App.pageAccountingOfGoods);
        }
    }
}
