namespace App.Practice_4.Task3;

public class Admin
{
    private List<Employee> employees;
    public List<Employee> Employees { get => employees; set => employees = value; }

    public Admin()
    {
        Employees = new List<Employee>();
    }
}