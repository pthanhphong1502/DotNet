using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JZsGreen.Data;
using JZsGreen.Models;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace JZsGreen.Controllers
{
    public class BillsController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JZenoDbContext _context;

        public BillsController(JZenoDbContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        // GET: Bills
        [Route("Bill/list")]
        public async Task<IActionResult> Index(string searchPhone)
        {
            ViewData["GetPhone"] = searchPhone;
            if (_signInManager.IsSignedIn(User) == true)
            {
                searchPhone = _userManager.GetUserAsync(User).Result!.PhoneNumber!;
            }
            var jZenoDbContext = _context.Bill.Where(e=>e.phone == searchPhone).OrderByDescending(e=>e.date).Include(b => b.User);
            return View(await jZenoDbContext.ToListAsync());
        }
        // GET: Bills/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Bill == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill
                .Include(b => b.User)
                .Include(b=>b.detailsOrders)!.ThenInclude(e=>e.product).ThenInclude(e=>e!.images)
                .FirstOrDefaultAsync(m => m.billID == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }
        public IActionResult ActivePoint(string id)
        {
           if(_signInManager.IsSignedIn(User) == true)
            {
                var point = _userManager.GetUserAsync(User).Result!.point;
                var userMail = User.FindFirstValue(ClaimTypes.Email);
                var user = _userManager.Users.ToList().FirstOrDefault(e => e.Email == userMail);
                var bill = _context.Bill.ToList().FirstOrDefault(m => m.billID == id);
                bill!.point = point;
                bill!.totalPrice -= point;
                user!.point = 0;
                _context.Update(user);
                _context.Update(bill);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
