using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeApiCustomModel.Filters;

public class CustomAuthFilter : ActionFilterAttribute
{
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
        {
            context.Result =
                new BadRequestObjectResult(
                    "Invalid request - No Auth token");

            return;
        }

        var authToken =
            context.HttpContext.Request.Headers["Authorization"]
                .ToString();

        if (!authToken.Contains("Bearer"))
        {
            context.Result =
                new BadRequestObjectResult(
                    "Invalid request - No Auth token");
        }
    }
}