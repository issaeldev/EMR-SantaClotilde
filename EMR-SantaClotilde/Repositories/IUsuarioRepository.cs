using EMR_SantaClotilde.Models;
using System.Collections.Generic;

namespace EMR_SantaClotilde.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario? GetById(int id);
        List<Usuario> GetAll();
        Usuario? GetByUsername(string username);
        List<Usuario> SearchByNombre(string nombre);
        void Add(Usuario usuario);
        void Update(Usuario usuario);
        void Delete(int id);
    }
}
