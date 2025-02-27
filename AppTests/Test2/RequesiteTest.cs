using App.Practice2;

namespace AppTests.Test2;

public class RequesiteTest
{
    [TestCase("860322260733", true)]
    [TestCase("1000052", false)]
    [TestCase("379394558221", true)]
    [TestCase("536904201650", true)]
    [TestCase("9153885734", true)]
    [TestCase("2605245659", true)]
    [TestCase("2605245658", false)]
    [TestCase("536904201651", false)]
    [TestCase("379394558220", false)]
    
    public void TestisValidInn(string inn, bool expected)
    {
        var actual = Requesite.IsValidInn(inn);
        Assert.That(actual, Is.EqualTo(expected));
    }
}