﻿using System;
using System.Collections;
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


using TRPO.Pages; //Подключение простанства Pages

namespace TRPO
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Task.Run(() => LoadBd());
            InitializeComponent();
            var uri = new Uri("Dictionary.xaml", UriKind.Relative);
            ResourceDictionary resourceDict = Application.LoadComponent(uri) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(resourceDict);

            MainFrame.Navigate(new AuthPage());
        }
        public void LoadBd()
        {
            SkladBDEntities skladBD = new SkladBDEntities();
            App.GetUsers = skladBD.users.ToList();
            App.GetProduct = skladBD.product.ToList();
            App.GetStaff = skladBD.staff.ToList();
            App.GetClassifications = skladBD.classification.ToList();
            App.GetPosition = skladBD.position.ToList();
            App.GetSupplier= skladBD.supplier.ToList();
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            var result = MessageBox.Show("Вы уверены, что хотите закрыть программу?", "Окно закрытия", MessageBoxButton.YesNo);
            if (result == MessageBoxResult.No) { e.Cancel=true; }
            else { e.Cancel = false; }
        }
    }
}
