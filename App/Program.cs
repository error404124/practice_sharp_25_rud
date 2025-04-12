using System.Collections;
using System.Reflection.Metadata;
using App.Practice2;

namespace App;

// public static class Extensions
// {
//     public static int WordCount(this string inputString)
//     {
//         if (string.IsNullOrEmpty(inputString))
//         {
//             return 0;
//         }
//
//
//         var words = inputString.Split(" ");
//
//         return words.Length;
//     }
//
//     public static bool IsPalindrome(this string inputString)
//     {
//         if (string.IsNullOrEmpty(inputString))
//         {
//             return false;
//         }
//
//         var temStr = inputString.Replace(" ", "");
//         for (var i = 0; i < temStr.Length / 2; i++)
//         {
//             if (temStr[i] != temStr[temStr.Length - 1 - i])
//             {
//                 return false;
//             }
//         }
//
//         return true;
//     }
//
//     public static string ToCustomString(this DateTime dateTime)
//     {
//         return dateTime.ToString("dd.MM.yyyy HH:mm:ss");
//     }
// }

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

public class Calculator
{
    public enum OperationType
    {
        Add,
        Sub,
        Mul
    }

    public delegate int OperationDelegate(int a, int b);

    private static int Add(int a, int b)
    {
        return a + b;
    }

    private static int Sub(int a, int b)
    {
        return a - b;
    }

    private static int Mul(int a, int b)
    {
        return a * b;
    }

    public static OperationDelegate GetOperation(OperationType operationType)
    {
        switch (operationType)
        {
            case OperationType.Add:
                return Add;
            case OperationType.Sub:
                return Sub;
            case OperationType.Mul:
                return Mul;
            default:
                return null;
            
        }
    }
}


public static class Extensions
{
    public static int[] ToIntArray(this string inputString)
    {
        return inputString.Where(x => x <='9' && x >= '0').Select(x => (int)x).ToArray();
    }

    public static int ScalarDot(this int[] integers1, int[] integers2, int length)
    {
        return integers1.
            Take(length).
            Zip(integers2.Take(length), (a,b) => a * b ).
            Sum();
    }

    public static List<string> ArrayToList(this string inputString)
    {
         return string
             .Join(' ', inputString.Select(x => char.IsLetterOrDigit(x) ? x : ' '))
             .Split(' ')
             .ToList();
    }

    public static Dictionary<string, string> ArrayToDictionary(this string inputString)
    {
        return string
            .Join(' ', inputString.Select(x => char.IsLetterOrDigit(x) ? x : ' '))
            .Split(' ')
            .ToDictionary(x => x.First().ToString(), x => x.Last().ToString());
    }

    public static int UniqueSymbol(this string inputString)
    {
        return inputString.Select(x => x).ToHashSet().Count();
    }
    
}

public static class Program
{
    public static void Main()
    {

    }
}