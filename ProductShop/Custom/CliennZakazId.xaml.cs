using ProductShop.Resource;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace ProductShop.Custom
{
    /// <summary>
    /// Логика взаимодействия для CliennZakazId.xaml
    /// </summary>
    public partial class CliennZakazId : Page
    {
        public CliennZakazId()
        {
            InitializeComponent();
            DbConnect.db.Order.Load();
            ListZakaz.ItemsSource = DbConnect.db.Order.Local.Where(x => x.Customer.User.Id == UserRoleId.Id).ToList();
        }
        private void Redaktor_Click(object sender, RoutedEventArgs e)
        {

        }
        
    }
}
