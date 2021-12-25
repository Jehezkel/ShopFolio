using Microsoft.AspNetCore.Mvc;
using ShopFolio.Api.DAL;
using ShopFolio.Api.Models;

namespace ShopFolio.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class ProductsController : ControllerBase
{
    private readonly Logger<ProductsController> _logger;
    private readonly ShopFolioDbContext _context;

    public ProductsController(Logger<ProductsController> logger,
                              ShopFolioDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    [HttpGet]
    public ActionResult<List<Product>> GetProducts() => _context.Products.ToList();
}