# Strategy Design Pattern Implementation

This repository contains multiple implementations of the **Strategy Design Pattern** in C#, demonstrating the evolution from tightly coupled to well-architected solutions.

## What is the Strategy Pattern?

The Strategy pattern defines a family of algorithms, encapsulates each algorithm, and makes them interchangeable. It lets the algorithm vary independently from clients that use it.

## Project Structure

### 📁 Strategy (Version 1)
**Tightly Coupled Implementation**
- Direct constructor dependency between strategies and models
- Payment strategies are bound to Customer objects
- Demonstrates common pitfalls in strategy implementation

### 📁 Strategy2 (Version 2)  
**Loosely Coupled Implementation**
- Order class acts as Strategy Context
- Independent payment strategies
- Better separation of concerns and flexibility
- Demonstrates proper Strategy pattern implementation

### 📁 Strategy3 (Version 3)
**Dependency Injection Implementation** *(Advanced)*
- Uses Microsoft Dependency Injection
- Service-oriented architecture
- Enterprise-ready implementation

## Key Learning Points

### 🎯 Pattern Benefits Demonstrated
- **Algorithmic Flexibility**: Easy to swap payment methods
- **Open/Closed Principle**: Add new strategies without modifying existing code
- **Single Responsibility**: Each strategy handles one payment method
- **Runtime Strategy Selection**: Choose payment method dynamically

### 🔄 Evolution Highlights

**Version 1 → Version 2**
- ❌ **From**: Tight coupling between strategy and model
- ✅ **To**: Context-based strategy management
- ❌ **From**: Strategy modifying external state directly  
- ✅ **To**: Context coordinating state changes

**Version 2 → Version 3**
- ✅ **Added**: Dependency injection support
- ✅ **Added**: Service layer architecture
- ✅ **Added**: Enterprise patterns integration

## Core Components Across Versions

### Strategy Interface
```csharp
public interface IPaymentStrategy
{
    void Pay(decimal orderValue);
}
```

### Concrete Strategies
- **CreditCardPaymentStrategy**: Handles credit card payments
- **PaypalPaymentStrategy**: Handles PayPal payments

### Context Evolution
- **Version 1**: Customer holds strategy reference
- **Version 2**: Order acts as strategy context
- **Version 3**: Service layer manages strategy execution

## Design Pattern Concepts Demonstrated

1. **Strategy Interface**: Defines common algorithm interface
2. **Concrete Strategies**: Implement specific algorithms
3. **Context**: Maintains reference to strategy and delegates work
4. **Client**: Configures context with specific strategy

## When to Use Strategy Pattern

✅ **Good for:**
- Multiple ways to perform a task
- Runtime algorithm selection
- Avoiding conditional statements for algorithm selection
- Supporting Open/Closed Principle

❌ **Avoid when:**
- Only one algorithm exists
- Algorithms never change
- Simple conditional logic suffices

## Technologies Used

- **.NET 9.0**: Latest C# features and performance
- **Microsoft.Extensions.DependencyInjection**: For Version 3
- **Object-Oriented Design**: SOLID principles demonstration

---

*This project serves as a comprehensive example of how the Strategy pattern can be implemented and improved iteratively, showcasing both common mistakes and best practices.*
