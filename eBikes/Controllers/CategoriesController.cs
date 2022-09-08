using eBikes.Data;
using eBikes.Data.Repositories;
using eBikes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace eBikes.Controllers
{
    public class CategoriesController : Controller
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICategoriesRepository _repository;

        public CategoriesController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, ICategoriesRepository repository)
        {
            //_userManager = userManager;
            //_signInManager = signInManager;
            _repository = repository;
        }

        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allCategories = await _repository.GetAllAsync();
            return View(allCategories);
        }

        //Get: Cinemas/Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("imageName,Name,Description")] Category category)
        {
            if (!ModelState.IsValid) return View(category);
            await _repository.AddAsync(category);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var categoryDetails = await _repository.GetByIdAsync(id);
            if (categoryDetails == null) return View("NotFound");
            return View(categoryDetails);
        }

        //Get: Cinemas/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var categoryDetails = await _repository.GetByIdAsync(id);
            if (categoryDetails == null) return View("NotFound");
            return View(categoryDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,imageName,Name,Description")] Category category)
        {
            if (!ModelState.IsValid) return View(category);
            await _repository.UpdateAsync(id, category);
            return RedirectToAction(nameof(Index));
        }

        //Get: Cinemas/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var categoryDetails = await _repository.GetByIdAsync(id);
            if (categoryDetails == null) return View("NotFound");
            return View(categoryDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            var categoryDetails = await _repository.GetByIdAsync(id);
            if (categoryDetails == null) return View("NotFound");

            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}