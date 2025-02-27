using App.Practice2;

namespace AppTests.Test2;

public class BenfordTest
{
    [TestCase("12, cdks1 42", new[] {0, 1, 0, 0, 1, 0, 0, 0, 0, 0})]
    [TestCase("912, 93cdks1 a4gb92", new[] {0, 0, 0, 0, 0, 0, 0, 0, 0, 2})]
    [TestCase("ANkla4lqsdo 5tdaf", new[] {0, 0, 0, 0, 0, 1, 0, 0, 0, 0})]
    [TestCase("abc123 123de", new[] {0, 1, 0, 0, 0, 0, 0, 0, 0, 0})]
    public void TestBenford(string text, int[] expected)
    {
        var actual =  Benford.GetBenfordStatistics(text);
        Assert.That(actual, Is.EqualTo(expected));
    }
}