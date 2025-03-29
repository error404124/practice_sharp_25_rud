using App.Practice3;

namespace App.Practice_4.Task3;

public class Customer: User
{
    private Cart cart;
    private List<Order> orders;
    public List<Order> Orders { get => orders; set => orders = value; }
    public Cart Cart { get => cart; set => cart = value; }
    
    public Customer()
    {
        orders = new List<Order>();
    }
}