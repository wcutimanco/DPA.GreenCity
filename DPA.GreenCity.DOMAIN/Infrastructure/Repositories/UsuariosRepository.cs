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
    public class UsuariosRepository : IUsuariosRepository
    {
        private readonly GreenCityDbContext _dbContext;

        public UsuariosRepository(GreenCityDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> Insert(Usuarios user)
        {
            await _dbContext.Usuarios.AddAsync(user);
            int rows = await _dbContext.SaveChangesAsync();
            return rows > 0;
        }

        public async Task<Usuarios> SignIn(string email, string pwd)
        {
            return await _dbContext
                .Usuarios
                .Where(x => x.Correo == email && x.Contraseña == pwd)
                .FirstOrDefaultAsync();
        }


    }
}
