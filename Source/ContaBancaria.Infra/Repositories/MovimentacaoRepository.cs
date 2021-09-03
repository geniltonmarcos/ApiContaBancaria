using ContaBancaria.Core.Dtos;
using ContaBancaria.Core.Interfaces.Repositories;
using ContaBancaria.Infra.Databases;
using System.Linq;

namespace ContaBancaria.Infra.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        public ExtratoDto Extrato(long contaId)
        {
            var conta = Database.Contas?.FirstOrDefault(e => e.Id == contaId);

            return new ExtratoDto() {
                Conta = conta.Nome,
                Saldo = conta.Saldo,
                Movimentacoes = conta?.Movimentacoes?.Select(s => new MovimentacaoDto() {
                    Data = s.Data,
                    Montante = s.Valor,
                    TipoOperacao = s.TipoMovimentacao.ToString()
                })
            };
        }
    }
}
