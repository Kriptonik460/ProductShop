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
using System.Windows.Shapes;

namespace ProductShop
{
    /// <summary>
    /// Логика взаимодействия для Customer.xaml
    /// </summary>
    public partial class Customer : Window
    {
        public Customer()
        {
            InitializeComponent();
        }

        private void Product_Click(object sender, RoutedEventArgs e) => Menu.Navigate(new Empl.Prod());


        private void Zakaz_Click(object sender, RoutedEventArgs e) => Menu.Navigate(new Custom.Zakaz());
       

        private void ExitSystem_Click(object sender, RoutedEventArgs e)
        {

            new MainWindow().Show();
            Close();
            
        }
        private void MinBut2_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void MinBut_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }
        private void ZakazClient_Click(object sender, RoutedEventArgs e) => Menu.Navigate(new Custom.CliennZakazId());
        
    }
}
