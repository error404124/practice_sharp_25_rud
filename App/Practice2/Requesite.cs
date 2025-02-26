namespace App.Practice2;

public class Requesite
{
    private static int ScalarDot(string inn, int[] innArray)
    {
        var number = 0;

        for (var i = 0; i < innArray.Length; i++)
        {
            number += int.Parse(inn[i].ToString()) * innArray[i];
        }

        return (number % 11) % 10;
    }

    public static bool isValidInn(string inn)
    {
        if (inn.Length == 12)
        {
            int[] innArrayFirst = { 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
            int[] innArraySecond = { 3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };

            var firstNumber = ScalarDot(inn, innArrayFirst);
            if (firstNumber == int.Parse(inn[10].ToString()))
            {
                var secondNumber = ScalarDot(inn, innArraySecond);
                return secondNumber == int.Parse(inn[11].ToString());
            }

            return false;
        }

        if (inn.Length == 10)
        {
            int[] innArray = { 2, 4, 10, 3, 5, 9, 4, 6, 8 };
            var firstNumber = ScalarDot(inn, innArray);
            return firstNumber == int.Parse(inn[9].ToString());
        }

        return false;
    }
}