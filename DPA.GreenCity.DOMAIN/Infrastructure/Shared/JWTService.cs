using DPA.GreenCity.DOMAIN.Core.Entities;
using DPA.GreenCity.DOMAIN.Core.Interfaces;
using DPA.GreenCity.DOMAIN.Core.Settings;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace DPA.GreenCity.DOMAIN.Infrastructure.Shared
{
    public class JWTService : IJWTService
        {
            public JWTSettings _settings { get; }
            public JWTService(IOptions<JWTSettings> settings)
            {
                _settings = settings.Value;
            }

            public string GenerateJWToken(Usuarios user)
            {
                var ssk = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_settings.SecretKey));
                var sc = new SigningCredentials(ssk, SecurityAlgorithms.HmacSha256);
                var header = new JwtHeader(sc);
                var role = user.TipoUsuario switch
                {
                    "ADM" => "Admin",
                    "CIU" => "User",
                    "AUL" => "LocalAuthority",
                    _ => "User" // Valor por defecto en caso de que TipoUsuario tenga un valor no esperado
                };

                var claims = new[] {
                    new Claim(ClaimTypes.Name, user.Nombre),
                    new Claim(ClaimTypes.Email, user.Correo),
                    new Claim(ClaimTypes.Role, role),
                    //new Claim(ClaimTypes.Role, user.TipoUsuario == "ADM" ? "Admin": "User"),
                    new Claim("UserId",user.IdUsuario.ToString()),
                };

                var payload = new JwtPayload(
                                _settings.Issuer
                                , _settings.Audience
                                , claims
                                , DateTime.UtcNow
                                , DateTime.UtcNow.AddMinutes(_settings.DurationInMinutes));

                var token = new JwtSecurityToken(header, payload);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }
        }
    }





