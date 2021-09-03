using ContaBancaria.Core.Dtos;
using ContaBancaria.Core.Interfaces.Repositories;
using ContaBancaria.Core.Interfaces.Services;

namespace ContaBancaria.Core.Services
{
    public class ExtratoService : IExtratoService
    {
        private readonly IMovimentacaoRepository movimentacaoRepository;
        public ExtratoService(IMovimentacaoRepository movimentacaoRepository)
        {
            this.movimentacaoRepository = movimentacaoRepository;
        }

        public ExtratoDto Extrato(long contaId)
        {
            var extrato = movimentacaoRepository.Extrato(contaId);
            return extrato;
        }
    }
}
