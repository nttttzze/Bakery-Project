using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;

public class ProductPostViewModel
{
    [Required(ErrorMessage = "Detta fält är obligatoriskt")]
    public string ArticleName { get; set; }
    public string BestBeforeDate { get; set; }
    public string ExpirationDate { get; set; }
    public int PackageAmount { get; set; }
    [Required(ErrorMessage = "Detta fält är obligatoriskt")]
    public decimal PricePerKg { get; set; }
    public int QuantityPerPackage { get; set; }
    public decimal Weight { get; set; }
}

