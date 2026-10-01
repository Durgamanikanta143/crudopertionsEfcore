using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : Controller
    {

        private readonly E_ployeeDbContet _context;
        public EmployeeController(E_ployeeDbContet con)
        {
            _context = con;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmp()
        {
            var employees = await _context.Employees.ToListAsync();
            return Ok(employees);
        }

        [HttpPost]
        public async Task<IActionResult> CreateEmp(Employee emp)
        {
            _context.Employees.Add(emp);
            await _context.SaveChangesAsync();
            return Ok(emp);

        }

        [HttpPut("{id}") ]

        public async Task<IActionResult> editemp(int id,Employee emp)
        {

            var employelst = await _context.Employees.FindAsync(id);

            if (employelst==null){

                return NotFound();
            }
            employelst.name=emp.name;
            employelst.desgination=emp.desgination;
            employelst.sal=emp.sal;

            await _context.SaveChangesAsync();
            return Ok(employelst);

        }

        [HttpDelete("{id}")]

        public async Task<IActionResult> deleteemp(int id)
        {
            var emplist = await _context.Employees.FindAsync(id);
                if (emplist==null)
            {

                return NotFound();
            }

            _context.Employees.Remove(emplist);
            await _context.SaveChangesAsync();

            return Ok(emplist);


            
         
        }

    }
}
