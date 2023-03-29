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
        public static List<product> products;
        ICollectionView view = CollectionViewSource.GetDefaultView(products);
        public StackPanel ProductStackPanelCreate(product product) 
        {
            StackPanel stackPanel = new StackPanel(); //Создание StackPanel для продукта
            stackPanel.Orientation = Orientation.Horizontal; //Ориаентация элементов StackPanel горизонтальная
            TextBlock ID = new TextBlock();
            ID.Text = product.product_id.ToString();
            ID.Width = 30;
            stackPanel.Children.Add(ID);
            TextBlock name = new TextBlock(); //Создаем текстовое поле для имени файла
            name.Name = "id" + product.product_id;
            name.Width = 250; //Ставим ширину текстового поля
            name.Margin = new Thickness(10, 0, 0, 0); //Отступ текстового поля
            name.Text = ChangeString(product.name); //Вернет обрезанную строчку если больше 30 символов
            stackPanel.Children.Add(name); //Добавляем элемент имени
            TextBlock count = new TextBlock(); //Создаем текстовое поле для кол-ва товаров
            count.Text = product.count.ToString();  //Число товаров
            count.Width= 30;
            stackPanel.Children.Add(count); //Добавляем сразу кол-во
            TextBlock price = new TextBlock();
            price.Text = product.price.ToString();
            price.Width= 60;
            stackPanel.Children.Add(price);
            ToolTip toolTip = new ToolTip(); //Создаем всплывающую подсказку
            toolTip.Content = product.name; //Вставляем полное имя товара из номенклатуры
            stackPanel.ToolTip = toolTip;
            return stackPanel;
        }
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
            products = App.GetProduct;
            ProductsListView.ItemsSource=products;
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
            ProductsListBox.Items.Clear();
            TextBlock SelectedItem = (TextBlock)ProductsCategoriesListBox.SelectedItem;
            if (SelectedItem.Text=="Все")
            {
                foreach (var item in App.GetProduct)
                {
                    if (item.name.Contains(SearchTextBox.Text))
                    {
                        ProductsListBox.Items.Add(ProductStackPanelCreate(item));
                    }
                }
            }
            else
            {
                int ClassificationId = App.GetClassifications.Where(x => x.classification1 == SelectedItem.Text).Select(x => x.classification_id).ToList().First();
                foreach (var item in App.GetProduct.Where(x => x.classification_id == ClassificationId).Select(x => x).ToList())
                {
                    if (item.name.Contains(SearchTextBox.Text))
                    {
                        ProductsListBox.Items.Add(ProductStackPanelCreate(item));
                    }
                }
            }


            if (SelectedItem.Text=="Все")
            {
                ProductsListView.ItemsSource = App.GetProduct;
                
                
                view.Refresh();
            }
            
        }


        private void ProductsCategoriesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ProductsListBox.Items.Clear();
            var selectedItem = (TextBlock)ProductsCategoriesListBox.SelectedItem;
            if (string.IsNullOrEmpty(SearchTextBox.Text))
            {
                if (selectedItem.Text == "Все")
                {
                    foreach (var item in App.GetProduct)
                    {
                        ProductsListBox.Items.Add(ProductStackPanelCreate(item));
                    }
                }
                else
                {
                    int ClassificationId = App.GetClassifications.Where(x => x.classification1 == selectedItem.Text).Select(x => x.classification_id).ToList().First();
                    foreach (var item in App.GetProduct.Where(x => x.classification_id == ClassificationId).Select(x => x).ToList())
                    {
                        ProductsListBox.Items.Add(ProductStackPanelCreate(item));
                    }
                }
            }
            else
            {
                if (selectedItem.Text == "Все")
                {
                    foreach (var item in App.GetProduct.Where(x=>x.name.Contains(SearchTextBox.Text)))
                    {
                        ProductsListBox.Items.Add(ProductStackPanelCreate(item));
                    }
                }
                else
                {
                    int ClassificationId = App.GetClassifications.Where(x => x.classification1 == selectedItem.Text).Select(x => x.classification_id).ToList().First();
                    foreach (var item in App.GetProduct.Where(x => x.classification_id == ClassificationId&&x.name.Contains(SearchTextBox.Text)).Select(x => x).ToList())
                    {
                        ProductsListBox.Items.Add(ProductStackPanelCreate(item));
                    }
                }
            }
            
        }
    }
}
