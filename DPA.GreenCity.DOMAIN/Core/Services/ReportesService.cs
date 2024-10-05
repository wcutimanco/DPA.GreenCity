using DPA.GreenCity.DOMAIN.Core.DTO;
using DPA.GreenCity.DOMAIN.Core.Entities;
using DPA.GreenCity.DOMAIN.Core.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.GreenCity.DOMAIN.Core.Services
{
    public class ReportesService : IReportesService
    {
        private readonly IReportesRepository _reportesRepository;

        public ReportesService(IReportesRepository reportesRepository)
        {
            _reportesRepository = reportesRepository;
        }

        public async Task<IEnumerable<ReporteListDTO>> GetReportes()
        {
            var reportes = await _reportesRepository.GetReportes();
            var reportesDTO = new List<ReporteListDTO>();
            foreach (var reporte in reportes)
            {
                var reporteDTO = new ReporteListDTO();
                reporteDTO.IdReporte = reporte.IdReporte;
                reporteDTO.IdUsuario = reporte.IdUsuario;
                reporteDTO.Categoria = reporte.Categoria;
                reporteDTO.Descripcion = reporte.Descripcion;
                reporteDTO.Estado = reporte.Estado;
                reporteDTO.FechaCreacion = reporte.FechaCreacion;
                reporteDTO.FechaActualizacion = reporte.FechaActualizacion;
                reportesDTO.Add(reporteDTO);
            }
            return reportesDTO;
        }
        public async Task<ReporteListDTO> GetReportesById(int id)
        {
            var reporte = await _reportesRepository.GetReportesById(id);
            var reporteDTO = new ReporteListDTO();
            reporteDTO.IdReporte = reporte.IdReporte;
            reporteDTO.Descripcion = reporte.Descripcion;
            return reporteDTO;
        }

        public async Task<int> InsertReportes(ReporteDescriptionDTO reporteDTO)
        {
            var reporte = new Reportes();
            reporte.Descripcion = reporteDTO.Descripcion;
            reporte.IsActive = true;

            int id = await _reportesRepository.InsertReporte(reporte);
            return id;
        }

        public async Task<bool> UpdateReportes(ReporteListDTO reporteListDTO)
        {
            var reporte = new Reportes();
            reporte.IdReporte = reporteListDTO.IdReporte;
            reporte.Descripcion = reporteListDTO.Descripcion;

            await _reportesRepository.UpdateReporte(reporte);
            return true;
        }

        public async Task<bool> DeleteReporte(int id)
        {
            return await _reportesRepository.DeleteReporte(id);
        }


    }
}
