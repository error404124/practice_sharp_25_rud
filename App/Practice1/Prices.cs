namespace App;

public static class Prices
{
    public static string GetCurrencyAlias(int price, bool isShorNotation, bool isFirstCapital)
    {
        string q;
        var lastDigit = price % 10;
        var lastTwoDigits = price % 100;

        if (lastTwoDigits >= 11 && lastTwoDigits <= 14)
            q = "рублей";

        else
        {
            switch (lastDigit)
            {
                case 1:
                    q = "рубль";
                    break;
                case 2:
                case 3:
                case 4:
                    q = "рубля";
                    break;
                default:
                    q = "рублей";
                    break;
            }
        }

        if (isShorNotation)
        {
            q = "руб.";
        }

        if (isFirstCapital)
        {
            q = char.ToUpper(q[0]) + q[1..];
        }

        return q;
    }
}