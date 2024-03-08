using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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

namespace _06_dataAdapter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        private SqlConnection connection;
        private SqlDataAdapter da;
        private DataSet set;
        private SqlCommandBuilder cmd;
        public MainWindow()
        {
            InitializeComponent();
            connection = new SqlConnection(ConfigurationManager.ConnectionStrings["connShop"].ConnectionString);
        }

        // Fill btn
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string sql = commandText.Text;
            da = new SqlDataAdapter(sql, connection);
            cmd = new SqlCommandBuilder(da); // create command builder for auto generate insert, update, delete
            set = new DataSet();
            da.Fill(set,"MyTable");
            dataGrid.ItemsSource = set.Tables["MyTable"].DefaultView;
        }
        // Update btn
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            da.Update(set,"MyTable");
        }
    }
}
