using System.ComponentModel.DataAnnotations;

public class OrderPostViewModel
{
    [Required(ErrorMessage = "CustomerId is required.")]

    [Range(1, int.MaxValue, ErrorMessage = "Invalid CustomerId")]
    public int CustomerId { get; set; }
    [Required(ErrorMessage = "Detta fält är obligatoriskt.")]


    [Range(1, int.MaxValue, ErrorMessage = "Invalid ProductId")]

    public int ProductId { get; set; }
    [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
    [Range(1, 1000, ErrorMessage = "Quantity must be between 1-1000.")]

    public int Quantity { get; set; }
}