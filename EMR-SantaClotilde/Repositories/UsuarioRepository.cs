using EMR_SantaClotilde.Models;
using System.Collections.Generic;
using System.Linq;

namespace EMR_SantaClotilde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EmrSantaClotildeContext _context;

        public UsuarioRepository(EmrSantaClotildeContext context)
        {
            _context = context;
        }

        private IQueryable<Usuario> QueryActivos()
        {
            return _context.Usuarios.Where(u => u.Activo);
        }

        public List<Usuario> GetAll()
        {
            return QueryActivos().ToList();
        }

        public Usuario? GetById(int id)
        {
            return QueryActivos().FirstOrDefault(u => u.Id == id);
        }

        public Usuario? GetByUsername(string username)
        {
            return QueryActivos().FirstOrDefault(u => u.Username == username);
        }

        public List<Usuario> SearchByNombre(string nombre)
        {
            return QueryActivos()
                .Where(u => u.NombreCompleto.Contains(nombre))
                .ToList();
        }

        public void Add(Usuario usuario)
        {
            usuario.Activo = true;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Update(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var usuario = _context.Usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario != null)
            {
                usuario.Activo = false;
                _context.Usuarios.Update(usuario);
                _context.SaveChanges();
            }
        }

        List<Usuario> IUsuarioRepository.SearchByNombre(string nombre)
        {
            throw new NotImplementedException();
        }
    }
}
