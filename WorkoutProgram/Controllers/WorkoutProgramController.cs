
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WorkoutProgram.Models;

namespace WorkoutProgram.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkoutProgramController : ControllerBase
    {
        private readonly WorkoutProgramContext _context;

        public WorkoutProgramController(WorkoutProgramContext context)
        {
            _context = context;
        }

        // GET: api/WorkoutProgram
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Models.WorkoutProgram>>> GetWorkoutPrograms()
        {
            return await _context.WorkoutPrograms.ToListAsync();
        }

        // GET: api/WorkoutProgram/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Models.WorkoutProgram>> GetWorkoutProgram(int id)
        {
            var program = await _context.WorkoutPrograms.FindAsync(id);

            if (program == null)
            {
                return NotFound();
            }

            return program;
        }

        // POST: api/WorkoutProgram
        [HttpPost]
        public async Task<ActionResult<Models.WorkoutProgram>> PostWorkoutProgram(
            Models.WorkoutProgram program)
        {
            _context.WorkoutPrograms.Add(program);
            await _context.SaveChangesAsync();

            return CreatedAtAction(
                nameof(GetWorkoutProgram),
                new { id = program.Id },
                program);
        }

        // PUT: api/WorkoutProgram/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutWorkoutProgram(
            int id,
            Models.WorkoutProgram program)
        {
            if (id != program.Id)
            {
                return BadRequest();
            }

            _context.Entry(program).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await WorkoutProgramExists(id))
                {
                    return NotFound();
                }

                throw;
            }

            return NoContent();
        }

        // DELETE: api/WorkoutProgram/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteWorkoutProgram(int id)
        {
            var program = await _context.WorkoutPrograms.FindAsync(id);

            if (program == null)
            {
                return NotFound();
            }

            _context.WorkoutPrograms.Remove(program);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private async Task<bool> WorkoutProgramExists(int id)
        {
            return await _context.WorkoutPrograms.AnyAsync(e => e.Id == id);
        }
    }
}
