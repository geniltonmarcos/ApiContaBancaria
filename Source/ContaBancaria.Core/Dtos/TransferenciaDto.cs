namespace ContaBancaria.Core.Dtos
{
    public class TransferenciaDto
    {
        public long ContaOrigemId { get; set; }
        public long ContaDestinoId { get; set; }
        public double Valor { get; set; }
    }
}
