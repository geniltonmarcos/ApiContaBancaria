using ContaBancaria.Infra.Databases;
using System.Collections.Generic;

namespace ContaBancaria.Core.Tests
{
    public class BaseTest
    {
        public void LimpaDatabase()
        {
            Database.Contas = new List<Entities.Conta>();
        }
    }
}
