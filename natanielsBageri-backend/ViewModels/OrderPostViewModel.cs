using System.ComponentModel.DataAnnotations;

public class OrderPostViewModel
{
    [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
    public int CustomerId { get; set; }
    [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
    public int ProductId { get; set; }
    [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
    public int Quantity { get; set; }
}