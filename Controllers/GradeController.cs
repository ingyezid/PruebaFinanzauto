using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFinanzauto.DataContext;
using PruebaFinanzauto.Models;

namespace PruebaFinanzauto.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GradeController : ControllerBase
    {
        private readonly ProjectContext _context;

        public GradeController(ProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Grade>>> GetGrades()
        {
            return await _context.Grades
                                 .Include(g => g.Student)
                                 .Include(g => g.Course)
                                 .ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Grade>> GetGrade(Guid id)
        {
            var grade = await _context.Grades
                                      .Include(g => g.Student)
                                      .Include(g => g.Course)
                                      .FirstOrDefaultAsync(g => g.Id == id);

            if (grade == null)
                return NotFound();

            return grade;
        }

        [HttpPost]
        public async Task<ActionResult<Grade>> PostGrade(Grade grade)
        {
            _context.Grades.Add(grade);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGrade), new { id = grade.Id }, grade);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutGrade(Guid id, Grade grade)
        {
            if (id != grade.Id)
                return BadRequest();

            var gradeFind = await _context.Grades.FindAsync(id);
            if (gradeFind == null)
                return NotFound();

            gradeFind.Score = grade.Score;
            gradeFind.CourseId = grade.CourseId;           
            gradeFind.StudentId = grade.StudentId;
            

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGrade(Guid id)
        {
            var grade = await _context.Grades.FindAsync(id);
            if (grade == null)
                return NotFound();

            _context.Grades.Remove(grade);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
