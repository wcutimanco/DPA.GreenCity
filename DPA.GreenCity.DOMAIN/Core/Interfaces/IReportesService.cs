using DPA.GreenCity.DOMAIN.Core.DTO;
using DPA.GreenCity.DOMAIN.Core.Entities;

namespace DPA.GreenCity.DOMAIN.Core.Interfaces
{
    public interface IReportesService
    {
        Task<bool> DeleteReporte(int id);
        Task<IEnumerable<ReporteListDTO>> GetReportes();
        Task<ReporteListDTO> GetReportesById(int id);
        Task<bool> InsertReporte(Reportes reporte);
        Task<bool> UpdateReportes(ReporteListDTO reporteListDTO);
    }
}