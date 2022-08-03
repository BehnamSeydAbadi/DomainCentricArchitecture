using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Presentation.Common;

namespace Presentation.Filters
{
    public class OutputActionFilter : IActionFilter
    {
        public static OutputActionFilter Instance => new OutputActionFilter();

        private OutputActionFilter() { }

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            var result = context.Result as ObjectResult;

            if (result == null || result.Value == null)
                return;


            var output = Output.Create(result.Value);

            result.Value = output;

            context.Result = result;
        }
    }
}
