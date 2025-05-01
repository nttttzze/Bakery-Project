using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mormorsBageri.Entitites;
using mormorsBageri.Entities;


namespace mormorsBageri.Controllers;
[ApiController]
[Route("api/[controller]")]
public class ProductsController : ControllerBase
{
    private readonly DataContext _context;
    public ProductsController(DataContext context)
    {
        _context = context;
    }

    // -----------------------
    // Lägg till felhantering. 
    // -----------------------


    [HttpGet()] // Visa alla prdoukter.
    public async Task<ActionResult> ListAllProducts()
    {


        var p = await _context.Products
        .Select(p => new
        {
            p.Id,
            p.ArticleName,
            p.BestBeforeDate,
            p.ExpirationDate,
            p.PackageAmount,
            p.PricePerKg,
            p.QuantityPerPackage,
            p.Weight
        }
        )
        .ToListAsync();
        return Ok(new { success = true, products = p });
    }

    [HttpPost()] // Lägg till produkt.
    public async Task<ActionResult> AddProduct(ProductPostViewModel model)
    {
        try
        {

            var existingProduct = await _context.Products.FirstOrDefaultAsync(p => p.ArticleName == model.ArticleName) != null;

            if (existingProduct)
            {
                return Conflict(new { success = false, message = "Produkten finns redan. " });
            }

            var product = new Product
            {
                ArticleName = model.ArticleName,
                BestBeforeDate = model.BestBeforeDate,
                ExpirationDate = model.ExpirationDate,
                PackageAmount = model.PackageAmount,
                PricePerKg = model.PricePerKg,
                QuantityPerPackage = model.QuantityPerPackage,
                Weight = model.Weight
            };

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, data = product });

        }
        catch (Exception ex)
        {
            return StatusCode(500, new { success = false, message = ex.Message });
        }
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult> UpdateProductPrice(int id, [FromQuery] decimal pricePerKg)
    {
        var product = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);

        if (product == null)
        {
            return NotFound(new { success = false, message = $"Produkten med ID {id} finns ej. " });
        }

        product.PricePerKg = pricePerKg;

        await _context.SaveChangesAsync();

        return Ok(new { success = true, data = product });
    }
}
