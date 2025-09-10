namespace Strategy.Business.Models;

public class Order
{
    public Order(int id, Decimal orderValue, Customer customer)
    {
        Id = id;
        OrderValue = orderValue;
        Customer = customer;
        Customer.OutstandingBalance = orderValue;
    }

    public int Id { get; set; }
    public Decimal OrderValue { get; set; }
    public Customer? Customer { get; set; }
    public int? CustomerId { get; set; }

}
