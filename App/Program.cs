using System.Reflection.Metadata;
using App.Practice2;

namespace App;

public static class Extensions
{
    public static int WordCount(this string inputString)
    {
        if (string.IsNullOrEmpty(inputString))
        {
            return 0;
        }


        var words = inputString.Split(" ");

        return words.Length;
    }

    public static bool IsPalindrome(this string inputString)
    {
        if (string.IsNullOrEmpty(inputString))
        {
            return false;
        }

        var temStr = inputString.Replace(" ", "");
        for (var i = 0; i < temStr.Length / 2; i++)
        {
            if (temStr[i] != temStr[temStr.Length - 1 - i])
            {
                return false;
            }
        }

        return true;
    }

    public static string ToCustomString(this DateTime dateTime)
    {
        return dateTime.ToString("dd.MM.yyyy HH:mm:ss");
    }
}

public static class Program
{
    public static void Main()
    {
    }
}