using Aviation.Data;
using Aviation.Models;
using Microsoft.AspNetCore.Mvc;

namespace Aviation.Controllers
{
    public class GulfstreamController : Controller
    {
        private readonly IGulfstreamRepository _repo;  //Makes transient from Program.cs (Line 21) active


        public GulfstreamController(IGulfstreamRepository repo) //Constructor for field
        {
            _repo = repo;
        }

        public IActionResult Index()
        {
            var plane = _repo.GetAllGulfstream();
            return View(plane);
        }

        public IActionResult ViewGulfstream(int id)
        {
            var plane = _repo.GetGulfstream(id);
            return View(plane);
        }

        public IActionResult UpdateGulfstream(int id)
        {
            Gulfstream plane = _repo.GetGulfstream(id);
            if (plane == null)
            {
                return View("ProductNotFound");
            }
            return View(plane);
        }

        public IActionResult UpdateGulfstreamToDatabase(Gulfstream plane)
        {
            _repo.UpdateGulfstream(plane);

            return RedirectToAction("ViewGulfstream", new { id = plane.GulfstreamID });
        }

        public IActionResult InsertGulfstream()
        {
            var plane = _repo.AssignCategory();
            return View(plane);
        }

        public IActionResult InsertGulfstreamToDatabase(Gulfstream planeToInsert)
        {
            _repo.InsertGulfstream(planeToInsert);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteGulfstream(Gulfstream plane)
        {
            _repo.DeleteGulfstream(plane);
            return RedirectToAction("Index");
        }
    }
}
