using eBikes.Data;
using eBikes.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eBikes.Controllers
{
    public class ProductsController : Controller
    {
        private readonly AppDbContext _context;

        public ProductsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            //_userManager = userManager;
            //_signInManager = signInManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var allProducts = await _context.Products.Include(n => n.Category).OrderBy(n => n.Name).ToListAsync();
            return View(allProducts);
        }
    }
}

