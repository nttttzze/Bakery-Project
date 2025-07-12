using System.ComponentModel.DataAnnotations;

public class SupplierPostViewModel
{
    [StringLength(50, ErrorMessage = "Max 50 char")]
    [RegularExpression(@"^[a-öA-Ö\s]+$", ErrorMessage = "Only letters allowed.")]
    [Required(ErrorMessage = "This field is required.")]
    public string Name { get; set; }
    [StringLength(50, ErrorMessage = "Max 50 char")]
    [RegularExpression(@"^[a-öA-Ö0-9\s]+$", ErrorMessage = "Only numbers and letters allowed.")]
    public string Address { get; set; }
    [StringLength(50, ErrorMessage = "Max 50 char")]
    [RegularExpression(@"^[a-öA-Ö\s]+$", ErrorMessage = "Only letters allowed.")]
    [Required(ErrorMessage = "This field is required.")]
    public string ContactPerson { get; set; }

    [Required(ErrorMessage = "This field is required.")]
    [RegularExpression(@"^[0-9\s\-\+]+$", ErrorMessage = "Only numbers, spaces, '+' and '-' are allowed.")]
    [StringLength(50, ErrorMessage = "Max 50 char")]
    public string Phone { get; set; }
    [EmailAddress(ErrorMessage = "Invalid Email.")]
    [StringLength(50, ErrorMessage = "Max 50 char")]
    public string Email { get; set; }
}



