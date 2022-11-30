using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Organizer.Models.Errors;
using Organizer.Models.Exceptions.Base;

namespace Organizer.Filters;

public class CustomExceptionFilterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var ex = context.Exception;
        var message = ex.Message;

        IActionResult result = ex switch
        {
            BaseCustomException baseEx => new BadRequestObjectResult(new ErrorResponse
            {
                Errors = new List<ErrorModel>
                    { new ErrorModel { CauseOfError = baseEx.CauseOfError, Message = message } }
            }),
            _ => new ObjectResult(new ErrorResponse
            {
                Errors = new List<ErrorModel> 
                    {new ErrorModel {CauseOfError = "General Error", Message = message}}
            })
            {
                StatusCode = 500
            }
        };
        context.ExceptionHandled = true;
        context.Result = result;
    }
}