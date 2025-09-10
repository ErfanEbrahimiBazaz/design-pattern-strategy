namespace Strategy.Business.Strategies.Payment;

public class PaypalPaymentStrategy() : IPaymentStrategy
{
    public void Pay(decimal orderValue)
    {
        Console.WriteLine("Payed with paypal");
        //customer.OutstandingBalance -= orderValue;
    }
}
