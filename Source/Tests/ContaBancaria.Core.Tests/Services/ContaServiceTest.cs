using ContaBancaria.Core.Interfaces.Repositories;
using ContaBancaria.Core.Interfaces.Services;
using ContaBancaria.Core.Services;
using ContaBancaria.Infra.Repositories;
using Moq;
using System;
using System.Linq;
using Xunit;

namespace ContaBancaria.Core.Tests
{
    public class ContaServiceTest : BaseTest
    {
        public ContaService service;

        public ContaServiceTest()
        {
            IContaRepository repos = new Mock<ContaRepository>().Object;
            service = new ContaService(repos);
        }

        [Fact]
        public void DeveNaoConterErroAberturaDeConta()
        {
            LimpaDatabase();
            var conta = new Dtos.AberturaDto() { Nome = "Banco do Brasil", SaldoInicial = 30 };
            var possuiErros = service.Abrir(conta).Errors.Any();
            Assert.False(possuiErros);
        }

        [Fact]
        public void DeveConterErroAberturaDeConta()
        {
            LimpaDatabase();
            var conta = new Dtos.AberturaDto() { Nome = "", SaldoInicial = 30 };
            var possuiErros = service.Abrir(conta).Errors.Any();
            Assert.True(possuiErros);
        }

        [Fact]
        public void DeveRealizarTransferencia()
        {
            LimpaDatabase();
            double transferencia = 5;

            var conta01 = new Dtos.AberturaDto() { Nome = "Conta 01", SaldoInicial = 100 };
            var conta02 = new Dtos.AberturaDto() { Nome = "Conta 02", SaldoInicial = 50 };
            service.Abrir(conta01);
            service.Abrir(conta02);

            var possuiErro = service.Transferir(new Dtos.TransferenciaDto() { ContaOrigemId = 1, ContaDestinoId = 2, Valor = transferencia }).Errors.Any();
            Assert.False(possuiErro);

            bool result = service.GetById(1).Saldo == (conta01.SaldoInicial - transferencia - Configs.ConfigTaxas.TxMontanteTransferencia);
            Assert.True(result);

            result = service.GetById(2).Saldo == (conta02.SaldoInicial + transferencia);
            Assert.True(result);
        }

        [Fact]
        public void DeveRealizarDeposito()
        {
            LimpaDatabase();
            double valor = 20;

            var conta01 = new Dtos.AberturaDto() { Nome = "Conta 01", SaldoInicial = 100 };
            service.Abrir(conta01);
            service.Depositar(new Dtos.ContaDto() { Id = 1, Valor = valor });

            double tarifa = service.TarifaDeposito(valor);
            double valorEsperado = conta01.SaldoInicial + valor - tarifa;
            double saldo = service.GetById(1).Saldo;

            Assert.Equal(valorEsperado, saldo);
        }

        [Fact]
        public void DeveRealizarSaque()
        {
            LimpaDatabase();
            double valor = 6;

            var conta01 = new Dtos.AberturaDto() { Nome = "Conta BB", SaldoInicial = 25 };
            service.Abrir(conta01);
            service.Sacar(new Dtos.ContaDto() { Id = 1, Valor = valor });

            double valorEsperado = conta01.SaldoInicial - (valor + Configs.ConfigTaxas.TxMontanteSaque);
            double saldo = service.GetById(1).Saldo;

            Assert.Equal(valorEsperado, saldo);
        }
    }
}
