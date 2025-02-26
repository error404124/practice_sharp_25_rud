using App.Practice2;

namespace AppTests.Test2;

public class ChatBotTest
{
    [TestCase(new string[]
        { "pop 0" }, null)]
    public void TestCalculateString(string[] input, string expected)
    {
        var actual = ChatBot.CalculateString(input);
        Assert.That(actual, Is.EqualTo(expected));
    }
}