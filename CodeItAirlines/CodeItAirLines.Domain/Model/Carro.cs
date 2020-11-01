using System.Collections.Generic;

namespace CodeItAirLines.Domain.Model
{
    public class Carro
    {
        public int Id { get; set; }
        public string Modelo { get; set; }
        public int QuantidadeOcupantes { get; set; }
        public List<Tripulante> Passageiros { get; set; }
        public Tripulante Motorista { get; set; }

        public Carro(int id, string modelo, int quantidadeOcupantes)
        {
            Passageiros = new List<Tripulante>();
            Id = id;
            Modelo = modelo;
            QuantidadeOcupantes = quantidadeOcupantes;
        }
    }
}
