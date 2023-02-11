using CoreApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace CoreApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private AppDBContext _appDBContext;

        public HomeController(ILogger<HomeController> logger, AppDBContext appDBContext)
        {
            _logger = logger;
            _appDBContext = appDBContext;
        }

        public IActionResult Index()
        {
            List<User> users = this._appDBContext.Users.Include(u => u.Product).ToList();
            return View(users);
        }

        [HttpGet]
        public IActionResult Create()
        {

            ViewBag.ProductId = this._appDBContext.Products.Select(x => new SelectListItem() { Text = x.Name, Value = x.ProductId.ToString() });
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid) 
            { 
                this._appDBContext.Users.Add(user);
                this._appDBContext.SaveChanges();
                return RedirectToAction("Index"); 
            }
            return RedirectToAction("Create");
        }
    }
}