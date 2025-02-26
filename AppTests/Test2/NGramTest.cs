using App.Practice2;

namespace AppTests.Test2;

public class NGramTest
{
    [TestCase("a, b")]

    public void TestNGram(string inputString)
    {
        var actual = NGram.FrequencyAnalysis(inputString);
        var expected = new Dictionary<string, string>
        {
            { "a", "b" },
        };
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}