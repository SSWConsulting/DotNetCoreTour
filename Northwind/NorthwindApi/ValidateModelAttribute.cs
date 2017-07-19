using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace NorthwindTraders.NorthwindApi
{
    public class ValidateModelAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.Result = new ValidationFailedResult(context.ModelState);
            }
        }
    }


    public class ValidationFailedResult : BadRequestObjectResult
    {
        public ValidationFailedResult(ModelStateDictionary modelState) : base(modelState)
        {
            StatusCode = StatusCodes.Status422UnprocessableEntity;
        }
    }

}