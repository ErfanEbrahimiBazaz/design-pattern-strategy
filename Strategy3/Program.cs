
using Microsoft.Extensions.DependencyInjection;
using Strategy;
using Strategy.Business.Models;
using Strategy.Business.Strategies.Payment;
using Strategy.Services;


// solution 1 - manual dependency injection (constructor injection)
//Customer customer1 = new Customer(1, "Erfan Ebrahimi");
//Order order1 = new Order(1, 50, customer1);
//IPaymentStrategy paymentStrategy = new CreditCardPaymentStrategy();
//OrderService orderService = new OrderService(order1, paymentStrategy);

//Console.WriteLine($"Customer outstanding balance before payment: {customer1.OutstandingBalance}");
//orderService.Pay();
//Console.WriteLine($"Customer outstanding balance after payment: {customer1.OutstandingBalance}");


// solution 2 - built in .Net DI (Microsoft.Extensions.DependencyInjection)
IServiceCollection services = new ServiceCollection();
services.AddDependencies();
var provider = services.BuildServiceProvider();

Customer customer1 = new Customer(1, "Erfan Ebrahimi");
Order order1 = new Order(1, 50, customer1);
Console.WriteLine($"Customer outstanding balance before payment: {customer1.OutstandingBalance}");
OrderService orderService = provider.GetRequiredService<OrderService>();
orderService.Pay(order1, "PaypalPaymentStrategy");
Console.WriteLine($"Customer outstanding balance after payment: {customer1.OutstandingBalance}");