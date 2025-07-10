using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EXAMEN_PARCIAL.Data;
using EXAMEN_PARCIAL.Models;

namespace EXAMEN_PARCIAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DocentesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public DocentesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/docentes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Docente>>> GetDocentes()
        {
            return await _context.Docentes.ToListAsync();
        }

        // GET: api/docentes/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Docente>> GetDocente(int id)
        {
            var docente = await _context.Docentes.FindAsync(id);

            if (docente == null)
            {
                return NotFound();
            }

            return docente;
        }

        // POST: api/docentes
        [HttpPost]
        public async Task<ActionResult<Docente>> PostDocente(Docente docente)
        {
            _context.Docentes.Add(docente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDocente), new { id = docente.Id }, docente);
        }

        // PUT: api/docentes/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutDocente(int id, Docente docente)
        {
            if (id != docente.Id)
            {
                return BadRequest();
            }

            _context.Entry(docente).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/docentes/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocente(int id)
        {
            var docente = await _context.Docentes.FindAsync(id);
            if (docente == null)
            {
                return NotFound();
            }

            _context.Docentes.Remove(docente);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
