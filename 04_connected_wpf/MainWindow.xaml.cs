using _05_Data_access.Model;
using System;
using System.Collections.Generic;
using System.Configuration;
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
namespace _04_connected_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SportShopDb db;
        public MainWindow()
        {
            InitializeComponent();
            db = new SportShopDb(ConfigurationManager.ConnectionStrings["connShop"].ConnectionString);
        }

        private void getProducts(object sender, RoutedEventArgs e)
        {
            dataGrid.ItemsSource = db.GetAll();
        }

        private void getProduct(object sender, RoutedEventArgs e)
        {
            int id = int.Parse(idProduct.Text);
            List<Product> list = new List<Product>();

            Product item = db.getOneProduct(id);
            if (item != null)
            {
                list.Add(item);
                dataGrid.ItemsSource = list;
            }
            else
            {
                MessageBox.Show(" id not found");
            }
            idProduct.Text = "";
        }

        private void Button_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                this.getProduct(sender, e);
            }
        }
    }
}

