using App.Practice3;

namespace AppTests.Test3;

public class UserTest
{
    [Test]
    public void PhoneTest1()
    {
        var user = new User("test_login", "test_password", "-", "-", "860322260733", "89833136827");
        Assert.That(user.Phone, Is.EqualTo("89833136827"));
    }
    
    [Test]
    public void PhoneTest2()
    {
        Assert.Throws<ArgumentException>(() =>
        {
           new User("test_login", "test_password", "-", "-", "860322260733", "123");
        });
        
    }
    
    [Test]
    public void PhoneTest3()
    {
        var user = new User("test_login", "test_password", "-", "-", "860322260733", "89833136827");
        
        user.Phone = "+7-983-313-6827";
        Assert.That(user.Phone, Is.EqualTo("+7-983-313-6827"));
        
    }
    
    [Test]
    public void PhoneTest4()
    {
        var user = new User("test_login", "test_password", "-", "-", "860322260733", "89833136827");
        
        Assert.Throws<ArgumentException>(() => user.Phone = "+7-asdf");
        
    }
    
    [Test]
    public void InnTest1()
    {
        var user = new User("test_login", "test_password", "-", "-", "860322260733", "89833136827");
        Assert.That(user.Inn, Is.EqualTo("860322260733"));
    }
    
    [Test]
    public void InnTest2()
    {
        Assert.Throws<ArgumentException>(() =>
        {
            new User("test_login", "test_password", "-", "-", "4132qsad", "89833136827");
        });
    }
    
    [Test]
    public void RegisterDate1()
    {
        var user = new User();
        
        Assert.NotNull(user.RegisterDate);
    }
    
    [Test]
    public void IdTest1()
    {
        var user = new User();
        
        Assert.NotNull(user.Id);
    }
    
    
}