using EmployeeApiCRUD.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApiCRUD.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private static List<Employee> employees =
        GetStandardEmployeeList();

    [HttpGet]
    public ActionResult<List<Employee>> Get()
    {
        return Ok(employees);
    }

    [HttpPut("{id}")]
    public ActionResult<Employee> Update(
        int id,
        [FromBody] Employee employee)
    {
        if (id <= 0)
        {
            return BadRequest("Invalid employee id");
        }

        var existingEmployee =
            employees.FirstOrDefault(e => e.Id == id);

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

    private static List<Employee> GetStandardEmployeeList()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Faraz",
                Salary = 50000,
                Permanent = true,
                DateOfBirth = new DateTime(2003,5,10),

                Department = new Department
                {
                    Id = 1,
                    Name = "IT"
                },

                Skills = new List<Skill>
                {
                    new Skill
                    {
                        Id = 1,
                        Name = "Java"
                    }
                }
            }
        };
    }
}