using ContaBancaria.Core.Configs;
using ContaBancaria.Core.Dtos;
using ContaBancaria.Core.Entities;
using ContaBancaria.Core.Enums;
using ContaBancaria.Core.Helpers;
using ContaBancaria.Core.Interfaces.Repositories;
using ContaBancaria.Core.Interfaces.Services;
using System;
using System.Collections.Generic;

namespace ContaBancaria.Core.Services
{
    public class ContaService : IContaService
    {
        private readonly IContaRepository contaRepository;
        public ContaService(IContaRepository contaRepository)
        {
            this.contaRepository = contaRepository;
        }

        public FluentResult Depositar(ContaDto contaDto)
        {
            var fl = new FluentResult();

            if (contaDto.Valor > 0)
            {
                var conta = contaRepository.GetById(contaDto.Id);
                if (conta != null)
                {
                    double tarifa = TarifaDeposito(contaDto.Valor);

                    var movimentacao = new Movimentacao(conta.Id, contaDto.Valor, TipoMovimentacao.Deposito);
                    conta.AdicionaMovimentacao(movimentacao);

                    TaxaBancaria(conta, tarifa);
                }
                else
                {
                    fl.Errors.Add("Conta inválida.");
                }
            }
            else
            {
                fl.Errors.Add("Informe um valor válido");
            }
            return fl;
        }

        public double TarifaDeposito(double valor)
        {
            return Math.Round(valor * ConfigTaxas.TxPercDeposito, 2);
        }

        public FluentResult Sacar(ContaDto contaDto)
        {
            var fl = new FluentResult();
            if (contaDto.Valor > 0)
            {
                var conta = contaRepository.GetById(contaDto.Id);
                if (conta != null)
                {
                    double saldoMinimo = contaDto.Valor + ConfigTaxas.TxMontanteSaque;
                    if (conta.Saldo >= saldoMinimo)
                    {
                        var movimentacao = new Movimentacao(conta.Id, contaDto.Valor * (-1), TipoMovimentacao.Saque);
                        conta.AdicionaMovimentacao(movimentacao);

                        TaxaBancaria(conta, ConfigTaxas.TxMontanteSaque);
                    }
                    else
                    {
                        fl.Errors.Add("Saldo insuficiente");
                    }
                }
                else
                {
                    fl.Errors.Add("Conta inválida.");
                }
            }
            else
            {
                fl.Errors.Add("Informe um valor válido");
            }
            return fl;
        }

        public FluentResult Transferir(TransferenciaDto transferencia)
        {
            var fl = new FluentResult();
            if (transferencia.Valor > 0)
            {
                var contaOrigem = contaRepository.GetById(transferencia.ContaOrigemId);
                var contaDestino = contaRepository.GetById(transferencia.ContaDestinoId);
                if (contaOrigem != null && contaDestino != null)
                {
                    double saldoMinimo = transferencia.Valor + ConfigTaxas.TxMontanteTransferencia;

                    if (contaOrigem.Saldo >= saldoMinimo)
                    {
                        var movimentacao = new Movimentacao(contaOrigem.Id, transferencia.Valor * (-1), TipoMovimentacao.Transferencia);
                        contaOrigem.AdicionaMovimentacao(movimentacao);

                        TaxaBancaria(contaOrigem, ConfigTaxas.TxMontanteTransferencia);

                        movimentacao = new Movimentacao(contaDestino.Id, transferencia.Valor, TipoMovimentacao.Transferencia);
                        contaDestino.AdicionaMovimentacao(movimentacao);
                    }
                    else
                    {
                        fl.Errors.Add("Saldo insuficiente");
                    }
                }
                else
                {
                    fl.Errors.Add("Conta(s) inválida(s).");
                }
            }
            else
            {
                fl.Errors.Add("Informe um valor válido");
            }
            return fl;
        }

        public FluentResult Abrir(AberturaDto abreConta)
        {
            var fl = new FluentResult();
            if (!string.IsNullOrWhiteSpace(abreConta.Nome))
            {
                var conta = new Conta(abreConta.Nome, abreConta.SaldoInicial);

                if(abreConta.SaldoInicial > 0)
                {
                    var movimentacao = new Movimentacao(conta.Id, abreConta.SaldoInicial, TipoMovimentacao.Deposito);
                    conta.AdicionaMovimentacao(movimentacao);
                }

                contaRepository.Add(conta);
            }
            else
            {
                fl.Errors.Add("Informe um nome para a conta");
            }

            return fl;
        }

        public IEnumerable<ContaListDto> Lista()
        {
            var contas = contaRepository.List();
            return contas;
        }

        public Conta GetById(long contaId)
        {
            var conta = contaRepository.GetById(contaId);
            return conta;
        }

        private static void TaxaBancaria(Conta conta, double tarifa)
        {
            tarifa *= -1;
            var movimentacao = new Movimentacao(conta.Id, tarifa, TipoMovimentacao.TarifaBancaria);
            conta.AdicionaMovimentacao(movimentacao);
        }
    }
}
