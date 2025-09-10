# Strategy Pattern Implementation - Version 2

This folder contains an improved implementation of the Strategy design pattern that addresses the coupling issues from Version 1.

## Overview

This implementation demonstrates a **loosely coupled** approach where the Order class serves as the context for payment strategies, providing better separation of concerns and flexibility.

## Key Components

### Models
- **Customer**: Clean model focused only on customer data (ID, name, balance, orders collection)
- **Order**: Enhanced order class that acts as the **Strategy Context**

### Strategies
- **IPaymentStrategy**: Interface defining the payment contract
- **PaymentStrategy**: Abstract base class for common functionality
- **CreditCardPaymentStrategy**: Credit card payment implementation
- **PaypalPaymentStrategy**: PayPal payment implementation

## Architecture Improvements

### Loose Coupling
- Payment strategies are **independent** and don't require Customer in constructor
- Order class acts as the **Context** that manages strategy execution
- Clear separation between payment processing and balance management

### Context Pattern Implementation
The `Order` class serves as the Strategy Context:
- Holds reference to the payment strategy
- Provides multiple constructor overloads for flexibility
- Manages the payment workflow through the `Pay()` method

### Enhanced Constructors
```csharp
// Basic order
Order(int id, decimal orderValue)

// Order with customer
Order(int id, decimal orderValue, Customer customer)

// Order with customer and strategy
Order(int id, decimal orderValue, Customer customer, IPaymentStrategy paymentStrategy)
```

## Usage Pattern

```csharp
Customer customer1 = new Customer(1, "Erfan Ebrahimi");
Order order1 = new Order(1, 50, customer1);
order1.PaymentStrategy = new CreditCardPaymentStrategy();
order1.Pay();
```

## Design Benefits

### Advantages
- **Loose coupling**: Strategies are independent of specific models
- **Better separation of concerns**: Payment logic separated from balance management
- **Flexible context**: Order manages the strategy execution
- **Extensible**: Easy to add new payment methods
- **Reusable**: Strategies can be used across different contexts

### Key Improvements over Version 1
- ✅ Removed constructor dependency on Customer
- ✅ Context-based strategy execution
- ✅ Cleaner responsibility separation
- ✅ More flexible object construction
- ✅ Better adherence to SOLID principles

## Strategy Context Flow
1. Order is created with customer and value
2. Payment strategy is assigned (either via constructor or property)
3. `Pay()` method coordinates the payment process
4. Strategy handles payment logic
5. Context manages balance updates

This implementation better demonstrates the Strategy pattern's intent: defining a family of algorithms, encapsulating each one, and making them interchangeable.
