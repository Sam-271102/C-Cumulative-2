using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolDatabaseMVP.Models;

[ApiController]
[Route("api/[controller]")]
public class TeacherAPIController : ControllerBase
{
    private readonly SchoolDbContext _context;

    public TeacherAPIController(SchoolDbContext context)
    {
        _context = context;
    }

    // PUT: api/TeacherAPI/5
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateTeacher(int id, Teacher teacher)
    {
        if (id != teacher.TeacherId)
        {
            return BadRequest("Teacher ID mismatch.");
        }

        var existingTeacher = await _context.Teachers.FindAsync(id);
        if (existingTeacher == null)
        {
            return NotFound("Teacher not found.");
        }

        // Update the teacher fields
        existingTeacher.TeacherFname = teacher.TeacherFname;
        existingTeacher.TeacherLname = teacher.TeacherLname;
        existingTeacher.EmployeeNumber = teacher.EmployeeNumber;
        existingTeacher.HireDate = teacher.HireDate;
        existingTeacher.Salary = teacher.Salary;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Teachers.Any(e => e.TeacherId == id))
            {
                return NotFound("Teacher not found.");
            }
            else
            {
                throw;
            }
        }

        return NoContent();  // Successfully updated
    }
}
