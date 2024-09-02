using IntroduceDotnetCore.Models;
using Microsoft.AspNetCore.Mvc;

namespace IntroduceDotnetCore.Controllers
{
    public class KullaniciController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Kayit()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Kayit(User user )
        {
            //denetle: User nesnesi bütün kuralları (Required, Password, Email vs)
            if (ModelState.IsValid)
            {
                return View("Tamam");
            }  
            return View();
        }
    }
}
