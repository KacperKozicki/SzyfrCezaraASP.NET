using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using SzyfrCezaraASP.NET.Models;


namespace SzyfrCezaraASP.NET.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        public IActionResult Szyfrowanie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Szyfrowanie(string tekst, int klucz)
        {
            SzyfrCezara szyfrcezara = new SzyfrCezara();
            // Tutaj umieść logikę szyfrowania
            string zaszyfrowanyTekst = szyfrcezara.Szyfruj(tekst, klucz);
            ViewBag.ZaszyfrowanyTekst = zaszyfrowanyTekst;
            return View();
        }

        public IActionResult DeSzyfrowanie()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DeSzyfrowanie(string tekst, int klucz)
        {
            SzyfrCezara szyfrcezara = new SzyfrCezara();
            // Tutaj umieść logikę szyfrowania
            string zaszyfrowanyTekst = szyfrcezara.DeSzyfruj(tekst, klucz);
            ViewBag.ZaszyfrowanyTekst = zaszyfrowanyTekst;
            return View();
        }
    }
}