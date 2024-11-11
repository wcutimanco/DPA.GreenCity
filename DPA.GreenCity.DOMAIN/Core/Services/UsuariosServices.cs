using DPA.GreenCity.DOMAIN.Core.DTO;
using DPA.GreenCity.DOMAIN.Core.Entities;
using DPA.GreenCity.DOMAIN.Core.Interfaces;
using DPA.GreenCity.DOMAIN.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DPA.GreenCity.DOMAIN.Core.Services
{
    public class UsuariosServices : IUsuariosServices
    {
        private readonly IUsuariosRepository _usuariosRepository;
        private readonly IJWTService _jwtService;
        public UsuariosServices(IUsuariosRepository usuariosRepository, IJWTService jwtService)
        {
            _usuariosRepository = usuariosRepository;
            _jwtService = jwtService;
        }

        public async Task<UsuariosResponseAuthDTO> SignIn(string email, string pwd)
        {
            var user = await _usuariosRepository.SignIn(email, pwd);
            if (user == null)
                return null;

            //TODO: implementar token & email
            var token = _jwtService.GenerateJWToken(user);
            var sendEmail = false;

            var usuarioResponseAuth = new UsuariosResponseAuthDTO()
            {
                IdUsuario = user.IdUsuario,
                Correo = email,
                Nombre = user.Nombre,
                Telefono = user.Telefono,
                Direccion = user.Direccion,
                Token = token,
                IsEmailSent = sendEmail,
            };
            return usuarioResponseAuth;
        }

        public async Task<bool> Insert(Usuarios user)
        {
            return await _usuariosRepository.Insert(user);
        }
    }
}

