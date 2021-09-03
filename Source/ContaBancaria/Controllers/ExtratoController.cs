using ContaBancaria.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContaBancaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExtratoController : BaseController
    {
        private readonly IExtratoService extratoService;

        public ExtratoController(IExtratoService extratoService)
        {
            this.extratoService = extratoService;
        }

        [HttpGet("{contaId}")]
        public ActionResult Extrato(long contaId)
        {
            var contas = extratoService.Extrato(contaId);
            return new ObjectResult(contas);
        }
    }
}
