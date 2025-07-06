using System.ComponentModel.DataAnnotations;

public class SupplierPostViewModel
{
    [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
    public string Name { get; set; }

    public string Address { get; set; }
    
    [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
    public string ContactPerson { get; set; }

    [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
    public string Phone { get; set; }
    public string Email { get; set; }
}
