using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EMR_SantaClotilde.Services
{
    public class ResultadoService : IResultadoService
    {
        private readonly EmrSantaClotildeContext _context;

        public ResultadoService(EmrSantaClotildeContext context)
        {
            _context = context;
        }

        public async Task<ResultadoOperacion> AgregarAsync(Resultado resultado)
        {
            try
            {
                _context.Resultados.Add(resultado);
                await _context.SaveChangesAsync();

                return new ResultadoOperacion
                {
                    Exito = true,
                    Datos = resultado
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion
                {
                    Exito = false,
                    MensajeError = "Error al agregar resultado: " + ex.Message
                };
            }
        }

        public async Task<ResultadoOperacion> ModificarAsync(Resultado resultado)
        {
            try
            {
                _context.Resultados.Update(resultado);
                await _context.SaveChangesAsync();

                return new ResultadoOperacion
                {
                    Exito = true,
                    Datos = resultado
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion
                {
                    Exito = false,
                    MensajeError = "Error al modificar resultado: " + ex.Message
                };
            }
        }

        public async Task<bool> EliminarAsync(int id)
        {
            var resultado = await _context.Resultados.FindAsync(id);
            if (resultado == null)
                return false;

            _context.Resultados.Remove(resultado);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Resultado?> ObtenerPorIdAsync(int id)
        {
            return await _context.Resultados
                .Include(r => r.Paciente)
                .Include(r => r.MedicoSolicitanteNavigation)
                .Include(r => r.Cita)
                .FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<IEnumerable<Resultado>> ObtenerTodosAsync()
        {
            return await _context.Resultados
                .Include(r => r.Paciente)
                .Include(r => r.MedicoSolicitanteNavigation)
                .Include(r => r.Cita)
                .ToListAsync();
        }

        public async Task<IEnumerable<Resultado>> BuscarPorPacienteAsync(int pacienteId)
        {
            return await _context.Resultados
                .Include(r => r.Paciente)
                .Where(r => r.PacienteId == pacienteId)
                .ToListAsync();
        }
    }
}
