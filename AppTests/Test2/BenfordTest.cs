using App.Practice2;

namespace AppTests.Test2;

public class BenfordTest
{
    [TestCase("12, cdks 1; 42", new[] {0, 2, 0, 0, 1, 0, 0, 0})]
    public void TestBenford(string text, int[] expected)
    {
        var actual =  Benford.GetBenfordStatistics(text);
        Assert.That(actual, Is.EqualTo(expected));
    }
}