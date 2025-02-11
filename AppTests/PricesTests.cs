using App;

namespace AppTests;

public class PricesTests
{
    [TestCase(1000052, "рубля")]
    [TestCase(25, "рублей")]
    [TestCase(11, "рублей")]
    [TestCase(12, "рублей")]
    [TestCase(111, "рублей")]
    [TestCase(101, "рубль")]
    [TestCase(52, "рубля")]
    [TestCase(1, "рубль")]
    
    public void TestPasses_When_Result_Correct(int price, string expected)
    {
        var actual = Prices.GetCurrencyAlias(price, false, false);
        Assert.That(actual, Is.EqualTo(expected));
    }
}