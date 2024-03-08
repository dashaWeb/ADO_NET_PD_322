
using _03_Data_access_layer;
using System.Configuration;
using System.Text;
internal class Program
{
    private static void Main(string[] args)
    {
        Console.OutputEncoding = Encoding.UTF8;
        SportShopDb db = new SportShopDb(ConfigurationManager.ConnectionStrings["connShop"].ConnectionString);
        var list_pr = db.GetAll();
        list_pr.ForEach(p => { Console.WriteLine(p); });

        /*Product product = new Product() { Name = "Ball", Type = "Equipment", CostPrice = 100, Quantity = 15, Producer = "China", Price = 200 };
        db.CreateProduct(product);*/
        //db.Delete(1007);
        Product product = db.getOneProduct(2);
        Console.WriteLine();
        Console.WriteLine(product);
        product.Price -= 50;
        product.Quantity -= 5;
        Console.WriteLine();
        Console.WriteLine(product);
        db.Update(product);
    }


//Реалізуйте консольний додаток, що дозволяє користувачеві виконувати наступні операції:
//1. Додати нового продавця/покупця
//4. Видалити продавця або покупця по id
//5. Показати продавця, загальна сума продаж якого є найбільшою
//Всі параметри для запитів користувач повинен вводити з клавіатури.
}