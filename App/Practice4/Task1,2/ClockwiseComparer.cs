namespace App.Practice_4;

public class ClockwiseComparer : IComparer<IVertex>
{
    private double CustomAtan2(IVertex vertex)
    {
        var angle = Math.Atan2(vertex.X, vertex.Y);
        if (angle < 0)
        {
            angle += 2 * Math.PI;
        }

        return angle;
    }

    public int Compare(IVertex v1, IVertex v2)
    {
        if (v1 == null || v2 == null)
        {
            throw new ArgumentNullException("Null values are not allowed");
        }

        var angle1 = CustomAtan2(v1);
        var angle2 = CustomAtan2(v2);


        if (angle1 < angle2) return 1;
        if (angle1 > angle2) return -1;

        if (Math.Abs(angle1 - angle2) < double.Epsilon)
        {
            var dist1 = v1.X * v1.X + v1.Y * v1.Y;
            var dist2 = v2.X * v2.X + v2.Y * v2.Y;
            return dist1.CompareTo(dist2);
        }

        return 0;
    }
}