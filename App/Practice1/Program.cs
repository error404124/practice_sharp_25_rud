using System.Reflection.Metadata;
using App.Practice2;

namespace App;

public class User
{
    private string name;
    private string inn;
    private int age;


    public string Inn
    {
        get { return inn; }
        set
        {
            if (!Requesite.isValidInn(value))
            {
                throw new ArgumentException("Invalid Inn");
            }

            inn = value;
        }
    }

    public int Age
    {
        get { return age; }
        set
        {
            if (value < 0 || value > 100)
            {
                throw new ArgumentException("Invalid Age");
            }

            age = value;
        }
    }

    public User()
    {
    }

    public User(string name)
    {
        this.Inn = inn;
        this.Age = age;
        this.name = name;
    }
}

public static class Program
{
    public static void Main()
    {
        var user = new User();
        user.Inn = "9153885730";
    }
}