

namespace mormorsBageri.Entities;

public class Product
{
    public int Id { get; set; }
    public string ArticleName { get; set; }
    public string BestBeforeDate { get; set; }
    public string ExpirationDate { get; set; }
    public int PackageAmount { get; set; }
    public decimal? PricePerKg { get; set; }
    public int QuantityPerPackage { get; set; }
    public decimal Weight { get; set; }

    public ICollection<SupplierProduct> SupplierProducts { get; set; }
}