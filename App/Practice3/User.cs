using App.Practice2;

namespace App.Practice3;

public static class UserCreator
{
    public static User CreateUser(string login, string password, string name, string surname, string inn, string phone)
    {
        var passwordHash = CreateMd5(password);
        return new User(login, passwordHash, name, surname, inn, phone);
    }

    private static string CreateMd5(string password)
    {
        var md5 = System.Security.Cryptography.MD5.Create();
        var passwordBytes = System.Text.Encoding.ASCII.GetBytes(password);
        var hash = md5.ComputeHash(passwordBytes);
        return BitConverter.ToString(hash).Replace("-", "").ToLower();
    }
}

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
        init { }
    }

    public string Password
    {
        get { return passwordHash; }
        init { }
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

            throw new ArgumentException("Телефон некорректен.");
        }
    }

    public string Inn
    {
        get { return inn; }
    }

    public Guid ID
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