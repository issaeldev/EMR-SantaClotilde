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

        /// <summary>
        /// Retorna un IQueryable con solo los usuarios activos.
        /// Puedes componer más filtros antes de ejecutar ToList(), FirstOrDefault(), etc.
        /// </summary>
        private IQueryable<Usuarios> QueryActivos()
        {
            return _context.Usuarios.Where(u => u.Activo);
        }

        public List<Usuarios> GetAll()
        {
            return QueryActivos().ToList();
        }

        public Usuarios? GetById(int id)
        {
            return QueryActivos().FirstOrDefault(u => u.Id == id);
        }

        public Usuarios? GetByUsername(string username)
        {
            return QueryActivos().FirstOrDefault(u => u.Username == username);
        }

        public List<Usuarios> SearchByNombre(string nombre)
        {
            return QueryActivos()
                .Where(u => u.NombreCompleto.Contains(nombre))
                .ToList();
        }

        public void Add(Usuarios usuario)
        {
            usuario.Activo = true;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
        }

        public void Update(Usuarios usuario)
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
