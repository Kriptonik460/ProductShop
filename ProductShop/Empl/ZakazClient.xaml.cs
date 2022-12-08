using ProductShop.Resource;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;

namespace ProductShop.Empl
{
    /// <summary>
    /// Логика взаимодействия для ZakazClient.xaml
    /// </summary>
    public partial class ZakazClient : Page
    {
        public ZakazClient()
        {
            InitializeComponent();
            DbConnect.db.Order.Load();
        }

        private void Redaktor_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
