using DPA.GreenCity.DOMAIN.Core.DTO;
using DPA.GreenCity.DOMAIN.Core.Entities;

namespace DPA.GreenCity.DOMAIN.Core.Interfaces
{
    public interface IUsuariosServices
    {
        Task<bool> Insert(Usuarios user);
        Task<UsuariosResponseAuthDTO> SignIn(string email, string pwd);
    }
}