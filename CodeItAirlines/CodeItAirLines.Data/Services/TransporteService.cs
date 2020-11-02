using CodeItAirLines.Domain;
using CodeItAirLines.Domain.Interfaces.Repository;
using CodeItAirLines.Domain.Model;
using System;
using System.Linq;
using System.Threading;

namespace CodeItAirLines.Data.Services
{
    public class TransporteService
    {
        private readonly ITripulantesRepository _tripulantesRepository;
        private readonly ICarroRepository _carrosRepository;
        private readonly ILocaisRepository _locaisRepository;

        public TransporteService(ITripulantesRepository tripulantesRepository,
            ICarroRepository carroRepository, ILocaisRepository locaisRepository)
        {
            _tripulantesRepository = tripulantesRepository;
            _carrosRepository = carroRepository;
            _locaisRepository = locaisRepository;
        }

        public void IniciarTransporte()
        {
            try
            {
                var origem = _locaisRepository.ListaLocais().FirstOrDefault();                
                var carros = _carrosRepository.ListaCarros();
                var destino = _locaisRepository.ListaLocais().LastOrDefault();
                Console.WriteLine("Transferindo de " + origem.Local  + " para " + destino.Local + " de " + carros.FirstOrDefault().Modelo);
                while(origem.Tripulantes.Count > 0)
                {
                    Transportar(origem, destino);
                }
                Console.WriteLine("Todos embarcados no avião!");
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Transportar(Locais origem, Locais destino)
        {
            Tripulante motorista = null;
            Tripulante passageiro = null;
            bool ultimaviagem = false;

            if (_locaisRepository.ContemTipo(origem, TipoTripulantes.Oficial))
            {
                passageiro = origem.Tripulantes.FirstOrDefault(t => t.TipoTripulante == TipoTripulantes.Oficial);
                motorista = origem.Tripulantes.FirstOrDefault(t => t.TipoTripulante == TipoTripulantes.Piloto);
                ForTwo(motorista, passageiro);
            }
            else if (_locaisRepository.ContemTipo(origem, TipoTripulantes.Piloto))
            {
                passageiro = origem.Tripulantes.FirstOrDefault(t => t.TipoTripulante == TipoTripulantes.Piloto);
                motorista = origem.Tripulantes.FirstOrDefault(t => t.TipoTripulante == TipoTripulantes.ChefeDeServico);
                ForTwo(motorista, passageiro);
            }
            else if (_locaisRepository.ContemTipo(origem, TipoTripulantes.Comissaria))
            {
                passageiro = origem.Tripulantes.FirstOrDefault(t => t.TipoTripulante == TipoTripulantes.Comissaria);
                motorista = origem.Tripulantes.FirstOrDefault(t => t.TipoTripulante == TipoTripulantes.ChefeDeServico);
                ForTwo(motorista, passageiro);
            }
            else if (_locaisRepository.ContemTipo(origem, TipoTripulantes.ChefeDeServico))
            {
                passageiro = origem.Tripulantes.FirstOrDefault(t => t.TipoTripulante == TipoTripulantes.ChefeDeServico);
                motorista = origem.Tripulantes.FirstOrDefault(t => t.TipoTripulante == TipoTripulantes.Policial);
                ForTwo(motorista, passageiro);
            }
            else
            {
                passageiro = origem.Tripulantes.FirstOrDefault(t => t.TipoTripulante == TipoTripulantes.Presidiario);
                motorista = origem.Tripulantes.FirstOrDefault(t => t.TipoTripulante == TipoTripulantes.Policial);
                ForTwo(motorista, passageiro);
                ultimaviagem = true;
            }
            
            RealizarEmbarque(origem, destino, passageiro, motorista, ultimaviagem);
        }

        private void RealizarEmbarque(Locais origem, Locais destino, Tripulante passageiro, Tripulante motorista, bool ultimaViagem)
        {
            _tripulantesRepository.ValidaMotorista(motorista);
            _tripulantesRepository.ValidaPassageiro(motorista, passageiro);
            Console.WriteLine("Saindo de Aeroporto até Avião");
            if (ultimaViagem)
            {
                Desembarque(motorista, null, origem, destino, ultimaViagem);                
            }
            Desembarque(passageiro, motorista, origem, destino, ultimaViagem);
            Console.WriteLine("---------------------------------------------------------------------------------------------");
            Thread.Sleep(2000);
        }        

        private void Desembarque(Tripulante passageiro, Tripulante motorista, Locais origem, Locais destino, bool ultimaViagem)
        {
            origem.Tripulantes.Remove(passageiro);
            destino.Tripulantes.Add(passageiro);
            Console.WriteLine(passageiro.Nome + "("+ passageiro.TipoTripulante.ToString()+") desceu em: " + destino.Local);

            if(motorista != null && !ultimaViagem)
                Console.WriteLine(motorista.Nome + "(" + motorista.TipoTripulante.ToString() + ") voltou ao Aeroporto");
        }

        private void ForTwo(Tripulante motorista, Tripulante passageiro)
        {
            Console.WriteLine("Dirigindo o ForTwo " + motorista.Nome + "(" + motorista.TipoTripulante.ToString() + ")" + 
                " e com o passageiro " + passageiro.Nome + "(" + passageiro.TipoTripulante.ToString() + ")");
        }
    }
}
