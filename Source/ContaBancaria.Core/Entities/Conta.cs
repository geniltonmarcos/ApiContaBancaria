using System.Collections.Generic;
using System.Linq;

namespace ContaBancaria.Core.Entities
{
    public abstract class Conta
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public double Saldo { get; private set; }
        public List<Movimentacao> Movimentacoes { get; private set; }

        public void AdicionaMovimentacao(Movimentacao movimentacao)
        {
            Movimentacoes.Add(movimentacao);
            Saldo = Movimentacoes.Sum(s => s.Valor);
        }
        
        public Conta(string nome, double valor)
        {
            Nome = nome;
            Saldo = valor;
            Movimentacoes = new List<Movimentacao>();
        }
    }
}
