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
    // https://localhost:portnumber/api/students
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly SidhalingeswaraRiceMillContext dbContext;
        public EmployeesController(SidhalingeswaraRiceMillContext dbContext)
        {
            this.dbContext = dbContext;
        }

        // api/employees
        [HttpGet]
        public IEnumerable<EmployeeTbl> GetEnployees()
        {
            return this.dbContext.EmployeeTbls.ToList();
        }
        // GET: api/Employees/5
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
        // GET: https://localhost:portnumber/api/employees
        [HttpGet("all")]
        public IActionResult GetAllEmployees()
        {
            string[] employeeNames = new string[] { "Shreyas", "Tejas", "Ranjan", "Rohan" };
            return Ok(employeeNames);
        }
    }
}
