using GerenciamentoTimes.Data;
using GerenciamentoTimes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTimes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TimesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public TimesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Time>>> Get()
        {
            return await _context.Times.Include(t => t.Jogadores).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Time>> Get(int id)
        {
            var time = await _context.Times.Include(t => t.Jogadores).FirstOrDefaultAsync(t => t.Id == id);
            if (time == null) return NotFound();
            return time;
        }

        [HttpPost]
        public async Task<ActionResult<Time>> Post(Time time)
        {
            _context.Times.Add(time);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = time.Id }, time);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var time = await _context.Times.FindAsync(id);
            if (time == null) return NotFound();

            _context.Times.Remove(time);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
