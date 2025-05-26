using GerenciamentoTimes.Data;
using GerenciamentoTimes.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GerenciamentoTimes.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class JogadoresController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JogadoresController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Jogador>>> Get()
        {
            return await _context.Jogadores.Include(j => j.Time).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Jogador>> Get(int id)
        {
            var jogador = await _context.Jogadores.Include(j => j.Time).FirstOrDefaultAsync(j => j.Id == id);
            if (jogador == null) return NotFound();
            return jogador;
        }

        [HttpGet("por-nome/{nome}")]
        public async Task<ActionResult<IEnumerable<Jogador>>> GetPorNome(string nome)
        {
            return await _context.Jogadores
                .Where(j => j.Nome.ToLower().Contains(nome.ToLower()))
                .Include(j => j.Time)
                .ToListAsync();
        }

        [HttpPost]
        public async Task<ActionResult<Jogador>> Post(Jogador jogador)
        {
            _context.Jogadores.Add(jogador);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(Get), new { id = jogador.Id }, jogador);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var jogador = await _context.Jogadores.FindAsync(id);
            if (jogador == null) return NotFound();

            _context.Jogadores.Remove(jogador);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
