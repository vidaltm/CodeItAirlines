using CodeItAirLines.Data.Builder;
using CodeItAirLines.Domain;
using CodeItAirLines.Domain.Interfaces.Repository;
using CodeItAirLines.Domain.Model;
using System;
using System.Collections.Generic;

namespace CodeItAirLines.Data.Repository
{
    public class TripulantesRepository : ITripulantesRepository
    {
        
        public List<Tripulante> ListarTripulantes()
        {
            var builder = new TriupulateBuilder();
            var tripulantes = new List<Tripulante>();
            
            tripulantes.Add(builder.SetId(1).SetNome("Thiago").SetPodeDirigir(true).SetTipoTripulante(TipoTripulantes.Piloto).Create());
            tripulantes.Add(builder.SetId(2).SetNome("Vitor").SetPodeDirigir(true).SetTipoTripulante(TipoTripulantes.ChefeDeServico).Create());
            tripulantes.Add(builder.SetId(3).SetNome("Murilo").SetPodeDirigir(false).SetTipoTripulante(TipoTripulantes.Oficial).Create());
            tripulantes.Add(builder.SetId(4).SetNome("Jacir").SetPodeDirigir(false).SetTipoTripulante(TipoTripulantes.Oficial).Create());
            tripulantes.Add(builder.SetId(5).SetNome("Franquiele").SetPodeDirigir(false).SetTipoTripulante(TipoTripulantes.Comissaria).Create());
            tripulantes.Add(builder.SetId(6).SetNome("Andresa").SetPodeDirigir(false).SetTipoTripulante(TipoTripulantes.Comissaria).Create());
            tripulantes.Add(builder.SetId(7).SetNome("Japones da Federal").SetPodeDirigir(true).SetTipoTripulante(TipoTripulantes.Policial).Create());
            tripulantes.Add(builder.SetId(8).SetNome("Fernandinho Beira Mar").SetPodeDirigir(false).SetTipoTripulante(TipoTripulantes.Presidiario).Create());

            return tripulantes;
        }

        public void ValidaMotorista(Tripulante tripulanteMotorista)
        {
            if (!tripulanteMotorista.Motorista)
                throw new Exception("Este tripulante selecionado para motorista não pode dirigir");
        }

        public void ValidaPassageiro(Tripulante tripulanteMotorista, Tripulante triupantePassageiro)
        {
            if ((tripulanteMotorista.TipoTripulante == TipoTripulantes.Piloto && triupantePassageiro.TipoTripulante == TipoTripulantes.Comissaria) ||
                (tripulanteMotorista.TipoTripulante == TipoTripulantes.Comissaria && triupantePassageiro.TipoTripulante == TipoTripulantes.Piloto))
            {
                throw new Exception("O Piloto e a Comissaria não podem ficar a sós");
            }
            if ((tripulanteMotorista.TipoTripulante == TipoTripulantes.ChefeDeServico && triupantePassageiro.TipoTripulante == TipoTripulantes.Oficial) ||
                (tripulanteMotorista.TipoTripulante == TipoTripulantes.Oficial && triupantePassageiro.TipoTripulante == TipoTripulantes.ChefeDeServico))
            {
                throw new Exception("O Chefe de Serviço e o Oficial não podem ficar a sós");
            }
        }
    }
}
