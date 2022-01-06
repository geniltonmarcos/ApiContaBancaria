using ContaBancaria.Core.Dtos;
using ContaBancaria.Core.Entities;

namespace ContaBancaria.Core.Interfaces.Services
{
    public interface IPacoteService
    {
        Pacote Solicitar(PacoteDto pacoteDto);
    }
}
