namespace App.Practice2;

public class Requesite
{
    private static int ScalarDot(string inn, string numberName)
    {
        var number = 0;

        if (inn.Length == 10)
        {
            int[] innArray = { 2, 4, 10, 3, 5, 9, 4, 6, 8 };
            for (var i = 0; i < 9; i++)
            {
                number += int.Parse(inn[i].ToString()) * innArray[i];
            }
        }

        else if (numberName == "first")
        {
            int[] innArrayFirst = { 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
            for (var i = 0; i < 10; ++i)
            {
                number += int.Parse(inn[i].ToString()) * innArrayFirst[i];
            }
        }

        else if (numberName == "second")
        {
            int[] innArraySecond = { 3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
            for (var i = 0; i < 11; ++i)
            {
                number += int.Parse(inn[i].ToString()) * innArraySecond[i];
            }
        }

        return (number % 11) % 10;
    }

    public static bool isValidInn(string inn)
    {
        if (inn.Length == 12)
        {
            var firstNumber = ScalarDot(inn, "first");
            if (firstNumber == int.Parse(inn[10].ToString()))
            {
                var secondNumber = ScalarDot(inn, "second");
                if (secondNumber == int.Parse(inn[11].ToString()))
                {
                    return true;
                }
            }

            return false;
        }

        if (inn.Length == 10)
        {
            var firstNumber = ScalarDot(inn, null);
            if (firstNumber == int.Parse(inn[9].ToString()))
            {
                return true;
            }

            return false;
        }

        return false;
    }
}