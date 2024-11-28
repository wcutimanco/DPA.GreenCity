using DPA.GreenCity.DOMAIN.Core.DTO;
using DPA.GreenCity.DOMAIN.Core.Entities;

namespace DPA.GreenCity.DOMAIN.Core.Interfaces
{
    public interface IInformesService
    {
        Task<IEnumerable<InformesDTO>> GetInformes();
        Task<InformesListDTO> GetInformesById(int id);
        Task<bool> InsertInforme(Informes informes);
        Task<bool> UpdateInformes(InformesDTO informesDTO);
    }
}