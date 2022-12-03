using ProductShop.Properties;
using ProductShop.Resource;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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

namespace ProductShop
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        int count = 0;
        public const int CustomerRoleId = 3;
        public const int EmployeeRoleId = 2;
        public const int MaxAuth = 3;
        public static readonly TimeSpan DateAuth = new TimeSpan(0, 1, 0);
        public MainWindow()
        {
            InitializeComponent();
            DbConnect.db.User.Load();


        }

        private void MinBut2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinBut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        

        private void logotype_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

       





        private void Avtor_Click(object sender, RoutedEventArgs e)
        {
            if (count >= MaxAuth)
            {
                MessageBox.Show("Пароль или логин введены неверны 3 раза", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return;
            }

            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Text.Trim();

            User user = DbConnect.db.User.Local.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user == null)
            {
                MessageBox.Show("Такого пользователя нет", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                count++;
                return;
            }

            if (user.RoleId == EmployeeRoleId)
                new Employee().Show();

            if (user.RoleId == CustomerRoleId)
                new Customer().Show();
            Close();
        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {
            new Registration().Show();
            Close();
        }
    }
}
