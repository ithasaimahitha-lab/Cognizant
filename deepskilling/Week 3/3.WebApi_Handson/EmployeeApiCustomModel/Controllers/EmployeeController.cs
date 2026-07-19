using EmployeeApiCustomModel.Filters;
using EmployeeApiCustomModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeApiCustomModel.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    private readonly List<Employee> employees;

    public EmployeeController()
    {
        employees = GetStandardEmployeeList();
    }

    [AllowAnonymous]
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK)]
    public ActionResult<List<Employee>> GetStandard()
    {
        return Ok(employees);
    }

    [HttpPost]
    [CustomAuthFilter]
    public IActionResult Post([FromBody] Employee employee)
    {
        return Ok(employee);
    }

    [HttpPut]
    [CustomAuthFilter]
    public IActionResult Put([FromBody] Employee employee)
    {
        return Ok(employee);
    }

    private List<Employee> GetStandardEmployeeList()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Faraz",
                Salary = 50000,
                Permanent = true,
                DateOfBirth = new DateTime(2003, 5, 10),

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
                    },
                    new Skill
                    {
                        Id = 2,
                        Name = "React"
                    }
                }
            }
        };
    }
}