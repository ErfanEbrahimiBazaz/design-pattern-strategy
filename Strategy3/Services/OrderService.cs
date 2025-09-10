using Strategy.Business.Models;
using Strategy.Business.Strategies.Payment;

namespace Strategy.Services;

// OrderService class is payment strategy context
public class OrderService
{
    private readonly IEnumerable<IPaymentStrategy> paymentStrategies;
    public OrderService( IEnumerable<IPaymentStrategy> paymentStrategies)
    {
        this.paymentStrategies = paymentStrategies;
    }
    public void Pay(Order order, string strategyName)
    {
        var paymentStrategy = paymentStrategies.FirstOrDefault(s => s.GetType().Name.Equals(strategyName, StringComparison.OrdinalIgnoreCase));
        if (paymentStrategy == null)
        {
            throw new InvalidOperationException($"Payment strategy '{strategyName}' not found!");
        }
        Console.WriteLine($"Paying customer {order.Customer.FullName} order {order.Id} with value {order.OrderValue} with {paymentStrategy.GetType().Name}");
        paymentStrategy.Pay(order.OrderValue);
        if (order.Customer != null)
        {
            order.Customer.OutstandingBalance -= order.OrderValue;
        }
    }
}
