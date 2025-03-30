namespace App.Practice_4.Task3;

public class Seller
{
    public List<Product> Products { get; set; }

    public List<Order> Orders { get; set; }

    public Seller()
    {
        Products = new List<Product>();
        Orders = new List<Order>();
    }
}