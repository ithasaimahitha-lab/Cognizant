using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EmployeeApi.Filters;

public class CustomExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        string path = "ExceptionLog.txt";

        File.AppendAllText(
            path,
            $"[{DateTime.Now}] {context.Exception.Message}{Environment.NewLine}");

        context.Result = new ObjectResult(new
        {
            message = "Internal Server Error"
        })
        {
            StatusCode = StatusCodes.Status500InternalServerError
        };

        context.ExceptionHandled = true;
    }
}