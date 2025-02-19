namespace App.Practice2;

public class Benford
{
    public static int[] GetBenfordStatistics(string text)
    {
        var statistics = new int[10];

        var words = text.Split(new char[] { ' ', '\t', '\n', '\r', ',', '.', ';', '!', '?' },
            StringSplitOptions.RemoveEmptyEntries);
        
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