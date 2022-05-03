using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Data;
using RealEstate.Helpers;
using RealEstate.Models;
using RealEstate.ViewModel;
using System.Security.Claims;

namespace RealEstate.Controllers
{
    public class AuthController : Controller
    {
        private readonly EstateDbContext context;

        public AuthController(EstateDbContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            UserViewModel user = new UserViewModel();
            return View(user);
        }
        [HttpPost]
        public IActionResult Login(UserViewModel userView)
        {
            if(ModelState.IsValid)
            {
                ClaimsIdentity identiy = null;
                bool isAuthenticated = false;
                User user = context.Users.Include(k => k.Rolee).FirstOrDefault(m => m.Email == userView.Email && m.Password == userView.Password);
                if (user==null)
                {
                    ModelState.AddModelError("", "Kullanıcı bulunamadı");
                    return View();
                }
                if (user.RoleID==1)
                {
                    return Redirect("~/Auth/RegisterMessage");
                }
                if (user.RoleID == 2)
                {
                    return Redirect("~/Home/Index");
                }
              
                identiy = new ClaimsIdentity(
                    new []
                    {
                        new Claim(ClaimTypes.Sid,user.UserID.ToString()),
                        new Claim(ClaimTypes.Email,user.Email),
                        new Claim(ClaimTypes.Role,user.Rolee.RoleName),
                    }, CookieAuthenticationDefaults.AuthenticationScheme
                    );
                isAuthenticated = true;
                if (isAuthenticated)
                {
                    var claim = new ClaimsPrincipal(identiy);
                    var login = HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claim,

                        new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTime.Now.AddMinutes(60)
                        });


                    if (user.Rolee.RoleName == "Supervisor")
                    {
                        return Redirect("~/HomeAdmin/Index");
                    }
                    else if (user.Rolee.RoleName == "Admin")
                    {
                        return Redirect("~/Admin/Index");
                    }

                    else if (user.Rolee.RoleName == "AktifKullanıcı")
                    {
                        return Redirect("~/Home/Index");
                    }
                    else
                    {
                        return Redirect("~/Home/ErrorPage");
                    }

                }

            }
            return View(userView); 
        }

        public IActionResult Register()
        {
            User user = new User();

            return View(user);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("UserID", "Email", "Password", "RePassword", "UserName", "RoleID")] User user)
        {
            user.RoleID = 1;
            User userr = await context.Users.SingleOrDefaultAsync(a => a.Email == user.Email);
            if (userr!=null)
            {
                ModelState.AddModelError("Hata1", "Bu E-Posta Daha Önce Kullanılmış");

            }
            if (ModelState.IsValid)
            {
                await context.Users.AddAsync(user);
                await context.SaveChangesAsync();
                EpostaIslemleri.AktivasyonMailiGonder(user.Email);
                return RedirectToAction("RegisterMessage","Auth");
            }
            return View(user);
        }

        public IActionResult RegisterMessage()
        {
            return View();
        }
        public IActionResult RegisterAply(string kkk)
        {
            string eposta = Sifreleme.SifreyiCoz(kkk);
            User user = context.Users.SingleOrDefault(a => a.Email == eposta);
            if (user!=null)
            {
                user.RoleID = 2;
                context.Users.Update(user);
                context.SaveChanges();
                return View();
            }
          
            return View();
        }
        [HttpPost]
        public IActionResult RePassword(User user)
        {
            var p=context.Users.SingleOrDefault(a=>a.Email==user.Email);
            if(p!=null)
            {
                EpostaIslemleri.SıfırlamaMailiGonder(user.Email);
                return RedirectToAction("ReActivation","Auth");
            }
            ModelState.AddModelError("Hata2", "Böyle bir E-posta bulunamamıştır");
            return View();
        }
        public IActionResult ReActivation()
        {
            return View();
        }

        public IActionResult RePasswordApply()
        {
           
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> RePasswordApply(string kkk, User user)
        {
            string eposta = Sifreleme.SifreyiCoz(kkk);
            User userr =await context.Users.SingleOrDefaultAsync(a => a.Email == eposta);
            if (userr!=null && ModelState.IsValid)
            {
               context.Users.Update(user);
                context.SaveChanges();
                return View("Login", "Auth");
                
            }
            return View();
        }

    }
}
