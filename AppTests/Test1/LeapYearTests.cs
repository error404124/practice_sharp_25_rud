using App;

namespace AppTests;

public class LeapYearTests
{
    [TestCase(2100, false)]
    [TestCase(2400, true)]
    [TestCase(2024, true)]
    [TestCase(2019, false)]
    [TestCase(1896, true)]
    [TestCase(1936, true)]
    [TestCase(1908, true)]
    public void TestPasses_When_Result_Correct(int year, bool expected)
    {
        var actual = LeapYear.IsLeapYear(year);
        Assert.That(actual, Is.EqualTo(expected));
    }
}