using DPA.GreenCity.DOMAIN.Core.Entities;

namespace DPA.GreenCity.DOMAIN.Core.Interfaces
{
    public interface IInformesRepository
    {
        Task<bool> Delete(int id);
        Task<IEnumerable<Informes>> GetInformes();
        Task<Informes> GetInformesById(int id);
        Task<bool> Insert(Informes informes);
        Task<bool> Update(Informes informes);
    }
}