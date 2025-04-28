using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AllModels;
using AllServices;
using LogIn;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
namespace pizza2.Controllers
{
    [Route("[controller]")]
    public class LoginController : BaseController
    {
        ILoginManager _check;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILoginManager check, ILogger<LoginController> logger)
        {
            _check =check;
            _logger = logger;
        }

        [HttpPost]
        [Route("[action]")]
        public ActionResult<String> Login(string name, string password)
        {

            var dt = DateTime.Now;

             worker w1=_check.IsExsist(name,password);
            if (w1==null)
            {
                return Unauthorized();
            }
     var claims = new List<Claim>
     {
        new Claim("Role",w1.Role)
     };

            var token = PizzaTokenService.GetToken(claims);

            return new OkObjectResult(PizzaTokenService.WriteToken(token));
        }
    }
}