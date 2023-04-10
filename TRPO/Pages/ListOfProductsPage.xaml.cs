using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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
    /// Логика взаимодействия для ListOfProductsPage.xaml
    /// </summary>
    public partial class ListOfProductsPage : Page
    {
        public ListOfProductsPage()
        {
            InitializeComponent();
            TextBlock textBlock = new TextBlock();
            textBlock.Text = "Все";
            ProductsCategoriesListBox.Items.Add(textBlock);
            ProductsCategoriesListBox.SelectedItem = ProductsCategoriesListBox.Items[0];
            foreach (var item in App.GetClassifications)
            {
                TextBlock ClassificationTextBlock = new TextBlock();
                ClassificationTextBlock.Text = item.classification1;
                ProductsCategoriesListBox.Items.Add(ClassificationTextBlock);
            }
            ProductsListView.ItemsSource= App.GetProduct;
        }
        public string ChangeString(string text)
        {
            if (text.Length>=30)
            {
                return text.Substring(0, 30)+"...";
            }
            else
            {
                return text;
            }
        }
        public void Button_Click(object sender, RoutedEventArgs e) 
        {
            
        }

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            SearchTextBlock.Visibility = Visibility.Hidden;
        }

        private void SearchTextBox_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SearchTextBox.Text))
            {
                SearchTextBlock.Visibility = Visibility.Visible;
            }
        }

        private void SearchTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBlock SelectedItem = (TextBlock)ProductsCategoriesListBox.SelectedItem;
            if (SelectedItem.Text=="Все")
            {
                ProductsListView.ItemsSource= App.GetProduct.Where(x=>x.name.ToLower().Contains(SearchTextBox.Text.ToLower())).Select(x=>x).ToList();

            }
            else 
            {
                ProductsListView.ItemsSource = App.GetProduct.Where(x => x.GetClassification() == SelectedItem.Text && x.name.ToLower().Contains(SearchTextBox.Text.ToLower())).Select(x => x).ToList();

            }

        }
        private void ProductsCategoriesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = (TextBlock)ProductsCategoriesListBox.SelectedItem;
            if (string.IsNullOrEmpty(SearchTextBox.Text))
            {
                if (selectedItem.Text == "Все")
                {
                    ProductsListView.ItemsSource = App.GetProduct;
                }
                else
                {
                    ProductsListView.ItemsSource = App.GetProduct.Where(x => x.GetClassification() == selectedItem.Text).Select(x => x).ToList();
                }
            }
            else
            {
                if (selectedItem.Text == "Все")
                {
                    ProductsListView.ItemsSource = App.GetProduct.Where(x => x.name.ToLower().Contains(SearchTextBox.Text.ToLower())).Select(x=>x).ToList();
                }
                else
                {
                    ProductsListView.ItemsSource = App.GetProduct.Where(x => x.GetClassification() == selectedItem.Text && x.name.ToLower().Contains(SearchTextBox.Text.ToLower())).Select(x => x).ToList();
                }
            }
            
        }

        private void ProductsListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
