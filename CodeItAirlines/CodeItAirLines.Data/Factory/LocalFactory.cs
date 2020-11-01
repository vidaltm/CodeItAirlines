using CodeItAirLines.Data.Repository;
using CodeItAirLines.Domain.Interfaces.Repository;

namespace CodeItAirLines.Data.Factory
{
    public class LocalFactory
    {
        public static ILocaisRepository Create()
        {
            return new LocaisRepository(TripulanteFactory.Create());
        }
    }
}
