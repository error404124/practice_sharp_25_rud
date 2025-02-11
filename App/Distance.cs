namespace App;

public static class Distance
{
    public static double DistanceToSegment(
        // позиция курсора
        double x, double y,
        // отрезок
        double x1, double y1, double x2, double y2)
    {
        var AB_x = x2 - x1;
        var AB_y = y2 - y1;
        var AC_x = x - x1;
        var AC_y = y - y1;
        var BC_x = x - x2;
        var BC_y = y - y2;
        var AB_len = AB_x * AB_x + AB_y * AB_y;

        if (AB_len == 0)
        {
            return Math.Sqrt(AC_x * AC_x + AC_y * AC_y);
        }

        var scalar_product = AC_x * AB_x + AC_y * AB_y;
        var t = scalar_product / AB_len;

        if (t < 0)
        {
            return Math.Sqrt(AC_x * AC_x + AC_y * AC_y);
        }

        if (t > 1)
        {
            return Math.Sqrt(BC_x * BC_x + BC_y * BC_y);
        }

        var C_x = x1 + t * AB_x;
        var C_y = y1 + t * AB_y;
        var D_x = x - C_x;
        var D_y = y - C_y;
        return Math.Sqrt(D_x * D_x + D_y * D_y);
    }
}