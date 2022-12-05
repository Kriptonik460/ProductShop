using ProductShop.Resource;
using System;
using System.Windows;
using System.Windows.Input;

namespace ProductShop.Empl
{
    /// <summary>
    /// Логика взаимодействия для CreateProduct.xaml
    /// </summary>
    public partial class CreateProduct : Window
    {



        public Product Product
        {
            get { return (Product)GetValue(ProductProperty); }
            set { SetValue(ProductProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Product.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductProperty =
            DependencyProperty.Register("Product", typeof(Product), typeof(CreateProduct));



        public CreateProduct()
        {
            InitializeComponent();
            Product = new Product()
            {
                AdDate = DateTime.Now
            };
        }

        private void logotype_MouseDown(object sender, MouseButtonEventArgs e)
        {

        }

        private void Registr_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Registr_Click_1(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
