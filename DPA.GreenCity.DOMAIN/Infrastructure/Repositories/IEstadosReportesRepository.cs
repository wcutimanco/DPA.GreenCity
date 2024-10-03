using DPA.GreenCity.DOMAIN.Core.Entities;

namespace DPA.GreenCity.DOMAIN.Infrastructure.Repositories
{
    public interface IEstadosReportesRepository
    {
        Task<bool> DeleteEstadoReportes(int id);
        Task<IEnumerable<EstadosReportes>> GetEstadoReportes();
        Task<IEnumerable<EstadosReportes>> GetEstadosReportesById(int id);
        Task<int> InsertEstadoReportes(EstadosReportes estadosReportes);
        Task<bool> UpdateEstadoReportes(EstadosReportes estadosReportes);
    }
}