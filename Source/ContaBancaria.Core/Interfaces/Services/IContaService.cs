using ContaBancaria.Core.Dtos;
using ContaBancaria.Core.Helpers;
using System.Collections.Generic;

namespace ContaBancaria.Core.Interfaces.Services
{
    public interface IContaService
    {
        FluentResult Abrir(AberturaDto abreConta);
        IEnumerable<ContaListDto> Lista();
        FluentResult Depositar(ContaDto contaDto);
        FluentResult Sacar(ContaDto contaDto);
        FluentResult Transferir(TransferenciaDto transferenciaDto);
    }
}
