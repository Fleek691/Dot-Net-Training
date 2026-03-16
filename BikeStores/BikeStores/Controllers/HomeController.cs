
using BikeStores.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

public class ProductController : Controller
{
    private readonly BikeStoresContext _context;

    public ProductController(BikeStoresContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index(int page = 1)
    {
        if (page < 1) page = 1;

        var products = await _context.Products
            .FromSqlRaw("EXEC ProductPage @PageNumber = {0}", page)
            .ToListAsync();

        var viewModel = new ProductPageViewModel
        {
            Products = products,
            CurrentPage = page,
            HasNextPage = products.Count == 50
        };

        return View(viewModel);
    }
}