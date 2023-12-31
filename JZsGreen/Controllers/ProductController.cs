using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JZsGreen.Data;
using Microsoft.AspNetCore.OutputCaching;
using X.PagedList;

namespace JZsGreen.Controllers
{
    public class ProductController : Controller
    {
        private readonly JZenoDbContext _context;

        public ProductController(JZenoDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index(string id, string searchName,string discount, int? page)
        {
            ViewData["GetData"] = searchName;
            ViewData["GetDiscount"] = discount;
            ViewData["GetPro"] = await _context.Category.Include(e => e.CategoryChild).ToListAsync();
            var product = from b in _context.Product
                          select b;
            if (searchName != null && id == null && discount == null)
            {
                product = product.Where(e => e.name!.Contains(searchName));
            }
            else if (searchName == null && id != null  && discount == null)
            {
                ViewData["GetTitle"] = id;
                product = product.Where(e => e.Category!.name!.Contains(id));
            }
            else if (searchName != null && id == null && discount == null)
            {
                product = product.Where(e => e.name!.Contains(searchName) && e.Category!.name!.Contains(id!));
            }
            else if (searchName == null && id == null && discount != null)
            {
                product = product.Where(e => e.discount > 0);
            }
            else if (searchName == null && id != null && discount != null)
            {
                ViewData["GetTitle"] = id;
                product = product.Where(e => e.discount > 0 && e.Category!.name!.Contains(id));
            }
            else if (searchName != null && id == null && discount != null)
            {
                product = product.Where(e=> e.name!.Contains(searchName) && e.discount > 0);
            }
            else if (searchName != null || id != null || discount != null)
            {
                ViewData["GetTitle"] = id;
                product = product.Where(e => e.name!.Contains(searchName!) && e.discount > 0 && e.Category!.name!.Contains(id!));
            }
            return View(await product.Include(e=>e.images).OrderByDescending(e=>e.isActive).ToPagedListAsync(page ?? 1, 12));

        }
        
        public async Task<JsonResult> GetNameList()
        {
            var productList = await _context.Product.Select(e=>e.name).ToListAsync();
            return Json(productList);
        }
        public async Task<IActionResult> SideBar()
        {
            var category = await _context.Category.OrderByDescending(e=>e.Id).Include(e => e.CategoryChild)!.ThenInclude(e => e.Products).ToListAsync();
            return PartialView("SideBar", category);
        }
        [Route("SanPham/{id}")]
        public async Task<IActionResult> Details(string id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }

            var product = await _context.Product.Include(e => e.Category).ThenInclude(e => e.Products)!.ThenInclude(e => e.images).Include(e => e.images)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }
    }
}
