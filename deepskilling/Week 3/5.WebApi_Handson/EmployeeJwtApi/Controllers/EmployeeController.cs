using EmployeeJwtApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeJwtApi.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize] // later change to Roles = "POC" and then "Admin,POC"
public class EmployeeController : ControllerBase
{
    private static readonly List<Employee> employees = new()
    {
        new Employee { Id = 1, Name = "Faraz", Department = "IT" },
        new Employee { Id = 2, Name = "Rahul", Department = "HR" }
    };

    [HttpGet]
    public ActionResult<List<Employee>> Get()
    {
        return Ok(employees);
    }
}