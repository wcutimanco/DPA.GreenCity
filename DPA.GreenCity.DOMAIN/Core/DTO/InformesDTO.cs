using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.GreenCity.DOMAIN.Core.DTO
{
    public class InformesDTO
    {
        public int IdInforme { get; set; }

        public int? IdUsuario { get; set; }

        public string TipoInforme { get; set; } = null!;

    }

    public class InformesListDTO
    {
        public int IdInforme { get; set; }

        public string TipoInforme { get; set; } = null!;

        internal void Add(InformesListDTO informeDTO)
        {
            throw new NotImplementedException();
        }
    }

    public class InformesTipoDTO
    {
       public string TipoInforme { get; set; } = null!;

    }



}
