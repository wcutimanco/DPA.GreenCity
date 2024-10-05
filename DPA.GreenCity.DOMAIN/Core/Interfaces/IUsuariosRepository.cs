using DPA.GreenCity.DOMAIN.Core.Entities;

namespace DPA.GreenCity.DOMAIN.Core.Interfaces
{
    public interface IUsuariosRepository
    {
        Task<bool> DeleteUsuario(int id);
        Task<IEnumerable<Reportes>> GetUsuarios();
        Task<Reportes> GetUsuarioById(int id);
        Task<int> InsertUsuario(Usuarios usuario);
        Task<bool> UpdateUsuario(Usuarios usuario);
    }
}
