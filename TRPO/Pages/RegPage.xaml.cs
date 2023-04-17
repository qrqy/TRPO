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
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public class ComboData
        {
            public int Id { get; set; }
            public string Value { get; set; }
        }
        public RegPage()
        {
            InitializeComponent();
            List<ComboData> ListData = new List<ComboData>();
            foreach (var item in App.GetPosition)
            {
                ListData.Add(new ComboData { Id=item.position_id, Value=item.position1 });
            }
            PositionComboBox.ItemsSource= ListData;
            PositionComboBox.DisplayMemberPath = "Value";
            PositionComboBox.SelectedValuePath = "Id";
        }

        private void Reg_Button_Click(object sender, RoutedEventArgs e)
        {
            //Проверка на не нулл
            if (string.IsNullOrEmpty(TextBoxFIO.Text)|string.IsNullOrEmpty(TextBoxLogin.Text)|string.IsNullOrEmpty(TextBoxPassword.Text)|string.IsNullOrEmpty(TextBoxPasswordConf.Text)|string.IsNullOrEmpty(TextBoxZP.Text)|string.IsNullOrEmpty(PositionComboBox.Text))
            {
                MessageBox.Show("Обязательно заполните все поля");
                return;
            }
            if (!App.CheckPassword(TextBoxPassword.Text))
            {
                MessageBox.Show("Пароль неверен");
                return;
            }
            if (TextBoxPassword.Text!=TextBoxPasswordConf.Text|TextBoxPassword.Text.Length<8)
            {
                MessageBox.Show("Пароли несовпадают или длина не 8 символов");
                return;
            }
            try
            {
                int.Parse(TextBoxZP.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Введите зарплату в рублях только цифрами");
                return;
            }


            MessageBox.Show("Good");
            
            SkladBDEntitie skladBDEntitie = new SkladBDEntitie();
            skladBDEntitie.staff.Add(new staff() { familia = TextBoxFIO.Text.Split()[0], imya = TextBoxFIO.Text.Split()[1], otchestvo = TextBoxFIO.Text.Split()[2], salary = int.Parse(TextBoxZP.Text), position_id = App.GetPositionIdFromPositionName(PositionComboBox.Text) }) ;
            skladBDEntitie.users.Add(new users() { familia = TextBoxFIO.Text.Split()[0], imya = TextBoxFIO.Text.Split()[1], otchestvo = TextBoxFIO.Text.Split()[2], login = TextBoxLogin.Text, password = App.GetHashPasswordFromString(TextBoxPassword.Text), role = PositionComboBox.Text});
            App.GetStaff = skladBDEntitie.staff.ToList();
            App.GetUsers = skladBDEntitie.users.ToList();
            skladBDEntitie.SaveChanges();
            skladBDEntitie.Dispose();
            
        }
    }
}
