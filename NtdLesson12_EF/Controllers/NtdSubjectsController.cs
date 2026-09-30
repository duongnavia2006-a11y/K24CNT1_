using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NtdLesson12_EF.Data;
using NtdLesson12_EF.Models;

namespace NtdLesson12_EF.Controllers
{
    public class NtdSubjectsController : Controller
    {
        private readonly NtdAppDbContext _ntdContext;

        public NtdSubjectsController(NtdAppDbContext ntdContext)
        {
            _ntdContext = ntdContext;
        }

        // GET: NtdSubjects
        public async Task<IActionResult> Index()
        {
            var ntdSubjects = await _ntdContext.Subjects.OrderBy(s => s.Id).ToListAsync();
            return View(ntdSubjects);
        }

        // GET: NtdSubjects/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: NtdSubjects/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SubjectName")] NtdSubject ntdSubject)
        {
            if (await _ntdContext.Subjects.AnyAsync(s => s.SubjectName == ntdSubject.SubjectName))
            {
                ModelState.AddModelError("SubjectName", "Tên môn học này đã tồn tại.");
            }

            if (ModelState.IsValid)
            {
                _ntdContext.Add(ntdSubject);
                await _ntdContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ntdSubject);
        }

        // GET: NtdSubjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdSubject = await _ntdContext.Subjects.FindAsync(id);
            if (ntdSubject == null)
            {
                return NotFound();
            }
            return View(ntdSubject);
        }

        // POST: NtdSubjects/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SubjectName")] NtdSubject ntdSubject)
        {
            if (id != ntdSubject.Id)
            {
                return NotFound();
            }

            if (await _ntdContext.Subjects.AnyAsync(s => s.SubjectName == ntdSubject.SubjectName && s.Id != id))
            {
                ModelState.AddModelError("SubjectName", "Tên môn học này đã tồn tại.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ntdContext.Update(ntdSubject);
                    await _ntdContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NtdSubjectExists(ntdSubject.Id))
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
            return View(ntdSubject);
        }

        // GET: NtdSubjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdSubject = await _ntdContext.Subjects.FirstOrDefaultAsync(m => m.Id == id);
            if (ntdSubject == null)
            {
                return NotFound();
            }

            return View(ntdSubject);
        }

        // POST: NtdSubjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ntdSubject = await _ntdContext.Subjects.FindAsync(id);
            if (ntdSubject != null)
            {
                _ntdContext.Subjects.Remove(ntdSubject);
                await _ntdContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool NtdSubjectExists(int id)
        {
            return _ntdContext.Subjects.Any(e => e.Id == id);
        }
    }
}
