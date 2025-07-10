using Microsoft.AspNetCore.Mvc;
using PortfolioWebsite.Data;
using PortfolioWebsite.Models;

namespace PortfolioWebsite.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GalleryController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GalleryController(ApplicationDbContext context)
        {
                _context = context;
        }
        public IActionResult Index()
        {
            return View(_context.Gallery.ToList());
        }
        public IActionResult AddOrEdit(int id)
        {
            if(id == 0) 
                return View(new Gallery());
            else
                return View(_context.Gallery.Find(id));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddOrEdit(Gallery gallery)
        {
            if(ModelState.IsValid)
            {
                if(gallery.Id==0)
                    _context.Gallery.Add(gallery);
                else
                    _context.Gallery.Update(gallery);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(gallery);
        }
    }
}
