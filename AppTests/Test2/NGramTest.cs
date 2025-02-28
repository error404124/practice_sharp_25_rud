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
            { "she stood", "up" },
            { "she", "stood" },
            { "stood", "up" },
            { "then she", "left" },
            { "then", "she" }
        };

        Assert.That(actual, Is.EqualTo(expected));
    }
}