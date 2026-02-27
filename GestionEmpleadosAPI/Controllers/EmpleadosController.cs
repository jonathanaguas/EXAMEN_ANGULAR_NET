using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GestionEmpleadosAPI.Data;
using GestionEmpleadosAPI.Models;

namespace GestionEmpleadosAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmpleadosController : ControllerBase
    {
        private readonly GestionContext _context;

        public EmpleadosController(GestionContext context)
        {
            _context = context;
        }

        // GET: api/empleados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empleado>>> GetEmpleados()
        {
            return await _context.Empleados
                                 .Include(e => e.Departamento) // incluir datos del departamento
                                 .ToListAsync();
        }

        // GET: api/empleados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empleado>> GetEmpleado(int id)
        {
            var empleado = await _context.Empleados
                                         .Include(e => e.Departamento)
                                         .FirstOrDefaultAsync(e => e.empleado_id == id);

            if (empleado == null)
            {
                return NotFound();
            }

            return empleado;
        }

        // POST: api/empleados
        [HttpPost]
        public async Task<ActionResult<Empleado>> PostEmpleado(Empleado empleado)
        {
            _context.Empleados.Add(empleado);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmpleado), new { id = empleado.empleado_id }, empleado);
        }

        // PUT: api/empleados/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpleado(int id, Empleado empleado)
        {
            if (id != empleado.empleado_id)
            {
                return BadRequest();
            }

            _context.Entry(empleado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!_context.Empleados.Any(e => e.empleado_id == id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/empleados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpleado(int id)
        {
            var empleado = await _context.Empleados.FindAsync(id);
            if (empleado == null)
            {
                return NotFound();
            }

            _context.Empleados.Remove(empleado);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}