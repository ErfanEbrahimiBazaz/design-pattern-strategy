# Strategy Pattern Implementation - Version 1

This folder contains the first implementation of the Strategy design pattern for payment processing.

## Overview

This implementation demonstrates a **tightly coupled** approach to the Strategy pattern, where payment strategies are directly instantiated and coupled to specific customers.

## Key Components

### Models
- **Customer**: Represents a customer with outstanding balance and payment strategy
- **Order**: Simple order with ID and value

### Strategies
- **IPaymentStrategy**: Interface defining the payment contract
- **CreditCardPaymentStrategy**: Implements credit card payment logic
- **PaypalPaymentStrategy**: Implements PayPal payment logic

## Architecture Characteristics

### Tight Coupling
- Payment strategies require a `Customer` parameter in their constructor
- Strategies directly modify the customer's outstanding balance
- Customer class includes a reference to `IPaymentStrategy`

### Usage Pattern
```csharp
Customer customer1 = new Customer(1, "Erfan Ebrahimi");
Order order1 = new Order(1, 50);
customer1.OutstandingBalance = order1.OrderValue;

var PaymentStrategy = new CreditCardPaymentStrategy(customer1);
PaymentStrategy.Pay(order1.OrderValue);
```

## Design Trade-offs

### Advantages
- Simple and direct implementation
- Payment strategies have direct access to customer data

### Disadvantages
- **High coupling**: Strategies are tightly bound to the Customer class
- **Limited flexibility**: Hard to reuse strategies across different contexts
- **Violation of Single Responsibility**: Strategies handle both payment logic and balance updates

## Notes

This is marked as "First implementation - tight coupling" in the Program.cs comments, indicating it's an initial approach that demonstrates the pattern but with room for improvement in terms of separation of concerns.
