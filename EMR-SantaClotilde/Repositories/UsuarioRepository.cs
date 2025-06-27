using EMR_SantaClotilde.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public Usuario? GetById(int id)
        {
            return QueryActivos().FirstOrDefault(u => u.Id == id);
        }

        public List<Usuario> GetAll()
        {
            return QueryActivos().ToList();
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            return await QueryActivos().FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            return await QueryActivos().ToListAsync();
        }

        public async Task<Usuario?> GetByUsernameAsync(string username)
        {
            return await QueryActivos().FirstOrDefaultAsync(u => u.Username == username);
        }

        public async Task<List<Usuario>> SearchByNombreAsync(string nombre)
        {
            return await QueryActivos()
                .Where(u => u.NombreCompleto.Contains(nombre))
                .ToListAsync();
        }

        public async Task AddAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null && usuario.Activo)
            {
                usuario.Activo = false; // Eliminado lógico
                _context.Usuarios.Update(usuario);
                await _context.SaveChangesAsync();
            }
        }
    }
}