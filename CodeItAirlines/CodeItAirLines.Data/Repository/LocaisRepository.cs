using CodeItAirLines.Data.Builder;
using CodeItAirLines.Domain;
using CodeItAirLines.Domain.Interfaces.Repository;
using CodeItAirLines.Domain.Model;
using System.Collections.Generic;
using System.Linq;

namespace CodeItAirLines.Data.Repository
{
    public class LocaisRepository : ILocaisRepository
    {
        private readonly ITripulantesRepository _tripulantesRepository;

        public LocaisRepository(ITripulantesRepository tripulantesRepository)
        {
            _tripulantesRepository = tripulantesRepository;
        }
        public List<Locais> ListaLocais()
        {
            var builder = new LocalBuilder();
            var locais = new List<Locais>();

            locais.Add(builder.SetId(1).SetLocal("Aeroporto").SetListaTribulantes(_tripulantesRepository.ListarTripulantes()).Create());
            locais.Add(builder.SetId(2).SetLocal("Avião").SetListaTribulantes(new List<Tripulante>()).Create());
            return locais;
        }

        public bool ContemTipo(Locais locais, TipoTripulantes tipo)
        {
            return locais.Tripulantes.Any(t => t.TipoTripulante == tipo);
        }
    }
}
