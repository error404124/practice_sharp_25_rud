namespace App;

public static class Distance
{
    public static double DistanceToSegment(
        // позиция курсора
        double x, double y,
        // отрезок
        double x1, double y1, double x2, double y2)
    {
        var abX = x2 - x1;
        var abY = y2 - y1;
        var acX = x - x1;
        var acY = y - y1;
        var bcX = x - x2;
        var bcY = y - y2;
        var abLen = abX * abX + abY * abY;

        if (abLen == 0)
        {
            return Math.Sqrt(acX * acX + acY * acY);
        }

        var scalarProduct = acX * abX + acY * abY;
        var t = scalarProduct / abLen;

        if (t < 0)
        {
            return Math.Sqrt(acX * acX + acY * acY);
        }

        if (t > 1)
        {
            return Math.Sqrt(bcX * bcX + bcY * bcY);
        }

        var cX = x1 + t * abX;
        var cY = y1 + t * abY;
        var dX = x - cX;
        var dY = y - cY;
        return Math.Sqrt(dX * dX + dY * dY);
    }
}