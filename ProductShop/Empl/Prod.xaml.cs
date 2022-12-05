using ProductShop.Resource;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Windows;
using System.Windows.Controls;

namespace ProductShop.Empl
{
    /// <summary>
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Prod : Page
    {
       
        public ObservableCollection<Product> Products
        {
            get { return (ObservableCollection<Product>)GetValue(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Users.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductsProperty =
            DependencyProperty.Register("Products", typeof(ObservableCollection<Product>), typeof(Prod));


        public Prod()
        {
            InitializeComponent();
            DbConnect.db.Product.Load();
            Products = DbConnect.db.Product.Local;

        }


        
        private void CreateProd_Click(object sender, RoutedEventArgs e)
        {
            new CreateProduct().Show();
        }
    }
}
