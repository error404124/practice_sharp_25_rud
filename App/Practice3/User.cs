using App.Practice2;

namespace App.Practice3;

public class User
{
    private readonly Guid id;
    private readonly string login;
    private readonly string passwordHash;
    private readonly string name;
    private readonly string surname;
    private readonly string inn;
    private string phone;
    private readonly DateTime registerDate;


    public string Login
    {
        get { return login; }
        init { login = value; }
    }

    public string PasswordHash
    {
        get { return passwordHash; }
        init { passwordHash = value; }
    }

    public string Phone
    {
        get { return phone; }
        set
        {
            if (TryUpdatePhone(value))
            {
                phone = value;
            }
            else
            {
                throw new ArgumentException("Телефон некорректен.");
            }
        }
    }

    public string Inn
    {
        get { return inn; }
    }

    public Guid Id
    {
        get { return id; }
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

    public User(string login, string hash, string name, string surname, string inn, string phone)
    {
        id = Guid.NewGuid();
        registerDate = DateTime.Now;
        passwordHash = hash;
        this.login = login;
        this.name = name;
        this.surname = surname;
        Phone = phone;

        if (Requesite.IsValidInn(inn))
        {
            this.inn = inn;
        }
        else
        {
            throw new ArgumentException("ИНН некорректен.");
        }
    }

    public User()
    {
        id = Guid.NewGuid();
        registerDate = DateTime.Now;
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

    private bool TryUpdatePhone(string phone)
    {
        if (IsPhoneValid(phone))
        {
            this.phone = phone;
            return true;
        }

        return false;
    }
}