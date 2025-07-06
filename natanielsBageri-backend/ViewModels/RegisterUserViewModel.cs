using System.ComponentModel.DataAnnotations;

namespace mormorsBageri.ViewModels;

public class RegisterUserViewModel : LoginViewModel
{
    [Required(ErrorMessage = "Firstname is required")]
    public string FirstName { get; set; } = "";

    [Required(ErrorMessage = "Lastname is required")]
    public string LastName { get; set; } = "";
    
    [Required]
    public string ConfirmPassword { get; set; } = "";
}
