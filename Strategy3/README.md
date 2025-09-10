# Strategy Design Pattern Implementation

This project demonstrates the implementation of the Strategy design pattern in C# using a payment processing system. The Strategy pattern allows you to define a family of algorithms, encapsulate each one, and make them interchangeable at runtime.

## Overview

The Strategy pattern is a behavioral design pattern that enables selecting algorithms at runtime. Instead of implementing a single algorithm directly, code receives run-time instructions as to which in a family of algorithms to use.

## Project Structure

```
Strategy/
├── Business/
│   ├── Models/
│   │   ├── Customer.cs
│   │   └── Order.cs
│   └── Strategies/
│       └── Payment/
│           ├── IPaymentStrategy.cs
│           ├── CreditCardPaymentStrategy.cs
│           └── PaypalPaymentStrategy.cs
├── Services/
│   └── OrderService.cs
├── DependencyExtensions.cs
└── Program.cs
```

## Core Components

### 1. Strategy Interface (`IPaymentStrategy`)

The strategy interface defines the contract that all concrete strategies must implement:

```csharp
public interface IPaymentStrategy
{
    void ProcessPayment(Order order);
}
```

### 2. Concrete Strategies

#### Credit Card Payment Strategy
```csharp
public class CreditCardPaymentStrategy : IPaymentStrategy
{
    public void ProcessPayment(Order order)
    {
        // Credit card payment logic
        order.Customer.OutstandingBalance -= order.Amount;
        Console.WriteLine($"Paid ${order.Amount} using Credit Card");
    }
}
```

#### PayPal Payment Strategy
```csharp
public class PaypalPaymentStrategy : IPaymentStrategy
{
    public void ProcessPayment(Order order)
    {
        // PayPal payment logic
        order.Customer.OutstandingBalance -= order.Amount;
        Console.WriteLine($"Paid ${order.Amount} using PayPal");
    }
}
```

### 3. Context (`OrderService`)

The context class uses a strategy to perform operations. It maintains a reference to a strategy object and delegates the algorithm execution to it:

```csharp
public class OrderService
{
    private readonly IEnumerable<IPaymentStrategy> paymentStrategies;
    
    public OrderService(IEnumerable<IPaymentStrategy> paymentStrategies)
    {
        this.paymentStrategies = paymentStrategies;
    }
    
    public void Pay(Order order, string strategyName)
    {
        var strategy = paymentStrategies.FirstOrDefault(s => 
            s.GetType().Name.Contains(strategyName));
        
        if (strategy != null)
        {
            strategy.ProcessPayment(order);
        }
    }
}
```

### 4. Domain Models

#### Customer Model
```csharp
public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public decimal OutstandingBalance { get; set; }
    
    public Customer(int id, string name)
    {
        Id = id;
        Name = name;
        OutstandingBalance = 100; // Default balance
    }
}
```

#### Order Model
```csharp
public class Order
{
    public int Id { get; set; }
    public decimal Amount { get; set; }
    public Customer Customer { get; set; }
    
    public Order(int id, decimal amount, Customer customer)
    {
        Id = id;
        Amount = amount;
        Customer = customer;
    }
}
```

## Benefits of the Strategy Pattern

1. **Open/Closed Principle**: Open for extension (new payment methods) but closed for modification
2. **Single Responsibility Principle**: Each strategy handles one specific algorithm
3. **Runtime Algorithm Selection**: Strategies can be changed at runtime
4. **Code Reusability**: Strategies can be reused across different contexts
5. **Testability**: Each strategy can be tested independently

## Usage Examples

### Manual Dependency Injection
```csharp
Customer customer = new Customer(1, "John Doe");
Order order = new Order(1, 50, customer);
IPaymentStrategy paymentStrategy = new CreditCardPaymentStrategy();
OrderService orderService = new OrderService(new[] { paymentStrategy });

orderService.Pay(order, "CreditCard");
```

### Using Built-in .NET Dependency Injection
```csharp
IServiceCollection services = new ServiceCollection();
services.AddDependencies();
var provider = services.BuildServiceProvider();

Customer customer = new Customer(1, "John Doe");
Order order = new Order(1, 50, customer);
OrderService orderService = provider.GetRequiredService<OrderService>();

orderService.Pay(order, "CreditCard");
```

## When to Use Strategy Pattern

