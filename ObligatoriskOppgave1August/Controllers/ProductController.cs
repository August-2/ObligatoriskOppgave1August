using Microsoft.AspNetCore.Mvc;
using ObligatoriskOppgave1August.Models;
using System.Diagnostics;
using ObligatoriskOppgave1August.Models.Entities;
using ObligatoriskOppgave1August.Models.ViewModels;

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
            var product = repository.GetProductEditViewModel();
            return View(product);
        }

        // POST: Product/Create 
        [HttpPost]
        public ActionResult  Create([Bind("Name, Description, Price,CategoryId,ManufacturerId")]
            Product product)
        {
            var product2 = repository.GetProductEditViewModel();
            if (ModelState.IsValid)
            {
                
                Console.WriteLine("ALT ER VALID!!!!");
                // Kall til metoden save i repository 
                repository.Save(product);
                TempData["message"] = string.Format("{0} har blitt opprettet", product.Name);

                return RedirectToAction("Index");
            }
            else
            {
                Console.WriteLine("IKKE VALID!!!!!");
                return View(product2);
            }
        }

        // GET: Product/Update 
        public ActionResult Update(int? id)
        {
            var product = repository.GetProductEditViewModel();
            var product2 = repository.GetProductById(id);
            if (id is null or 0)
            {
                return NotFound();
            }

            if (product == null)
            {
                return NotFound();
            }
            return View(product);
        }

        // POST: Product/Update 
        [HttpPost]
        public ActionResult Update(Product product)
        {
            var product2 = repository.GetProductEditViewModel();
            if (ModelState.IsValid)
            {

                Console.WriteLine("ALT ER VALID!!!!");
                // Kall til metoden save i repository 
                repository.Update(product);
                TempData["message"] = string.Format("{0} har blitt endret", product.Name);

                return RedirectToAction("Index");
            }
            else
            {
                Console.WriteLine("IKKE VALID!!!!!");
                return View(product2);
            }
        }

        // GET: Product/Remove 
        public ActionResult Remove(Product product)
        {

            if (product == null)
            {
                return NotFound();
            }
            var product2 = repository.GetProductEditViewModel();
            return View(product);
        }

        // POST: Product/Remove 
        [HttpPost, ActionName("Remove")]
        [ValidateAntiForgeryToken]
        public ActionResult RemovePost(Product product)
        {
            var product2 = repository.GetProductEditViewModel();

            if (product == null)
            {
                return NotFound();
            }
                Console.WriteLine("ALT ER VALID!!!!");
                // Kall til metoden save i repository 
                repository.Remove(product);
                TempData["message"] = string.Format("{0} har blitt opprettet", product.Name);

                return RedirectToAction("Index");

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