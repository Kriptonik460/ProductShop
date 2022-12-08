using ProductShop.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Логика взаимодействия для Zakaz.xaml
    /// </summary>
    /// 
    public partial class Zakaz : Page
    {


        public List<ProductVM> Products
        {
            get { return (List<ProductVM>)GetValue(ProductsProperty); }
            set { SetValue(ProductsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Products.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductsProperty =
            DependencyProperty.Register("Products", typeof(List<ProductVM>), typeof(Zakaz));

        public IEnumerable<ProductVM> SelectedProducts => Products?.Where(product => product.IsSelected);
        public decimal? Summary => SelectedProducts?.Sum(product => product.Product.Cost * product.Count);

        public Zakaz()
        {
            InitializeComponent();
            Products = DbConnect.db.Product.Local.Select(product => new ProductVM(product)).ToList();
        }

        private void Page_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                MessageBox.Show($"{string.Join(", ", SelectedProducts.Select(product => product.Name))}");
        }
    }

    public class ProductVM : INotifyPropertyChanged
    {
        public Product Product { get; set; }
        private bool _selected = false;

        public string Name => Product.Name;
        public string Description => Product.Description;
        public decimal Cost => Product.Cost;
        public decimal Count => Product.Count;
        public bool IsSelected
        {
            get => _selected;
            set
            {
                _selected = value;
                OnPropertyChanged();
            }
        }

        public ProductVM(Product product) =>
            Product = product;

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string propName = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
    }
}
