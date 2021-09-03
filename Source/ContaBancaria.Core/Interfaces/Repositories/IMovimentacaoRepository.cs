using ContaBancaria.Core.Dtos;

namespace ContaBancaria.Core.Interfaces.Repositories
{
    public interface IMovimentacaoRepository
    {
        ExtratoDto Extrato(long contaId);
    }
}
