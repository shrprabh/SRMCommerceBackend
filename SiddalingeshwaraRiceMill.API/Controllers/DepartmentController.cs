using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiddalingeshwaraRiceMill.API.Models;
using System.Linq;
using System.Threading.Tasks;

namespace SiddalingeshwaraRiceMill.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly SidhalingeswaraRiceMillContext _context;

        public DepartmentController(SidhalingeswaraRiceMillContext context)
        {
            _context = context;
        }

        // GET: api/department
        [HttpGet]
        public async Task<IActionResult> GetAllDepartments()
        {
            var departments = await _context.DepartmentTbls.ToListAsync();
            return Ok(departments);
        }

        // GET: api/department/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDepartmentById(int id)
        {
            var department = await _context.DepartmentTbls.FindAsync(id);

            if (department == null)
            {
                return NotFound();
            }

            return Ok(department);
        }

        // POST: api/department
        [HttpPost]
        public async Task<IActionResult> CreateDepartment([FromBody] DepartmentTbl department)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DepartmentTbls.Add(department);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetDepartmentById), new { id = department.DepartmentId }, department);
        }

        // PUT: api/department/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDepartment(int id, [FromBody] DepartmentTbl department)
        {
            if (id != department.DepartmentId)
            {
                return BadRequest();
            }

            _context.Entry(department).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartmentExists(id))
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

        // DELETE: api/department/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDepartment(int id)
        {
            var department = await _context.DepartmentTbls.FindAsync(id);
            if (department == null)
            {
                return NotFound();
            }

            _context.DepartmentTbls.Remove(department);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool DepartmentExists(int id)
        {
            return _context.DepartmentTbls.Any(e => e.DepartmentId == id);
        }
    }
}
