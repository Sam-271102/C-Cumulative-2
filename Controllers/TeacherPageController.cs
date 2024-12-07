using Microsoft.AspNetCore.Mvc;
using SchoolDatabaseMVP.Models;

public class TeacherPageController : Controller
{
    private readonly SchoolDbContext _context;

    public TeacherPageController(SchoolDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult New()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> New(Teacher teacher)
    {
        if (!ModelState.IsValid)
            return View(teacher);

        await _context.Teachers.AddAsync(teacher);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }

    [HttpGet]
    public async Task<IActionResult> DeleteConfirm(int id)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher == null)
            return NotFound();

        return View(teacher);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher == null)
            return NotFound();

        _context.Teachers.Remove(teacher);
        await _context.SaveChangesAsync();

        return RedirectToAction("Index");
    }
}
