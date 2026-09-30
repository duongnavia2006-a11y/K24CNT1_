using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NtdLesson12_EF.Data;
using NtdLesson12_EF.Models;

namespace NtdLesson12_EF.Controllers
{
    public class NtdMarksController : Controller
    {
        private readonly NtdAppDbContext _ntdContext;

        public NtdMarksController(NtdAppDbContext ntdContext)
        {
            _ntdContext = ntdContext;
        }

        // GET: NtdMarks
        public async Task<IActionResult> Index()
        {
            var ntdMarks = await _ntdContext.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .ToListAsync();
            return View(ntdMarks);
        }

        // GET: NtdMarks/Create
        public IActionResult Create()
        {
            ViewData["StudentId"] = new SelectList(_ntdContext.Students, "Id", "StudentName");
            ViewData["SubjectId"] = new SelectList(_ntdContext.Subjects, "Id", "SubjectName");
            return View();
        }

        // POST: NtdMarks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SubjectId,StudentId,Score")] NtdMark ntdMark)
        {
            if (await _ntdContext.Marks.AnyAsync(m => m.SubjectId == ntdMark.SubjectId && m.StudentId == ntdMark.StudentId))
            {
                ModelState.AddModelError("", "Sinh viên này đã có điểm môn học này. Hãy dùng chức năng Chỉnh sửa để cập nhật điểm!");
            }

            if (ModelState.IsValid)
            {
                _ntdContext.Add(ntdMark);
                await _ntdContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["StudentId"] = new SelectList(_ntdContext.Students, "Id", "StudentName", ntdMark.StudentId);
            ViewData["SubjectId"] = new SelectList(_ntdContext.Subjects, "Id", "SubjectName", ntdMark.SubjectId);
            return View(ntdMark);
        }

        // GET: NtdMarks/Edit?subjectId=1&studentId=2
        public async Task<IActionResult> Edit(int? subjectId, int? studentId)
        {
            if (subjectId == null || studentId == null)
            {
                return NotFound();
            }

            var ntdMark = await _ntdContext.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.SubjectId == subjectId && m.StudentId == studentId);

            if (ntdMark == null)
            {
                return NotFound();
            }

            return View(ntdMark);
        }

        // POST: NtdMarks/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int subjectId, int studentId, [Bind("SubjectId,StudentId,Score")] NtdMark ntdMark)
        {
            if (subjectId != ntdMark.SubjectId || studentId != ntdMark.StudentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ntdContext.Update(ntdMark);
                    await _ntdContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NtdMarkExists(ntdMark.SubjectId, ntdMark.StudentId))
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
            return View(ntdMark);
        }

        // GET: NtdMarks/Delete?subjectId=1&studentId=2
        public async Task<IActionResult> Delete(int? subjectId, int? studentId)
        {
            if (subjectId == null || studentId == null)
            {
                return NotFound();
            }

            var ntdMark = await _ntdContext.Marks
                .Include(m => m.Student)
                .Include(m => m.Subject)
                .FirstOrDefaultAsync(m => m.SubjectId == subjectId && m.StudentId == studentId);

            if (ntdMark == null)
            {
                return NotFound();
            }

            return View(ntdMark);
        }

        // POST: NtdMarks/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int subjectId, int studentId)
        {
            var ntdMark = await _ntdContext.Marks.FindAsync(subjectId, studentId);
            if (ntdMark != null)
            {
                _ntdContext.Marks.Remove(ntdMark);
                await _ntdContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool NtdMarkExists(int subjectId, int studentId)
        {
            return _ntdContext.Marks.Any(e => e.SubjectId == subjectId && e.StudentId == studentId);
        }
    }
}
