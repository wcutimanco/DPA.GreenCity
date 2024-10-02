using DPA.GreenCity.DOMAIN.Core.Entities;

namespace DPA.GreenCity.DOMAIN.Core.Interfaces
{
    public interface IReportesRepository
    {
        Task<bool> DeleteReporte(int id);
        Task<IEnumerable<Reportes>> GetReportes();
        Task<Reportes> GetReportesById(int id);
        Task<int> InsertReporte(Reportes reporte);
        Task<bool> UpdateReporte(Reportes reporte);
    }
}