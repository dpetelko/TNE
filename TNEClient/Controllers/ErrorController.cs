using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGeneration;
using Refit;
using Serilog;
using System.Collections;
using TNEClient.Dtos;

namespace TNEClient.Controllers
{
   // [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : Controller
    {
        [Route("/error")]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var exception = context.Error;
            var message = exception.Message;
            var source = exception.GetType().Name;
            Log.Warning("Handling {source} - {message}...", source, message);

            if (exception is ValidationApiException exception1) 
            {
                var qq = exception1;
                Refit.ProblemDetails problem = qq.Content;

                foreach (var pair in problem.Errors)
                {
                    var w1 = pair.Key;
                    var w2 = pair.Value;
                    foreach (var item in w2)
                    {
                        ModelState.AddModelError(w1, item);
                        Log.Error("!!!!!!! ERROR IS {w1} - {w2}", w1, w2);
                    }
                    
                }
                return Redirect(Request.Headers["Referer"].ToString());
            }

            if (exception is ApiException)
            {
                ViewBag.Error = exception.Message;

            }

            return View();
        }
    }
}
