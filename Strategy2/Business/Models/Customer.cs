namespace Strategy.Business.Models;

public class Customer
{

    public Customer(int id, string fullName)
    {
        Id = id;
        FullName = fullName;
    }
    public int Id { get; set; }
    public string FullName { get; set; }
    public Decimal OutstandingBalance { get; set; }
    public IEnumerable<Order>? Orders{ get; set; }
}
