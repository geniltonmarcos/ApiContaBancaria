using ContaBancaria.Core.Helpers;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace ContaBancaria.Controllers
{
    public class BaseController : ControllerBase
    {
        /// <summary>
        /// Convenionalmente, utilizo Middleware para tratar as requests
        /// </summary>
        protected ActionResult ResultadoHttp(FluentResult fluent)
        {
            if (fluent.Errors.Any())
            {
                return BadRequest(fluent.Errors);
            }
            else
            {
                return Ok();
            }
        }
    }
}
