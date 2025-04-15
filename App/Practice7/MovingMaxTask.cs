namespace App.Practice7;

public static class MovingMaxTask
{
    public static IEnumerable<DataPoint> MovingMax(this IEnumerable<DataPoint> data, int windowWidth)
    {
        var window = new Queue<double>();
        var result = new List<DataPoint>();
        
        foreach (var point in data)
        {
            window.Enqueue(point.OriginalY);
            if (window.Count > windowWidth)
                window.Dequeue();

            var max = window.Max(); 
            result.Add(point.WithMaxY(max));
        }
        return result;
    }
}