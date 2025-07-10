using Microsoft.AspNetCore.Mvc;
using PortfolioWebsite.Models;
using PortfolioWebsite.ViewModel;
using System.Diagnostics;
using PortfolioWebsite.Data;

namespace PortfolioWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger,ApplicationDbContext context)
        {
            _logger = logger;
            _context= context;
        }

        public IActionResult Index()
        {
            var ViewModel = new formViewModel
            {
                aboutMe = _context.AboutMe.ToList().Take(1),
                experiences=_context.Expericence.ToList(),
                educations=_context.Education.ToList(),
                services=_context.Services.ToList(),
                skills=_context.Skills.ToList(),
                clientOpinion= _context.ClientOpinion.ToList(),
                blogs=_context.Blog.ToList(),
                Sliders=_context.Slider.ToList().Take(1),
            };
         
         
            return View(ViewModel);
        }
        public IActionResult download(int id)
        {

            return View();

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Add(Contact contact)
        {
            var viewModel = new formViewModel
            {
                Name = contact.Name,
                Subject = contact.Subject,
                Email = contact.Email,
                Message = contact.Message,
            };
            if (ModelState.IsValid)
            {
                if (contact.Id == 0)
                    _context.Contacts.Add(contact);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contact);
        }


        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}