using Strategy.Business.Models;

namespace Strategy.Business.Strategies;

public class CreditCardPaymentStrategy(Customer customer) : IPaymentStrategy
{
    public void Pay(decimal orderValue)
    {
        Console.WriteLine("Paid with credit card");
        customer.OutstandingBalance -= orderValue;
    }
}
