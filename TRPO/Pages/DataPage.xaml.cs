using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для DataPage.xaml
    /// </summary>
    public partial class DataPage : Page
    {
        public DataPage()
        {
            InitializeComponent();
        }

        private void UploadButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Текстовые файлы(*.txt) | *.txt | All files(*.*) | *.* ";
            if (openFileDialog.ShowDialog()==true)
            {
                MessageBox.Show(File.ReadAllText(openFileDialog.FileName));
            }
        }

        private void DownloadButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Текстовые файлы(*.txt) | *.txt | All files(*.*) | *.* ";
            if (saveFileDialog.ShowDialog()==true)
            {
                File.WriteAllText(saveFileDialog.FileName, string.Join("\n",App.GetProduct.Select(x=>x.name+" "+x.count).ToArray()));
            }
        }
    }
}
