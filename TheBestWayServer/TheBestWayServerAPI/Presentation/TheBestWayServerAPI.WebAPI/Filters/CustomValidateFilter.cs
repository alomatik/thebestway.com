using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace TheBestWayServerAPI.WebAPI.Filters
{
    public class CustomValidateFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                List<string> errors = context.ModelState.Values.SelectMany(modelState => modelState.Errors).Select(modelError => modelError.ErrorMessage).ToList();

                context.Result = new BadRequestObjectResult(new
                {
                    StatusCode = 400,
                    Message = errors
                });
            }
            base.OnActionExecuting(context);
        }
    }
}
