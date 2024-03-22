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
    public class EmployeesController : ControllerBase
    {
        private readonly SidhalingeswaraRiceMillContext dbContext;

        public EmployeesController(SidhalingeswaraRiceMillContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // GET: api/employees
        [HttpGet]
        public IEnumerable<EmployeeTbl> GetEmployees()
        {
            return this.dbContext.EmployeeTbls.ToList();
        }

        // GET: api/employees/{id}
        [HttpGet("{id}")]
        public IActionResult GetEmployee(int id)
        {
            var employee = this.dbContext.EmployeeTbls.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            return Ok(employee);
        }

        // POST: api/employees
        [HttpPost]
        public IActionResult AddEmployee(EmployeeTbl employee)
        {
            if (employee == null)
            {
                return BadRequest();
            }

            try
            {
                this.dbContext.EmployeeTbls.Add(employee);
                this.dbContext.SaveChanges();

                return CreatedAtAction(nameof(GetEmployee), new { id = employee.EmployeeId }, employee);
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Error occurred while adding employee: {ex.Message}");
                return StatusCode(500, "An error occurred while saving the employee data.");
            }
        }


        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        public IActionResult UpdateEmployee(int id, EmployeeTbl employee)
        {
            if (id != employee.EmployeeId)
            {
                return BadRequest();
            }

            this.dbContext.Entry(employee).State = EntityState.Modified;

            try
            {
                this.dbContext.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeExists(id))
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

        // DELETE: api/employees/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteEmployee(int id)
        {
            var employee = this.dbContext.EmployeeTbls.Find(id);

            if (employee == null)
            {
                return NotFound();
            }

            this.dbContext.EmployeeTbls.Remove(employee);
            this.dbContext.SaveChanges();

            return NoContent();
        }

        private bool EmployeeExists(int id)
        {
            return this.dbContext.EmployeeTbls.Any(e => e.EmployeeId == id);
        }
    }
}
