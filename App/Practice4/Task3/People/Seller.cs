namespace App.Practice_4.Task3;

public class Seller
{
    private List<Product> products;
    private List<Order> orders;
    public List<Product> Products { get => products; set => products = value; }
    public List<Order> Orders { get => orders; set => orders = value; }

    public Seller()
    {
        products = new List<Product>();
        orders = new List<Order>();
    }
    
}