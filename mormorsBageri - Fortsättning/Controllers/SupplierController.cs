using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using mormorsBageri.Entitites;
using mormorsBageri.Entities;
using Microsoft.EntityFrameworkCore;

namespace mormorsBageri.Controllers;
[ApiController]
[Route("api/[controller]")]
public class SupplierController : ControllerBase
{
    private readonly DataContext _context;

    public SupplierController(DataContext context)
    {
        _context = context;
    }

    // Skapa en endpoint metod som kan användas
    // för att söka efter en leverantör och få dess produkter listade med pris och övrig
    // information om produkten.

    // http://localhost:5010/api/Supplier/#  /* Verkar inte fungera :( */
    [HttpGet("{id}")]
    public async Task<ActionResult> FindSupplier(int id)
    {
        var sup = await _context.SupplierProducts
        .Where(s => s.SupplierId == id)
        .Include(s => s.Supplier)
        .Include(s => s.Product)
        .Select(s => new{
            SupplierName = s.Supplier.Name,
            Product = s.Supplier.SupplierProducts 
            .Select(p => new{
                ProductId = s.Product.Id,
                Productname = s.Product.ArticleName,
                s.Product.PricePerKg
            })}
        ).FirstOrDefaultAsync();

        return Ok(new { success = true, statusCode = 200, sup  });

    }

    [HttpPost()] // La till denna för att se om den fungerade medan Product POST inte fungerade. DEnna fungerar dock.???
    public async Task<ActionResult> AddSupplier(SupplierPostViewModel model)
    {
  
        var supplier = new Supplier
        {
            Name = model.Name,
            Address = model.Address,
            ContactPerson = model.ContactPerson,
            Phone = model.Phone,
            Email = model.Email
        };

        await _context.Suppliers.AddAsync(supplier);
        await _context.SaveChangesAsync();

        return Ok(new { success = true, data = supplier });
    }


    // Behövde lägga till denna för nya inlämningen.
    [HttpGet()]
    public async Task<ActionResult> ListAllSuppliers()
    {
        var p = await _context.Suppliers
        .Select(p => new{
            p.Name,
            p.Address,
            p.Phone,
            p.Email
        }
        )
        .ToListAsync();
        return Ok(new{ success = true, p});
    }

    

}
