using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {

            var req = from x in App.GetUsers
                      where x.login == Login.Text
                      select x.password;
            
            MainWindow mainWindow = (MainWindow)Application.Current.MainWindow;
            if (req.Count() > 0 && req.ToList().Contains(Password.Password.ToString()))
            {
                mainWindow.MainFrame.Navigate(new AuthPage());
            }
            else
            {
                MessageBox.Show("Не верный логин или пароль");
                Password.Clear();
            }
            
        }


        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                Password.Focus();
            }

        }

        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                LoginButton.Focus();
            }
        }
        private void ShowPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e) => ShowPasswordFunction();
        private void ShowPassword_PreviewMouseUp(object sender, MouseButtonEventArgs e) => HidePasswordFunction();
        private void ShowPassword_MouseLeave(object sender, MouseEventArgs e) => HidePasswordFunction();
        private void ShowPasswordFunction()
        {
            ShowPassword.Text = "Скрыть пароль";
            PasswordUnmask.Visibility = Visibility.Visible;
            Password.Visibility = Visibility.Hidden;
            PasswordUnmask.Text = Password.Password;

        }

        private void HidePasswordFunction()
        {
            ShowPassword.Text = "Показать пароль";
            PasswordUnmask.Visibility = Visibility.Hidden;
            Password.Visibility = Visibility.Visible;

        }

        private void LoginButton_PreviewMouseDown(object sender, MouseButtonEventArgs e) => LoginButton_Event();
        private void LoginButton_Event()
        {
            MessageBox.Show("Для регистрации обратитесь к администратору");
        }

        private void Login_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Login.Text=="Введите логин")
            {
                Login.Clear();
            }
        }

        private void Login_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(Login.Text))
            {
                Login.Text = "Введите логин";
            }
        }
    }
}
