using ContaBancaria.Core.Entities;

namespace ContaBancaria.Core.Interfaces.Factories
{
    public interface IContaFactory
    {
        ContaCorrente CreateContaCorrente(string nome, double saldo);
        ContaPoupanca CreateContaPoupanca(string nome, double saldo);
    }
}
