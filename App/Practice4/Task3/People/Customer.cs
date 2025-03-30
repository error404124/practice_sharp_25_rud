using App.Practice3;

namespace App.Practice_4.Task3;

public class Customer : User
{
    public List<Order> Orders { get; set; }
    public Cart Cart { get; set; }

    public Customer()
    {
        Orders = new List<Order>();
    }
}