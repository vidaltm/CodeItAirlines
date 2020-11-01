using CodeItAirLines.Data.Builder;
using CodeItAirLines.Domain.Interfaces.Repository;
using CodeItAirLines.Domain.Model;
using System.Collections.Generic;

namespace CodeItAirLines.Data.Repository
{
    public class CarroRepository : ICarroRepository
    {
        public List<Carro> ListaCarros()
        {
            var builder = new CarroBuilder();
            var carros = new List<Carro>();

            carros.Add(builder.SetId(1).SetModelo("ForTwo").SetQuantidadeOcupantes(2).Create());
            return carros;
        }
    }
}
