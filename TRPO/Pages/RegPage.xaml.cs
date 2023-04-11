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
    }
}
