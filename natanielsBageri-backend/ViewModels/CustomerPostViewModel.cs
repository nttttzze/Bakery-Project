using System.ComponentModel.DataAnnotations;

public class CustomerPostViewModel
{
    [StringLength(50, ErrorMessage = "Max 50 char")]
    [RegularExpression(@"^[a-öA-Ö\s]+$", ErrorMessage = "Only letters allowed.")]
    [Required(ErrorMessage = "This field is required.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    [RegularExpression(@"^[0-9\s\-\+]+$", ErrorMessage = "Only numbers, spaces, '+' and '-' are allowed.")]
    public string Phone { get; set; }
    [StringLength(50, ErrorMessage = "Max 50 char")]
    [Required(ErrorMessage = "This field is required.")]
    public string ContactPerson { get; set; }
    [StringLength(50, ErrorMessage = "Max 50 char")]
    public string DeliveryAddress { get; set; }
    [StringLength(50, ErrorMessage = "Max 50 char")]
    public string InvoiceAddress { get; set; }
}
