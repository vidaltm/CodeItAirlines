using CodeItAirLines.Data.Repository;
using CodeItAirLines.Domain.Interfaces.Repository;

namespace CodeItAirLines.Data.Factory
{
    public class CarroFactory
    {
        public static ICarroRepository Create()
        {
            return new CarroRepository();
        }
    }
}
