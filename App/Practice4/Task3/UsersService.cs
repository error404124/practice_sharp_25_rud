using App.Practice3;

namespace App.Practice_4.Task3;

public class UsersService : IUsersService
{
    private List<User> users;
    public List<User> Users { get => users;}

    private void NullId(Guid userId)
    {
        if (users == null)
        {
            throw new ArgumentNullException("User id cannot be null");
        }
    }

    private void CheckUserDto(CreateUserDto createUserDto)
    {
        if (createUserDto == null)
        {
            throw new ArgumentNullException("createUserDto cannot be null");
        }

        if (createUserDto.Password == null)
        {
            throw new ArgumentNullException("password cannot be null");
        }
        
        if (createUserDto.Login == null)
        {
            throw new ArgumentNullException("login cannot be null");
        }

        if (createUserDto.Phone == null)
        {
            throw new ArgumentNullException("phone cannot be null");
        }

        if (createUserDto.Surname == null)
        {
            throw new ArgumentNullException("surname cannot be null");
        }

        if (createUserDto.Name == null)
        {
            throw new ArgumentNullException("name cannot be null");
        }
    }
    
    public User GetUser(Guid userId)
    {
        NullId(userId);

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
        
        // var User = new User
        // {
        //     Name = createUserDto.Name,
        //     Surname = createUserDto.Surname,
        //     Login = createUserDto.Login,
        //     Password = createUserDto.Password,
        //     Phone = createUserDto.Phone,
        //     Inn = createUserDto.Inn,
        // };
        //
        
        throw new NotImplementedException();
    }

    public void DeleteUser(Guid userId)
    {
        throw new NotImplementedException();
    }

    public void ChangePassword(Guid userId, string oldPassword, string newPassword)
    {
        throw new NotImplementedException();
    }

    public void UpdateUser(Guid userId, UpdateUserDto updateUserDto)
    {
        throw new NotImplementedException();
    }

    public Guid LogIn(string login, string password)
    {
        throw new NotImplementedException();
    }
}