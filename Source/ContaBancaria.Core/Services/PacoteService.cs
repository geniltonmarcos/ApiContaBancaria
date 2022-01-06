using ContaBancaria.Core.Dtos;
using ContaBancaria.Core.Entities;
using ContaBancaria.Core.Interfaces.Adapters;
using ContaBancaria.Core.Interfaces.Services;

namespace PacoteBancaria.Core.Services
{
    public class PacoteService : IPacoteService
    {
        private readonly IPacoteAdapter pacoteAdapter;

        public PacoteService(IPacoteAdapter pacoteAdapter)
        {
            this.pacoteAdapter = pacoteAdapter;
        }

        public Pacote Solicitar(PacoteDto pacoteDto)
        {
            var result = pacoteAdapter.GetPacote(pacoteDto?.Nome);
            return result;
        }
    }
}
