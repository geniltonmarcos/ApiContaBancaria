using ContaBancaria.Core.Enums;
using System;

namespace ContaBancaria.Core.Entities
{
    public class Movimentacao
    {
        public DateTime Data { get; private set; }
        public long ContaId { get; private set; }
        public double Valor { get; private set; }
        public TipoMovimentacao TipoMovimentacao{ get; private set; }

        public Movimentacao(long contaId, double valor, TipoMovimentacao tipoMovimentacao)
        {
            ContaId = contaId;
            Valor = valor;
            TipoMovimentacao = tipoMovimentacao;
            Data = DateTime.Now;
        }
    }
}
