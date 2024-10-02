using DPA.GreenCity.DOMAIN.Core.Entities;
using DPA.GreenCity.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.GreenCity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IReportesRepository _reportesRepository;

        public ReportesController(IReportesRepository reportesRepository)
        {
            _reportesRepository = reportesRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetReportes()
        {
            var reportes = await _reportesRepository.GetReportes();
            return Ok(reportes);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetReporteById(int id)
        {
            var reporte = await _reportesRepository.GetReportesById(id);
            if(reporte == null) return NotFound();
            return Ok(reporte);
        }
        [HttpPost]
        public async Task<IActionResult> CreateReporte([FromBody]Reportes reportes)
        {
            int id = await _reportesRepository.InsertReporte(reportes);
            return Ok(id);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReporte([FromRoute]int id, [FromBody]Reportes reporte)
        {
            if(id != reporte.IdReporte)return BadRequest();
            var result = await _reportesRepository.UpdateReporte(reporte);
            if(!result)return BadRequest();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReporte([FromRoute]int id)
        {
            var result = await _reportesRepository.DeleteReporte(id);
            if(!result) return BadRequest();
            return Ok(result);
        }
    }
}
