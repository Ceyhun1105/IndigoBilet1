using IndigoBilet1.DbContextFiles;
using IndigoBilet1.Helpers;
using IndigoBilet1.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace IndigoBilet1.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PostController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public PostController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }
        public IActionResult Index()
        {
            List<Post> posts = _context.Posts.ToList();
            return View(posts);
        }
        public IActionResult Create()
        {
            return View();
        }
        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Create(Post post)
        {
            if (!ModelState.IsValid) return View(post);

            if (post.ImageFile == null)
            {
                ModelState.AddModelError("ImageFile", "Required");
                return View(post);
            }

            if (!post.ImageFile.CheckFileLength(1048576 * 3))
            {
                ModelState.AddModelError("ImageFile", "Please, upload less than 3 MB");
                return View(post);
            }
            if (!post.ImageFile.CheckFileType())
            {
                ModelState.AddModelError("ImageFile", "Please, upload only png , jpg or jpeg files.");
                return View(post);
            }

            post.Imageurl = post.ImageFile.SaveFile(_env.WebRootPath, "uploads/posts");

            _context.Posts.Add(post);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        public IActionResult Update(int id)
        {
            Post post = _context.Posts.FirstOrDefault(x => x.Id == id);
            if (post == null) return NotFound();
            ViewBag.Image = post.Imageurl;

            return View(post);
        }

        [AutoValidateAntiforgeryToken]
        [HttpPost]
        public IActionResult Update(Post post)
        {
            Post existPost = _context.Posts.FirstOrDefault(x => x.Id == post.Id);
            if (existPost == null) return NotFound();
            ViewBag.Image = existPost.Imageurl;

            if (!ModelState.IsValid) return View(post);
            


            if (post.ImageFile != null)
            {
                if (!post.ImageFile.CheckFileLength(1048576 * 3))
                {
                    ModelState.AddModelError("ImageFile", "Please, upload less than 3 MB");
                    return View(post);
                }
                if (!post.ImageFile.CheckFileType())
                {
                    ModelState.AddModelError("ImageFile", "Please, upload only png , jpg or jpeg files.");
                    return View(post);
                }

                string path = Path.Combine(_env.WebRootPath, "uploads/posts", existPost.Imageurl);
                if (System.IO.File.Exists(path))
                    System.IO.File.Delete(path);

                post.Imageurl = post.ImageFile.SaveFile(_env.WebRootPath, "uploads/posts");
                existPost.Imageurl = post.Imageurl;
            }

            existPost.Title = post.Title;
            existPost.Description = post.Description;
            existPost.LearnMoreurl = post.LearnMoreurl;

            _context.SaveChanges();


            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int id)
        {
            Post post = _context.Posts.FirstOrDefault(x => x.Id == id);
            if (post == null) return NotFound();
            string path = Path.Combine(_env.WebRootPath, "uploads/posts", post.Imageurl);
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
            _context.Posts.Remove(post);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
