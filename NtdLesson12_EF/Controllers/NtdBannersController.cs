using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NtdLesson12_EF.Data;
using NtdLesson12_EF.Models;

namespace NtdLesson12_EF.Controllers
{
    public class NtdBannersController : Controller
    {
        private readonly NtdAppDbContext _ntdContext;

        public NtdBannersController(NtdAppDbContext ntdContext)
        {
            _ntdContext = ntdContext;
        }

        // GET: NtdBanners
        public async Task<IActionResult> Index()
        {
            var ntdBanners = await _ntdContext.Banners.OrderByDescending(b => b.Id).ToListAsync();
            return View(ntdBanners);
        }

        // GET: NtdBanners/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdBanner = await _ntdContext.Banners.FirstOrDefaultAsync(m => m.Id == id);
            if (ntdBanner == null)
            {
                return NotFound();
            }

            return View(ntdBanner);
        }

        // GET: NtdBanners/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NtdBanners/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NtdBanner ntdBanner)
        {
            if (ModelState.IsValid)
            {
                var ntdFiles = HttpContext.Request.Form.Files;
                if (ntdFiles.Count > 0 && ntdFiles[0].Length > 0)
                {
                    var ntdFile = ntdFiles[0];
                    var ntdFileName = Guid.NewGuid().ToString("N").Substring(0, 8) + "_" + Path.GetFileName(ntdFile.FileName);
                    var ntdDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Banner");
                    if (!Directory.Exists(ntdDir))
                    {
                        Directory.CreateDirectory(ntdDir);
                    }
                    var ntdPath = Path.Combine(ntdDir, ntdFileName);
                    using (var stream = new FileStream(ntdPath, FileMode.Create))
                    {
                        await ntdFile.CopyToAsync(stream);
                    }
                    ntdBanner.Image = ntdFileName;
                }

                ntdBanner.CreatedDate = DateTime.Now;
                _ntdContext.Add(ntdBanner);
                await _ntdContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ntdBanner);
        }

        // GET: NtdBanners/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdBanner = await _ntdContext.Banners.FindAsync(id);
            if (ntdBanner == null)
            {
                return NotFound();
            }
            return View(ntdBanner);
        }

        // POST: NtdBanners/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NtdBanner ntdBanner)
        {
            if (id != ntdBanner.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var ntdExistingBanner = await _ntdContext.Banners.AsNoTracking().FirstOrDefaultAsync(b => b.Id == id);
                    if (ntdExistingBanner == null)
                    {
                        return NotFound();
                    }

                    var ntdFiles = HttpContext.Request.Form.Files;
                    if (ntdFiles.Count > 0 && ntdFiles[0].Length > 0)
                    {
                        var ntdFile = ntdFiles[0];
                        var ntdFileName = Guid.NewGuid().ToString("N").Substring(0, 8) + "_" + Path.GetFileName(ntdFile.FileName);
                        var ntdDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Banner");
                        if (!Directory.Exists(ntdDir))
                        {
                            Directory.CreateDirectory(ntdDir);
                        }
                        var ntdPath = Path.Combine(ntdDir, ntdFileName);
                        using (var stream = new FileStream(ntdPath, FileMode.Create))
                        {
                            await ntdFile.CopyToAsync(stream);
                        }
                        ntdBanner.Image = ntdFileName;
                    }
                    else
                    {
                        ntdBanner.Image = ntdExistingBanner.Image;
                    }

                    ntdBanner.CreatedDate = ntdExistingBanner.CreatedDate;
                    _ntdContext.Update(ntdBanner);
                    await _ntdContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NtdBannerExists(ntdBanner.Id))
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
            return View(ntdBanner);
        }

        // GET: NtdBanners/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdBanner = await _ntdContext.Banners.FirstOrDefaultAsync(m => m.Id == id);
            if (ntdBanner == null)
            {
                return NotFound();
            }

            return View(ntdBanner);
        }

        // POST: NtdBanners/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ntdBanner = await _ntdContext.Banners.FindAsync(id);
            if (ntdBanner != null)
            {
                _ntdContext.Banners.Remove(ntdBanner);
                await _ntdContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool NtdBannerExists(int id)
        {
            return _ntdContext.Banners.Any(e => e.Id == id);
        }
    }
}
