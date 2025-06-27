using EMR_SantaClotilde.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> GetByIdAsync(int id);
        Task<List<Usuario>> GetAllAsync();
        Task<Usuario?> GetByUsernameAsync(string username);
        Task<List<Usuario>> SearchByNombreAsync(string nombre);
        Task AddAsync(Usuario usuario);
        Task UpdateAsync(Usuario usuario);
        Task DeleteAsync(int id);
    }
}