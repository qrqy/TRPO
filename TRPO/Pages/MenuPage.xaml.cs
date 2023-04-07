using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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

using TRPO;

namespace TRPO.Pages
{
    /// <summary>
    /// Логика взаимодействия для MenuPage.xaml
    /// </summary>
    public partial class MenuPage : Page
    {
        public MenuPage()
        {
            InitializeComponent();
        }
        public MainWindow mainWindow;
        public ListOfProductsPage productsPage = new ListOfProductsPage();
        public SettingsPage settingsPage = new SettingsPage();
        private void ListOfProducts_Click(object sender, RoutedEventArgs e)
        {
            mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.MainFrame.Navigate(productsPage);
        }

        private void ReceiptOfProducts_Click(object sender, RoutedEventArgs e)
        {
            //Перевод всех паролей в бд в прикол на хеше
            /* 
            using (SkladBDEntities skladBD = new SkladBDEntities())
            {
                foreach (var item in skladBD.users)
                {
                    item.password = App.GetHashPasswordFromString(item.password).ToString();
                }
                try
                {
                    skladBD.SaveChanges();
                }
                catch (DbEntityValidationException ex)
                {
                    foreach (DbEntityValidationResult validationError in ex.EntityValidationErrors)
                    {
                        MessageBox.Show("Object: " + validationError.Entry.Entity.ToString());
                        foreach (DbValidationError err in validationError.ValidationErrors)
                        {
                            MessageBox.Show(err.ErrorMessage);
                        }
                    }
                }
                
            }
            */
        }
        

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.MainFrame.Navigate(settingsPage);
        }
    }
}
