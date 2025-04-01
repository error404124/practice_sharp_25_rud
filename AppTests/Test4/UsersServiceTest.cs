using App.Practice_4.Task3;

namespace AppTests.Test4;

public class UsersServiceTest
{
    [Test]
    public void UsersServiceTest1()
    {
        var usersService = new UsersService();
        var createUserDto = new CreateUserDto
        {
            Name = "A",
            Surname = "B",
            Login = "test1",
            Password = "2025",
            Inn = "860322260733",
            Phone = "+7-983-313-6827"
        };
        var user = usersService.CreateUser(createUserDto);
        Assert.IsNotNull(usersService.Users);
    }
    
    [Test]
    public void UsersServiceTest2()
    {
        var usersService = new UsersService();
        var createUserDto = new CreateUserDto
        {
            Name = "A",
            Surname = "B",
            Login = "test",
            Password = "2025",
            Inn = "860322260733",
            Phone = "+7-983-313-6827"
        };
        var user = usersService.CreateUser(createUserDto);
        
        usersService.ChangePassword(user, "2025", "2026");
        Assert.Throws<ArgumentException>(() => usersService.LogIn("test", "2026"));
    }
    
    [Test]
    public void UsersServiceTest3()
    {
        var usersService = new UsersService();
        var createUserDto = new CreateUserDto
        {
            Name = "A",
            Surname = "B",
            Login = "test",
            Password = "2025",
            Inn = "860322260733",
            Phone = "+7-983-313-6827"
        };
        var user = usersService.CreateUser(createUserDto);
        
        usersService.DeleteUser(user);
        Assert.That(usersService.Users, Is.Empty);
    }
    
    [Test]
    public void UsersServiceTest4()
    {
        var usersService = new UsersService();
        var createUserDto = new CreateUserDto
        {
            Name = "A",
            Surname = "B",
            Login = "test",
            Password = "2025",
            Inn = "860322260733",
            Phone = "+7-983-313-6827"
        };
        var user = usersService.CreateUser(createUserDto);
        var updateUserDto = new UpdateUserDto
        {
            Name = "C",
            Surname = "D",
            Inn = "379394558221",
            Phone = "+7-999-999-6827"
        };
        usersService.UpdateUser(user, updateUserDto);
        Assert.IsNotNull(usersService.Users);
        var name = usersService.Users[0].Name;
        var s = usersService.Users[0].Surname;
        var inn = usersService.Users[0].Inn;
        var phone = usersService.Users[0].Phone;
        Assert.That(name, Is.EqualTo("C"));
        Assert.That(s, Is.EqualTo("D"));
        Assert.That(inn, Is.EqualTo("379394558221"));
        Assert.That(phone, Is.EqualTo("+7-999-999-6827"));
    }
}