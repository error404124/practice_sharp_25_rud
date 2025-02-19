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
        var rateMonth = rate / (12 * 100);

        if (rate == 0)
        {
            return amount;
        }

        if (plan == PaymentsPlan.Differentiated)
        {
            decimal total = 0;
            var p = amount / monthsCount;

            for (int month = 1; month <= monthsCount; month++)
            {
                total += p + (amount - p * (month - 1)) * rateMonth;
            }

            return total;
        }

        var paymentPerMonth = amount * rateMonth * (decimal)Math.Pow(1 + (double)rateMonth, monthsCount) /
                                ((decimal)Math.Pow(1 + (double)rateMonth, monthsCount) - 1);

        return paymentPerMonth * monthsCount;
    }
}