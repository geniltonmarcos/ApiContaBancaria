using System.Collections.Generic;

namespace ContaBancaria.Core.Dtos
{
    public class ExtratoDto
    {
        public double Saldo { get; set; }
        public string Conta { get; set; }
        public IEnumerable<MovimentacaoDto> Movimentacoes { get; set; }
    }
}
