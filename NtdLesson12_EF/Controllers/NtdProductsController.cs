using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NtdLesson12_EF.Data;
using NtdLesson12_EF.Models;

namespace NtdLesson12_EF.Controllers
{
    public class NtdProductsController : Controller
    {
        private readonly NtdAppDbContext _ntdContext;

        public NtdProductsController(NtdAppDbContext ntdContext)
        {
            _ntdContext = ntdContext;
        }

        // GET: NtdProducts
        public async Task<IActionResult> Index()
        {
            var ntdProducts = await _ntdContext.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.Id)
                .ToListAsync();
            return View(ntdProducts);
        }

        // GET: NtdProducts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdProduct = await _ntdContext.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ntdProduct == null)
            {
                return NotFound();
            }

            return View(ntdProduct);
        }

        // GET: NtdProducts/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_ntdContext.Categories, "Id", "Name");
            return View();
        }

        // POST: NtdProducts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NtdProduct ntdProduct)
        {
            if (ModelState.IsValid)
            {
                // Upload file ảnh vào thư mục wwwroot/Product theo đúng slide Lab 06
                var ntdFiles = HttpContext.Request.Form.Files;
                if (ntdFiles.Count > 0 && ntdFiles[0].Length > 0)
                {
                    var ntdFile = ntdFiles[0];
                    var ntdFileName = Guid.NewGuid().ToString("N").Substring(0, 8) + "_" + Path.GetFileName(ntdFile.FileName);
                    var ntdDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Product");
                    if (!Directory.Exists(ntdDir))
                    {
                        Directory.CreateDirectory(ntdDir);
                    }
                    var ntdPath = Path.Combine(ntdDir, ntdFileName);
                    using (var stream = new FileStream(ntdPath, FileMode.Create))
                    {
                        await ntdFile.CopyToAsync(stream);
                    }
                    ntdProduct.Image = ntdFileName;
                }

                ntdProduct.CreatedDate = DateTime.Now;
                _ntdContext.Add(ntdProduct);
                await _ntdContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["CategoryId"] = new SelectList(_ntdContext.Categories, "Id", "Name", ntdProduct.CategoryId);
            return View(ntdProduct);
        }

        // GET: NtdProducts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdProduct = await _ntdContext.Products.FindAsync(id);
            if (ntdProduct == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_ntdContext.Categories, "Id", "Name", ntdProduct.CategoryId);
            return View(ntdProduct);
        }

        // POST: NtdProducts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NtdProduct ntdProduct)
        {
            if (id != ntdProduct.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ntdExistingProduct = await _ntdContext.Products.AsNoTracking().FirstOrDefaultAsync(p => p.Id == id);
                    if (ntdExistingProduct == null)
                    {
                        return NotFound();
                    }

                    var ntdFiles = HttpContext.Request.Form.Files;
                    if (ntdFiles.Count > 0 && ntdFiles[0].Length > 0)
                    {
                        var ntdFile = ntdFiles[0];
                        var ntdFileName = Guid.NewGuid().ToString("N").Substring(0, 8) + "_" + Path.GetFileName(ntdFile.FileName);
                        var ntdDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Product");
                        if (!Directory.Exists(ntdDir))
                        {
                            Directory.CreateDirectory(ntdDir);
                        }
                        var ntdPath = Path.Combine(ntdDir, ntdFileName);
                        using (var stream = new FileStream(ntdPath, FileMode.Create))
                        {
                            await ntdFile.CopyToAsync(stream);
                        }
                        ntdProduct.Image = ntdFileName;
                    }
                    else
                    {
                        // Giữ lại ảnh cũ nếu không tải ảnh mới
                        ntdProduct.Image = ntdExistingProduct.Image;
                    }

                    ntdProduct.CreatedDate = ntdExistingProduct.CreatedDate;
                    _ntdContext.Update(ntdProduct);
                    await _ntdContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NtdProductExists(ntdProduct.Id))
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

            ViewData["CategoryId"] = new SelectList(_ntdContext.Categories, "Id", "Name", ntdProduct.CategoryId);
            return View(ntdProduct);
        }

        // GET: NtdProducts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdProduct = await _ntdContext.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ntdProduct == null)
            {
                return NotFound();
            }

            return View(ntdProduct);
        }

        // POST: NtdProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ntdProduct = await _ntdContext.Products.FindAsync(id);
            if (ntdProduct != null)
            {
                _ntdContext.Products.Remove(ntdProduct);
                await _ntdContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool NtdProductExists(int id)
        {
            return _ntdContext.Products.Any(e => e.Id == id);
        }
    }
}
