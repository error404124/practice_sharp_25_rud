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
            foreach (var symbol in word)
            {
                if (symbol >= '0' && symbol <= '9')
                {
                    statistics[symbol - '0']++;
                    break;
                }
            }
        }
        return statistics;
    }
}