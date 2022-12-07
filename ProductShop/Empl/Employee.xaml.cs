using ProductShop.Empl;
using System.Windows;
using System.Windows.Input;


namespace ProductShop
{
    /// <summary>
    /// Логика взаимодействия для Employee.xaml
    /// </summary>
    public partial class Employee : Window
    {
        public Employee()
        {
            InitializeComponent();
        }

        

        private void ExitSystem_Click(object sender, RoutedEventArgs e)
        {
            new MainWindow().Show();
            Close();
        }
        //private void MinBut2_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    this.Close();
        //}

        //private void MinBut_MouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    this.WindowState = WindowState.Minimized;
        //}
        private void MainPag_Click(object sender, RoutedEventArgs e) => Menu.Navigate(new MainPag());
        

        private void Button_Click_1(object sender, RoutedEventArgs e) => Menu.Navigate(new Prod());

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

        }

        private void ClintPage_Click(object sender, RoutedEventArgs e) => Menu.Navigate(new ZakazClient());

        private void Settings_Click(object sender, RoutedEventArgs e) => Menu.Navigate(new Setting());
        
    }
}
