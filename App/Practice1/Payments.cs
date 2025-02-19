namespace App;

public enum PaymentsPlan
{
    Differentiated,
    Annuity
}

public class Payments
{
    public static decimal CalculateTotalPayments(PaymentsPlan plan, decimal rate, int monthsCount, decimal amount)
    {
        var rate_month = rate / (12 * 100);

        if (rate == 0)
        {
            return amount;
        }

        if (plan == PaymentsPlan.Differentiated)
        {
            decimal total = 0;
            decimal P = amount / monthsCount;

            for (int month = 1; month <= monthsCount; month++)
            {
                total += P + (amount - P * (month - 1)) * rate_month;
            }

            return (int)total;
        }

        var payment_per_month = amount * rate_month * (decimal)Math.Pow(1 + (double)rate_month, monthsCount) /
                                ((decimal)Math.Pow(1 + (double)rate_month, monthsCount) - 1);

        return payment_per_month * monthsCount * 100 / 100;
    }
}