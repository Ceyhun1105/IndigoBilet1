using IndigoBilet1.DbContextFiles;
using IndigoBilet1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace IndigoBilet1.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            List<Post> posts = _context.Posts.ToList();
            return View(posts);
        }

      
    }
}