namespace App;

public static class Program
{
    public static void Main()
    {
  
        Console.WriteLine(Payments.CalculateTotalPayments(PaymentsPlan.Annuity, 7, 3, 10000));
    }
}