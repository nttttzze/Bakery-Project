using System.ComponentModel.DataAnnotations;

namespace mormorsBageri.ViewModels;

public class RegisterUserViewModel : LoginViewModel
{
    [StringLength(50, ErrorMessage = "Max 50 char")]
    [RegularExpression(@"^[a-öA-Ö\s]+$", ErrorMessage = "Only letters allowed.")]
    [Required(ErrorMessage = "Firstname is required")]
    public string FirstName { get; set; } = "";
    [StringLength(50, ErrorMessage = "Max 50 char")]
    [RegularExpression(@"^[a-öA-Ö\s]+$", ErrorMessage = "Only letters allowed.")]
    [Required(ErrorMessage = "Lastname is required")]
    public string LastName { get; set; } = "";

    [Required]
    [Compare("Password", ErrorMessage = "Paswords do not match.")]
    public string ConfirmPassword { get; set; } = "";
}
