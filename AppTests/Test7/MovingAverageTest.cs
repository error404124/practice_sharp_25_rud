using App.Practice7;

namespace AppTests.Test7;

public class MovingAverageTest
{
    [Test]
    public void MovingAverageTest1()
    {
        var data = new List<DataPoint>
        {
            new DataPoint(0, 10),
            new DataPoint(1, 20),
            new DataPoint(2, 30),
            new DataPoint(3, 40),
        };
        var window = 2;
        var smoothed = data.MovingAverage(window);
        double[] res = { 10, 15, 25, 35 };
        var i = 0;
        foreach (var point in smoothed)
        {
            Assert.That(res[i], Is.EqualTo(point.AvgSmoothedY));
            i++;
        }
    }
}