using CodeItAirLines.Domain;
using CodeItAirLines.Domain.Model;

namespace CodeItAirLines.Data.Builder
{
    public class TriupulateBuilder
    {
        private int _id;
        private string _nome;
        private TipoTripulantes _tipo;
        private bool _podeDirigir;

        public TriupulateBuilder SetId(int id)
        {
            _id = id;
            return this;
        }

        public TriupulateBuilder SetNome(string nome)
        {
            _nome = nome;
            return this;
        }

        public TriupulateBuilder SetTipoTripulante(TipoTripulantes tipo)
        {
            _tipo = tipo;
            return this;
        }

        public TriupulateBuilder SetPodeDirigir(bool podeDirigir)
        {
            _podeDirigir = podeDirigir;
            return this;
        }

        public Tripulante Create()
        {
            return new Tripulante(_id, _nome, _tipo, _podeDirigir);
        }
    }
}
