namespace Strategy.Business.Strategies.Payment;

public interface IPaymentStrategy
{
    public void Pay(decimal orderValue);
}
