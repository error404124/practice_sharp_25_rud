namespace App.Practice2;

public class NGram
{
    public static Dictionary<string, string> FrequencyAnalysis(string inputString)
    {
        inputString = inputString.Replace(" ", "");
        var dict = new Dictionary<string, string>(StringComparer.Ordinal);
        var parseInputString = inputString.Split('.', StringSplitOptions.RemoveEmptyEntries);

        foreach (var parseInput in parseInputString)
        {
            for (int i = 0; i < parseInput.Length - 1; i++)
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