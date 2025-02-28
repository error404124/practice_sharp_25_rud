using System.Text.RegularExpressions;

namespace App.Practice2;

public class Benford
{
    public static int[] GetBenfordStatistics(string text)
    {
        if (string.IsNullOrEmpty(text))
        {
            return new int[10];
        }
        var statistics = new int[10];

        var words = Regex.Split(text, @"[^0-9a-zA-Z]+");

        foreach (var word in words)
        {
            if (word[0] >= '0' && word[0] <= '9')
            {
                statistics[word[0] - '0']++;
            }
        }

        return statistics;
    }
}