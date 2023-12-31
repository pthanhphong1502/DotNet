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
using Microsoft.AspNetCore.Authorization;
using X.PagedList;
using Microsoft.Data.SqlClient;

namespace JZsGreen.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
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

        [Route("Admin/Bills/")]
        public async Task<IActionResult> Index()
        {
   
            var jZenoDbContext = from b in _context.Bill 
                                 select b;
       
            return View(await jZenoDbContext.ToListAsync());
        }
        [Route("/Admin/Bills/updateActive/",Name = "updateActive")]
        public async Task<JsonResult> updateActive(string billID,int payment)
        {
            var bill = await _context.Bill.FindAsync(billID);

            if (ModelState.IsValid)
            {
                try
                {
                    if (bill!.payment == null) bill.payment = 0;
                    else bill!.payment = payment;
                    var user = await _context.Users.FirstOrDefaultAsync(e => e.PhoneNumber == bill.phone);

                    if (bill!.payment == 3)
                    {
                        if(user != null)
                        {
                            var point = (int)bill.totalPrice! * 0.01;
                            user!.point += (int) point;                   
                            _context.Update(user);
                        }
                    }
                    if(bill!.payment == 4)
                    {
                        if (user != null)
                        {
                            user!.point += bill.point!;
                            _context.Update(user);
                        }
                    }
                    _context.Update(bill);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return Json(bill);
            }
            return Json(bill);
        }

        [Route("Admin/Bills/Details/{id?}")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Bill == null)
            {
                return NotFound();
            }

            var bill = await _context.Bill
                .Include(b => b.User)
                .Include(b => b.detailsOrders)!.ThenInclude(e => e.product).ThenInclude(e => e.images)
                .FirstOrDefaultAsync(m => m.billID == id);
            if (bill == null)
            {
                return NotFound();
            }

            return View(bill);
        }
    }
}
