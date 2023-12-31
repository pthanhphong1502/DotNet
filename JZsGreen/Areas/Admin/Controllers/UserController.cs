using JZsGreen.Data;
using JZsGreen.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JZsGreen.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly JZenoDbContext _context;
        public UserController(UserManager<User> userManager, SignInManager<User> signInManager, JZenoDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [Route("Admin/User")]
        public IActionResult Index()
        {
            var user = _userManager.Users.ToList();
            return View(user);
        }
        public ActionResult lockOut(string? id)
        {
            var user = _userManager.Users.ToList().FirstOrDefault(e => e.Id == id);
            user!.LockoutEnabled = true;
            user!.LockoutEnd = DateTime.Now.AddDays(30);
            _context.Update(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult unLock(string? id)
        {
            var user = _userManager.Users.ToList().FirstOrDefault(e => e.Id == id);
            user!.LockoutEnabled = false;
            user!.LockoutEnd = DateTime.Now;
            _context.Update(user);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        public ActionResult UpdatePoint(string? id)
        {
            var user = _userManager.Users.ToList().FirstOrDefault(e => e.Id == id);
            user!.point = 0;
             _context.Update(user);
             _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}
