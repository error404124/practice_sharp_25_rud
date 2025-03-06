using App.Practice2;

namespace AppTests.Test2;

public class NGramTest
{
    [TestCase("She stood up. Then she left.")]
    public void TestNGram(string inputString)
    {
        var actual = NGram.FrequencyAnalysis(inputString);
        var expected = new Dictionary<string, string>
        {
            { "stood", "up" },
            { "then", "she" },
            { "she", "left" },
            { "she stood", "up" },
            { "then she", "left" },
        };

        Assert.That(actual, Is.EqualTo(expected));
    }
}