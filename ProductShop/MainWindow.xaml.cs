﻿using ProductShop.Resource;
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
        public MainWindow()
        {
            InitializeComponent();
            DbConnect.db.User.Load();
        }

        private void Registr(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Password.Trim();
            if (!(login.Length > 0 && password.Length > 5))
            {
                MessageBox.Show("Не заполнен логин или пароль меньше 6 символов", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            } 
            if (!Regex.IsMatch(password, @"[\!\@\$\%\#\^]"))
            {
                MessageBox.Show("необходим минимум один символ из набора: ! @ # $ % ^ ", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }
            if (!Regex.IsMatch(password, @"\d"))
            {
                MessageBox.Show("необходим минимум 1 цифра", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            try
                {
                    User user = new User()
                    {
                        Login = login,
                        Password = password,
                        RoleId = 3
                    };
                    DbConnect.db.User.Add(user);
                    DbConnect.db.SaveChanges();
                    MessageBox.Show("Регистрация прошла успешно", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);

                }
                catch
                {
                    MessageBox.Show("Ошибка при добавлении данных!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Error);

                }
                
               
            
        }

        

        private void Avtor(object sender, RoutedEventArgs e)
        {
            string login = LoginTb.Text.Trim();
            string password = PasswordTb.Password.Trim();

            User user = DbConnect.db.User.Local.FirstOrDefault(x => x.Login == login && x.Password == password);
            if (user == null)
                MessageBox.Show("Такого пользователя нет", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
            
            else
            {
                if (user.RoleId == 2)
                    new Employee().Show();
                if (user.RoleId == 3)
                    new Customer().Show();
                Close();
            }
        }

        

        private void TextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            LoginTb.Text = "";

        }
        
    }
}
