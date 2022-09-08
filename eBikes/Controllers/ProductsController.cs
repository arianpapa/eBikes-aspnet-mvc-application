using eBikes.Data;
using eBikes.Data.Repositories;
using eBikes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace eBikes.Controllers
{
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

        //[AllowAnonymous]
        //public async Task<IActionResult> Filter(string searchString)
        //{
        //    var allMovies = await _service.GetAllAsync(n => n.Cinema);

        //    if (!string.IsNullOrEmpty(searchString))
        //    {
        //        //var filteredResult = allMovies.Where(n => n.Name.ToLower().Contains(searchString.ToLower()) || n.Description.ToLower().Contains(searchString.ToLower())).ToList();

        //        var filteredResultNew = allMovies.Where(n => string.Equals(n.Name, searchString, StringComparison.CurrentCultureIgnoreCase) || string.Equals(n.Description, searchString, StringComparison.CurrentCultureIgnoreCase)).ToList();

        //        return View("Index", filteredResultNew);
        //    }

        //    return View("Index", allMovies);
        //}

        //GET: Products/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var productDetail = await _repository.GetMovieByIdAsync(id);
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
                StartDate = productDetails.StartDate,
                EndDate = productDetails.EndDate,
                ImageURL = productDetails.ImageURL,
                MovieCategory = productDetails.MovieCategory,
                CinemaId = productDetails.CinemaId,
                ProducerId = productDetails.ProducerId,
                ActorIds = productDetails.Actors_Movies.Select(n => n.ActorId).ToList(),
            };

            var productDropdownsData = await _repository.GetNewProductDropdownsValues();
            ViewBag.Cinemas = new SelectList(productDropdownsData.Cinemas, "Id", "Name");
 
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, NewMovieVM movie)
        {
            if (id != movie.Id) return View("NotFound");

            if (!ModelState.IsValid)
            {
                var movieDropdownsData = await _service.GetNewMovieDropdownsValues();

                ViewBag.Cinemas = new SelectList(movieDropdownsData.Cinemas, "Id", "Name");
                ViewBag.Producers = new SelectList(movieDropdownsData.Producers, "Id", "FullName");
                ViewBag.Actors = new SelectList(movieDropdownsData.Actors, "Id", "FullName");

                return View(movie);
            }

            await _service.UpdateMovieAsync(movie);
            return RedirectToAction(nameof(Index));
        }
    }
}

