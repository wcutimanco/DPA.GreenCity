using DPA.GreenCity.DOMAIN.Core.Entities;
using DPA.GreenCity.DOMAIN.Core.Interfaces;
using DPA.GreenCity.DOMAIN.Infrastructure.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace DPA.GreenCity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosReportesController : ControllerBase
    {
        private readonly IEstadosReportesRepository _estadosReportesRepository;

        public EstadosReportesController(IEstadosReportesRepository estadosReportesRepository)
        {
            _estadosReportesRepository = estadosReportesRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetEstadoReportes()
        {
            var estados = await _estadosReportesRepository.GetEstadoReportes();
            return Ok(estados);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEstadoRepositoryByID(int id)
        {
            var estado = await _estadosReportesRepository.GetEstadosReportesById(id);
            if (estado == null) return BadRequest();
            return Ok(estado);

        }
        [HttpPost]
        public async Task<IActionResult> CreateEstadoReporte([FromBody] EstadosReportes estadosReportes)
        {
            int id = await _estadosReportesRepository.InsertEstadoReportes(estadosReportes);
            return Ok(id);
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateEstadoReportes([FromRoute] int id,[FromBody] EstadosReportes estadosReportes)
        {
            if (id != estadosReportes.IdEstado) return BadRequest();
            var result = await _estadosReportesRepository.UpdateEstadoReportes(estadosReportes);

            if(!result) return BadRequest();
            return Ok(result);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstadoReportes([ FromRoute]int id)
        {
            var result= await _estadosReportesRepository.DeleteEstadoReportes(id);
            if(!result) return BadRequest();
            return Ok(result);
        }


    }
}
