using DPA.GreenCity.DOMAIN.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.GreenCity.DOMAIN.Core.DTO
{
    public class InformesDTO
    {

        public int? IdUsuario { get; set; }

        public string TipoInforme { get; set; } = null!;

        public DateTime? FechaGeneracion { get; set; }

        public string? Ubicacion { get; set; }

        public string? Categoria { get; set; }

        public string? RutaArchivo { get; set; }
      
    }

    public class InformesListDTO
    {
        public int IdInforme { get; set; }

        public string TipoInforme { get; set; } = null!;


    }

    public class InformesTipoDTO
    {
       public string TipoInforme { get; set; } = null!;

    }



}
