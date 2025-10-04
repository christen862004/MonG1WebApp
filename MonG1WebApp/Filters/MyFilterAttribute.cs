using Microsoft.AspNetCore.Mvc.Filters;

namespace MonG1WebApp.Filters
{
    public class MyFilterAttribute : Attribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            //write Logic
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            //write Logic
        }
    }
}
