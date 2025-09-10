
using Strategy.Business.Models;
using Strategy.Business.Strategies.Payment;


Customer customer1 = new Customer(1, "Erfan Ebrahimi");
Order order1 = new Order(1, 50, customer1);
Console.WriteLine($"Customer outstanding balance before payment: {customer1.OutstandingBalance}");
order1.PaymentStrategy = new CreditCardPaymentStrategy();
order1.Pay();
Console.WriteLine($"Customer outstanding balance after payment: {customer1.OutstandingBalance}");


//Order order2 = new Order(1, 50, customer1, new PaypalPaymentStrategy());
//order2.Pay();
