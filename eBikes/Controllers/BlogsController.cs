using eBikes.Data;
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
        private readonly AppDbContext _context;

        public BlogsController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, AppDbContext context)
        {
            //_userManager = userManager;
            //_signInManager = signInManager;
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _context.Blogs.ToListAsync());
        }
    }
}
