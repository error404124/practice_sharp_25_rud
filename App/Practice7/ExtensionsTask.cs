namespace App.Practice7;

public static class ExtensionsTask
{
    public static double Median(this IEnumerable<double> items)
    {
        if (items is null)
            throw new ArgumentNullException(nameof(items));

        var sorted = items.OrderBy(x => x).ToList();
        var len = sorted.Count;
        
        if (len % 2 == 1)
        {
            return sorted[len / 2];
        }

        return (sorted[len / 2 - 1] + sorted[len / 2 + 1]) / 2.0;
    }

    public static IEnumerable<(T First, T Second)> Bigrams<T>(this IEnumerable<T> items)
    {
        var sorted = items.OrderBy(x => x).ToList();
        var len = sorted.Count;
        for (var i = 0; i < len - 1; i++)
        {
            yield return (sorted[i], sorted[i + 1]);
        }
    }
}