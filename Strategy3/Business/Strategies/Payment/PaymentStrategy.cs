namespace Strategy.Business.Strategies.Payment;

public abstract class PaymentStrategy : IPaymentStrategy
{
    // Impelment common functionalities
    public abstract void Pay(decimal orderValue);
    
}
