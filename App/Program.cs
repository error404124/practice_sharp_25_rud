using System.Reflection.Metadata;
using App.Practice2;
using App.Practice3;

namespace App;

// public interface IGeometry
// {
//     int VertexCount { get; }
//
//     public double CalculateArea();
// }
//
// public interface IVertex
// {
//     double X { get; set; }
//     double Y { get; set; }
// }
//
// class Vertex : IVertex
// {
//     public double X { get; set; }
//
//     public double Y { get; set; }
//
//     public Vertex(double x, double y)
//     {
//         X = x;
//         Y = y;
//     }
// }
//
// class Triangle : IGeometry
// {
//     IVertex V1 { get; set; }
//     IVertex V2 { get; set; }
//     IVertex V3 { get; set; }
//
//
//     public Triangle(IVertex v1, IVertex v2, IVertex v3)
//     {
//         if (CalculateLen(v1, v2) + CalculateLen(v2, v3) < CalculateLen(v1, v3) ||
//             CalculateLen(v1, v3) + CalculateLen(v2, v3) < CalculateLen(v1, v2) ||
//             CalculateLen(v1, v2) + CalculateLen(v1, v3) < CalculateLen(v2, v3))
//         {
//             throw new ArgumentException("Не выполнено нер-во треугольника");
//         }
//
//         V1 = v1;
//         V2 = v2;
//         V3 = v3;
//     }
//
//     public int VertexCount
//     {
//         get { return 3; }
//     }
//
//     private double CalculateLen(IVertex v1, IVertex v2)
//     {
//         return Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2));
//     }
//
//     private double CalculatePerimeter(IVertex v1, IVertex v2, IVertex v3)
//     {
//         return CalculateLen(v1, v2) + CalculateLen(v3, v2) + CalculateLen(v1, v3);
//     }
//
//     public double CalculateArea()
//     {
//         var perimeter = CalculatePerimeter(V1, V2, V3);
//         var semiPerimeter = perimeter / 2;
//
//         return Math.Sqrt(semiPerimeter * (semiPerimeter - CalculateLen(V1, V2)) *
//                          (semiPerimeter - CalculateLen(V2, V3)) * (semiPerimeter - CalculateLen(V1, V3)));
//     }
// }
//
// class Rectangle : IGeometry
// {
//     IVertex TopRight { get; set; }
//     IVertex TopLeft { get; set; }
//     IVertex UnderRight { get; set; }
//     IVertex UnderLeft { get; set; }
//
//     Rectangle(IVertex topRight, IVertex topLeft, IVertex underRight, IVertex underLeft)
//     {
//         if (!IsRectangle(topRight, topLeft, underRight, underLeft))
//         {
//             throw new ArgumentException("Не прямоугольник");
//         }
//         
//         TopRight = topRight;
//         TopLeft = topLeft;
//         UnderRight = underRight;
//         UnderLeft = underLeft;
//     }
//
//     private double CalculateLen(IVertex v1, IVertex v2)
//     {
//         return Math.Sqrt(Math.Pow(v1.X - v2.X, 2) + Math.Pow(v1.Y - v2.Y, 2));
//     }
//
//     private bool IsRectangle(IVertex topRight, IVertex topLeft, IVertex underRight, IVertex underLeft)
//     {
//         var topSide = CalculateLen(topRight, topLeft);
//         var bottomSide = CalculateLen(underRight, underLeft);
//         var leftSide = CalculateLen(topLeft, underLeft);
//         var rightSide = CalculateLen(topRight, underRight);
//
//         return (topSide - bottomSide < 0.001) && (leftSide - rightSide < 0.001);
//     }
//
//     public int VertexCount
//     {
//         get { return 4; }
//     }
//
//     public double CalculateArea()
//     {
//         double topSide = CalculateLen(TopRight, TopLeft);
//         double leftSide = CalculateLen(TopLeft, UnderLeft);
//         return topSide * leftSide;
//     }
// }

// class Square : Rectangle
// {
//     
// }

public static class Program
{
    public static void Main()
    {
        User first = new User("1234", "1234", "Joe", "Biden", "9153885734", "+79833136827");
        User second = new User("1234", "1234", "Boris", "Johnson", "2605245659", "+79899999999");

        first.TryUpdatePhone("89833136827");

        Console.WriteLine(second.GetUserFullName());
        Console.WriteLine(first.Phone);
    }
}