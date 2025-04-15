namespace App.Practice7;

public static class MovingAverageTask
{
    public static IEnumerable<DataPoint> MovingAverage(this IEnumerable<DataPoint> data, int windowWidth)
    {
        var queue = new Queue<DataPoint>();
        var result = new List<DataPoint>();
        var sum = 0.0;

        foreach (var point in data)
        {
            queue.Enqueue(point);
            sum += point.OriginalY;

            if (queue.Count > windowWidth)
            {
                sum -= queue.Dequeue().OriginalY;
            }

            var avg = sum / queue.Count;
            result.Add(point.WithAvgSmoothedY(avg));
        }

        return result;
    }
}