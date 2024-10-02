using System;
using System.Collections.Generic;

namespace DPA.GreenCity.DOMAIN.Core.Entities;

public partial class Reportes
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

    public virtual ICollection<Comentarios> Comentarios { get; set; } = new List<Comentarios>();

    public virtual ICollection<EstadosReportes> EstadosReportes { get; set; } = new List<EstadosReportes>();

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
