namespace App.Practice2;

public class PhoneNumber
{
    public static bool TryParsePhone(string inputString, out string parsedPhone)
    {
        int[] phoneNumbers = new int[11];
        var numberCounter = 0;
        for (int i = 0; i < inputString.Length; i++)
        {
            if (inputString[i] >= '0' && inputString[i] <= '9')
            {
                phoneNumbers[numberCounter] = inputString[i] - '0';
                numberCounter++;
            }
        }

        if (numberCounter != 11 && (phoneNumbers[0] != 8 || phoneNumbers[0] != 7))
        {
            parsedPhone = null;
            return false;
        }

        phoneNumbers[0] = 7;
        parsedPhone = "+7" + string.Join("", phoneNumbers);
        return true;
    }
}