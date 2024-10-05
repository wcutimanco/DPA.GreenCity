using DPA.GreenCity.DOMAIN.Core.Entities;
using DPA.GreenCity.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.GreenCity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuariosRepository _usuariosRepository;

        public UsuariosController(IUsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetUsuarios()
        {
            var reportes = await _usuariosRepository.GetUsuarios();
            return Ok(reportes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUsuarioById(int id)
        {
            var reporte = await _usuariosRepository.GetUsuarioById(id);
            if (reporte == null) return NotFound();
            return Ok(reporte);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUsuario([FromBody] Reportes reportes)
        {
            int id = await _usuariosRepository.InsertUsuario(reportes);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUsuario([FromRoute] int id, [FromBody] Reportes reporte)
        {
            if (id != reporte.IdReporte) return BadRequest();
            var result = await _usuariosRepository.UpdateUsuario(reporte);
            if (!result) return BadRequest();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario([FromRoute] int id)
        {
            var result = await _usuariosRepository.DeleteUsuario(id);
            if (!result) return BadRequest();
            return Ok(result);
        }
    }
}
