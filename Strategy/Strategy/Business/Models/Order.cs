namespace Strategy.Business.Models;

public class Order
{
    public Order()
    {
        
    }
    public Order(int id, Decimal orderValue): base()
    {
        Id = id;
        OrderValue = orderValue;
    }
    public int Id { get; set; }
    public Decimal OrderValue { get; set; }
    public Customer? Customer { get; set; }
    public int? CustomerId { get; set; }
}
