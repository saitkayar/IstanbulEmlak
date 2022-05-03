using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Data;
using System.Diagnostics;

namespace RealEstate.Controllers
{
    //[Authorize(Roles = "Admin")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EstateDbContext _context;

        public HomeController(ILogger<HomeController> logger, EstateDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var house = _context.Houses.ToList();
            return View(house);
        }
        public IActionResult AddDistrict()
        {
            return View();
        }
        public IActionResult AddHouse()
        {
            return View();
        }
      
    }
}