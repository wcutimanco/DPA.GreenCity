using System;
using System.Collections.Generic;

namespace DPA.GreenCity.DOMAIN.Infrastructure.Data;

public partial class Usuarios
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Contraseña { get; set; } = null!;

    public string TipoUsuario { get; set; } = null!;

    public string? Telefono { get; set; }

    public string? Direccion { get; set; }

    public virtual ICollection<Comentarios> Comentarios { get; set; } = new List<Comentarios>();

    public virtual ICollection<Informes> Informes { get; set; } = new List<Informes>();

    public virtual ICollection<Reportes> Reportes { get; set; } = new List<Reportes>();
}
