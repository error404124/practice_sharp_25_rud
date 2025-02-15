using App;

namespace AppTests;

public class PaymentsTests
{
    [TestCase(PaymentsPlan.Annuity, 10, 10, 500, 523)]
    [TestCase(PaymentsPlan.Annuity, 7, 3, 10000, 10116)]
    [TestCase(PaymentsPlan.Differentiated, 3, 5, 200000, 201500)]
    [TestCase(PaymentsPlan.Differentiated, 10, 2, 500, 506)]
    public void TestPasses_When_Result_Correct(PaymentsPlan plan, decimal rate, int monthsCount, decimal amount, decimal expected)
    {
        var actual = Payments.CalculateTotalPayments(plan, rate, monthsCount, amount);
        Assert.That(actual, Is.EqualTo(expected));
    }
}