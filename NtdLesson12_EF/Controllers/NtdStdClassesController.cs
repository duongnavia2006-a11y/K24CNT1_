using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NtdLesson12_EF.Data;
using NtdLesson12_EF.Models;

namespace NtdLesson12_EF.Controllers
{
    public class NtdStdClassesController : Controller
    {
        private readonly NtdAppDbContext _ntdContext;

        public NtdStdClassesController(NtdAppDbContext ntdContext)
        {
            _ntdContext = ntdContext;
        }

        // GET: NtdStdClasses
        public async Task<IActionResult> Index()
        {
            var ntdClasses = await _ntdContext.StdClasses
                .Include(c => c.Students)
                .OrderBy(c => c.Id)
                .ToListAsync();
            return View(ntdClasses);
        }

        // GET: NtdStdClasses/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdClass = await _ntdContext.StdClasses
                .Include(c => c.Students)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ntdClass == null)
            {
                return NotFound();
            }

            return View(ntdClass);
        }

        // GET: NtdStdClasses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NtdStdClasses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClassName")] NtdStdClass ntdStdClass)
        {
            if (ModelState.IsValid)
            {
                _ntdContext.Add(ntdStdClass);
                await _ntdContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ntdStdClass);
        }

        // GET: NtdStdClasses/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdClass = await _ntdContext.StdClasses.FindAsync(id);
            if (ntdClass == null)
            {
                return NotFound();
            }
            return View(ntdClass);
        }

        // POST: NtdStdClasses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClassName")] NtdStdClass ntdStdClass)
        {
            if (id != ntdStdClass.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ntdContext.Update(ntdStdClass);
                    await _ntdContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NtdStdClassExists(ntdStdClass.Id))
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
            return View(ntdStdClass);
        }

        // GET: NtdStdClasses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdClass = await _ntdContext.StdClasses
                .Include(c => c.Students)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ntdClass == null)
            {
                return NotFound();
            }

            return View(ntdClass);
        }

        // POST: NtdStdClasses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ntdClass = await _ntdContext.StdClasses.FindAsync(id);
            if (ntdClass != null)
            {
                _ntdContext.StdClasses.Remove(ntdClass);
                await _ntdContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool NtdStdClassExists(int id)
        {
            return _ntdContext.StdClasses.Any(e => e.Id == id);
        }
    }
}
