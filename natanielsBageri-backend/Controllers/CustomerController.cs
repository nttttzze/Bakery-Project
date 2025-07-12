using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mormorsBageri.Entities;
using mormorsBageri.Entitites;

namespace mormorsBageri.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CustomerController : ControllerBase
{
    private readonly DataContext _context;
    public CustomerController(DataContext context)
    {
        _context = context;
    }

    [Authorize]
    [HttpPost()]
    public async Task<ActionResult> AddCustomer(CustomerPostViewModel model)
    {
        var sanitizer = new HtmlSanitizer();
        try
        {

            var existingCustomer = await _context.Customers.FirstOrDefaultAsync(c => c.Name == model.Name) != null;

            if (existingCustomer)
            {
                return Conflict(new { success = false, message = "Kunden finns redan. " });
            }


            var customer = new Customer
            {
                Name = sanitizer.Sanitize(model.Name),
                Phone = model.Phone,
                ContactPerson = sanitizer.Sanitize(model.ContactPerson),
                DeliveryAddress = sanitizer.Sanitize(model.DeliveryAddress),
                InvoiceAddress = sanitizer.Sanitize(model.InvoiceAddress)
            };

            await _context.Customers.AddAsync(customer);
            await _context.SaveChangesAsync();

            return Ok(new { success = true, data = customer });

        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpGet()]
    public async Task<ActionResult> ListCustomers()
    {
        try
        {
            var c = await _context.Customers
            .Select(c => new
            {
                c.Id,
                c.Name,
                c.Phone,
                c.ContactPerson,
                c.DeliveryAddress,
                c.InvoiceAddress
            }).ToListAsync();
            return Ok(new { success = true, c });
        }
        catch (Exception)
        {
            return StatusCode(500, new { success = false, message = "Ett fel uppstod." });
        }
    }

    [HttpGet("{id}")]
    public async Task<ActionResult> GetCustomer(int id)
    {
        try
        {
            var c = await _context.Customers
            .Include(c => c.OrderHistory)
            .Where(c => c.Id == id)
            .Select(c => new
            {
                c.Id,
                c.Name,
                c.Phone,
                c.ContactPerson,
                c.DeliveryAddress,
                c.InvoiceAddress,
                OrderHistory = c.OrderHistory.Select(o => new
                {
                    o.Id,
                    o.OrderDate,
                    o.Customer,
                    o.ProductId,
                    o.Product,
                    o.Quantity,
                    o.Price,
                    o.PriceTotal
                }).ToList()
            }).FirstOrDefaultAsync();

            if (c is null)
            {
                return NotFound(new { success = false, message = "Kunden hittades inte." });
            }

            return Ok(new { success = true, c });
        }
        catch (Exception)
        {
            return StatusCode(500, new { success = false, message = "Ett fel uppstod." });
        }
    }
}
