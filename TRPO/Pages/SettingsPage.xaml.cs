using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
    /// Логика взаимодействия для SettingsPage.xaml
    /// </summary>
    public partial class SettingsPage : Page
    {
        public SettingsPage()
        {
            InitializeComponent();
            ThemeComboBox.SelectedIndex= 2;
        }

        private void ThemeComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch (ThemeComboBox.SelectedIndex)
            {
                case 0:
                    var White = new Uri("/Dictionaries/WhiteTheme.xaml", UriKind.Relative);
                    ResourceDictionary resourceDictW = Application.LoadComponent(White) as ResourceDictionary;
                    Application.Current.Resources.Clear();
                    Application.Current.Resources.MergedDictionaries.Add(resourceDictW);
                    break;
                case 1:
                    var Dark = new Uri("/Dictionaries/DarkTheme.xaml", UriKind.Relative);
                    ResourceDictionary resourceDictD = Application.LoadComponent(Dark) as ResourceDictionary;
                    Application.Current.Resources.Clear();
                    Application.Current.Resources.MergedDictionaries.Add(resourceDictD);
                    break;
                case 2:
                    var Color = new Uri("/Dictionaries/Dictionary.xaml", UriKind.Relative);
                    ResourceDictionary resourceDictC = Application.LoadComponent(Color) as ResourceDictionary;
                    Application.Current.Resources.Clear();
                    Application.Current.Resources.MergedDictionaries.Add(resourceDictC);
                    break;
            }
        }

        private void Exit_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow) Application.Current.MainWindow;
            mainWindow.MainFrame.Navigate(mainWindow.authPage.menuPage);
        }
    }
}
