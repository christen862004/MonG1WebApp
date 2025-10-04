using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace MonG1WebApp.Filters
{
    public class HandeErrorAttribute : Attribute,IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            //ContentResult result = new ContentResult();
            //result.Content = "Some Exception happen";
            ViewResult result=new ViewResult();
            result.ViewName = "Error";//shared
            context.Result = result;
        }
    }
}
