using EMR_SantaClotilde.Models;
using Microsoft.EntityFrameworkCore;

namespace EMR_SantaClotilde.Repositories
{
    public class ResultadoRepository : IResultadoRepository
    {
        private readonly EmrSantaClotildeContext _context;

        public ResultadoRepository(EmrSantaClotildeContext context)
        {
            _context = context;
        }
        private IQueryable<Resultado> QueryActivos()
        {
            return _context.Resultados
                .Include(r => r.Paciente)
                .Include(r => r.MedicoSolicitanteNavigation)
                .Include(r => r.Cita)
                .Where(r => r.Activo);
        }

        public async Task<Resultado?> ObtenerPorIdAsync(int id)
        {
            return await QueryActivos().FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Resultado>> ObtenerTodosAsync()
        {
            return await QueryActivos().ToListAsync();
        }

        public async Task<IEnumerable<Resultado>> BuscarPorPacienteAsync(int pacienteId)
        {
            return await QueryActivos()
                .Where(r => r.PacienteId == pacienteId)
                .ToListAsync();
        }

        public async Task<IEnumerable<Resultado>> BuscarPorCitaAsync(int citaId)
        {
            return await QueryActivos()
                .Where(r => r.CitaId == citaId)
                .OrderByDescending(r => r.FechaSolicitud)
                .ToListAsync();
        }

        public async Task<IEnumerable<Resultado>> ObtenerPendientesAsync()
        {
            return await QueryActivos()
                .Where(r => !r.FechaResultado.HasValue)
                .OrderBy(r => r.FechaSolicitud)
                .ToListAsync();
        }

        public async Task AgregarAsync(Resultado resultado)
        {
            resultado.Activo = true; // Se marca como activo al crear
            _context.Resultados.Add(resultado);
            await _context.SaveChangesAsync();
        }

        public async Task ModificarAsync(Resultado resultado)
        {
            _context.Resultados.Update(resultado);
            await _context.SaveChangesAsync();
        }
        public async Task<bool> EliminarAsync(int id)
        {
            var resultado = await _context.Resultados.FindAsync(id);
            if (resultado == null || !resultado.Activo)
                return false;

            resultado.Activo = false;
            _context.Resultados.Update(resultado);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}