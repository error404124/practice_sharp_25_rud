namespace App;

public static class Program
{

    public static List<char> FindDuplicates(string text)
    {
        var answer = new List<char>();
        var dict = new Dictionary<char, int>();

        for (int i = 0; i < text.Length; i++)
        {
            dict.TryAdd(text[i], 0);
            dict[text[i]]++;
        }

        foreach (var pair in dict)
        {
            if (pair.Value > 1)
            {
                answer.Add(pair.Key);
            }
        }
        return answer;
    }
    
    public static void Main()
    {
        var answer = FindDuplicates("aabbqwecc");
        for (int i = 0; i < answer.Count; i++)
        {
            Console.WriteLine(answer[i]);
        }

    }
}