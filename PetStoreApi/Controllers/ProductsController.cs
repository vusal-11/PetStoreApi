using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PetsData.DbContexts;

namespace PetStoreApi.Controllers;


[ApiController]
[Authorize]
public class ProductsController : ControllerBase
{
    private readonly PetDbContext _context;

    private readonly IHttpContextAccessor _httpContextAccessor;

    public ProductsController(PetDbContext context, IHttpContextAccessor httpContextAccessor)
    {

        _context = context;
        _httpContextAccessor = httpContextAccessor;
    }

    [AllowAnonymous]
    [HttpGet("api/products")]
    public async Task<IActionResult> GetProducts()
    {
        var products = await _context.Products.ToListAsync();
        
        return Ok(products);
    }

    [HttpGet("api/products2")]
    public async Task<IActionResult> GetProducts2()
    {
        var products = await _context.Products.ToListAsync();

        var authorizationHeader = _httpContextAccessor
           .HttpContext.Request.Headers;


        //await Console.Out.WriteLineAsync(authorizationHeader);

        Console.WriteLine(authorizationHeader);

        return Ok(products);
    }
}
