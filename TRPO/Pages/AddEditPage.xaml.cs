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
        public AddEditPage()
        {
            InitializeComponent();
            SupplierComboBox.ItemsSource = App.GetSupplier;
            ClassificationComboBox.ItemsSource = App.GetClassifications;
        }
        public AddEditPage(product Product)
        {
            InitializeComponent();
            SupplierComboBox.ItemsSource = App.GetSupplier;
            ClassificationComboBox.ItemsSource = App.GetClassifications;


            IdTextBox.Text = Product.product_id.ToString();
            NameTextBox.Text = Product.name.ToString();
            CountTextBox.Text = Product.count.ToString();
            PriceTextBox.Text = Product.price.ToString();
            LengthTextBox.Text = Product.length.ToString();
            WidthTextBox.Text = Product.width.ToString();
            HeigthTextBox.Text = Product.height.ToString();
            SupplierComboBox.SelectedIndex = 0;
            MessageBox.Show(Product.supplier_id.ToString());
            ClassificationComboBox.SelectedIndex=Product.classification.classification_id-1;
            MessageBox.Show(Product.classification_id.ToString());

        }




        private void SupplierComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            supplier Supplier = (supplier)SupplierComboBox.SelectedItem;
        }

        private void ClassificationComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            classification Classification = (classification)ClassificationComboBox.SelectedItem;
        }
    }
}
