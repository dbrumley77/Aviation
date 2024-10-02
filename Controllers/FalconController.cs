using Aviation.Data;
using Aviation.Models;
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
            var plane = _repo.GetAllFalcon();
            return View(plane);
        }

        public IActionResult ViewFalcon(int id)
        {
            var plane = _repo.GetFalcon(id);
            return View(plane);
        }

        public IActionResult UpdateFalcon(int id)
        {
            Falcon plane = _repo.GetFalcon(id);
            if (plane == null)
            {
                return View("ProductNotFound");
            }
            return View(plane);
        }

        public IActionResult UpdateFalconToDatabase(Falcon plane)
        {
            _repo.UpdateFalcon(plane);

            return RedirectToAction("ViewFalcon", new { id = plane.FalconID });
        }

        public IActionResult InsertFalcon()
        {
            var plane = _repo.AssignCategory();
            return View(plane);
        }

        public IActionResult InsertFalconToDatabase(Falcon planeToInsert)
        {
            _repo.InsertFalcon(planeToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteFalcon(Falcon plane)
        {
            _repo.DeleteFalcon(plane);
            return RedirectToAction("Index");
        }
    }
}
