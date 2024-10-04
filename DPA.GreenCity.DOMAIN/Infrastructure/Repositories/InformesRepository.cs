using DPA.GreenCity.DOMAIN.Core.Entities;
using DPA.GreenCity.DOMAIN.Core.Interfaces;
using DPA.GreenCity.DOMAIN.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.GreenCity.DOMAIN.Infrastructure.Repositories
{
    public class InformesRepository : IInformesRepository
    {
        private readonly GreenCityDbContext _dbContext;

        public InformesRepository(GreenCityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Informes>> GetInformes()
        {
            var listinformes = await _dbContext.Informes.ToListAsync();
            return listinformes;
        }

        public async Task<Informes> GetInformesById(int id)
        {
            var info = await _dbContext
                        .Informes.Where(i => i.IdInforme == id)
                        .FirstOrDefaultAsync();
            return info;
        }

        public async Task<int> Insert(Informes informes)
        {
            await _dbContext.Informes.AddAsync(informes);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0 ? informes.IdInforme : -1;

        }

        public async Task<bool> Update(Informes informes)
        {
            _dbContext.Informes.Update(informes);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<bool> Delete(int id)
        {
            var informe = _dbContext.Informes.Find(id);
            if (informe == null) return false;

            _dbContext.Informes.Remove(informe);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;

        }


    }
}
