using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02_params
{
    public class Product
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Quantity { get; set; }
        public int CostPrice { get; set; }
        public string Producer { get; set; }
        public int Price { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            string conn = ConfigurationManager.ConnectionStrings["connShop"].ConnectionString;
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();

            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;
            //string name = Console.ReadLine();
            //ShowProductByNameUnSafe(name, connection);
            //ShowProductByName(name, connection);
            AddProduct(new Product()
            {
                Name = "Шарф",
                Type = "Аксесуари",
                Quantity = 15,
                CostPrice= 50,
                Price = 150,
                Producer = "Україна"
            }, connection);
            connection.Close();
        }
        // варіант передачі параметрів в запиті, якій містить велику 'дирку' в безпеці
        static void ShowProductByNameUnSafe(string name, SqlConnection connection)
        {
            // name = "test; drop table Products"
            string cmdText = $@"select * from Products where Name = '{name}'";
            SqlCommand command = new SqlCommand(cmdText, connection);
            var reader = command.ExecuteReader();
            ShowReaderData(reader);
        }
        static void ShowProductByName(string name, SqlConnection connection)
        {
            string cmdText = $@"select * from Products where Name = @prod_name";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("@prod_name", System.Data.SqlDbType.NVarChar).Value = name;
            var reader = command.ExecuteReader();
            ShowReaderData(reader);
        }
        static void AddProduct(Product product, SqlConnection connection)
        {
            string cmdText = @"insert into Products values(@name,@type,@quantity,@cost_price,@producer,@price)";
            SqlCommand command = new SqlCommand(cmdText, connection);
            command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = product.Name;
            command.Parameters.Add("@type", System.Data.SqlDbType.NVarChar).Value = product.Type;
            command.Parameters.Add("@quantity", System.Data.SqlDbType.Int).Value = product.Quantity;
            command.Parameters.Add("@cost_price", System.Data.SqlDbType.Int).Value = product.CostPrice;
            command.Parameters.Add("@producer", System.Data.SqlDbType.NVarChar).Value = product.Producer;
            command.Parameters.Add("@price", System.Data.SqlDbType.Int).Value = product.Price;
            command.ExecuteNonQuery();

        }
        static void ShowReaderData(SqlDataReader reader)
        {
            for (int i = 0; i < reader.FieldCount; i++) // FieldCount - кількість стовпців у таблиці
            {
                Console.Write($"{reader.GetName(i),16}");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-', 120));
            // відображаємо всі значення кожного рядка
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader[i],16}");
                }
                Console.WriteLine();
            }
        }
    }
}
