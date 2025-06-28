using EMR_SantaClotilde.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDbContextFactory<EmrSantaClotildeContext> _contextFactory;

        public UsuarioRepository(IDbContextFactory<EmrSantaClotildeContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        private IQueryable<Usuario> QueryActivos(EmrSantaClotildeContext context)
        {
            return context.Usuarios.Where(u => u.Activo);
        }

        public async Task<Usuario?> GetByIdAsync(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await QueryActivos(context).FirstOrDefaultAsync(u => u.Id == id);
            }
        }

        public async Task<List<Usuario>> GetAllAsync()
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await QueryActivos(context).ToListAsync();
            }
        }

        public async Task<Usuario?> GetByUsernameAsync(string username)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await QueryActivos(context).FirstOrDefaultAsync(u => u.Username == username);
            }
        }

        public async Task<List<Usuario>> SearchByNombreAsync(string nombre)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                return await QueryActivos(context)
                    .Where(u => u.NombreCompleto.Contains(nombre))
                    .ToListAsync();
            }
        }

        public async Task AddAsync(Usuario usuario)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                await context.Usuarios.AddAsync(usuario);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Usuario usuario)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                context.Usuarios.Update(usuario);
                await context.SaveChangesAsync();
            }
        }

        public async Task DeleteAsync(int id)
        {
            using (var context = _contextFactory.CreateDbContext())
            {
                var usuario = await context.Usuarios.FindAsync(id);
                if (usuario != null && usuario.Activo)
                {
                    usuario.Activo = false; // Eliminado lógico
                    context.Usuarios.Update(usuario);
                    await context.SaveChangesAsync();
                }
            }
        }
    }
}