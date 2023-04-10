using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

using System.Security.Cryptography;
using System.Text;

namespace TRPO
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static List<users> GetUsers { get; set; }
        public static List<product> GetProduct { get; set; }
        public static List<staff> GetStaff { get; set; }
        public static List<classification> GetClassifications { get; set; }
        public static List<position> GetPosition { get; set; }
        public static List<supplier> GetSupplier { get; set; }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            LoadBd();
        }
        public void LoadBd()
        {
            SkladBDEntitie skladBD = new SkladBDEntitie();
            GetUsers = skladBD.users.ToList();
            GetProduct = skladBD.product.ToList();
            GetStaff = skladBD.staff.ToList();
            GetClassifications = skladBD.classification.ToList();
            GetPosition = skladBD.position.ToList();
            GetSupplier = skladBD.supplier.ToList();
            skladBD.Dispose();
        }
        public static string GetHashPasswordFromString(string PasswordSring)
        {
            using (var Hash = SHA1.Create())
            {
                return string.Concat(Hash.ComputeHash(Encoding.UTF8.GetBytes(PasswordSring)));
            }
        }
    }   
}
