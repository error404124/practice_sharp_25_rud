using App.Practice2;

namespace App.Practice3;

public class User
{
    public readonly Guid Id;
    private string login;
    private string password;
    private readonly string name;
    private readonly string surname;
    private readonly string inn;
    private string phone;
    private readonly DateTime registerDate;


    public string Login
    {
        get { return login; }
        set { login = value; }
    }

    public string Password
    {
        get { return password; }
        set { password = value; }
    }

    public string Phone
    {
        get { return phone; }
    }

    public string Inn
    {
        get { return inn; }
    }
    
    public Guid ID
    {
        get { return Id; }
    }

    public string Name
    {
        get { return name; }
    }

    public string Surname
    {
        get { return surname; }
    }

    public DateTime RegisterDate
    {
        get { return registerDate; }
    }

    public User(string login, string password, string name, string surname, string inn, string phone)
    {
        Id = Guid.NewGuid();
        registerDate = DateTime.Now;
        this.login = login;
        this.password = password;
        this.name = name;
        this.surname = surname;

        if (IsPhoneValid(phone))
        {
            this.phone = phone;
        }
        else
        {
            throw new ArgumentException("Телефон некорректен.");
        }

        if (Requesite.IsValidInn(inn))
        {
            this.inn = inn;
        }
        else
        {
            throw new ArgumentException("ИНН некорректен.");
        }
    }

    public string GetUserFullName()
    {
        return $"{surname} {name}";
    }

    private static bool IsPhoneValid(string phone)
    {
        if (PhoneNumber.TryParsePhone(phone, out _))
        {
            return true;
        }

        return false;
    }

    public bool TryUpdatePhone(string phone)
    {
        if (IsPhoneValid(phone))
        {
            this.phone = phone;
            return true;
        }

        return false;
    }
}