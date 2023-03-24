﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

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
    }
}
