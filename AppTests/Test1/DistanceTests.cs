using App;

namespace AppTests;

public class DistanceTests
{
    [TestCase(1, 1, 1, 1, 1, 1, 0)]
    [TestCase(5, 1, 1, 1, 3, 1, 2)]
    [TestCase(0, 5, 0, 0, 4, 0, 5)]
    [TestCase(6, 0, 0, 0, 5, 0, 1)]
    [TestCase(-1, 0, 0, 0, 5, 0, 1)]

    public void TestPasses_When_Result_Correct(
        // позиция курсора
        double x, double y,
        // отрезок
        double x1, double y1, double x2, double y2,
        double expected)
    {
        var actual = Distance.DistanceToSegment(x, y, x1, y1, x2, y2);
        Assert.That(actual, Is.EqualTo(expected));
    }
}