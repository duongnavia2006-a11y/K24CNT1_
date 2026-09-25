using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NtdLesson10EFDbFirst.Models;

namespace NtdLesson10EFDbFirst.Controllers;

public class NtdMembersController : Controller
{
    private readonly NtdK24cntt2lesson10EFdbContext _context;

    public NtdMembersController(NtdK24cntt2lesson10EFdbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Index()
    {
        return View(await _context.NtdMembers.ToListAsync());
    }

    public async Task<IActionResult> Details(int? id)
    {
        if (id == null) return NotFound();
        var member = await _context.NtdMembers.FirstOrDefaultAsync(x => x.NtdMemberId == id);
        if (member == null) return NotFound();
        return View(member);
    }

    public IActionResult Create() => View();

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(NtdMember member)
    {
        if (!ModelState.IsValid) return View(member);
        _context.Add(member);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null) return NotFound();
        var member = await _context.NtdMembers.FindAsync(id);
        if (member == null) return NotFound();
        return View(member);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, NtdMember member)
    {
        if (id != member.NtdMemberId) return NotFound();
        if (!ModelState.IsValid) return View(member);
        _context.Update(member);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null) return NotFound();
        var member = await _context.NtdMembers.FirstOrDefaultAsync(x => x.NtdMemberId == id);
        if (member == null) return NotFound();
        return View(member);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var member = await _context.NtdMembers.FindAsync(id);
        if (member != null)
        {
            _context.NtdMembers.Remove(member);
            await _context.SaveChangesAsync();
        }
        return RedirectToAction(nameof(Index));
    }
}
