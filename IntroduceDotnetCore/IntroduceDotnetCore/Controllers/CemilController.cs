using Microsoft.AspNetCore.Mvc;

namespace IntroduceDotnetCore.Controllers
{
    public class CemilController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Orhan(string? test, string? ad)
        {
            //Amaç: 
            dynamic value = "tarım";
            var result = value.ToUpper();
            ViewBag.Deger = test;
            ViewBag.Ad = ad;
            return View();
        }
    }
}
