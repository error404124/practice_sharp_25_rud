using System.Drawing;

namespace App.Practice7;

public static class ExpSmoothingTask
{
    public static IEnumerable<DataPoint> SmoothExponentialy(this IEnumerable<DataPoint> data, double alpha)
    {
        var result = new List<DataPoint>();
        var s0 = data.First();
        DataPoint x0 = s0.WithExpSmoothedY(s0.OriginalY);

        foreach (var s in data)
        {
            var x1 = alpha * s.OriginalY + (1 - alpha) * x0.ExpSmoothedY;
            x0 = s.WithExpSmoothedY(x1);
            result.Add(x0);
        }

        return result;
    }
}