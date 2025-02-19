namespace App.Practice2;

public class Requesite
{
    public static bool isValidInn(string inn)
    {
        if (inn.Length == 12)
        {
            int fisrt = 0;
            int second = 0;

            int[] innArrayFirst = { 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };
            int[] innArraySecond = { 3, 7, 2, 4, 10, 3, 5, 9, 4, 6, 8 };

            for (int i = 0; i < 10; i++)
            {
                fisrt += int.Parse(inn[i].ToString()) * innArrayFirst[i];
            }

            int tmpFirst = (fisrt % 11) % 10;

            if (tmpFirst == int.Parse(inn[10].ToString()))
            {
                for (int i = 0; i < 11; ++i)
                {
                    second += int.Parse(inn[i].ToString()) * innArraySecond[i];
                }

                int tmpSecond = second % 11 % 10;

                if (tmpSecond == int.Parse(inn[11].ToString()))
                {
                    return true;
                }
            }

            return false;
        }

        if (inn.Length == 10)
        {
            int[] innArray = { 2, 4, 10, 3, 5, 9, 4, 6, 8 };
            int sum = 0;

            for (int i = 0; i < 9; i++)
            {
                sum += int.Parse(inn[i].ToString()) * innArray[i];
            }

            int tmp = sum % 11 % 10;

            if (tmp == int.Parse(inn[9].ToString()))
            {
                return true;
            }

            return false;
        }

        return false;
    }
}