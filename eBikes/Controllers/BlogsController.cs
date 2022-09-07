using eBikes.Data;
using eBikes.Data.Repositories;
using eBikes.Data.Repositories;
using eBikes.Models;
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
            var data = await _repository.GetAllBlogs();
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
             _repository.Add(blog);
            return RedirectToAction(nameof(Index));
        }

    }
}
