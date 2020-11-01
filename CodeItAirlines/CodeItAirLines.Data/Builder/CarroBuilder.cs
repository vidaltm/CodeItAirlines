using CodeItAirLines.Domain.Model;

namespace CodeItAirLines.Data.Builder
{
    public class CarroBuilder
    {
        private int _id;
        private string _modelo;
        private int _quantidadeOcupantes;

        public CarroBuilder SetId(int id)
        {
            _id = id;
            return this;
        }

        public CarroBuilder SetModelo(string modelo)
        {
            _modelo = modelo;
            return this;
        }

        public CarroBuilder SetQuantidadeOcupantes(int quantidadeOcupantes)
        {
            _quantidadeOcupantes = quantidadeOcupantes;
            return this;
        }

        public Carro Create()
        {
            return new Carro(_id, _modelo, _quantidadeOcupantes);
        }
    }
}
