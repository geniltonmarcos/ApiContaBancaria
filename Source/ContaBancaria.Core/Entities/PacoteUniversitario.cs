namespace ContaBancaria.Core.Entities
{
    public class PacoteUniversitario : Pacote
    {
        public override string Nome { get { return "PKG Universitário"; } }
        public override double Taxa { get { return 0.5; } }
    }
}
