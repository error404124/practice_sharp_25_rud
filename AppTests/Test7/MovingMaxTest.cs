using App.Practice7;

namespace AppTests.Test7;

public class MovingMaxTest
{
    [Test]
    public void MovingMaxTest1()
    {
        var data = new List<DataPoint>
        {
            new DataPoint(0, 10),
            new DataPoint(1, 20),
            new DataPoint(2, 30),
            new DataPoint(3, 40),
        };
        var window = 2;
        var smoothed = data.MovingMax(window);
        double[] res = { 10, 20, 30, 40 };
        var i = 0;
        foreach (var point in smoothed)
        {
            Assert.That(res[i], Is.EqualTo(point.MaxY));
            i++;
        }
        
    }
}