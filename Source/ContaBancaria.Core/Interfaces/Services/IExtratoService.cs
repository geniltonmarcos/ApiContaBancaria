using ContaBancaria.Core.Dtos;

namespace ContaBancaria.Core.Interfaces.Services
{
    public interface IExtratoService
    {
        ExtratoDto Extrato(long contaId);
    }
}
