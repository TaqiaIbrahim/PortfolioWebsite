using Microsoft.AspNetCore.Mvc;
using PortfolioWebsite.Data;
using PortfolioWebsite.Models;
using System.Diagnostics.Eventing.Reader;

namespace PortfolioWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BlogController : Controller
    {
        private readonly ApplicationDbContext _context;
        public BlogController( ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Blog.ToList());
        }
        public IActionResult AddOrEdit(int id)
        {
            if(id == 0)
            
                return View(new Blog());
                else
                    return View(_context.Blog.Find(id));
            
           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Blog blog)
        {
          if(ModelState.IsValid)
            {
                if(blog.Id==0)
                    _context.Blog.Add(blog);
                else
                    _context.Blog.Update(blog);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
          return View(blog);
        }
        public IActionResult Delete(int id) {
            var blog = _context.Blog.Find(id);
            _context.Blog.Remove(blog);
            _context.SaveChanges();
            return RedirectToAction("Index");
        
        }
    }
}
