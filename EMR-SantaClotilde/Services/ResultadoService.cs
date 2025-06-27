using EMR_SantaClotilde.Common;
using EMR_SantaClotilde.Models;
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
                var errores = new List<string>();

                if (resultado == null)
                {
                    return ResultadoOperacion.Fallido("El resultado no puede ser nulo");
                }

                // Validar campos requeridos
                if (string.IsNullOrWhiteSpace(resultado.TipoExamen))
                {
                    errores.Add("El tipo de examen es requerido");
                }

                if (string.IsNullOrWhiteSpace(resultado.NombreExamen))
                {
                    errores.Add("El nombre del examen es requerido");
                }

                if (resultado.PacienteId <= 0)
                {
                    errores.Add("Debe especificar un paciente válido");
                }

                if (resultado.MedicoSolicitante <= 0)
                {
                    errores.Add("Debe especificar un médico válido");
                }

                // Validar fechas
                if (resultado.FechaSolicitud > DateTime.Now)
                {
                    errores.Add("La fecha de solicitud no puede ser futura");
                }

                if (resultado.FechaResultado.HasValue && resultado.FechaResultado.Value < resultado.FechaSolicitud)
                {
                    errores.Add("La fecha del resultado no puede ser anterior a la fecha de solicitud");
                }

                // Validar que el paciente existe
                var pacienteExiste = await _context.Pacientes.AnyAsync(p => p.Id == resultado.PacienteId);
                if (!pacienteExiste)
                {
                    errores.Add("El paciente especificado no existe");
                }

                // Validar que el médico existe
                var medicoExiste = await _context.Usuarios.AnyAsync(u => u.Id == resultado.MedicoSolicitante);
                if (!medicoExiste)
                {
                    errores.Add("El médico especificado no existe");
                }

                // Validar que la cita existe (si se especifica)
                if (resultado.CitaId.HasValue)
                {
                    var citaExiste = await _context.Citas.AnyAsync(c => c.Id == resultado.CitaId.Value);
                    if (!citaExiste)
                    {
                        errores.Add("La cita especificada no existe");
                    }
                }

                if (errores.Any())
                {
                    return ResultadoOperacion.Fallido("Error de validación", errores);
                }

                // resultado.FechaCreacion = DateTime.UtcNow;
                resultado.Sincronizado = false;

                _context.Resultados.Add(resultado);
                await _context.SaveChangesAsync();

                return ResultadoOperacion.Exitoso("Resultado agregado correctamente");
            }
            catch (Exception ex)
            {
                return ResultadoOperacion.Fallido("Error al agregar resultado", ex.Message);
            }
        }

        public async Task<ResultadoOperacion> ModificarAsync(Resultado resultado)
        {
            try
            {
                // Validaciones iniciales
                var errores = new List<string>();

                if (resultado == null)
                {
                    return ResultadoOperacion.Fallido("El resultado no puede ser nulo");
                }

                if (resultado.Id <= 0)
                {
                    return ResultadoOperacion.Fallido("ID de resultado inválido");
                }

                var resultadoExistente = await _context.Resultados
                    .FirstOrDefaultAsync(r => r.Id == resultado.Id);

                if (resultadoExistente == null)
                {
                    return ResultadoOperacion.Fallido("El resultado no existe");
                }

                // No permitir modificar resultados que ya tienen fecha de resultado (completados)
                if (resultadoExistente.FechaResultado.HasValue &&
                    resultadoExistente.FechaResultado.Value.Date < DateTime.Now.Date)
                {
                    return ResultadoOperacion.Fallido("No se puede modificar un resultado que ya fue procesado anteriormente");
                }

                if (string.IsNullOrWhiteSpace(resultado.TipoExamen))
                {
                    errores.Add("El tipo de examen es requerido");
                }

                if (string.IsNullOrWhiteSpace(resultado.NombreExamen))
                {
                    errores.Add("El nombre del examen es requerido");
                }

                if (resultado.PacienteId <= 0)
                {
                    errores.Add("Debe especificar un paciente válido");
                }

                if (resultado.MedicoSolicitante <= 0)
                {
                    errores.Add("Debe especificar un médico válido");
                }

                if (resultado.FechaSolicitud > DateTime.Now)
                {
                    errores.Add("La fecha de solicitud no puede ser futura");
                }

                if (resultado.FechaResultado.HasValue && resultado.FechaResultado.Value < resultado.FechaSolicitud)
                {
                    errores.Add("La fecha del resultado no puede ser anterior a la fecha de solicitud");
                }

                if (resultado.PacienteId != resultadoExistente.PacienteId)
                {
                    var pacienteExiste = await _context.Pacientes.AnyAsync(p => p.Id == resultado.PacienteId);
                    if (!pacienteExiste)
                    {
                        errores.Add("El paciente especificado no existe");
                    }
                }

                if (resultado.MedicoSolicitante != resultadoExistente.MedicoSolicitante)
                {
                    var medicoExiste = await _context.Usuarios.AnyAsync(u => u.Id == resultado.MedicoSolicitante);
                    if (!medicoExiste)
                    {
                        errores.Add("El médico especificado no existe");
                    }
                }

                if (resultado.CitaId.HasValue && resultado.CitaId != resultadoExistente.CitaId)
                {
                    var citaExiste = await _context.Citas.AnyAsync(c => c.Id == resultado.CitaId.Value);
                    if (!citaExiste)
                    {
                        errores.Add("La cita especificada no existe");
                    }
                }

                if (!string.IsNullOrEmpty(resultadoExistente.ArchivoAdjunto) &&
                    resultadoExistente.ArchivoAdjunto != "pendiente" &&
                    !string.IsNullOrEmpty(resultado.Resultado1) &&
                    resultado.Resultado1 != resultadoExistente.Resultado1)
                {
                    // Solo advertencia, no error
                    errores.Add("ADVERTENCIA: Este resultado tiene archivos adjuntos. Verifique la consistencia de los datos.");
                }

                if (errores.Any())
                {
                    // Filtrar solo errores críticos (no advertencias)
                    var erroresCriticos = errores.Where(e => !e.StartsWith("ADVERTENCIA:")).ToList();
                    if (erroresCriticos.Any())
                    {
                        return ResultadoOperacion.Fallido("Error de validación", erroresCriticos);
                    }
                }

                resultadoExistente.PacienteId = resultado.PacienteId;
                resultadoExistente.CitaId = resultado.CitaId;
                resultadoExistente.MedicoSolicitante = resultado.MedicoSolicitante;
                resultadoExistente.TipoExamen = resultado.TipoExamen;
                resultadoExistente.NombreExamen = resultado.NombreExamen;
                resultadoExistente.FechaSolicitud = resultado.FechaSolicitud;
                resultadoExistente.FechaResultado = resultado.FechaResultado;
                resultadoExistente.Resultado1 = resultado.Resultado1;
                resultadoExistente.UnidadMedida = resultado.UnidadMedida;
                resultadoExistente.ArchivoAdjunto = resultado.ArchivoAdjunto;

                // resultadoExistente.FechaModificacion = DateTime.UtcNow;
                resultadoExistente.Sincronizado = false; // Marcar para re-sincronización

                await _context.SaveChangesAsync();

                string mensaje = "Resultado modificado correctamente";
                if (errores.Any(e => e.StartsWith("ADVERTENCIA:")))
                {
                    mensaje += ". " + string.Join(" ", errores.Where(e => e.StartsWith("ADVERTENCIA:")));
                }

                return ResultadoOperacion.Exitoso(mensaje);
            }
            catch (Exception ex)
            {
                return ResultadoOperacion.Fallido("Error al modificar resultado", ex.Message);
            }
        }


        public async Task<bool> EliminarAsync(int id)
        {
            try
            {
                var resultado = await _context.Resultados.FindAsync(id);
                if (resultado == null)
                    return false;

                // resultado.Activo = false;

                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
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

        public async Task<IEnumerable<Resultado>> BuscarPorCitaAsync(int citaId)
        {
            return await _context.Resultados
                .Include(r => r.Paciente)
                .Include(r => r.MedicoSolicitanteNavigation)
                .Include(r => r.Cita)
                .Where(r => r.CitaId == citaId)
                .OrderByDescending(r => r.FechaSolicitud)
                .ToListAsync();
        }

        public async Task<IEnumerable<Resultado>> ObtenerPendientesAsync()
        {
            return await _context.Resultados
                .Include(r => r.Paciente)
                .Include(r => r.MedicoSolicitanteNavigation)
                .Include(r => r.Cita)
                .Where(r => !r.FechaResultado.HasValue)
                .OrderBy(r => r.FechaSolicitud)
                .ToListAsync();
        }
    }
}
