using DPA.GreenCity.DOMAIN.Core.Entities;

namespace DPA.GreenCity.DOMAIN.Core.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<bool> Insert(Usuarios user);
        Task<Usuarios> SignIn(string email, string pwd);
    }
}