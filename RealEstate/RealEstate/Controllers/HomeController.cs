using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RealEstate.Data;
using RealEstate.Models;
using RealEstate.ViewModel;
using System.Diagnostics;

namespace RealEstate.Controllers
{
   
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private EstateDbContext _context;
        public HomeController(ILogger<HomeController> logger,EstateDbContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {

            var house = from h in _context.Houses
                        join d in _context.Districts on h.LocationId equals d.Id
                        join s in _context.Statuses on h.StatusId equals s.Id
                        select new HouseViewModel
                        {
                            Id = h.Id,
                            LocationName = d.LocationName,
                            Price = h.Price,
                            RoomNumber = h.RoomNumber,
                            Square = h.Square,
                            Statu = s.Statu,
                            Title = h.Title,
                            Image = h.Image
                        };

            ViewBag.hw = house.ToList();
            ViewBag.ds = _context.Districts.ToList();
            return View();
        }
        public IActionResult ForSelling()
        {
            var house = from h in _context.Houses
                        join d in _context.Districts on h.LocationId equals d.Id
                        join s in _context.Statuses on h.StatusId equals s.Id
                        select new HouseViewModel
                        {
                            Id = h.Id,
                            LocationName = d.LocationName,
                            Price = h.Price,
                            RoomNumber = h.RoomNumber,
                            Square = h.Square,
                            Statu = s.Statu,
                            Title = h.Title,
                              Image = h.Image
                        };

            //ViewBag.ev = _context.Houses.Where(a=>a.StatusId==2).ToList();
            ViewBag.ev = house.Where(a => a.Statu == "Satılık").ToList();

            return View();
        }
        public IActionResult ForRenting()
        {
            var house = from h in _context.Houses
                        join d in _context.Districts on h.LocationId equals d.Id
                        join s in _context.Statuses on h.StatusId equals s.Id
                        select new HouseViewModel
                        {
                            Id = h.Id,
                            LocationName = d.LocationName,
                            Price = h.Price,
                            RoomNumber = h.RoomNumber,
                            Square = h.Square,
                            Statu = s.Statu,
                            Title = h.Title,
                            Image= h.Image
                        };

            //ViewBag.ev = _context.Houses.Where(a=>a.StatusId==2).ToList();
            ViewBag.ev = house.Where(a => a.Statu == "Kiralık").ToList();

            return View();
        }
        [Authorize(Roles = "AktifKullanıcı")]
        public IActionResult Detail()
        {
         
         

            return View();
        }


    }
}