using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using data_access_fluentApi;
namespace _14_Fluent_api_wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        AirplaneDbContext context;
        public MainWindow()
        {
            InitializeComponent();
            context = new AirplaneDbContext();
        }

        private void getFlights(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = context.Flights.ToList();
        }
        private void getAirplanes(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource = context.Airplanes.ToList();
        }
        private void getClients(object sender, RoutedEventArgs e)
        {
            grid.ItemsSource= context.Clients.ToList();
        }
    }
}