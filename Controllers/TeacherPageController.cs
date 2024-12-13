using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDatabaseMVP.Models;

public class TeacherPageController : Controller
{
    private readonly SchoolDbContext _context;

    public TeacherPageController(SchoolDbContext context)
    {
        _context = context;
    }

    // GET: /Teacher/Edit/5
    [HttpGet]
    public async Task<IActionResult> Edit(int id)
    {
        var teacher = await _context.Teachers.FindAsync(id);
        if (teacher == null)
        {
            return NotFound();
        }
        return View(teacher);
    }

    // POST: /Teacher/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, Teacher teacher)
    {
        if (id != teacher.TeacherId)
        {
            return BadRequest();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(teacher);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Teachers.Any(e => e.TeacherId == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));  // Or wherever you'd like to redirect
        }
        return View(teacher);
    }
}
