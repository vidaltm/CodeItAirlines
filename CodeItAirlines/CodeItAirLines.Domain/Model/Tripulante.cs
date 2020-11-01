namespace CodeItAirLines.Domain.Model
{
    public class Tripulante
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Motorista { get; set; }
        public TipoTripulantes TipoTripulante { get; set; }

        public Tripulante(int id, string nome, TipoTripulantes tipo, bool podeDirigir)
        {
            Id = id;
            Nome = nome;
            TipoTripulante = tipo;
            Motorista = podeDirigir;
        }
    }
}
