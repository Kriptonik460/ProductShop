using Microsoft.Win32;
using ProductShop.Resource;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace ProductShop.Empl
{
    /// <summary>
    /// Логика взаимодействия для CreateProduct.xaml
    /// </summary>
    public partial class CreateProduct : Window , INotifyPropertyChanged
    {


        public void OnPropertyChanged([CallerMemberName] string propName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
       

        public Product Product
        {
            get { return (Product)GetValue(ProductProperty); }
            set { SetValue(ProductProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Product.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ProductProperty =
            DependencyProperty.Register("Product", typeof(Product), typeof(CreateProduct));

        public event PropertyChangedEventHandler PropertyChanged;

        public CreateProduct()
        {
            InitializeComponent();
            Product = new Product()
            {
                AdDate = DateTime.Now
            };
            DbConnect.db.Unit.Load();
        }


        private void SavenBtn(object sender, RoutedEventArgs e)
        {
            DbConnect.db.Product.Add(Product);
            
            
            

            DbConnect.db.SaveChanges();
            
        }

        private void CloseBtn(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void ChangeImageClick(object sender, RoutedEventArgs e)
        {
            string photo = Image();
            if (photo == null)
                return;

           Photo = File.ReadAllBytes(photo);
        }

        private string Image()
        {
            OpenFileDialog photo = new OpenFileDialog()
            {
                Filter = "фото|*.png;*.jpg;*.jpeg",
                DefaultExt = "фото|*.png;*.jpg;*.jpeg",
                CheckFileExists = true,
                Multiselect = false
            };
            if (photo.ShowDialog() == true)
                return photo.FileName;
            return null;
        }
        public byte[] Photo
        {
            get => Product?.Photo;
            set
            {
                Product.Photo = value;
                OnPropertyChanged();
            }
        }

        
    }
}
