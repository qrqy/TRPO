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
            if (App.listOfProductsPage == null)
            {
                App.listOfProductsPage = new ListOfProductsPage();
            }
            if (App.settingsPage==null)
            {
                App.settingsPage = new SettingsPage();
            }
            if (App.regPage==null)
            {
                App.regPage = new RegPage();
            }
            if (App.pageAccountingOfGoods==null)
            {
                App.pageAccountingOfGoods = new PageAccountingOfGoods();
            }
        }
        public MainWindow mainWindow;
        private void ListOfProducts_Click(object sender, RoutedEventArgs e)
        {
            mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.MainFrame.Navigate(App.listOfProductsPage);
        }

        private void ReceiptOfProducts_Click(object sender, RoutedEventArgs e)
        {
            mainWindow= (MainWindow)App.Current.MainWindow;
            mainWindow.MainFrame.Navigate(new DataPage());


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
            mainWindow.MainFrame.Navigate(App.settingsPage);
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.MainFrame.Navigate(App.regPage);
        }

        private void Accounting_Click(object sender, RoutedEventArgs e)
        {
            mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.MainFrame.Navigate(App.pageAccountingOfGoods);
        }

        private void LogOut_Click(object sender, RoutedEventArgs e)
        {
            mainWindow = (MainWindow)App.Current.MainWindow;
            App.authPage = new AuthPage();
            mainWindow.MainFrame.Navigate(App.authPage);
        }
    }
}
