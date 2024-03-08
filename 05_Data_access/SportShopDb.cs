using _05_Data_access.Model;
using System.Data.SqlClient;

public class SportShopDb
{
    // CRUD
    // [C]reate
    // [R]ead
    // [U]pdate
    // [D]elete
    private SqlConnection connection;
    public SportShopDb(string connectionString)
    {
        connection = new SqlConnection(connectionString);
        connection.Open();
        Console.WriteLine("Connected to database");
    }
    public void CreateProduct(Product product)
    {
        string cmdText = $@"insert into Products
                            values(@name,@type,@quantity,@cost_price,@producer,@price)";
        SqlCommand command = new SqlCommand(cmdText, connection);
        setCommandParams(ref command, product);
        command.ExecuteNonQuery();
    }
    public List<Product> getAllProductQuery(SqlCommand command)
    {
        List<Product> products = new List<Product>();
        SqlDataReader reader = command.ExecuteReader();
        while (reader.Read())
        {
            products.Add(new Product()
            {
                Id = (int)reader[0], // reader["Id"]
                Name = (string)reader[1],
                Type = (string)reader[2],
                Quantity = (int)reader[3],
                CostPrice = (int)reader[4],
                Producer = (string)reader[5],
                Price = (int)reader[6]
            });
        }
        reader.Close();
        return products;
    }
    private void setCommandParams(ref SqlCommand command, Product product)
    {
        command.Parameters.Add("@name", System.Data.SqlDbType.NVarChar).Value = product.Name;
        command.Parameters.Add("@type", System.Data.SqlDbType.NVarChar).Value = product.Type;
        command.Parameters.Add("@quantity", System.Data.SqlDbType.Int).Value = product.Quantity;
        command.Parameters.Add("@cost_price", System.Data.SqlDbType.Int).Value = product.CostPrice;
        command.Parameters.Add("@producer", System.Data.SqlDbType.NVarChar).Value = product.Producer;
        command.Parameters.Add("@price", System.Data.SqlDbType.Int).Value = product.Price;
    }
    public Product getOneProduct(int id)
    {
        string cmdText = "select* from Products where Id = @id";
        SqlCommand command = new SqlCommand(cmdText, connection);
        command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
        return getAllProductQuery(command).FirstOrDefault();
    }
    public List<Product> GetAll() // Read 
    {
        string cmdText = "select* from Products";
        SqlCommand command = new SqlCommand(cmdText, connection);
        return getAllProductQuery(command);
    }
    public void Update(Product product)
    {
        string cmdText = @"update Products
                           set
                                Name = @name,
                                TypeProduct = @type,
                                Quantity = @quantity,
                                CostPrice = @cost_price,
                                Producer = @producer,
                                Price = @price
                            where Id = @id";

        SqlCommand command = new SqlCommand(cmdText, connection);
        setCommandParams(ref command, product);
        command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = product.Id;
        command.ExecuteNonQuery();
    }
    public void Delete(int id)
    {

        string cmdText = @"delete from Products
                           where Id = @id";
        SqlCommand command = new SqlCommand(cmdText, connection);
        command.Parameters.Add("@id", System.Data.SqlDbType.Int).Value = id;
        command.ExecuteNonQuery();
    }
    ~SportShopDb()
    {
        connection.Close();
    }
}
