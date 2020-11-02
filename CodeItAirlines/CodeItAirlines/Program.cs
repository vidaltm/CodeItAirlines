using CodeItAirLines.Data.Factory;
using CodeItAirLines.Data.Services;
using System;

namespace CodeItAirlines
{
    class Program
    {
        static void Main(string[] args)
        {
            TransporteService transporteService = new TransporteService(TripulanteFactory.Create(),
                CarroFactory.Create(), LocalFactory.Create());
            Console.WriteLine("Iniciar o transporte? S / N ?");            
            if (Console.ReadLine().ToUpper() == "S")
            {
                transporteService.IniciarTransporte();
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine("Sair!");
            }
        }
    }
}
