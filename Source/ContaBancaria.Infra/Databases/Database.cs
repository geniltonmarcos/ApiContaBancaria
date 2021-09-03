using ContaBancaria.Core.Entities;
using System.Collections.Generic;

namespace ContaBancaria.Infra.Databases
{
    public static class Database
    {
        public static List<Conta> Contas { get; set; } = new List<Conta>();
    }
}
