using DPA.GreenCity.DOMAIN.Core.Entities;
using DPA.GreenCity.DOMAIN.Core.Interfaces;
using DPA.GreenCity.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.GreenCity.DOMAIN.Infrastructure.Repositories
{
    public class ReportesRepository : IReportesRepository
    {
        public readonly GreenCityDbContext _greenCityDbContext;

        public ReportesRepository(GreenCityDbContext greenCityDbContext)
        {
            _greenCityDbContext = greenCityDbContext;
        }
        public async Task<IEnumerable<Reportes>> GetReportes()
        {
            var reportes = await _greenCityDbContext.Reportes.ToListAsync();
            return reportes;
        }
        public async Task<Reportes> GetReportesById(int id)
        {
            var reporte = await _greenCityDbContext.Reportes
                .Where(r => r.IdReporte == id)
                .FirstOrDefaultAsync();
            return reporte;
        }
        public async Task<bool> InsertReporte(Reportes reporte)
        {
            reporte.IsActive = true;
            await _greenCityDbContext.Reportes.AddAsync(reporte);
            int row = await _greenCityDbContext.SaveChangesAsync();
            return row > 0;
        }

        public async Task<bool> UpdateReporte(Reportes reporte)
        {
            _greenCityDbContext.Reportes.Update(reporte);
            int rows = await _greenCityDbContext.SaveChangesAsync();
            return rows > 0 ? true : false;
        }

        public async Task<bool> DeleteReporte(int id)
        {
            var reporte = await _greenCityDbContext.Reportes.FindAsync(id);
            if (reporte == null) return false;
            reporte.IsActive = false;
            int rows = await _greenCityDbContext.SaveChangesAsync();
            return (rows > 0);

        }


    }
}
