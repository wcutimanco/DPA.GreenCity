using DPA.GreenCity.DOMAIN.Core.DTO;
using DPA.GreenCity.DOMAIN.Core.Entities;
using DPA.GreenCity.DOMAIN.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.GreenCity.DOMAIN.Core.Services
{
    public class InformesService : IInformesService
    {
        private readonly IInformesRepository _informesRepository;

        public InformesService(IInformesRepository informesRepository)
        {
            _informesRepository = informesRepository;
        }


        public async Task<IEnumerable<InformesDTO>> GetInformes()
        {
            var informes = await _informesRepository.GetInformes();
            var informesDTO = new List<InformesDTO>();
            foreach (var informe in informes)
            {
                var informeDTO = new InformesDTO();
                informeDTO.IdUsuario = informe.IdUsuario;
                informeDTO.TipoInforme = informe.TipoInforme;
                informeDTO.FechaGeneracion = informe.FechaGeneracion;
                informeDTO.Ubicacion = informe.Ubicacion;
                informeDTO.Categoria = informe.Categoria;
                informeDTO.RutaArchivo = informe.RutaArchivo;
                informesDTO.Add(informeDTO);

            }

            return informesDTO;
        }

        public async Task<bool> InsertInforme(Informes informes)
        {
            return await _informesRepository.Insert(informes);
        }

        public async Task<InformesListDTO> GetInformesById(int id)
        {
            var informes = await _informesRepository.GetInformesById(id);
            var informeDTO = new InformesListDTO();

            informeDTO.IdInforme = informes.IdInforme;
            informeDTO.TipoInforme = informes.TipoInforme;

            return informeDTO;

        }

        public async Task<bool> UpdateInformes(InformesDTO informesDTO)
        {
            var informe = new Informes();
            informe.IdUsuario = informesDTO.IdUsuario;
            informe.RutaArchivo = informesDTO.RutaArchivo;

            await _informesRepository.Update(informe);
            return true;
        }







    }
}
