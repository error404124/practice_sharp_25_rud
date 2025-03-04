using System.Text;
using System.Text.RegularExpressions;

namespace App.Practice2;

public class NGram
{
    public static Dictionary<string, string> FrequencyAnalysis(string inputString)
    {
        var strBuilder = new StringBuilder(inputString.Length);
        foreach (var c in inputString.ToLower())
        {
            if (char.IsLetter(c) || c == ' ' || c == '.')
            {
                strBuilder.Append(c);
            }
        }

        var str = strBuilder.ToString();
        var dict = new Dictionary<string, string>(StringComparer.Ordinal);
        var parseInputString = str.Split('.', StringSplitOptions.RemoveEmptyEntries);
        var nGramsList = new List<string>();

        foreach (var parseInput in parseInputString)
        {
            var words = parseInput.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (var i = 0; i < words.Length - 1; i++)
            {
                if (i < words.Length - 2)
                {
                    nGramsList.Add($"{words[i]} {words[i + 1]} {words[i + 2]}");
                }

                if (i < words.Length - 1)
                {
                    nGramsList.Add($"{words[i]} {words[i + 1]}");
                }
            }
        }

        nGramsList.Sort();

        foreach (var nGram in nGramsList)
        {
            var words = nGram.Split(' ');
            if (words.Length == 2)
            {
                dict.TryAdd(words[0], words[1]);
            }

            if (words.Length == 3)
            {
                dict.TryAdd($"{words[0]} {words[1]}", words[2]);
            }
        }

        return dict;
    }
}