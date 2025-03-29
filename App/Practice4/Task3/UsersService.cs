using App.Practice2;
using App.Practice3;

namespace App.Practice_4.Task3;

public class UsersService : IUsersService
{
    private List<User> users;
    
    public UsersService(){
        users = new List<User>();
    }

    public List<User> Users
    {
        get => users;
    }

    private void CheckInn(string inn)
    {
        if (inn.Length != 12)
        {
            throw new ArgumentException("inn must be 12 characters long");
        }

        if (!Requesite.IsValidInn(inn))
        {
            throw new ArgumentException("inn is not a valid inn");
        }
    }

    private void CheckPassword(string password)
    {
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentException("Password cannot be null or empty");
        }
    }

    private void CheckLogin(string login)
    {
        if (string.IsNullOrEmpty(login))
        {
            throw new ArgumentException("Login cannot be null or empty");
        }
    }

    private void CheckPhone(string phone)
    {
        if (string.IsNullOrEmpty(phone))
        {
            throw new ArgumentException("Phone cannot be null or empty");
        }

        if (!PhoneNumber.TryParsePhone(phone, out _))
        {
            throw new ArgumentException("Wrong phone format");
        }
    }

    private void CheckSurname(string surname)
    {
        if (string.IsNullOrEmpty(surname))
        {
            throw new ArgumentException("Surname cannot be null or empty");
        }
    }

    private void CheckName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            throw new ArgumentException("Name cannot be null or empty");
        }
    }

    private void CheckUserId(Guid userId)
    {
        if (userId == Guid.Empty)
        {
            throw new ArgumentException("User ID cannot be empty");
        }
    }

    private void CheckUserDto(CreateUserDto createUserDto)
    {
        if (createUserDto == null)
        {
            throw new ArgumentException("createUserDto cannot be null");
        }

        CheckPassword(createUserDto.Password);
        CheckLogin(createUserDto.Login);
        CheckPhone(createUserDto.Phone);
        CheckSurname(createUserDto.Surname);
        CheckName(createUserDto.Name);
    }

    public User GetUser(Guid userId)
    {
        CheckUserId(userId);

        foreach (User user in users)
        {
            if (user.Id == userId)
            {
                return user;
            }
        }

        throw new ArgumentException("User does not exist");
    }

    public Guid CreateUser(CreateUserDto createUserDto)
    {
        CheckUserDto(createUserDto);

        var user = new User
        {
            Name = createUserDto.Name,
            Surname = createUserDto.Surname,
            Login = createUserDto.Login,
            PasswordHash = UserCreator.CreateMd5(createUserDto.Password),
            Phone = createUserDto.Phone,
            Inn = createUserDto.Inn,
        };

        users.Add(user);
        return user.Id;
    }

    public void DeleteUser(Guid userId)
    {
        CheckUserId(userId);
        var user = GetUser(userId);
        users.Remove(user);
    }

    public void ChangePassword(Guid userId, string oldPassword, string newPassword)
    {
        CheckUserId(userId);
        CheckPassword(oldPassword);
        CheckPassword(newPassword);
        if (oldPassword == newPassword)
        {
            throw new ArgumentException("Passwords cannot be the same");
        }

        var user = GetUser(userId);
        user.PasswordHash = UserCreator.CreateMd5(newPassword);
    }

    public void UpdateUser(Guid userId, UpdateUserDto updateUserDto)
    {
        CheckUserId(userId);
        CheckName(updateUserDto.Name);
        CheckSurname(updateUserDto.Surname);
        CheckPhone(updateUserDto.Phone);
        CheckInn(updateUserDto.Inn);

        var user = GetUser(userId);
        user.Name = updateUserDto.Name;
        user.Surname = updateUserDto.Surname;
        user.Phone = updateUserDto.Phone;
        user.Inn = updateUserDto.Inn;
    }

    public Guid LogIn(string login, string password)
    {
        CheckLogin(login);
        CheckPassword(password);
        foreach (var user in users)
        {
            if (user.Login == login && user.PasswordHash == password)
            {
                return user.Id;
            }
        }

        throw new ArgumentException("Wrong login or password");
    }
}