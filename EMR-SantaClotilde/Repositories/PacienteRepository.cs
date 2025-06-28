using EMR_SantaClotilde.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly IDbContextFactory<EmrSantaClotildeContext> _contextFactory;

        public PacienteRepository(IDbContextFactory<EmrSantaClotildeContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        public IQueryable<Paciente> QueryActivos(EmrSantaClotildeContext context)
        {
            return context.Pacientes.Where(p => p.Activo);
        }

        public async Task<List<Paciente>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await QueryActivos(context).ToListAsync();
        }

        public async Task<Paciente?> GetByIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            return await QueryActivos(context).FirstOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Paciente?> GetByDniAsync(string dni)
        {
            using var context = _contextFactory.CreateDbContext();
            return await QueryActivos(context).FirstOrDefaultAsync(p => p.Dni == dni);
        }

        public async Task<List<Paciente>> SearchByNombreAsync(string nombre)
        {
            using var context = _contextFactory.CreateDbContext();
            return await QueryActivos(context)
                .Where(p => p.Nombres.Contains(nombre))
                .ToListAsync();
        }

        public async Task AddAsync(Paciente paciente)
        {
            using var context = _contextFactory.CreateDbContext();
            paciente.Activo = true; // Por defecto activo al crear
            await context.Pacientes.AddAsync(paciente);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Paciente paciente)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Pacientes.Update(paciente);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var paciente = await context.Pacientes.FirstOrDefaultAsync(p => p.Id == id);
            if (paciente != null)
            {
                paciente.Activo = false; // Borrado lógico
                context.Pacientes.Update(paciente);
                await context.SaveChangesAsync();
            }
        }
    }
}