using System.Collections;
using mormorsBageri.Entities;

namespace mormorsBageri.Entitites;

public class Supplier
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    public string ContactPerson { get; set; }
    public string Phone { get; set; }
    public string Email { get; set; }

    public ICollection<SupplierProduct> SupplierProducts{ get; set; }
}
