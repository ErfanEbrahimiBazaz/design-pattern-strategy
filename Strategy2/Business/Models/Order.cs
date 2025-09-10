using Strategy.Business.Strategies.Payment;
using System.Runtime.CompilerServices;

namespace Strategy.Business.Models;

public class Order
{
    public Order()
    {
        
    }
    public Order(int id, Decimal orderValue): base()
    {
        Id = id;
        OrderValue = orderValue;
    }

    public Order(int id, Decimal orderValue, Customer customer) : this(id, orderValue)
    {
        Customer = customer;
        Customer.OutstandingBalance = orderValue;
    }
    public Order(int id, Decimal orderValue, Customer customer, IPaymentStrategy paymentStrategy) : this(id, orderValue, customer)
    {
        PaymentStrategy = paymentStrategy;
    }
    public int Id { get; set; }
    public Decimal OrderValue { get; set; }
    
    //navigation property
    public Customer? Customer { get; set; }
    public int? CustomerId { get; set; }

    // Order class is payment strategy context
    public IPaymentStrategy PaymentStrategy { get; set; }
    public void Pay()
    {
        Console.WriteLine($"Paying customer {Customer.FullName} order {Id} with value {OrderValue} with {PaymentStrategy.GetType().Name}");
        PaymentStrategy.Pay(OrderValue);
        if (Customer != null)
        {
            Customer.OutstandingBalance -= OrderValue;
        }
    }
}
