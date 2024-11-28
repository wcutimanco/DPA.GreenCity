using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.GreenCity.DOMAIN.Core.DTO
{
   
        public class ReporteDTO
        {
            public int IdReporte { get; set; }

            public int? IdUsuario { get; set; }

            public string Categoria { get; set; } = null!;

            public string? Subcategoria { get; set; }

            public string Descripcion { get; set; } = null!;

            public string Estado { get; set; } = null!;

            public DateTime? FechaCreacion { get; set; }

            public DateTime? FechaActualizacion { get; set; }

            public double? UbicacionLat { get; set; }

            public double? UbicacionLng { get; set; }

            public string? Foto { get; set; }
            public bool? IsActive { get; set; }
        }
        public class ReporteListDTO
        {
            public int IdReporte { get; set; }

            public int? IdUsuario { get; set; }

            public string Categoria { get; set; } = null!;

            public string Descripcion { get; set; } = null!;

            public string Estado { get; set; } = null!;

            public DateTime? FechaCreacion { get; set; }

            public DateTime? FechaActualizacion { get; set; }

           
        }

        public class ReporteDescriptionDTO
        {
            public string? Descripcion { get; set; }
        }

    public class ReportePostDTO
    {

        public int? IdUsuario { get; set; }

        public string Categoria { get; set; } = null!;

        public string? Subcategoria { get; set; }

        public string Descripcion { get; set; } = null!;

       
        public DateTime? FechaCreacion { get; set; }


      


       }

    }
