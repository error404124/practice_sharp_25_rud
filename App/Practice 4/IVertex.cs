namespace App.Practice_4;

public interface IVertex
{
    double X { get; set; }
    double Y { get; set; }
}

public class Vertex : IVertex
{
    public double X { get; set; }

    public double Y { get; set; }

    public Vertex(double x, double y)
    {
        X = x;
        Y = y;
    }

    public override string ToString()
    {
        return $"({X:F3}, {Y:F3})";
    }
}
