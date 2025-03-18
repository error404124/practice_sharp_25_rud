namespace App.Practice_4;

public class Rectangle : IGeometry
{
    IVertex TopRight { get; set; }
    IVertex TopLeft { get; set; }
    IVertex UnderRight { get; set; }
    IVertex UnderLeft { get; set; }

    public Rectangle(IVertex topRight, IVertex topLeft, IVertex underRight, IVertex underLeft)
    {
        if (!IsRectangle(topRight, topLeft, underRight, underLeft))
        {
            throw new ArgumentException("Не прямоугольник");
        }

        TopRight = topRight;
        TopLeft = topLeft;
        UnderRight = underRight;
        UnderLeft = underLeft;
    }

    protected double CalculateLen(IVertex v1, IVertex v2)
    {
        return Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2));
    }

    private bool IsRectangle(IVertex topRight, IVertex topLeft, IVertex underRight, IVertex underLeft)
    {
        var topSide = CalculateLen(topRight, topLeft);
        var bottomSide = CalculateLen(underRight, underLeft);
        var leftSide = CalculateLen(topLeft, underLeft);
        var rightSide = CalculateLen(topRight, underRight);

        return (topSide - bottomSide < 0.001) && (leftSide - rightSide < 0.001);
    }

    public int VertexCount
    {
        get { return 4; }
    }

    public double CalculateArea()
    {
        double topSide = CalculateLen(TopRight, TopLeft);
        double leftSide = CalculateLen(TopLeft, UnderLeft);
        return topSide * leftSide;
    }
}