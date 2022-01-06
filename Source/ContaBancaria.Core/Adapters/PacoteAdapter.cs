using ContaBancaria.Core.Entities;
using ContaBancaria.Core.Interfaces.Adapters;
using System;

namespace ContaBancaria.Core.Adapters
{
    public class PacoteAdapter : IPacoteAdapter
    {
        public Pacote GetPacote(string nome)
        {
            var pacote = new Pacote();
            switch (nome)
            {
                case "universitario":
                    pacote = new PacoteUniversitario();
                    break;
                case "ouro":
                    pacote = new PacoteOuro();
                    break;
                default:
                    break;
            }

            Console.WriteLine("Pacote "+ pacote.Nome +" | Taxa: " + pacote.Taxa);
            return pacote;
        }
    }
}
