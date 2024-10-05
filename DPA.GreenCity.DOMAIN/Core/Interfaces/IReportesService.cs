using DPA.GreenCity.DOMAIN.Core.DTO;

namespace DPA.GreenCity.DOMAIN.Core.Interfaces
{
    public interface IReportesService
    {
        Task<bool> DeleteReporte(int id);
        Task<IEnumerable<ReporteListDTO>> GetReportes();
        Task<ReporteListDTO> GetReportesById(int id);
        Task<int> InsertReportes(ReporteDescriptionDTO reporteDTO);
        Task<bool> UpdateReportes(ReporteListDTO reporteListDTO);
    }
}