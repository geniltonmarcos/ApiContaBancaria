using ContaBancaria.Core.Dtos;
using ContaBancaria.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace ContaBancaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PacoteController : BaseController
    {
        private readonly IPacoteService pacoteService;

        public PacoteController(IPacoteService pacoteService)
        {
            this.pacoteService = pacoteService;
        }

        [HttpPost]
        public ActionResult Pacote(PacoteDto dto)
        {
            var pacote = pacoteService.Solicitar(dto);
            return new ObjectResult(pacote);
        }
    }
}
