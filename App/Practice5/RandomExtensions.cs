namespace Experiments;

public class RandomExtensions
{
    private static readonly Random Random = new();
    public static int NextInclusive(int min, int max)
    {
        return Random.Next(min, max + 1);
    }
    
    public static double NextDoubleInclusive(double min, double max)
    {
        return Random.NextDouble() * (max - min) + min;
    }
}