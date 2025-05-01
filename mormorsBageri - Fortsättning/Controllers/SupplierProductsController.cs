using Microsoft.AspNetCore.Mvc;
using mormorsBageri.Entities;
using mormorsBageri.Entitites;
using mormorsBageri.Data;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace mormorsBageri;

[ApiController]
[Route("api/[controller]")]
public class SPController : ControllerBase
{
    private readonly DataContext _context;

    public SPController(DataContext context)
    {
        _context = context;
    }

    //http://localhost:5010/api/sp/list
    [HttpGet("list")] /* Visar Supplierproducts, alltså vilka Suppliers som har vilka Produkter inkl PRIS */
    public async Task<ActionResult> ListAllSP()
    {
      var sp = await _context.SupplierProducts
      .Select(sp => new{
        sp.SupplierId,
        sp.ProductId,
        sp.PricePerKg
      })
      .ToListAsync();
      return Ok(new { success = true, statusCode = 200, sp });
    }


    /* Skapa ENDPOINT som kan användas för att söka efter en råvara och
    returnerar json resultat som visar råvara + vilka leverantör
    som tillhandahåller prdukten :)*/

    // localhost:5010/api/SP/# 
    [HttpGet("{id}")]
    public async Task<ActionResult> Find(int id)
    {
        //var ids = await _context.SupplierProducts.SingleOrDefaultAsync();
        var ids = await _context.SupplierProducts
        .Where(p => p.ProductId == id)
        .Include(p => p.Product)
        .Include(p => p.Supplier)
        .Select(p => new{
            ProductName = p.Product.ArticleName,
            Supplier = new{
                p.SupplierId,
                p.Supplier.Name,
                p.Supplier.Phone
                },
                Price = p.PricePerKg
        }
        )
        .ToListAsync();
       
       if(ids.Count == 0){
        return NotFound(new {success=false,message=$"Produkten {id} finns inte!", id});
       }
       else{
        return Ok(new { success = true, statusCode = 200, ids  });
       }

   
    }
}
