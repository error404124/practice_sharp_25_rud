namespace App.Practice_4;

public class Figure
{
    public interface IGeometry
    {
        int VertexCount { get; }

        public double CalculateArea();
    }

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
    }

    public class Triangle : IGeometry
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

        public double CalculateLen(IVertex v1, IVertex v2)
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


    public class Square : Rectangle
    {
        IVertex TopRight { get; set; }
        IVertex TopLeft { get; set; }
        IVertex UnderRight { get; set; }
        IVertex UnderLeft { get; set; }

        public Square(IVertex topRight, IVertex topLeft, IVertex underRight, IVertex underLeft):base(topRight, topLeft, underRight, underLeft)
        {
            if (!IsSquare(topRight, topLeft, underRight, underLeft))
            {
                throw new ArgumentException("Не Квадрат");
            }
            TopRight = topRight;
            TopLeft = topLeft;
            UnderRight = underRight;
            UnderLeft = underLeft;
        }

        bool IsSquare(IVertex topRight, IVertex topLeft, IVertex underRight, IVertex underLeft)
        {
            if (CalculateLen(topRight, topLeft) - CalculateLen(underRight, underLeft) > 0.001 ||
                CalculateLen(topRight, underRight) - CalculateLen(underRight, underLeft) > 0.001 ||
                CalculateLen(topLeft, underLeft) - CalculateLen(underRight, underLeft) > 0.001)
            {
                return false;
            }
            return true;
        }

        
    }

}