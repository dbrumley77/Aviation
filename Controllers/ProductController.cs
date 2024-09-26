using Aviation.Data;
using Microsoft.AspNetCore.Mvc;

namespace Aviation.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository _repo;  //Makes transient from Program.cs (Line 21) active

        
        public ProductController(IProductRepository repo) //Constructor
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var products = _repo.GetAllProducts();
            return View(products);
        }
    }
}
