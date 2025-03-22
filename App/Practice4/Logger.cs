namespace App.Practice_4;

public class Logger
{
    public static string LogGeometry(IGeometry geometry)
    {
        switch (geometry)
        {
            case Square:
                return "Square";
            case Rectangle:
                return "Rectangle";
            case Triangle:
                return "Triangle";
            default: return "Unknown Geometry";
        }
    }
}