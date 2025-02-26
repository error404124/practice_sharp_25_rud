using System.Text;
using System.Text.RegularExpressions;

namespace App.Practice2;

public class NGram
{
    public static Dictionary<string, string> FrequencyAnalysis(string inputString)
    {
        var strBuilder = new StringBuilder(inputString.Length);
        foreach (var c in inputString)
        {
            if (char.IsLetter(c) || c == '.')
            {
                strBuilder.Append(c);
            }
        }
        var str = strBuilder.ToString();
        var dict = new Dictionary<string, string>(StringComparer.Ordinal);
        var parseInputString = str.Split('.', StringSplitOptions.RemoveEmptyEntries);

        foreach (var parseInput in parseInputString)
        {
            for (var i = 0; i < parseInput.Length - 1; i++)
            {
                if (i < parseInput.Length - 2)
                {
                    dict.TryAdd($"{parseInput[i]} {parseInput[i + 1]}", $"{parseInput[i + 2]}");
                }

                if (i < parseInput.Length - 1)
                {
                    dict.TryAdd($"{parseInput[i]}", $"{parseInput[i + 1]}");
                }
            }
        }
        
        return dict;
    }
}