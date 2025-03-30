using App.Practice3;

namespace App.Practice_4.Task3;

public class Employee : User
{
    public List<Order> Orders { get; set; }

    public Employee()
    {
        Orders = new List<Order>();
    }
}