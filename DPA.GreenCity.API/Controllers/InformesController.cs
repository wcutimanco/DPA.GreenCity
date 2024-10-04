using DPA.GreenCity.DOMAIN.Core.Entities;
using DPA.GreenCity.DOMAIN.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DPA.GreenCity.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InformesController : ControllerBase
    {
        private readonly IInformesRepository _informesRepository;

        public InformesController(IInformesRepository informesRepository)
        {
            _informesRepository = informesRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetInformes()
        {
            var informes = await _informesRepository.GetInformes();
            return Ok(informes);

        }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetInformesById(int id)
        {
            var informes = await _informesRepository.GetInformesById(id);
            if (informes == null) return NotFound();
            return Ok(informes);

        }

        [HttpPost]

        public async Task<IActionResult> Create([FromBody] Informes informes)
        {
            int id = await _informesRepository.Insert(informes);
            return Ok(id);
        
        }

        [HttpPut("{id}")]

        public async Task<IActionResult>Update([FromRoute]int id, [FromBody] Informes informes)
        {
            if (id != informes.IdInforme) return BadRequest();

            var result = await _informesRepository.Update(informes);
            if (!result) return BadRequest();
            return Ok(result);


        }

        [HttpDelete]

        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var result = await _informesRepository.Delete(id);
            if (!result) return BadRequest();
            return Ok(result);
        }


    }
}
