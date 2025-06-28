using EMR_SantaClotilde.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Repositories
{
    internal class CitaRepository : ICitaRepository
    {
        private readonly IDbContextFactory<EmrSantaClotildeContext> _contextFactory;

        public CitaRepository(IDbContextFactory<EmrSantaClotildeContext> contextFactory)
        {
            _contextFactory = contextFactory;
        }

        private IQueryable<Cita> QueryBase(EmrSantaClotildeContext context)
        {
            return context.Set<Cita>()
                .Include(c => c.Paciente)
                .Include(c => c.Medico);
        }

        private IQueryable<Cita> QueryBaseWithResultados(EmrSantaClotildeContext context)
        {
            return context.Set<Cita>()
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Include(c => c.Resultados);
        }

        public async Task<List<Cita>> GetAllAsync()
        {
            using var context = _contextFactory.CreateDbContext();
            return await QueryBase(context)
                .OrderByDescending(c => c.FechaHora)
                .ToListAsync();
        }

        public async Task<Cita?> GetByIdAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            return await QueryBaseWithResultados(context)
                .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task AddAsync(Cita cita)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Set<Cita>().Add(cita);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cita cita)
        {
            using var context = _contextFactory.CreateDbContext();
            context.Set<Cita>().Update(cita);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            using var context = _contextFactory.CreateDbContext();
            var cita = await context.Set<Cita>().FindAsync(id);
            if (cita != null)
            {
                context.Set<Cita>().Remove(cita);
                await context.SaveChangesAsync();
            }
        }

        public async Task<List<Cita>> GetByFechaAsync(DateTime fecha)
        {
            using var context = _contextFactory.CreateDbContext();
            var inicio = fecha.Date;
            var fin = inicio.AddDays(1).AddSeconds(-1);

            return await QueryBase(context)
                .Where(c => c.FechaHora >= inicio && c.FechaHora <= fin)
                .OrderBy(c => c.FechaHora)
                .ToListAsync();
        }

        public async Task<List<Cita>> GetByMedicoAsync(int medicoId, DateTime? fecha = null)
        {
            using var context = _contextFactory.CreateDbContext();
            var query = QueryBase(context).Where(c => c.MedicoId == medicoId);

            if (fecha.HasValue)
            {
                var inicio = fecha.Value.Date;
                var fin = inicio.AddDays(1).AddSeconds(-1);
                query = query.Where(c => c.FechaHora >= inicio && c.FechaHora <= fin);
            }

            return await query.OrderBy(c => c.FechaHora).ToListAsync();
        }

        public async Task<List<Cita>> GetByPacienteIdAsync(int pacienteId)
        {
            using var context = _contextFactory.CreateDbContext();
            return await QueryBase(context)
                .Where(c => c.PacienteId == pacienteId)
                .OrderByDescending(c => c.FechaHora)
                .ToListAsync();
        }

        public async Task<List<Cita>> SearchByMotivoAsync(string texto)
        {
            using var context = _contextFactory.CreateDbContext();
            return await QueryBase(context)
                .Where(c => c.Motivo.Contains(texto) || c.Observaciones.Contains(texto))
                .OrderByDescending(c => c.FechaHora)
                .ToListAsync();
        }

        public async Task<bool> ExisteSolapamientoAsync(DateTime fechaHora, int medicoId, int? excludeId = null)
        {
            using var context = _contextFactory.CreateDbContext();
            var rangoInicio = fechaHora.AddMinutes(-30);
            var rangoFin = fechaHora.AddMinutes(30);

            var query = context.Set<Cita>()
                .Where(c => c.MedicoId == medicoId)
                .Where(c => c.FechaHora >= rangoInicio && c.FechaHora <= rangoFin)
                .Where(c => c.Estado != "Cancelada");

            if (excludeId.HasValue)
                query = query.Where(c => c.Id != excludeId.Value);

            return await query.AnyAsync();
        }

        public async Task<List<Cita>> GetByEstadoAsync(string estado, DateTime? fecha = null)
        {
            using var context = _contextFactory.CreateDbContext();
            var query = QueryBase(context).Where(c => c.Estado == estado);

            if (fecha.HasValue)
            {
                var inicio = fecha.Value.Date;
                var fin = inicio.AddDays(1).AddSeconds(-1);
                query = query.Where(c => c.FechaHora >= inicio && c.FechaHora <= fin);
            }

            return await query.OrderBy(c => c.FechaHora).ToListAsync();
        }

        public async Task<List<Cita>> GetProximasCitasAsync(int horas = 24)
        {
            using var context = _contextFactory.CreateDbContext();
            var ahora = DateTime.Now;
            var limite = ahora.AddHours(horas);

            return await QueryBase(context)
                .Where(c => c.FechaHora >= ahora && c.FechaHora <= limite)
                .Where(c => c.Estado == "Programada")
                .OrderBy(c => c.FechaHora)
                .ToListAsync();
        }

        public async Task<Dictionary<string, int>> GetEstadisticasPorMedicoAsync(DateTime fechaInicio, DateTime fechaFin)
        {
            using var context = _contextFactory.CreateDbContext();
            return await QueryBase(context)
                .Where(c => c.FechaHora >= fechaInicio && c.FechaHora <= fechaFin)
                .GroupBy(c => c.Medico.NombreCompleto)
                .ToDictionaryAsync(g => g.Key, g => g.Count());
        }

        public async Task<List<Cita>> BuscarTextoLibreAsync(string texto)
        {
            using var context = _contextFactory.CreateDbContext();
            var textoLower = texto.ToLower();

            return await QueryBase(context)
                .Where(c =>
                    c.Motivo.ToLower().Contains(textoLower) ||
                    c.Observaciones.ToLower().Contains(textoLower) ||
                    c.Paciente.Nombres.ToLower().Contains(textoLower) ||
                    c.Medico.NombreCompleto.ToLower().Contains(textoLower) ||
                    c.Tipo.ToLower().Contains(textoLower))
                .OrderByDescending(c => c.FechaHora)
                .ToListAsync();
        }
    }
}