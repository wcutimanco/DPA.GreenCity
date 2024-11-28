using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.GreenCity.DOMAIN.Core.DTO
{
    public class UsuariosDTO
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Contraseña { get; set; } = null!;

        public string TipoUsuario { get; set; } = null!;

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

    }

    public class UsuariosRequestAuthDTO
    {

        public string Nombre { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string Contraseña { get; set; } = null!;

        public string? Telefono { get; set; }

        public string? Direccion { get; set; }
    }

    public class UsuariosResponseAuthDTO
    {
        public int IdUsuario { get; set; }

        public string Nombre { get; set; } = null!;

        public string Correo { get; set; } = null!;

        public string TipoUsuario { get; set; } = null!;
        public string? Telefono { get; set; }

        public string? Direccion { get; set; }

        public string? Token { get; set; }
        public bool IsEmailSent { get; set; }

    }

    public class UsuariosAuthDTO 
    {
        public string Correo { get; set; } = null!;
        public string Contraseña { get; set; } = null!;

    }


}
