using CodeItAirLines.Data.Repository;
using CodeItAirLines.Domain.Interfaces.Repository;

namespace CodeItAirLines.Data.Factory
{
    public class TripulanteFactory
    {
        public static ITripulantesRepository Create()
        {
            return new TripulantesRepository();
        }
    }
}
