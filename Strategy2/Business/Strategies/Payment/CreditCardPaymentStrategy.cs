namespace Strategy.Business.Strategies.Payment;

public class CreditCardPaymentStrategy() : IPaymentStrategy
{
    public void Pay(decimal orderValue)
    {
        Console.WriteLine("Paid with credit card");
        // API calls to the credit card provider.
        //customer.OutstandingBalance -= orderValue;
    }
}
