using System;

namespace ContaBancaria.Core.Dtos
{
    public class MovimentacaoDto
    {
        public DateTime Data { get; set; }
        public string TipoOperacao { get; set; }
        public double Montante { get; set; }
    }
}
