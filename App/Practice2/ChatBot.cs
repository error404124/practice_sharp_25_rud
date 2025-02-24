namespace App.Practice2;

public class ChatBot
{
    static string[] ParseLine(string line)
    {
        var parts = line.Split(' ', 2);
        return parts;
    }

    public static string CalculateString(string[] codeLines)
    {
        if (codeLines.Length == 0)
        {
            return null;
        }

        var stack = new Stack<char>();
        foreach (var line in codeLines)
        {
            var commands = ParseLine(line);
            if (commands[0] == "push")
            {
                for (var i = 0; i < commands[1].Length; i++)
                {
                    stack.Push(commands[1][i]);
                }
            }

            else if (commands[0] == "pop")
            {
                var number = int.Parse(commands[1]);
                for (var i = 0; i < number; i++)
                {
                    stack.Pop();
                }
            }
        }

        stack.Pop();
        var answer = string.Join("", stack.Reverse());
        return answer;
    }
}