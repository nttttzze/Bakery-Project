
namespace mormorsBageri.Entities;

public class Order
{
    public int Id { get; set; }
    public string OrderDate { get; set; }
    public int CustomerId { get; set; }
    public Customer Customer { get; set; }
    public int ProductId { get; set; }
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal PriceTotal { get; set; }
}
