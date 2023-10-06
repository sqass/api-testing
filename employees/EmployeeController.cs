using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

[Route("api/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
    private readonly AppDbContext _context;

    public EmployeeController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/Employee
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Employee>>> GetEmployeeDetails()
    {
        return await _context.EmployeeDetails.ToListAsync();
    }

    // GET: api/Employee/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        var employee = await _context.EmployeeDetails.FindAsync(id);

        if (employee == null)
        {
            return NotFound();
        }

        return employee;
    }

    // POST: api/Employee
    [HttpPost]
    public async Task<ActionResult<Employee>> PostEmployee(Employee employee)
    {
        _context.EmployeeDetails.Add(employee);
        await _context.SaveChangesAsync();

        return CreatedAtAction("GetEmployee", new { id = employee.EmployeeID }, employee);
    }

    // PUT: api/Employee/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutEmployee(int id, Employee employee)
    {
        if (id != employee.EmployeeID)
        {
            return BadRequest();
        }

        _context.Entry(employee).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
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

        return Ok(employee);
    }

    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchEmployee(int id, [FromBody] NewCity newCity)
    {
        if (string.IsNullOrEmpty(newCity.State))
        {
            return BadRequest("NewCity is required in the request body.");
        }

        var employee = await _context.EmployeeDetails.FindAsync(id);

        if (employee == null)
        {
            return NotFound();
        }

        employee.State = newCity.State;

        try
        {
            await _context.SaveChangesAsync();
            return Ok(employee);
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
    }

    // DELETE: api/Employee/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteEmployee(int id)
    {
        var employee = await _context.EmployeeDetails.FindAsync(id);

        if (employee == null)
        {
            return NotFound();
        }

        _context.EmployeeDetails.Remove(employee);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    private bool EmployeeExists(int id)
    {
        return _context.EmployeeDetails.Any(e => e.EmployeeID == id);
    }
}
