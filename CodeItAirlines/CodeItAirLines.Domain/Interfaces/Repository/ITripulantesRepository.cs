using CodeItAirLines.Domain.Model;
using System.Collections.Generic;

namespace CodeItAirLines.Domain.Interfaces.Repository
{
    public interface ITripulantesRepository
    {
        List<Tripulante> ListarTripulantes();
        void ValidaMotorista(Tripulante tripulanteMotorista);
        void ValidaPassageiro(Tripulante tripulanteMotorista, Tripulante triupantePassageiro);
    }
}
