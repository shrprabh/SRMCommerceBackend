using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SiddalingeshwaraRiceMill.API.Models;

namespace SiddalingeshwaraRiceMill.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoleController : ControllerBase
    {
        private readonly SidhalingeswaraRiceMillContext _context;

        public RoleController(SidhalingeswaraRiceMillContext context)
        {
            _context = context;
        }

        // GET: api/Role
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoleTbl>>> GetRoles()
        {
            return await _context.RoleTbls.ToListAsync();
        }

        // GET: api/Role/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoleTbl>> GetRole(int id)
        {
            var roleTbl = await _context.RoleTbls
                //.Include(r => r.Dept)  // Include department information
                .FirstOrDefaultAsync(r => r.RoleId == id);

            if (roleTbl == null)
            {
                return NotFound();
            }

            return roleTbl;
        }


        // POST: api/Role
        [HttpPost]
        public async Task<ActionResult<RoleTbl>> PostRole(RoleTbl roleTbl)
        {
            _context.RoleTbls.Add(roleTbl);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRole), new { id = roleTbl.RoleId }, roleTbl);
        }

        // PUT: api/Role/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, RoleTbl roleTbl)
        {
            if (id != roleTbl.RoleId)
            {
                return BadRequest();
            }

            _context.Entry(roleTbl).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleTblExists(id))
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

        // DELETE: api/Role/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            var roleTbl = await _context.RoleTbls.FindAsync(id);
            if (roleTbl == null)
            {
                return NotFound();
            }

            _context.RoleTbls.Remove(roleTbl);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleTblExists(int id)
        {
            return _context.RoleTbls.Any(e => e.RoleId == id);
        }
    }
}
