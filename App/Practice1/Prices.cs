namespace App;

public static class Prices
{
    public static string GetCurrencyAlias(int price, bool isShorNotation, bool isFirstCapital)
    {
        string q;
        var lastDigit = price % 10;
        var lastTwoDigits = price % 100;

        q = isFirstCapital ? "Р" : "р";

        if (isShorNotation)
        {
            q += "уб.";
            return q;
        }

        if (lastTwoDigits >= 11 && lastTwoDigits <= 14)
        {
            q += "ублей";
        }
        else
        {
            switch (lastDigit)
            {
                case 1:
                    q += "убль";
                    break;
                case 2:
                case 3:
                case 4:
                    q += "убля";
                    break;
                default:
                    q += "ублей";
                    break;
            }
        }

        return q;
    }
}