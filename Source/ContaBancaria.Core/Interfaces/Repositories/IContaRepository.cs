using ContaBancaria.Core.Dtos;
using ContaBancaria.Core.Entities;
using System.Collections.Generic;

namespace ContaBancaria.Core.Interfaces.Repositories
{
    public interface IContaRepository
    {
        void Add(Conta conta);
        void Update(Conta conta);
        Conta GetById(long contaId);
        IEnumerable<ContaListDto> List();
    }
}
