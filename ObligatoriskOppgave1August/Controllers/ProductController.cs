using Microsoft.AspNetCore.Mvc;
using ObligatoriskOppgave1August.Models;
using System.Diagnostics;
using ObligatoriskOppgave1August.Models.Entities;

namespace ObligatoriskOppgave1August.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            var products = repository.GetAll();

            return View(products);
        }

        // GET: Product/Create 
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create 
        [HttpPost]
        public ActionResult Create(Product Product)
        {
            try
            {
                // Kall til metoden save i repository 
                repository.Save(Product);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
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