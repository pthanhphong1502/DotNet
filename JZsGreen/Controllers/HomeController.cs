using JZsGreen.Data;
using JZsGreen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace JZsGreen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly JZenoDbContext _context;
        public HomeController(ILogger<HomeController> logger, JZenoDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        [OutputCache(NoStore = true, Duration = 10)]
        public async Task<IActionResult> Index()
        {   
                var product = await _context.Product!.OrderByDescending(e=>e.isActive)!.Where(e => e.isActive == true).Include(e => e.images).ToListAsync();
                return View(product);           
        }
        [OutputCache(NoStore =true, Duration =10)]
        public async Task<IActionResult> ProductDisCountView()
        {
            var productDiscount = await _context.Product!.OrderByDescending(e => e.isActive)!.Where(e => e.isActive == true).Include(e => e.images).ToListAsync();
            return PartialView("ProductDisCountView", productDiscount);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}