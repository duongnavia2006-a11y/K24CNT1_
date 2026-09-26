using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NguyenTungDuong2410900017_exam.Models;

namespace NguyenTungDuong2410900017_exam.Controllers
{
    public class NtdStudentsController : Controller
    {
        private readonly NguyenTungDuong2410900017DbContext _context;

        public NtdStudentsController(NguyenTungDuong2410900017DbContext context)
        {
            _context = context;
        }

        // GET: NtdStudents
        public async Task<IActionResult> Index()
        {
            var students = await _context.NtdStudents.OrderBy(s => s.Id).ToListAsync();
            return View(students);
        }

        // GET: NtdStudents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.NtdStudents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: NtdStudents/Create
        public IActionResult Create()
        {
            // Giá trị mặc định khi tạo mới: Nam (true), Đang học (true)
            var newStudent = new NtdStudent
            {
                NtdGender = true,
                NtdActive = true
            };
            return View(newStudent);
        }

        // POST: NtdStudents/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,NtdName,NtdGender,NtdBirthDay,NtdEmail,NtdPhone,NtdActive")] NtdStudent ntdStudent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ntdStudent);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Thêm mới sinh viên thành công!";
                return RedirectToAction(nameof(Index));
            }
            return View(ntdStudent);
        }

        // GET: NtdStudents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.NtdStudents.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: NtdStudents/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NtdName,NtdGender,NtdBirthDay,NtdEmail,NtdPhone,NtdActive")] NtdStudent ntdStudent)
        {
            if (id != ntdStudent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ntdStudent);
                    await _context.SaveChangesAsync();
                    TempData["SuccessMessage"] = "Cập nhật sinh viên thành công!";
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
            return View(ntdStudent);
        }

        // GET: NtdStudents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.NtdStudents
                .FirstOrDefaultAsync(m => m.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: NtdStudents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.NtdStudents.FindAsync(id);
            if (student != null)
            {
                _context.NtdStudents.Remove(student);
                await _context.SaveChangesAsync();
                TempData["SuccessMessage"] = "Xóa sinh viên thành công!";
            }

            return RedirectToAction(nameof(Index));
        }

        private bool NtdStudentExists(int id)
        {
            return _context.NtdStudents.Any(e => e.Id == id);
        }
    }
}
