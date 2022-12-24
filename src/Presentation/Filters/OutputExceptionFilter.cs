using Common.Exception;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Presentation.Common;
using System.Net;

namespace Presentation.Filters
{
    public class OutputExceptionFilter : IExceptionFilter
    {
        public static OutputExceptionFilter Instance => new OutputExceptionFilter();

        private OutputExceptionFilter() { }

        public void OnException(ExceptionContext context)
        {
            var exception = context.Exception;

            var statusCode = (int)HttpStatusCode.InternalServerError;

            if (typeof(IException).IsAssignableFrom(exception.GetType()))
                statusCode = (int)HttpStatusCode.BadRequest;
            
            var output = Output.Create(
                            Error.Create(
                                exception.Message,
                                exception.InnerException?.ToString()));

            context.Result = new ObjectResult(output);

            context.HttpContext.Response.StatusCode = statusCode;
        }
    }
}
