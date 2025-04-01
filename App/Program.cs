using System.Collections;
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

public class CustomClass
{
    public IEnumerable<int> Odd()
    {
        var i = 0;
        while (true)
        {
            i++;
            if (i % 2 != 0)
            {
                yield return i;
            }
        }
    }

    public IEnumerable<int> Even()
    {
        var i = 0;
        while (true)
        {
            i++;
            if (i % 2 == 0)
            {
                yield return i;
            }
        }
    }
}

public static class StringExtensions
{
    public static IEnumerable<string> ToUpper(this IEnumerable<string> inputString)
    {
        foreach (var s in inputString)
        {
            yield return s.ToUpper();
        }   
    }

    public static IEnumerable<string> AppendToEnd(this IEnumerable<string> inputString, string postfix)
    {
        foreach (var s in inputString)
        {
            yield return s + postfix;
        }
    }

    public static IEnumerable<string> Reverse(this IEnumerable<string> inputString)
    {
        var reversed = new List<string>(inputString);
        var length = reversed.Count;
        for (var i = 0; i < length; i++)
        {
            yield return reversed[length - i - 1];
        }
    }
}

public static class Program
{
    public static void Main()
    {
        var c = new CustomClass();
        foreach (var i in c.Even())
        {
            Console.WriteLine(i);
        }
    }
}