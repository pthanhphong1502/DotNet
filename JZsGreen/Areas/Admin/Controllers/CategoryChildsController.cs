using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JZsGreen.Data;
using JZsGreen.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace JZsGreen.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class CategoryChildsController : Controller
    {
        private readonly JZenoDbContext _context;

        public CategoryChildsController(JZenoDbContext context)
        {
            _context = context;
        }

        [Route("Admin/CategoryChilds")]
        public async Task<IActionResult> Index()
        {
            var jZenoDbContext = _context.CategoryChildren.Include(c => c.Category);
            return View(await jZenoDbContext.ToListAsync());
        }


        [Route("Admin/CategoryChilds/Create")]
        public IActionResult Create()
        {
            ViewData["categoryId"] = new SelectList(_context.Category, "Id", "name");
            return View();
        }

        [Route("Admin/CategoryChilds/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,categoryId")] CategoryChild categoryChild)
        {
            if (ModelState.IsValid)
            {
                categoryChild.Id = categoryChild.name;
                _context.Add(categoryChild);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["categoryId"] = new SelectList(_context.Category, "Id", "name", categoryChild.categoryId);
            return View(categoryChild);
        }

        [Route("Admin/CategoryChilds/Edit/{id?}")]

        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.CategoryChildren == null)
            {
                return NotFound();
            }

            var categoryChild = await _context.CategoryChildren.FindAsync(id);
            if (categoryChild == null)
            {
                return NotFound();
            }
            ViewData["categoryId"] = new SelectList(_context.Category, "Id", "name", categoryChild.categoryId);
            return View(categoryChild);
        }

        [Route("Admin/CategoryChilds/Edit/{id?}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,name,categoryId")] CategoryChild categoryChild)
        {
            if (id != categoryChild.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(categoryChild);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CategoryChildExists(categoryChild.Id!))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["categoryId"] = new SelectList(_context.Category, "Id", "name", categoryChild.categoryId);
            return View(categoryChild);
        }

        [Route("Admin/CategoryChilds/Delete/{id?}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.CategoryChildren == null)
            {
                return NotFound();
            }

            var categoryChild = await _context.CategoryChildren
                .Include(c => c.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (categoryChild == null)
            {
                return NotFound();
            }

            return View(categoryChild);
        }

        [Route("Admin/CategoryChilds/Delete/{id?}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.CategoryChildren == null)
            {
                return Problem("Entity set 'JZenoDbContext.CategoryChildren'  is null.");
            }
            var categoryChild = await _context.CategoryChildren.FindAsync(id);
            if (categoryChild != null)
            {
                _context.CategoryChildren.Remove(categoryChild);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CategoryChildExists(string id)
        {
          return (_context.CategoryChildren?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
