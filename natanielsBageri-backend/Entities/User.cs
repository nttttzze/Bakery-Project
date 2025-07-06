
using Microsoft.AspNetCore.Identity;

namespace mormorsBageri.Entities;

public class User : IdentityUser
{
    public string FirstName { get; set; } = "";
    public string LastName { get; set; } = "";
}
