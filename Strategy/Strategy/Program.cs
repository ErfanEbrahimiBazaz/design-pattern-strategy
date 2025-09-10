
using Strategy.Business.Models;
using Strategy.Business.Strategies;

// First implementation - tight coupling
Customer customer1 = new Customer(1, "Erfan Ebrahimi");
Order order1 = new Order(1, 50);
customer1.OutstandingBalance = order1.OrderValue;
Console.WriteLine($"Customer deficit before payment is {customer1.OutstandingBalance.ToString()}");
var PaymentStrategy = new CreditCardPaymentStrategy(customer1);
PaymentStrategy.Pay(order1.OrderValue);
Console.WriteLine($"Customer deficit before payment is {customer1.OutstandingBalance.ToString()}");


// Second implementation - defining context for strategies
