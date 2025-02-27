using App.Practice2;

namespace AppTests.Test2;

public class ChatBotTest
{
    [TestCase(new string[] { "pop 0" }, null)]
    [TestCase(new string[] { "push a", "push b", "push c" }, "abc")]
    [TestCase(new string[]
        {
            "push Привет! Это снова я! Пока!", 
            "pop 5", 
            "push Как твои успехи? Плохо?", 
            "push qwertyuiop",
            "push 1234567890",
            "pop 26"
        },
        "Привет! Это снова я! Как твои успехи?")]
    [TestCase(new string[] { "push a", "push b", "push c", "pop 3" }, null)]
    public void TestCalculateString(string[] input, string expected)
    {
        var actual = ChatBot.CalculateString(input);
        Assert.That(actual, Is.EqualTo(expected));
    }
}