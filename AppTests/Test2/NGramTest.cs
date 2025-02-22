using App.Practice2;

namespace AppTests.Test2;

public class NGramTest
{
    [TestCase("a b c d. b c d. e b c a d.")]

    public void TestNGram(string inputString)
    {
        var actual = NGram.FrequencyAnalysis(inputString);
        var expected = new Dictionary<string, string>
        {
            { "a", "b" },
            { "b", "c" },
            { "c", "d" },
            { "e", "b" },
            { "a b", "c" },
            { "b c", "d" },
            { "e b", "c" },
            { "c a", "d" }
        };
        
        Assert.That(actual, Is.EqualTo(expected));
    }
}