- When you have multiple ways to perform a task
- When you want to avoid conditional statements for algorithm selection
- When algorithms should be interchangeable at runtime
- When you want to isolate the implementation details of algorithms

## Dependency Injection in Strategy Pattern

Dependency Injection (DI) enhances the Strategy pattern by providing automatic management of strategy instances and their dependencies. This section explains how DI integrates with the Strategy pattern in this implementation.

### DI Configuration

The `DependencyExtensions` class configures the DI container:

```csharp
public static class DependencyExtensions
{
    public static IServiceCollection AddDependencies(this IServiceCollection services)
    {
        services.AddScoped<OrderService>();
        services.AddScoped<IPaymentStrategy, CreditCardPaymentStrategy>();
        services.AddScoped<IPaymentStrategy, PaypalPaymentStrategy>();
        return services;
    }
}
```

### Benefits of DI with Strategy Pattern

#### 1. **Automatic Strategy Collection**
The DI container automatically injects all registered `IPaymentStrategy` implementations into the `OrderService`:

```csharp
public class OrderService
{
    private readonly IEnumerable<IPaymentStrategy> paymentStrategies;
    
    // DI container automatically provides all registered IPaymentStrategy instances
    public OrderService(IEnumerable<IPaymentStrategy> paymentStrategies)
    {
        this.paymentStrategies = paymentStrategies;
    }
}
```

#### 2. **Lifecycle Management**
- **Scoped**: Each request gets the same instance within its scope
- **Transient**: New instance created each time
- **Singleton**: Single instance throughout application lifetime

#### 3. **Easy Extension**
Adding new payment strategies requires only registering them in the DI container:

```csharp
services.AddScoped<IPaymentStrategy, ApplePayStrategy>();
services.AddScoped<IPaymentStrategy, GooglePayStrategy>();
```

#### 4. **Dependency Resolution**
If strategies have their own dependencies, DI handles the entire dependency graph:

```csharp
public class CreditCardPaymentStrategy : IPaymentStrategy
{
    private readonly ICreditCardValidator validator;
    private readonly ILogger<CreditCardPaymentStrategy> logger;
    
    // DI automatically injects these dependencies
    public CreditCardPaymentStrategy(
        ICreditCardValidator validator,
        ILogger<CreditCardPaymentStrategy> logger)
    {
        this.validator = validator;
        this.logger = logger;
    }
}
```

### Design Considerations

#### 1. **Service vs. Data Separation**
- **Services** (like `OrderService`) should be registered in DI
- **Data objects** (like `Order`, `Customer`) should be passed as method parameters
- This maintains proper separation of concerns and avoids DI container becoming a service locator

#### 2. **Strategy Selection**
The current implementation uses string-based strategy selection:

```csharp
public void Pay(Order order, string strategyName)
{
    var strategy = paymentStrategies.FirstOrDefault(s => 
        s.GetType().Name.Contains(strategyName));
    // ...
}
```

**Alternative approaches:**
- **Factory Pattern**: Create a strategy factory service
- **Enum-based**: Use enums for strategy identification
- **Attribute-based**: Use attributes to mark and identify strategies

#### 3. **Configuration-Driven Strategy Selection**
For more sophisticated scenarios, consider configuration-driven strategy selection:

```csharp
public class PaymentConfiguration
{
    public string DefaultPaymentMethod { get; set; }
    public Dictionary<string, string> PaymentMethods { get; set; }
}

public class OrderService
{
    private readonly IEnumerable<IPaymentStrategy> paymentStrategies;
    private readonly IOptions<PaymentConfiguration> config;
    
    public OrderService(
        IEnumerable<IPaymentStrategy> paymentStrategies,
        IOptions<PaymentConfiguration> config)
    {
        this.paymentStrategies = paymentStrategies;
        this.config = config;
    }
}
```

### Best Practices

1. **Register strategies, not data**: Only register services and strategies in DI, not domain models
2. **Use appropriate lifetimes**: Most strategies can be scoped or transient
3. **Favor composition over inheritance**: DI encourages composition-based design
4. **Keep strategies stateless**: Stateless strategies are safer and more reusable
5. **Test with DI**: Use DI in tests for better isolation and mocking

The combination of Strategy pattern and Dependency Injection provides a powerful, flexible, and maintainable approach to algorithm selection and management in .NET applications.