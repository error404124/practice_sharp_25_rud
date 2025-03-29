using App.Practice3;

namespace App.Practice_4.Task3;

public class Employee: User
{
    private List<Order> orders;
    public List<Order> Orders { get => orders; set => orders = value; }
    public Employee()
    {
        orders = new List<Order>();
    }
}