namespace Strategy.Business.Strategies;

public interface IPaymentStrategy
{
    public void Pay(Decimal orderValue);
}
