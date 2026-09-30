using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NtdLesson12_EF.Data;
using NtdLesson12_EF.Models;

namespace NtdLesson12_EF.Controllers
{
    public class NtdCategoriesController : Controller
    {
        private readonly NtdAppDbContext _ntdContext;

        public NtdCategoriesController(NtdAppDbContext ntdContext)
        {
            _ntdContext = ntdContext;
        }

        // GET: NtdCategories
        public async Task<IActionResult> Index()
        {
            var ntdCategories = await _ntdContext.Categories.ToListAsync();
            return View(ntdCategories);
        }

        // GET: NtdCategories/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdCategory = await _ntdContext.Categories
                .Include(c => c.Products)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (ntdCategory == null)
            {
                return NotFound();
            }

            return View(ntdCategory);
        }

        // GET: NtdCategories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NtdCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Status")] NtdCategory ntdCategory)
        {
            if (ModelState.IsValid)
            {
                ntdCategory.CreatedDate = DateTime.Now;
                _ntdContext.Add(ntdCategory);
                await _ntdContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ntdCategory);
        }

        // GET: NtdCategories/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdCategory = await _ntdContext.Categories.FindAsync(id);
            if (ntdCategory == null)
            {
                return NotFound();
            }
            return View(ntdCategory);
        }

        // POST: NtdCategories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Status")] NtdCategory ntdCategory)
        {
            if (id != ntdCategory.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    ntdCategory.CreatedDate = DateTime.Now;
                    _ntdContext.Update(ntdCategory);
                    await _ntdContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NtdCategoryExists(ntdCategory.Id))
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
            return View(ntdCategory);
        }

        // GET: NtdCategories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdCategory = await _ntdContext.Categories
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ntdCategory == null)
            {
                return NotFound();
            }

            return View(ntdCategory);
        }

        // POST: NtdCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ntdCategory = await _ntdContext.Categories.FindAsync(id);
            if (ntdCategory != null)
            {
                _ntdContext.Categories.Remove(ntdCategory);
                await _ntdContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool NtdCategoryExists(int id)
        {
            return _ntdContext.Categories.Any(e => e.Id == id);
        }
    }
}
