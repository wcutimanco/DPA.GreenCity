using DPA.GreenCity.DOMAIN.Core.DTO;
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

        private readonly IInformesService _informesService;

        public InformesController(IInformesService informesService) 
            {
                _informesService = informesService;
            }

        [HttpGet]

        public async Task<IActionResult> GetInformes() {
                var informes = await _informesService.GetInformes();
                return Ok(informes);

            }

        [HttpGet("{id}")]

        public async Task<IActionResult> GetInformesById(int id)
        {
                var informes = await _informesService.GetInformesById(id);
                if (informes == null) return NotFound();
                return Ok(informes);

        }

        [HttpPost("Informar")]

        public async Task<IActionResult> CreateInforme([FromBody] InformesDTO informesDTO)
        {
                var informes = new Informes()
                {
                    IdUsuario = informesDTO.IdUsuario,
                    TipoInforme = informesDTO.TipoInforme,
                    Ubicacion = informesDTO.Ubicacion,
                    Categoria = informesDTO.Categoria,
                    RutaArchivo = informesDTO.RutaArchivo,

                };

                var result = await _informesService.InsertInforme(informes);
                if (!result) return BadRequest(result);
                return Ok(result);
         }

            /*  [HttpPut("{id}")]

              public async Task<IActionResult>Update([FromRoute]int id, [FromBody] Informes informes)
              {
                  if (id != informes.IdInforme) return BadRequest();

                  var result = await _informesService.Update(informes);
                  if (!result) return BadRequest();
                  return Ok(result);


              }

             /* [HttpDelete]

              public async Task<IActionResult> Delete([FromRoute] int id)
              {
                  var result = await _informesService.Delete(id);
                  if (!result) return BadRequest();
                  return Ok(result);
              }*/


        }
    }

