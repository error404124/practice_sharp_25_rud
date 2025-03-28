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
        return BitConverter.ToString(hash);
    }
}