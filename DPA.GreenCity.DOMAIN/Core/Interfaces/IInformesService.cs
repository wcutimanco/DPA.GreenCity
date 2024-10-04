using DPA.GreenCity.DOMAIN.Core.DTO;

namespace DPA.GreenCity.DOMAIN.Core.Interfaces
{
    public interface IInformesService
    {
        Task<IEnumerable<InformesListDTO>> GetInformes();
        Task<InformesListDTO> GetInformesById(int id);
    }
}