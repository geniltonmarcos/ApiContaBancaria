using ContaBancaria.Core.Entities;
using ContaBancaria.Core.Interfaces.Factories;
using System;

namespace ContaBancaria.Core.Factories
{
    public class ContaFactory : IContaFactory
    {
        public ContaCorrente CreateContaCorrente(string nome, double saldo)
        {
            Console.WriteLine("Criando conta corrente");
            return new ContaCorrente(nome,saldo);
        }

        public ContaPoupanca CreateContaPoupanca(string nome, double saldo)
        {
            Console.WriteLine("Criando conta poupanca");
            return new ContaPoupanca(nome, saldo);
        }
    }
}
