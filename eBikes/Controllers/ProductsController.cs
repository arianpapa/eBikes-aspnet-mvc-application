using eBikes.Data;
using eBikes.Data.Repositories;
using eBikes.Data.Static;
using eBikes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eBikes.Controllers
{
    [Authorize(Roles = UserRoles.Admin)]
    public class ProductsController : Controller
    {
        private readonly IProductsRepository _repository;

        public ProductsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IProductsRepository repository)
        {
            //_userManager = userManager;
            //_signInManager = signInManager;
            _repository = repository;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allProducts = await _repository.GetAllAsync(n => n.Category);
            return View(allProducts);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Filter(string searchString)
        {
            var allProducts = await _repository.GetAllAsync(n => n.Category);

            if (!string.IsNullOrEmpty(searchString))
            {
                var filteredResult = allProducts.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || 
                n.Description.ToLower().Contains(searchString.ToLower())).ToList();

                //var filteredResultNew = allProducts.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

                return View("Index", filteredResult);
            }

            return View("Index", allProducts);
        }

        //GET: Products/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var productDetail = await _repository.GetProductByIdAsync(id);
            return View(productDetail);
        }

        //GET: Products/Create
        public async Task<IActionResult> Create()
        {
            var productDropdownsData = await _repository.GetNewProductDropdownsValues();

            ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "Name");
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(NewProductVM product)
        {
            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _repository.GetNewProductDropdownsValues();

                ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "Name");

                return View(product);
            }

            await _repository.AddNewProductAsync(product);
            return RedirectToAction(nameof(Index));
        }


        //GET: Products/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var productDetails = await _repository.GetProductByIdAsync(id);
            if (productDetails == null) return View("NotFound");

            var response = new NewProductVM()
            {
                Id = productDetails.Id,
                Name = productDetails.Name,
                Description = productDetails.Description,
                Price = productDetails.Price,
                Created_at = productDetails.Created_at,
                imageName = productDetails.imageName,
                CategoryId = productDetails.CategoryId
            };

            var productDropdownsData = await _repository.GetNewProductDropdownsValues();
            ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "Name");
 
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewProductVM product)
        {
            if (id != product.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var productDropdownsData = await _repository.GetNewProductDropdownsValues();

                ViewBag.Categories = new SelectList(productDropdownsData.Categories, "Id", "Name");

                return View(product);
            }

            await _repository.UpdateProductAsync(product);
            return RedirectToAction(nameof(Index));
        }
    }
}

