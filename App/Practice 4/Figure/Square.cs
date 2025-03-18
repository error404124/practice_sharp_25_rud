namespace App.Practice_4;

public class Square : Rectangle
{
    IVertex TopRight { get; set; }
    IVertex TopLeft { get; set; }
    IVertex UnderRight { get; set; }
    IVertex UnderLeft { get; set; }

    public Square(IVertex topRight, IVertex topLeft, IVertex underRight, IVertex underLeft) : base(topRight, topLeft,
        underRight, underLeft)
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