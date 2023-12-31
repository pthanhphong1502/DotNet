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
using X.PagedList;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.OutputCaching;

namespace JZsGreen.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class ProductsController : Controller
    {

        private readonly JZenoDbContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductsController(JZenoDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        [Route("Admin/Products")]
        [OutputCache(NoStore = true, Duration = 10)]
        public async Task<IActionResult> Index()
        {
            var product = await _context.Product.Include(e => e.Category).ToListAsync();
            return View(product);
        }

        [Route("Admin/Products/Create")]
        public IActionResult Create()
        {
            Product product = new Product();
            var autoID = _context.Product.OrderByDescending(c => c.Id).FirstOrDefault();
            var lPro = _context.Product.ToList();
            if (autoID == null)
            {
                product.Id = "JZENO1";
            }
            else
            {
                product.Id = "JZENO" + (lPro.Count + 1).ToString();
            }
            ViewData["categoryID"] = new SelectList(_context.CategoryChildren, "Id", "name");
            return View(product);
        }

        [Route("Admin/Products/Create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,name,price,unit,quantity,discount,totalPrice,isActive,summary,description,files,categoryId")] Product product)
        {
            foreach (var item in product.files!)
            {
                string stringFileName = UploadFile(item);
                var productImgs = new ProductImage
                {
                    id = Guid.NewGuid().ToString(),
                    fileName = stringFileName,
                    Product = product
                };
                _context.Add(productImgs);
            }

            if (ModelState.IsValid)
            {
                if (product.discount == null) product.discount = 0;
                if (product.description == null) product.description = "Chưa cập nhật";
                if (product.price < 0) product.price = Math.Abs(product.price.Value);
                product.isActive = true;
                product.dateCreated = DateTime.Now;
                product.totalPrice = product.price - (product.price * (product.discount / 100));
                _context.Add(product);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["categoryID"] = new SelectList(_context.CategoryChildren, "Id", "name");
            return View(product);
        }

        [Route("Admin/Products/Edit/{id?}")]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }
            var product = await _context.Product.Include(e => e.images).FirstOrDefaultAsync(i => i.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            ViewData["categoryID"] = new SelectList(_context.CategoryChildren, "Id", "name");
            return View(product);
        }


        [Route("Admin/Products/Edit/{id?}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,name,unit,price,quantity,discount,totalPrice,isActive,summary,description,files,categoryId")] Product product)
        {
            if (id != product.Id)
            {
                return NotFound();
            }
            var productImg = _context.ProductImage.Where(m => m.productId == id);
            if (productImg != null)
            {
                foreach (var item in productImg)
                {
                    if (!product.files!.IsNullOrEmpty())
                    {
                        DeleteFile(item.fileName!);
                        _context.Remove(item);
                    }
                }
            }
            foreach (var item in product.files!)
            {
                string stringFileName = UploadFile(item);
                var productImgs = new ProductImage
                {
                    id = Guid.NewGuid().ToString(),
                    fileName = stringFileName,
                    productId = product.Id
                };
                _context.Add(productImgs);
            }
            if (ModelState.IsValid)
            {
                try
                {
                    product.dateCreated = DateTime.Now;
                    product.totalPrice = product.price - (product.price * (product.discount / 100));
                    if (product.quantity > 0)
                    {
                        product.isActive = true;
                    }
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductExists(product.Id))
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
            ViewData["categoryID"] = new SelectList(_context.CategoryChildren, "Id", "name");
            return View(product);
        }
        [Route("/Admin/Products/updateActive/{id?}")]
        public async Task<JsonResult> updateActive(string id)
        {
            var product = await _context.Product.FindAsync(id);

            if (ModelState.IsValid)
            {
                try
                {
                    if (product!.isActive == null) product.isActive = true;
                    else product!.isActive = !product!.isActive;
                    product.dateCreated = DateTime.Now;
                    _context.Update(product);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                }
                return Json(product);
            }
            return Json(product);
        }

        [Route("Admin/Products/Delete/{id?}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null || _context.Product == null)
            {
                return NotFound();
            }
            var product = await _context.Product
                .FirstOrDefaultAsync(m => m.Id == id);
            if (product == null)
            {
                return NotFound();
            }

            return View(product);
        }

        [Route("Admin/Products/Delete/{id?}")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.Product == null)
            {
                return Problem("Entity set 'JZenoDbContext.Products'  is null.");
            }
            var proImg = await _context.ProductImage.Where(e => e.productId == id).FirstOrDefaultAsync();
            var product = await _context.Product.FindAsync(id);
            if (product != null)
            {
                _context.ProductImage.Remove(proImg!);
                _context.Product.Remove(product);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductExists(string id)
        {
            return (_context.Product?.Any(e => e.Id == id)).GetValueOrDefault();
        }
        private void DeleteFile(string file)
        {
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\products", file);

            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }
        private string UploadFile(IFormFile file)
        {
            string? fileName = null;
            if (file != null)
            {
                string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/products");
                fileName = Guid.NewGuid().ToString() + "-" + file.FileName;
                string filePath = Path.Combine(uploadDir, fileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(fileStream);
                }
            }
            return fileName!;
        }
    }
}
