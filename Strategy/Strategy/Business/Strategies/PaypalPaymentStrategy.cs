using Strategy.Business.Models;

namespace Strategy.Business.Strategies;

public class PaypalPaymentStrategy(Customer customer) : IPaymentStrategy
{
    public void Pay(decimal orderValue)
    {
        Console.WriteLine("Payed with paypal");
        customer.OutstandingBalance -= orderValue;
    }
}
