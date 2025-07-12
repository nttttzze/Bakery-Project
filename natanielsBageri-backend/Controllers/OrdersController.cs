using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Ganss.Xss;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using mormorsBageri.Entities;
using mormorsBageri.Entitites;

namespace mormorsBageri.Controllers;

[ApiController]
[Route("api/[controller]")]
public class OrdersController : ControllerBase
{
    private readonly DataContext _context;
    public OrdersController(DataContext context)
    {
        _context = context;
    }

    [Authorize]
    [HttpPost()]
    public async Task<ActionResult> AddOrder(OrderPostViewModel model)
    {
        var product = await _context.Products.FindAsync(model.ProductId);
        if (product is null)
        {
            return NotFound(new { success = false, message = $"Produkten hittades inte. " });
        }

        var customer = await _context.Customers.FindAsync(model.CustomerId);
        if (customer is null)
        {
            return NotFound(new { success = false, message = $"Kunden hittades inte. " });
        }

        var order = new Order
        {
            OrderDate = DateTime.Now.ToString("yyyy-MM-dd"),
            CustomerId = customer.Id,
            Customer = customer,
            ProductId = model.ProductId,
            Product = product,
            Quantity = model.Quantity,
            Price = (decimal)product.PricePerKg,
            PriceTotal = (decimal)product.PricePerKg * model.Quantity
        };


        await _context.Orders.AddAsync(order);
        await _context.SaveChangesAsync();

        return Ok(new { success = true, data = order });
    }



    // orders/?orderDate=yyyy-mm-dd
    // orders/?orderId=x
    [HttpGet()]
    public async Task<ActionResult> GetOrders([FromQuery] int? orderId, [FromQuery] string orderDate)
    {
        try
        {

            var ord = _context.Orders
            .Include(o => o.Product)
            .Include(o => o.Customer).AsQueryable();


            if (orderId.HasValue)
            {
                ord = ord.Where(o => o.Id == orderId.Value);
            }
            if (!string.IsNullOrEmpty(orderDate))
                ord = ord.Where(o => o.OrderDate == orderDate);

            var order = await ord.ToListAsync();

            if (order == null || order.Count == 0)
            {
                return NotFound(new { success = false, message = "Ingen order hittades. " });
            }

            return Ok(new { success = true, data = order });

        }
        catch (Exception)
        {
            return StatusCode(500, new { success = false, message = "Något gick fel, försök igen. " });
        }
    }

    [HttpGet("all")]
    public async Task<ActionResult> ListOrders()
    {
        var orders = await _context.Orders
        .Include(o => o.Product)
        //.Include(o => o.Customer)
        .ToListAsync();

        if (orders == null || orders.Count == 0)
        {
            return NotFound(new { success = false, message = "Inga ordrar hittade. " });
        }

        return Ok(new { success = true, data = orders });
    }
}
