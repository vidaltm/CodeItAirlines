using CodeItAirLines.Domain.Model;
using System.Collections.Generic;

namespace CodeItAirLines.Domain.Interfaces.Repository
{
    public interface ICarroRepository
    {
        List<Carro> ListaCarros();
    }
}
