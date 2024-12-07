using Microsoft.AspNetCore.Mvc;
using SchoolDatabaseMVP.Models;

[Route("api/[controller]")]
[ApiController]
public class TeacherAPIController : ControllerBase
{
    private readonly SchoolDbContext _context;

    public TeacherAPIController(SchoolDbContext context)
    {
        _context = context;
    }

    [HttpPost]
    public async Task<IActionResult> AddTeacher([FromBody] Teacher teacher)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        await _context.Teachers.AddAsync(teacher);
        await _context.SaveChangesAsync();

        return Ok(teacher);
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteTeacher(int id)
    {
        var teacher = await _context.Teachers.FindAsync(id);

        if (teacher == null)
            return NotFound(new { Message = "Teacher not found." });

        _context.Teachers.Remove(teacher);
        await _context.SaveChangesAsync();

        return Ok(new { Message = "Teacher deleted successfully." });
    }
}
