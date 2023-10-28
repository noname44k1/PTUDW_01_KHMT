using Microsoft.AspNetCore.Mvc;
using PTUDW_01_KHMT.Models;

namespace PTUDW_01_KHMT.Controllers
{
    public class BlogController : Controller
    {
        private readonly HarmicContext _context;

        public BlogController(HarmicContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var blogs = _context.TbBlogs.Where(i => (bool)i.IsActive).OrderByDescending(i => i.BlogId).ToList();
            ViewBag.blogComment = _context.TbBlogComments.Where(m => (bool)m.IsActive).ToList();
            return View(blogs);
        }

        [Route("/blog/{alias}-{id}.html")]
        public IActionResult Details(int? id) {
            if (id == null)
                return NotFound();
            var blog = _context.TbBlogs.FirstOrDefault(i => i.BlogId == id && (bool)i.IsActive);
            ViewBag.blogComment = _context.TbBlogComments.Where(m=>m.BlogId == id && (bool)m.IsActive).ToList();
            if (blog == null)
                return NotFound();
            return View(blog);
        }
    }
}
