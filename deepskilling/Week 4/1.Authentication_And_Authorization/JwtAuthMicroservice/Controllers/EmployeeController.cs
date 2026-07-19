using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthMicroservice.Controllers;

[ApiController]
[Route("api/[controller]")]
public class EmployeeController : ControllerBase
{
    [Authorize]
    [HttpGet]
    public IActionResult GetEmployees()
    {
        var employees = new[]
        {
            new { Id = 1, Name = "Sarfaraz", Department = "IT" },
            new { Id = 2, Name = "Rahul", Department = "HR" },
            new { Id = 3, Name = "Aman", Department = "Finance" }
        };

        return Ok(employees);
    }
}