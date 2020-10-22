using System.Net.Http;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Refit;
using Serilog;

namespace TNEClient.Controllers
{
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
            if (exception is ApiException apiEx)
            {
                ViewBag.StatusCode = apiEx.StatusCode switch
                {
                    System.Net.HttpStatusCode.NotFound => "Запрашиваемые данные не найдены",
                    System.Net.HttpStatusCode.BadRequest => "Неверный запрос на сервер",
                    System.Net.HttpStatusCode.InternalServerError => "Внутренняя ошибка на сервере",
                    _ => "Неизвестная ошибка",
                };
            } else if (exception is HttpRequestException)
            {
                ViewBag.StatusCode = "Сервер не отвечает ;-)";
            }
            else
            {
                ViewBag.StatusCode = "Неизвестная ошибка!";
            }
            return View();
        }
    }
}
