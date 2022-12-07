using ProductShop.Resource;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace ProductShop.Empl
{
    /// <summary>
    /// Логика взаимодействия для Product.xaml
    /// </summary>
    public partial class Prod : Page
    {

       public ICollectionView Collection { get; set; }
        
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
            Collection = CollectionViewSource.GetDefaultView(Products);


        }


        
        private void CreateProd_Click(object sender, RoutedEventArgs e)
        {
            new CreateProduct().ShowDialog();
        }

       

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            
            Collection.Filter = (arg) =>
            {
                Product prod = arg as Product;
                return prod.Name.ToLower().Trim().StartsWith(Search.Text.ToLower().Trim()) || prod.Description.ToLower().Trim().StartsWith(Search.Text.ToLower().Trim());
            };
        }

        private void DeleteProduct_Click(object sender, RoutedEventArgs e)
        {
            foreach (Product product in DataProduct.SelectedItems.Cast<Product>().ToList())
                Products.Remove(product);
            DbConnect.db.SaveChanges();
        }

        private void SaveProduct_Click(object sender, RoutedEventArgs e)
        {
            DbConnect.db.SaveChanges();
        }
    }
}
