using System;
using System.Collections.Generic;

namespace DPA.GreenCity.DOMAIN.Core.Entities;

public partial class EstadosReportes
{
    public int IdEstado { get; set; }

    public int? IdReporte { get; set; }

    public string? EstadoAnterior { get; set; }

    public string? EstadoNuevo { get; set; }

    public DateTime? FechaCambio { get; set; }

    public string? ComentarioAdm { get; set; }

    public virtual Reportes? IdReporteNavigation { get; set; }
}
