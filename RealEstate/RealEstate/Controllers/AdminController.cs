using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using RealEstate.ViewModel;
using System.Linq;

namespace RealEstate.Controllers
{
    public class AdminController : Controller
    {
        private EstateDbContext _context;

        public AdminController(EstateDbContext context)
        {
            _context = context;
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
                            Title = h.Title
                        };

            ViewBag.ev = house.ToList();

            return View();
        }
        public IActionResult Add()
        {
            ViewBag.districts = _context.Set<District>().ToList();
            ViewBag.statu = _context.Set<Status>().ToList();

            return View();

        }
        [HttpPost]
        public IActionResult Add(House house)
        {
           
            if (house.Id==0)
            {
                _context.Houses.Add(house);
                _context.SaveChanges();
            }
           

            return RedirectToAction("Index");

        }

        public IActionResult Update(int id)
        {
            ViewBag.hw = _context.Set<House>().SingleOrDefault(a=>a.Id==id);
            ViewBag.districts = _context.Set<District>().ToList();
            ViewBag.statu = _context.Set<Status>().ToList();
            return View();
        }
        [HttpPost]
        public IActionResult Update(House house)
        {
            if (house.Id != 0)
            {
                _context.Houses.Update(house);
                _context.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public IActionResult Delete(House house,int id)
        {
            var delete=_context.Set<House>().SingleOrDefault(a=>a.Id==id);
            _context.Remove(delete);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
