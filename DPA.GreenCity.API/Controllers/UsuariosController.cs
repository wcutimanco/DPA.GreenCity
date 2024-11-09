using DPA.GreenCity.DOMAIN.Core.Entities;
using DPA.GreenCity.DOMAIN.Core.DTO;
using DPA.GreenCity.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.GreenCity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosServices _usuariosService;
        public UsuariosController(IUsuariosServices usuariosService)
        {
            _usuariosService = usuariosService;
        }

        [HttpPost("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] UsuariosRequestAuthDTO usuariosRequest)
        {
            var user = new Usuarios()
            {
                Correo = usuariosRequest.Correo,
                Contraseña = usuariosRequest.Contraseña,
                Nombre = usuariosRequest.Nombre,
                Telefono = usuariosRequest.Telefono,
                Direccion = usuariosRequest.Direccion,
                
            };

            var result = await _usuariosService.Insert(user);
            if (!result) return BadRequest(result);
            return Ok(result);
        }

        [HttpPost("SignIn")]
        public async Task<IActionResult> SignIn([FromBody] UsuariosAuthDTO authDTO)
        {
            //TODO: Validar email
            var result = await _usuariosService.SignIn(authDTO.Correo, authDTO.Contraseña);
            if (result == null) return NotFound();
            return Ok(result);
        }

    }

}

