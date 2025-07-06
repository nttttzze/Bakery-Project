using System.ComponentModel.DataAnnotations;

public class CustomerPostViewModel
{
    [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
    public string Name { get; set; }

    [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
    public string Phone { get; set; }

    [Required(ErrorMessage = "Detta fält är obligatoriskt.")]
    public string ContactPerson { get; set; }
    
    public string DeliveryAddress { get; set; }
    public string InvoiceAddress { get; set; }
}
