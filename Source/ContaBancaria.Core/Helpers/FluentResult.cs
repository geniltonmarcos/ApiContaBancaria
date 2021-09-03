using System.Collections.Generic;

namespace ContaBancaria.Core.Helpers
{
    /// <summary>
    /// Classe para retorno de processamento da service
    /// Simula um FluentResult ou algo do gênero
    /// </summary>
    public class FluentResult
    {
        public List<string> Errors { get; set; }
        public FluentResult()
        {
            Errors = new List<string>();
        }
    }
}
