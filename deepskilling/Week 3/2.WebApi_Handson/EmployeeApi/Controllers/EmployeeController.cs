using Microsoft.AspNetCore.Mvc;
using EmployeeApi.Models;

namespace EmployeeApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Employee>> Get()
    {
        return new List<Employee>
        {
            new Employee
            {
                Id = 1,
                Name = "Faraz",
                Department = "IT"
            },
            new Employee
            {
                Id = 2,
                Name = "Rahul",
                Department = "HR"
            }
        };
    }
}