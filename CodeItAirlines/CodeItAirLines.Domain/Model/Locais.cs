using System.Collections.Generic;

namespace CodeItAirLines.Domain.Model
{
    public class Locais
    {
        public int Id { get; set; }
        public string Local { get; set; }
        public List<Tripulante> Tripulantes { get; set; }

        public Locais(int id, string local, List<Tripulante> tripulante)
        {
            Tripulantes = tripulante;
            Id = id;
            Local = local;
        }
    }
}
