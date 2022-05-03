using Microsoft.AspNetCore.Mvc;
using RealEstate.Data;
using RealEstate.Models;

namespace RealEstate.Controllers
{
    public class DistrictsController : Controller
    {
        private EstateDbContext _context;

        public DistrictsController(EstateDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var district = _context.Districts.ToList();
            return View(district);
        }
        public IActionResult Add(District district)
        {
            _context.Districts.Add(district);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


    }
}
