using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NtdLesson14.Data;

namespace NtdLesson14.Controllers;

public abstract class NtdCrudController<TNtdEntity> : Controller where TNtdEntity : class
{
    protected readonly NtdStoreDbContext NtdContext;
    protected abstract DbSet<TNtdEntity> NtdEntities { get; }

    protected NtdCrudController(NtdStoreDbContext ntdContext)
    {
        NtdContext = ntdContext;
    }

    [HttpGet]
    [ActionName("Index")]
    public virtual async Task<IActionResult> NtdIndex()
    {
        return View(await NtdEntities.AsNoTracking().ToListAsync());
    }

    [HttpGet]
    [ActionName("Create")]
    public virtual IActionResult NtdCreate()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Create")]
    public virtual async Task<IActionResult> NtdCreate(TNtdEntity ntdEntity)
    {
        if (!ModelState.IsValid)
        {
            return View(ntdEntity);
        }

        NtdEntities.Add(ntdEntity);
        try
        {
            await NtdContext.SaveChangesAsync();
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError(string.Empty, "Dữ liệu đã tồn tại hoặc chưa hợp lệ.");
            return View(ntdEntity);
        }

        TempData["NtdSuccessMessage"] = "Đã thêm dữ liệu thành công.";
        return RedirectToAction("Index");
    }

    [HttpGet]
    [ActionName("Edit")]
    public virtual async Task<IActionResult> NtdEdit(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var ntdEntity = await NtdEntities.FindAsync(id.Value);
        return ntdEntity is null ? NotFound() : View(ntdEntity);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [ActionName("Edit")]
    public virtual async Task<IActionResult> NtdEdit(int id, TNtdEntity ntdEntity)
    {
        if (!ModelState.IsValid)
        {
            return View(ntdEntity);
        }

        var ntdEntry = NtdContext.Entry(ntdEntity);
        ntdEntry.State = EntityState.Modified;
        try
        {
            await NtdContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!await NtdEntities.AnyAsync(ntdItem => EF.Property<int>(ntdItem, "NtdId") == id))
            {
                return NotFound();
            }

            throw;
        }
        catch (DbUpdateException)
        {
            ModelState.AddModelError(string.Empty, "Dữ liệu đã tồn tại hoặc chưa hợp lệ.");
            return View(ntdEntity);
        }

        TempData["NtdSuccessMessage"] = "Đã cập nhật dữ liệu thành công.";
        return RedirectToAction("Index");
    }

    [HttpGet]
    [ActionName("Delete")]
    public virtual async Task<IActionResult> NtdDelete(int? id)
    {
        if (id is null)
        {
            return NotFound();
        }

        var ntdEntity = await NtdEntities.AsNoTracking()
            .FirstOrDefaultAsync(ntdItem => EF.Property<int>(ntdItem, "NtdId") == id.Value);
        return ntdEntity is null ? NotFound() : View(ntdEntity);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public virtual async Task<IActionResult> NtdDeleteConfirmed(int id)
    {
        var ntdEntity = await NtdEntities.FindAsync(id);
        if (ntdEntity is not null)
        {
            NtdEntities.Remove(ntdEntity);
            try
            {
                await NtdContext.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                NtdContext.Entry(ntdEntity).State = EntityState.Unchanged;
                TempData["NtdErrorMessage"] = "Không thể xóa dữ liệu đang được mục khác sử dụng.";
                return RedirectToAction("Index");
            }
        }

        TempData["NtdSuccessMessage"] = "Đã xóa dữ liệu thành công.";
        return RedirectToAction("Index");
    }
}
