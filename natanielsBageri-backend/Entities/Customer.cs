
namespace mormorsBageri.Entities;

public class Customer
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Phone { get; set; }
    public string ContactPerson { get; set; }
    public string DeliveryAddress { get; set; }
    public string InvoiceAddress { get; set; }

    public List<Order> OrderHistory {get; set; } = new List<Order>();
}
