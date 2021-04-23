using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PortfolioHeo.Data;
using PortfolioHeo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace PortfolioHeo.Controllers
{
    public class HomeController : Controller
    {
        private readonly PortfolioHeoContext _context;

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, PortfolioHeoContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            //ViewBag.Message = "TEST!!";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("Id,Name,Email,Contents")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    contact.RegDate = DateTime.Now;
                    _context.Contact.Add(contact);
                    await _context.SaveChangesAsync();

                    ViewBag.Message = "감사합니다. 연락드리겠습니다!";
                }
                catch (Exception ex)
                {
                    ModelState.Clear();
                    ViewBag.Message = $"예외가 발생했습니다. {ex.Message}";

                }
                //return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Profile()
        {
            return View();
        }
        public IActionResult Portfolio()
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
    }
}
