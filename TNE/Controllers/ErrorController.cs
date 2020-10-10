using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using TNE.Data.Exceptions;

namespace TNE.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : ControllerBase
    {
        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            var message = exception.Message;
            var source = exception.GetType().Name;
            Log.Warning("Handling {source} - {message}...", source, message);
            IActionResult result = StatusCode(500);
            if (exception is EntityNotFoundException) result = StatusCode(StatusCodes.Status404NotFound);
            else if (exception is InvalidEntityException) result = StatusCode(StatusCodes.Status400BadRequest);
            else if (exception is Exception) result = StatusCode(StatusCodes.Status500InternalServerError);
            return result;
        }
    }
}
