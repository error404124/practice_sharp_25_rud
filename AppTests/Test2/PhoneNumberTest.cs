using App.Practice2;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;

namespace AppTests.Test2;

public class PhoneNumberTest
{
    [TestCase("+7-983-313-6827", null, true)]
    [TestCase("перезвонить по номеру 89833136827 завтра", null, true)]
    [TestCase("перез +234890 epfk;lwds", null, false)]
    [TestCase("8(983)-313-68-27", null, true)]
    
    public void TestPhoneNumber(string phoneNumber, out string parsedPhone, bool expected)
    {
        var actual = PhoneNumber.TryParsePhone(phoneNumber, out parsedPhone);
        Assert.That(actual, Is.EqualTo(expected));
    }
}