using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NtdLesson12_EF.Data;
using NtdLesson12_EF.Models;

namespace NtdLesson12_EF.Controllers
{
    public class NtdStudentsController : Controller
    {
        private readonly NtdAppDbContext _ntdContext;

        public NtdStudentsController(NtdAppDbContext ntdContext)
        {
            _ntdContext = ntdContext;
        }

        // GET: NtdStudents
        public async Task<IActionResult> Index()
        {
            var ntdStudents = await _ntdContext.Students
                .Include(s => s.StdClass)
                .OrderBy(s => s.Id)
                .ToListAsync();
            return View(ntdStudents);
        }

        // GET: NtdStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdStudent = await _ntdContext.Students
                .Include(s => s.StdClass)
                .Include(s => s.Marks)
                    .ThenInclude(m => m.Subject)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ntdStudent == null)
            {
                return NotFound();
            }

            return View(ntdStudent);
        }

        // GET: NtdStudents/Create
        public IActionResult Create()
        {
            ViewData["ClassId"] = new SelectList(_ntdContext.StdClasses, "Id", "ClassName");
            return View();
        }

        // POST: NtdStudents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(NtdStudent ntdStudent)
        {
            // Kiểm tra trùng email
            if (await _ntdContext.Students.AnyAsync(s => s.StudentEmail == ntdStudent.StudentEmail))
            {
                ModelState.AddModelError("StudentEmail", "Email này đã được sử dụng bởi sinh viên khác.");
            }

            // Kiểm tra trùng số điện thoại
            if (await _ntdContext.Students.AnyAsync(s => s.StudentPhone == ntdStudent.StudentPhone))
            {
                ModelState.AddModelError("StudentPhone", "Số điện thoại này đã được sử dụng.");
            }

            if (ModelState.IsValid)
            {
                _ntdContext.Add(ntdStudent);
                await _ntdContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewData["ClassId"] = new SelectList(_ntdContext.StdClasses, "Id", "ClassName", ntdStudent.ClassId);
            return View(ntdStudent);
        }

        // GET: NtdStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdStudent = await _ntdContext.Students.FindAsync(id);
            if (ntdStudent == null)
            {
                return NotFound();
            }

            ViewData["ClassId"] = new SelectList(_ntdContext.StdClasses, "Id", "ClassName", ntdStudent.ClassId);
            return View(ntdStudent);
        }

        // POST: NtdStudents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, NtdStudent ntdStudent)
        {
            if (id != ntdStudent.Id)
            {
                return NotFound();
            }

            // Kiểm tra trùng email với sinh viên khác
            if (await _ntdContext.Students.AnyAsync(s => s.StudentEmail == ntdStudent.StudentEmail && s.Id != id))
            {
                ModelState.AddModelError("StudentEmail", "Email này đã được sử dụng bởi sinh viên khác.");
            }

            // Kiểm tra trùng số điện thoại với sinh viên khác
            if (await _ntdContext.Students.AnyAsync(s => s.StudentPhone == ntdStudent.StudentPhone && s.Id != id))
            {
                ModelState.AddModelError("StudentPhone", "Số điện thoại này đã được sử dụng.");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _ntdContext.Update(ntdStudent);
                    await _ntdContext.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!NtdStudentExists(ntdStudent.Id))
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

            ViewData["ClassId"] = new SelectList(_ntdContext.StdClasses, "Id", "ClassName", ntdStudent.ClassId);
            return View(ntdStudent);
        }

        // GET: NtdStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ntdStudent = await _ntdContext.Students
                .Include(s => s.StdClass)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ntdStudent == null)
            {
                return NotFound();
            }

            return View(ntdStudent);
        }

        // POST: NtdStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ntdStudent = await _ntdContext.Students.FindAsync(id);
            if (ntdStudent != null)
            {
                _ntdContext.Students.Remove(ntdStudent);
                await _ntdContext.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool NtdStudentExists(int id)
        {
            return _ntdContext.Students.Any(e => e.Id == id);
        }
    }
}
