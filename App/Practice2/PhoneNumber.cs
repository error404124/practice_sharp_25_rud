using System.Text;

namespace App.Practice2;

public class PhoneNumber
{
    public static bool TryParsePhone(string inputString, out string parsedPhone)
    {
        if (inputString == "")
        {
            parsedPhone = null;
            return false;
        }

        var phoneNumbers = new StringBuilder();
        foreach (var symbol in inputString)
        {
            if (char.IsDigit(symbol))
            {
                phoneNumbers.Append(symbol);
            }
        }

        if (phoneNumbers.Length != 11 || (phoneNumbers[0] != '8' && phoneNumbers[0] != '7'))
        {
            parsedPhone = null;
            return false;
        }


        parsedPhone = phoneNumbers.ToString();
        return true;
    }
}