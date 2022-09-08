
using eBikes.Data.Repositories;
using eBikes.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eBikes.Controllers
{
    public class BlogsController : Controller
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        //private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IBlogsRepository _repository;

        public BlogsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IBlogsRepository repository)
        {
            //_userManager = userManager;
            //_signInManager = signInManager;
            _repository = repository;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _repository.GetAllAsync();
            return View(data);
        }

        //Get: Blogs/Create
        public IActionResult Create()
        {
            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Create([Bind("Title,Author,imageName,Description")] Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }
            await _repository.AddAsync(blog);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Details/1
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var blogDetails = await _repository.GetByIdAsync(id);

            if (blogDetails == null) return View("NotFound");
            return View(blogDetails);
        }

        //Get: Actors/Edit/1
        public async Task<IActionResult> Edit(int id)
        {
            var blogDetails = await _repository.GetByIdAsync(id);
            if (blogDetails == null) return View("NotFound");
            return View(blogDetails);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Author,imageName,Description")] Blog blog)
        {
            if (!ModelState.IsValid)
            {
                return View(blog);
            }
            await _repository.UpdateAsync(id, blog);
            return RedirectToAction(nameof(Index));
        }

        //Get: Actors/Delete/1
        public async Task<IActionResult> Delete(int id)
        {
            var blogDetails = await _repository.GetByIdAsync(id);
            if (blogDetails == null) return View("NotFound");
            return View(blogDetails);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var blogDetails = await _repository.GetByIdAsync(id);
            if (blogDetails == null) return View("NotFound");

            await _repository.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
