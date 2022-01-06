namespace ContaBancaria.Core.Entities
{
    public class PacoteOuro : Pacote
    {
        public override string Nome { get { return "PKG Ouro"; } }
        public override double Taxa { get { return 0.9; } }
    }
}
