using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PruebaFinanzauto.DataContext;
using PruebaFinanzauto.Models;

namespace PruebaFinanzauto.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {

        private readonly ProjectContext _context;

        public CourseController(ProjectContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Course>>> GetCourses()
        {
            return await _context.Courses.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Course>> GetCourse(Guid id)
        {
            var course = await _context.Courses.FindAsync(id);

            if (course == null)
                return NotFound();

            return course;
        }

        [HttpPost]
        public async Task<ActionResult<Course>> PostCourse(Course course)
        {
            _context.Courses.Add(course);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCourse), new { id = course.Id }, course);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutCourse(Guid id, Course course)
        {
            if (id != course.Id)
                return BadRequest();

            var courseFind = await _context.Courses.FindAsync(id);
            if (courseFind == null)
                return NotFound();

            courseFind.Name = course.Name;
            courseFind.Description = course.Description;
            courseFind.Credits = course.Credits;
            courseFind.TeacherId = course.TeacherId;
            courseFind.Grades = course.Grades;

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(Guid id)
        {
            var course = await _context.Courses.FindAsync(id);
            if (course == null)
                return NotFound();

            _context.Courses.Remove(course);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

