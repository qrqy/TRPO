﻿using System;
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
            //mainWindow.MainFrame.Navigate();
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            mainWindow = (MainWindow)App.Current.MainWindow;
            mainWindow.MainFrame.Navigate(settingsPage);
        }
    }
}
