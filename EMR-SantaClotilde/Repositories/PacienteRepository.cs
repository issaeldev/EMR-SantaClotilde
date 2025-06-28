using EMR_SantaClotilde.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

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

        public List<Paciente> GetAll()
        {
            using var context = _contextFactory.CreateDbContext();
            return QueryActivos(context).ToList();
        }

        public Paciente? GetById(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            return QueryActivos(context).FirstOrDefault(p => p.Id == id);
        }

        public Paciente? GetByDni(string dni)
        {
            using var context = _contextFactory.CreateDbContext();
            return QueryActivos(context).FirstOrDefault(p => p.Dni == dni);
        }

        public List<Paciente> SearchByNombre(string nombre)
        {
            using var context = _contextFactory.CreateDbContext();
            return QueryActivos(context)
                .Where(p => p.Nombres.Contains(nombre))
                .ToList();
        }

        public void Add(Paciente paciente)
        {
            using var context = _contextFactory.CreateDbContext();
            paciente.Activo = true; // Por defecto activo al crear
            context.Pacientes.Add(paciente);
            context.SaveChanges();
        }

        public void Update(Paciente paciente)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Pacientes.Update(paciente);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var paciente = context.Pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente != null)
            {
                paciente.Activo = false;            // ← Borrado lógico
                context.Pacientes.Update(paciente);
                context.SaveChanges();
            }
        }
    }
}