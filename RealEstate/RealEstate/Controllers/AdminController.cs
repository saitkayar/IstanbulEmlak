using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Models;
using RealEstate.ViewModel;
using System.Linq;

namespace RealEstate.Controllers
{ /*[Authorize(Roles = "Admin")]*/
    public class AdminController : Controller
    {
        private EstateDbContext _context;
        private IWebHostEnvironment _webHostEnviroment;

        public AdminController(EstateDbContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
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
                           Image=h.Image,
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
           
            if (ModelState.IsValid &&  house.Id==0)
            {
                var filePath = Path.Combine(_webHostEnviroment.WebRootPath, "Resimler");
                if (!Directory.Exists(filePath))
                {
                    Directory.CreateDirectory(filePath);

                }
                var path = Path.Combine(filePath, house.File.FileName);
                using (var fileStream=new FileStream(path,FileMode.Create))
                    {
                    house.File.CopyTo(fileStream);
                }
                house.Image = house.File.FileName;
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
                            Title = h.Title
                        };

            //ViewBag.ev = _context.Houses.Where(a=>a.StatusId==2).ToList();
            ViewBag.ev = house.Where(a=>a.Statu=="Satılık").ToList();

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
                            Title = h.Title
                        };

            //ViewBag.ev = _context.Houses.Where(a=>a.StatusId==2).ToList();
            ViewBag.ev = house.Where(a => a.Statu == "Kiralık").ToList();

            return View();
        }
    }
}
