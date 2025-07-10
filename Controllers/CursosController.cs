using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EXAMEN_PARCIAL.Data; 
using EXAMEN_PARCIAL.Models;

namespace EXAMEN_PARCIAL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CursosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/cursos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursos()
        {
            return await _context.Cursos.ToListAsync();
        }

        // GET: api/cursos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> GetCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);

            if (curso == null)
            {
                return NotFound();
            }

            return curso;
        }

        // GET: api/cursos/{ciclo}
        [HttpGet("ciclo/{ciclo}")]
        public async Task<ActionResult<IEnumerable<Curso>>> GetCursosByCiclo(string ciclo)
        {
            var cursos = await _context.Cursos.Where(c => c.Ciclo == ciclo).ToListAsync();

            if (cursos == null || cursos.Count == 0)
            {
                return NotFound();
            }

            return cursos;
        }

        // POST: api/cursos
        [HttpPost]
        public async Task<ActionResult<Curso>> PostCurso(Curso curso)
        {
            _context.Cursos.Add(curso);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCurso), new { id = curso.Id }, curso);
        }

        // PUT: api/cursos/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCurso(int id, Curso curso)
        {
            if (id != curso.Id)
            {
                return BadRequest();
            }

            _context.Entry(curso).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/cursos/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCurso(int id)
        {
            var curso = await _context.Cursos.FindAsync(id);
            if (curso == null)
            {
                return NotFound();
            }

            _context.Cursos.Remove(curso);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
