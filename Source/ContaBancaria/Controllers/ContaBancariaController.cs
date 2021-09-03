using ContaBancaria.Core.Dtos;
using ContaBancaria.Core.Entities;
using ContaBancaria.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace ContaBancaria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaBancariaController : BaseController
    {
        private readonly IContaService contaService;

        public ContaBancariaController(IContaService contaService)
        {
            this.contaService = contaService;
        }
      
        [HttpGet]
        public ActionResult<IEnumerable<ContaListDto>> All()
        {
            var contas = contaService.Lista();
            return new ObjectResult(contas);
        }

        [HttpPost("abrir")]
        public ActionResult AbrirConta([FromBody] AberturaDto contaDto)
        {
            var resultado = contaService.Abrir(contaDto);
            return ResultadoHttp(resultado);
        }

        [HttpPut("depositar")]
        public ActionResult Depositar([FromBody] ContaDto contaDto)
        {
            var resultado = contaService.Depositar(contaDto);
            return ResultadoHttp(resultado);
        }

        [HttpPut("sacar")]
        public ActionResult Sacar([FromBody] ContaDto contaDto)
        {
            var resultado = contaService.Sacar(contaDto);
            return ResultadoHttp(resultado);
        }

        [HttpPut("transferir")]
        public ActionResult Transferir([FromBody] TransferenciaDto transferenciaDto)
        {
            var resultado = contaService.Transferir(transferenciaDto);
            return ResultadoHttp(resultado);
        }

    }
}
