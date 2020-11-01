using CodeItAirLines.Domain.Model;
using System.Collections.Generic;

namespace CodeItAirLines.Domain.Interfaces.Repository
{
    public interface ILocaisRepository
    {
        List<Locais> ListaLocais();
        bool ContemTipo(Locais locais, TipoTripulantes tipo);
    }
}
