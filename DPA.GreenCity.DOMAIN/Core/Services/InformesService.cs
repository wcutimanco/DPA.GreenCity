using DPA.GreenCity.DOMAIN.Core.DTO;
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


        public async Task<IEnumerable<InformesListDTO>> GetInformes()
        {
            var informes = await _informesRepository.GetInformes();
            var informesDTO = new List<InformesListDTO>();
            foreach (var informe in informes)
            {
                var informeDTO = new InformesListDTO();
                informeDTO.IdInforme = informe.IdInforme;
                informeDTO.TipoInforme = informe.TipoInforme;
                informesDTO.Add(informeDTO);

            }

            return informesDTO;
        }

        public async Task<InformesListDTO> GetInformesById(int id)
        {
            var informes = await _informesRepository.GetInformesById(id);
            var informeDTO = new InformesListDTO();

            informeDTO.IdInforme = informes.IdInforme;
            informeDTO.TipoInforme = informes.TipoInforme;

            return informeDTO;

        }







    }
}
