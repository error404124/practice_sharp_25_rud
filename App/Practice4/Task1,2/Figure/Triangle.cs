namespace App.Practice_4;

public class Triangle: IGeometry
{
    IVertex V1 { get; set; }
    IVertex V2 { get; set; }
    IVertex V3 { get; set; }


    public Triangle(IVertex v1, IVertex v2, IVertex v3)
    {
        if (CalculateLen(v1, v2) + CalculateLen(v2, v3) < CalculateLen(v1, v3) ||
            CalculateLen(v1, v3) + CalculateLen(v2, v3) < CalculateLen(v1, v2) ||
            CalculateLen(v1, v2) + CalculateLen(v1, v3) < CalculateLen(v2, v3))
        {
            throw new ArgumentException("Не выполнено нер-во треугольника");
        }

        V1 = v1;
        V2 = v2;
        V3 = v3;
    }

    public int VertexCount
    {
        get { return 3; }
    }

    private double CalculateLen(IVertex v1, IVertex v2)
    {
        return Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2));
    }

    private double CalculatePerimeter(IVertex v1, IVertex v2, IVertex v3)
    {
        return CalculateLen(v1, v2) + CalculateLen(v3, v2) + CalculateLen(v1, v3);
    }

    public double CalculateArea()
    {
        var perimeter = CalculatePerimeter(V1, V2, V3);
        var semiPerimeter = perimeter / 2;

        return Math.Sqrt(semiPerimeter * (semiPerimeter - CalculateLen(V1, V2)) *
                         (semiPerimeter - CalculateLen(V2, V3)) * (semiPerimeter - CalculateLen(V1, V3)));
    }
}