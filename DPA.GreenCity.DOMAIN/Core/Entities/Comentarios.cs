using System;
using System.Collections.Generic;

namespace DPA.GreenCity.DOMAIN.Core.Entities;

public partial class Comentarios
{
    public int IdComentario { get; set; }

    public int? IdReporte { get; set; }

    public int? IdUsuario { get; set; }

    public string Comentario { get; set; } = null!;

    public DateTime? FechaComentario { get; set; }

    public virtual Reportes? IdReporteNavigation { get; set; }

    public virtual Usuarios? IdUsuarioNavigation { get; set; }
}
