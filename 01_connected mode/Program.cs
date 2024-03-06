using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_connected_mode
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Connection String - містить всю інформацію для підключення до сервера 
            // SQL Server
            // -- Windows Authentication -- 
            // "Data Source=server_name;Initial Catalog=db_name;Integrated Security=True"
            // -- Server Authentication -- 
            // "Data Source=server_name;Initial Catalog=db_name;Integrated Security=False;User ID=login;Password=password"

            string conn = @"Data Source=(localdb)\ProjectModels;Initial Catalog=SportShop;Integrated Security=True;Connect Timeout=2;";
            // default Connect Timeout = 30
            SqlConnection connection = new SqlConnection(conn);
            connection.Open();
            Console.WriteLine("Connected");


            /*string cmdText = @"insert into Products
                                values('Зошит', 'Школа', 50, 10, 'Україна', 5)";

            SqlCommand command = new SqlCommand(cmdText, connection);
            // ExecuteNonQuery - викoнує команду, яка не повертає результату (insert delete, update), але метод повертає кількість рядків, які були задіяні в команді
            int row = command.ExecuteNonQuery();
            Console.WriteLine($"{row} rows affected");*/

            // ExecuteScalar - виконує команду, яка повертає одне значення
            /*string cmdText = @"select AVG(Price) from Products";
            SqlCommand command = new SqlCommand(cmdText,connection);
            var res = (int)command.ExecuteScalar();
            Console.WriteLine($"Result avg price :: {res}");*/

            //ExecuteReader - виконує команду select та повертає результат у вигляді DbDataReader
            string cmdText = "select* from Products";
            SqlCommand command = new SqlCommand(cmdText,connection);
            SqlDataReader reader = command.ExecuteReader();

            Console.OutputEncoding = Encoding.UTF8;
            // відображається назва всіх колонок
            for (int i = 0;i < reader.FieldCount; i++) // FieldCount - кількість стовпців у таблиці
            {
                Console.Write($"{reader.GetName(i),16}");
            }
            Console.WriteLine();
            Console.WriteLine(new string('-',120));
            // відображаємо всі значення кожного рядка
            while (reader.Read())
            {
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    Console.Write($"{reader[i],16}");
                }
                Console.WriteLine();
            }
            connection.Close();

            // name; drop database Products
        }
    }
}
