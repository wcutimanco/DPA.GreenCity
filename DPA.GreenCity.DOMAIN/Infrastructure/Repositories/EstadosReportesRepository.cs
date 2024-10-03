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
    // aqui se crean los crud
    public class EstadosReportesRepository : IEstadosReportesRepository
    // internal se cambia por public
    {
        private readonly GreenCityDbContext _dbContext; // se crea variable del tipo GreencityDbContext


        // constructor no dice class
        public EstadosReportesRepository(GreenCityDbContext dbContext) // parametro dbContext, del tipo GreenCityDbContext
        {
            _dbContext = dbContext;
        }
        //getall                          //aqui llamas a las clases que pusiste en Entities
        public async Task<IEnumerable<EstadosReportes>> GetEstadoReportes()
        {
            var estados = await _dbContext.EstadosReportes.ToListAsync();
            return estados;
        }

        //get by ID
        public async Task<IEnumerable<EstadosReportes>> GetEstadosReportesById(int id)
        {
            var estado = await _dbContext.EstadosReportes.Where(e => e.IdEstado == id).ToListAsync();
            return estado;
        }
        //insert
        public async Task<int> InsertEstadoReportes(EstadosReportes estadosReportes)
        {
            await _dbContext.EstadosReportes.AddAsync(estadosReportes);
            var rows = await _dbContext.SaveChangesAsync();
            return rows;
        }
        // update
        public async Task<bool> UpdateEstadoReportes(EstadosReportes estadosReportes)
        {
            _dbContext.EstadosReportes.Update(estadosReportes);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0 ? true : false;

        }
        //delete
        public async Task<bool> DeleteEstadoReportes(int id)
        {
            var estado = await _dbContext.EstadosReportes.FindAsync(id);
            if (estado == null) return false;
            int rows = await _dbContext.SaveChangesAsync();
            return (rows > 0);
        }

    }
}
