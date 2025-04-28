using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace exeptions.Controllers
{
    [Route("[controller]")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorsControllers : Controller
    {
        private readonly ILogger<ErrorsControllers> _logger;

        public ErrorsControllers(ILogger<ErrorsControllers> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/error")]
        public ActionResult Error([FromServices] IHostEnvironment hostEnvironment)
        {
            var exceptionHandlerFeature =
           HttpContext.Features.Get<IExceptionHandlerFeature>();
            _logger.LogError(exceptionHandlerFeature?.Error.ToString());
            return Problem(
                detail: "Please try later...",
                title: "Sorry...");
        }
        [Route("/error-development")]
        public ActionResult DevelopmentError([FromServices] IHostEnvironment
      hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return Error(hostEnvironment);
            }
            var exceptionHandlerFeature =
                HttpContext.Features.Get<IExceptionHandlerFeature>();
            _logger.LogError(exceptionHandlerFeature?.Error.ToString());
            return Problem(
                detail: exceptionHandlerFeature?.Error.StackTrace,
                title: exceptionHandlerFeature?.Error.Message);
        }
    }
}