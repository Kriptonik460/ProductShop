using ProductShop.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace ProductShop.Empl
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        private ICollectionView _toys;
        public ICollectionView ToysSee
        {
            get
            {
                return _toys;
            }
            set
            {
                _toys = value;
            }
        }

        public MainPage()
        {
            DbConnect.db.Product.Load();

            InitializeComponent();

            _toys = new CollectionViewSource { Source = DbConnect.db.Product.Local }.View;

            ListToys.ItemsSource = _toys;

            SeachText.TextChanged += (s, e) => _toys.Refresh();

            _toys.Filter += (obj) =>
            {
                var toy = obj as Product;

                var search = SeachText.Text;

                if (toy.Name.Contains(search) || toy.Description.Contains(search))
                    return true;

                return false;
            };

            SortListToys.SelectionChanged += (s, e) =>
            {
                var tag = (SortListToys.SelectedItem as ComboBoxItem).Tag;

                switch (tag)
                {
                    case "CostDecreasing":
                        _toys.SortDescriptions.Clear();
                        _toys.SortDescriptions.Add(new SortDescription()
                        {
                            PropertyName = "Cost",
                            Direction = ListSortDirection.Ascending,
                        });
                        break;

                    case "CostIncreasing":
                        _toys.SortDescriptions.Clear();
                        _toys.SortDescriptions.Add(new SortDescription()
                        {
                            PropertyName = "Cost",
                            Direction = ListSortDirection.Descending,
                        });
                        break;

                    case "Any":
                        _toys.SortDescriptions.Clear();
                        break;
                }
            };
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

        }

        private void ButtonClickCodeAdmin(object sender, RoutedEventArgs e)
        {
            if (AdminCode.Text.Equals("0000"))
            {
                AddToy.Visibility = Visibility.Visible;
                EditToy.Visibility = Visibility.Visible;
                DeleteToy.Visibility = Visibility.Visible;

                AdminPanel.Visibility = Visibility.Collapsed;
                KlientPanel.Visibility = Visibility.Visible;
            }
        }

        private void ButtonClickCodeKlient(object sender, RoutedEventArgs e)
        {
            AdminPanel.Visibility = Visibility.Visible;
            KlientPanel.Visibility = Visibility.Collapsed;

            AddToy.Visibility = Visibility.Hidden;
            EditToy.Visibility = Visibility.Hidden;
            DeleteToy.Visibility = Visibility.Hidden;
        }
    }
}
