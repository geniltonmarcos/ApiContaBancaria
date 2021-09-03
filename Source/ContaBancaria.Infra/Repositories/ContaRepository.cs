using ContaBancaria.Core.Dtos;
using ContaBancaria.Core.Entities;
using ContaBancaria.Core.Interfaces.Repositories;
using ContaBancaria.Infra.Databases;
using System.Collections.Generic;
using System.Linq;

namespace ContaBancaria.Infra.Repositories
{
    public class ContaRepository : IContaRepository
    {
        public void Add(Conta conta)
        {
            Sequence(conta);
            Database.Contas.Add(conta);
        }

        public Conta GetById(long contaId)
        {
            var conta = Database.Contas.FirstOrDefault(e => e.Id == contaId);
            return conta;
        }

        public IEnumerable<ContaListDto> List()
        {
            return Database.Contas?.Select(s => new ContaListDto() { 
                Id = s.Id, 
                Nome = s.Nome,
                Saldo = s.Saldo
            });
        }

        public void Update(Conta conta)
        {
            var idx = Database.Contas.FindIndex(e => e.Id == conta.Id);
            Database.Contas[idx] = conta;
        }

        private static void Sequence(Conta conta)
        {
            long ultimo = 0;
            if(Database.Contas.Any())
                ultimo = Database.Contas.Max(s => s.Id);

            conta.Id = ultimo + 1;
        }
    }
}
