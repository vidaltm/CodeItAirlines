using CodeItAirLines.Domain.Model;
using System.Collections.Generic;

namespace CodeItAirLines.Data.Builder
{
    public class LocalBuilder
    {
        private int _id;
        private string _local;
        private List<Tripulante> _tripulantes;

        public LocalBuilder SetId(int id)
        {
            _id = id;
            return this;
        }

        public LocalBuilder SetLocal(string local)
        {
            _local = local;
            return this;
        }

        public LocalBuilder SetListaTribulantes(List<Tripulante> tripulantes)
        {
            _tripulantes = tripulantes;
            return this;
        }

        public Locais Create()
        {
            return new Locais(_id, _local, _tripulantes);
        }
    }
}
