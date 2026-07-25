using EmployeeApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApi.Controllers;

[ApiController]
[Route("Emp")]
[Authorize]
public class EmployeeController : ControllerBase
{
    private readonly List<Employee> employees;

    public EmployeeController()
    {
        employees = GetStandardEmployeeList();
    }

    private List<Employee> GetStandardEmployeeList()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Manasa",
                Salary = 50000,
                Permanent = true,
                DateOfBirth = new DateTime(2005, 11, 26),
                Department = new Department
                {
                    Id = 101,
                    Name = "AI & ML"
                },
                Skills = new List<Skill>
                {
                    new Skill { Id = 1, Name = "C#" },
                    new Skill { Id = 2, Name = "ASP.NET Core" }
                }
            },
            new Employee
            {
                Id = 2,
                Name = "Rahul",
                Salary = 45000,
                Permanent = false,
                DateOfBirth = new DateTime(2004, 5, 10),
                Department = new Department
                {
                    Id = 102,
                    Name = "IT"
                },
                Skills = new List<Skill>
                {
                    new Skill { Id = 3, Name = "SQL" }
                }
            }
        };
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Employee>> GetStandard()
    {
        return Ok(employees);
    }

    [HttpPost]
    public IActionResult Post([FromBody] Employee employee)
    {
        employees.Add(employee);
        return Ok(employee);
    }

    [HttpPut]
    public ActionResult<Employee> Put([FromBody] Employee employee)
    {
        if (employee.Id <= 0)
        {
            return BadRequest("Invalid employee id");
        }

        var existingEmployee = employees.FirstOrDefault(e => e.Id == employee.Id);

        if (existingEmployee == null)
        {
            return BadRequest("Invalid employee id");
        }

        existingEmployee.Name = employee.Name;
        existingEmployee.Salary = employee.Salary;
        existingEmployee.Permanent = employee.Permanent;
        existingEmployee.Department = employee.Department;
        existingEmployee.Skills = employee.Skills;
        existingEmployee.DateOfBirth = employee.DateOfBirth;

        return Ok(existingEmployee);
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(int id)
    {
        var employee = employees.FirstOrDefault(e => e.Id == id);

        if (employee == null)
        {
            return NotFound("Employee not found");
        }

        employees.Remove(employee);
        return Ok("Employee Deleted");
    }
}