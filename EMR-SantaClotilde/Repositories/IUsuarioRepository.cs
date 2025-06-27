using EMR_SantaClotilde.Models;
using System.Collections.Generic;

namespace EMR_SantaClotilde.Repositories
{
    public interface IUsuarioRepository
    {
        Usuarios? GetById(int id);
        List<Usuarios> GetAll();
        Usuarios? GetByUsername(string username);
        List<Usuario> SearchByNombre(string nombre);
        void Add(Usuarios usuario);
        void Update(Usuarios usuario);
        void Delete(int id);
    }
}
