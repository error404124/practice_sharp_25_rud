using App.Practice2;

namespace AppTests.Test2;

public class NGramTest
{
    [TestCase("a A a A")]
    public void TestNGram(string inputString)
    {
        var actual = NGram.FrequencyAnalysis(inputString);
        var expected = new Dictionary<string, string>
        {
            { "a", "a" },
            {"a a", "a"}
        };

        Assert.That(actual, Is.EqualTo(expected));
    }
}