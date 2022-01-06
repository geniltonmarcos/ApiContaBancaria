using ContaBancaria.Core.Entities;

namespace ContaBancaria.Core.Interfaces.Adapters
{
    public interface IPacoteAdapter
    {
        Pacote GetPacote(string nome);
    }
}
