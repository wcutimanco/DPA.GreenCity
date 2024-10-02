using System;
using System.Collections.Generic;

namespace DPA.GreenCity.DOMAIN.Core.Entities;

public partial class Informes
{
    public int IdInforme { get; set; }

    public int? IdUsuario { get; set; }

    public string TipoInforme { get; set; } = null!;

    public DateTime? FechaGeneracion { get; set; }

    public string? Ubicacion { get; set; }

    public string? Categoria { get; set; }

    public string? RutaArchivo { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
