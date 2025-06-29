using EMR_SantaClotilde.Common;
using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Services
{
    public class ResultadoService : IResultadoService
    {
        private readonly IResultadoRepository _resultadoRepository;
        private readonly EmrSantaClotildeContext _context; // Solo para validaciones cruzadas

        public ResultadoService(IResultadoRepository resultadoRepository, EmrSantaClotildeContext context)
        {
            _resultadoRepository = resultadoRepository;
            _context = context;
        }

        public async Task<ResultadoOperacion> AgregarAsync(Resultado resultado)
        {
            var errores = new List<string>();

            if (resultado == null)
                return ResultadoOperacion.Fallido("El resultado no puede ser nulo");

            // Validación de campos requeridos
            if (string.IsNullOrWhiteSpace(resultado.TipoExamen))
                errores.Add("El tipo de examen es requerido");

            if (string.IsNullOrWhiteSpace(resultado.NombreExamen))
                errores.Add("El nombre del examen es requerido");

            if (resultado.PacienteId <= 0)
                errores.Add("Debe especificar un paciente válido");

            if (resultado.MedicoSolicitante <= 0)
                errores.Add("Debe especificar un médico válido");

            // Validación de fechas
            if (resultado.FechaSolicitud > System.DateTime.Now)
                errores.Add("La fecha de solicitud no puede ser futura");

            if (resultado.FechaResultado.HasValue && resultado.FechaResultado.Value < resultado.FechaSolicitud)
                errores.Add("La fecha del resultado no puede ser anterior a la fecha de solicitud");

            // Validar existencia de paciente, médico y cita (si aplica)
            if (!await _context.Pacientes.AnyAsync(p => p.Id == resultado.PacienteId))
                errores.Add("El paciente especificado no existe");

            if (!await _context.Usuarios.AnyAsync(u => u.Id == resultado.MedicoSolicitante))
                errores.Add("El médico especificado no existe");

            if (resultado.CitaId.HasValue)
            {
                if (!await _context.Citas.AnyAsync(c => c.Id == resultado.CitaId.Value))
                    errores.Add("La cita especificada no existe");
            }

            if (errores.Any())
                return ResultadoOperacion.Fallido("Error de validación", errores);

            resultado.Sincronizado = false;

            try
            {
                await _resultadoRepository.AgregarAsync(resultado);
                return ResultadoOperacion.Exitoso("Resultado agregado correctamente");
            }
            catch (System.Exception ex)
            {
                return ResultadoOperacion.Fallido("Error al agregar resultado", ex.Message);
            }
        }

        public async Task<ResultadoOperacion> ModificarAsync(Resultado resultado)
        {
            var errores = new List<string>();

            if (resultado == null)
                return ResultadoOperacion.Fallido("El resultado no puede ser nulo");

            if (resultado.Id <= 0)
                return ResultadoOperacion.Fallido("ID de resultado inválido");

            var resultadoExistente = await _resultadoRepository.ObtenerPorIdAsync(resultado.Id);
            if (resultadoExistente == null)
                return ResultadoOperacion.Fallido("El resultado no existe");

            // Validaciones cruzadas si cambiaron los IDs
            if (resultado.PacienteId != resultadoExistente.PacienteId)
            {
                if (!await _context.Pacientes.AnyAsync(p => p.Id == resultado.PacienteId))
                    errores.Add("El paciente especificado no existe");
            }
            if (resultado.MedicoSolicitante != resultadoExistente.MedicoSolicitante)
            {
                if (!await _context.Usuarios.AnyAsync(u => u.Id == resultado.MedicoSolicitante))
                    errores.Add("El médico especificado no existe");
            }
            if (resultado.CitaId.HasValue && resultado.CitaId != resultadoExistente.CitaId)
            {
                if (!await _context.Citas.AnyAsync(c => c.Id == resultado.CitaId.Value))
                    errores.Add("La cita especificada no existe");
            }

            if (!string.IsNullOrEmpty(resultadoExistente.ArchivoAdjunto) &&
                resultadoExistente.ArchivoAdjunto != "pendiente" &&
                !string.IsNullOrEmpty(resultado.Resultado1) &&
                resultado.Resultado1 != resultadoExistente.Resultado1)
            {
                errores.Add("ADVERTENCIA: Este resultado tiene archivos adjuntos. Verifique la consistencia de los datos.");
            }

            if (errores.Any(e => !e.StartsWith("ADVERTENCIA:")))
            {
                var erroresCriticos = errores.Where(e => !e.StartsWith("ADVERTENCIA:")).ToList();
                return ResultadoOperacion.Fallido("Error de validación", erroresCriticos);
            }

            // Mapear cambios permitidos
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
            resultadoExistente.Sincronizado = false;

            try
            {
                await _resultadoRepository.ModificarAsync(resultadoExistente);

                string mensaje = "Resultado modificado correctamente";
                if (errores.Any(e => e.StartsWith("ADVERTENCIA:")))
                    mensaje += ". " + string.Join(" ", errores.Where(e => e.StartsWith("ADVERTENCIA:")));

                return ResultadoOperacion.Exitoso(mensaje);
            }
            catch (System.Exception ex)
            {
                return ResultadoOperacion.Fallido("Error al modificar resultado", ex.Message);
            }
        }

        public async Task<bool> EliminarAsync(int id)
        {
            return await _resultadoRepository.EliminarAsync(id);
        }

        public async Task<Resultado?> ObtenerPorIdAsync(int id)
        {
            return await _resultadoRepository.ObtenerPorIdAsync(id);
        }

        public async Task<IEnumerable<Resultado>> ObtenerTodosAsync()
        {
            return await _resultadoRepository.ObtenerTodosAsync();
        }

        public async Task<IEnumerable<Resultado>> BuscarPorPacienteAsync(int pacienteId)
        {
            return await _resultadoRepository.BuscarPorPacienteAsync(pacienteId);
        }

        public async Task<IEnumerable<Resultado>> BuscarPorCitaAsync(int citaId)
        {
            return await _resultadoRepository.BuscarPorCitaAsync(citaId);
        }

        public async Task<IEnumerable<Resultado>> ObtenerPendientesAsync()
        {
            return await _resultadoRepository.ObtenerPendientesAsync();
        }
    }
}
