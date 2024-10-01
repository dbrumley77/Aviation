using Aviation.Data;
using Microsoft.AspNetCore.Mvc;

namespace Aviation.Controllers
{
    public class FalconController : Controller
    {
        private readonly IFalconRepository _repo;  //Makes transient from Program.cs (Line 21) active

        
        public FalconController(IFalconRepository repo) //Constructor for field
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var products = _repo.GetAllFalcon();
            return View(products);
        }
    }
}
