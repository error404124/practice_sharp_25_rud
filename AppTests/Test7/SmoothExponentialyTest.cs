using App.Practice7;

namespace AppTests.Test7;

public class SmoothExponentialyTest
{
    [Test]
    public void SmoothExponentialyTest1()
    {
        var data = new List<DataPoint>
        {
            new DataPoint(0, 10),
            new DataPoint(1, 20),
            new DataPoint(2, 30),
            new DataPoint(3, 40),
        };
        double alpha = 0.5;
        var smoothed = data.SmoothExponentialy(alpha);
        double[] res = { 10, 15, 22.5, 31.25 };
        var i = 0;
        foreach (var point in smoothed)
        {
            Assert.That(res[i], Is.EqualTo(point.ExpSmoothedY));
            i++;
        }
        
    }
}