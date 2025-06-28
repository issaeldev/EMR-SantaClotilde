using EMR_SantaClotilde.Common;
using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Services
{
    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _citaRepository;

        public CitaService(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        public async Task<IEnumerable<Cita>> ObtenerTodasAsync()
        {
            return await _citaRepository.GetAllAsync();
        }

        public async Task<Cita?> ObtenerPorIdAsync(int id)
        {
            return await _citaRepository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<Cita>> ObtenerPorFechaAsync(DateTime fecha)
        {
            return await _citaRepository.GetByFechaAsync(fecha);
        }

        public async Task<IEnumerable<Cita>> ObtenerPorMedicoAsync(int medicoId, DateTime? fecha = null)
        {
            return await _citaRepository.GetByMedicoAsync(medicoId, fecha);
        }

        public async Task<IEnumerable<Cita>> ObtenerPorPacienteAsync(int pacienteId)
        {
            return await _citaRepository.GetByPacienteIdAsync(pacienteId);
        }

        public async Task<IEnumerable<Cita>> BuscarPorMotivoAsync(string texto)
        {
            return await _citaRepository.SearchByMotivoAsync(texto);
        }

        public async Task<ResultadoOperacion> CrearAsync(Cita cita)
        {
            var errores = new List<string>();

            if (cita == null)
                return ResultadoOperacion.Fallido("La cita no puede ser nula");

            if (cita.FechaHora < DateTime.Now)
                errores.Add("No se pueden programar citas en fechas pasadas");

            if (cita.FechaHora > DateTime.Now.AddYears(1))
                errores.Add("No se pueden programar citas con más de un año de anticipación");

            var hora = cita.FechaHora.TimeOfDay;
            if (hora < TimeSpan.FromHours(8) || hora > TimeSpan.FromHours(18))
                errores.Add("Las citas solo pueden programarse entre 8:00 AM y 6:00 PM");

            if (cita.FechaHora.DayOfWeek == DayOfWeek.Sunday)
                errores.Add("No se pueden programar citas los domingos");

            if (cita.PacienteId <= 0)
                errores.Add("Debe especificar un paciente válido");

            if (cita.MedicoId <= 0)
                errores.Add("Debe especificar un médico válido");

            if (string.IsNullOrWhiteSpace(cita.Motivo))
                errores.Add("El motivo de la cita es requerido");

            if (await _citaRepository.ExisteSolapamientoAsync(cita.FechaHora, cita.MedicoId))
                errores.Add("El médico ya tiene una cita programada para ese horario");

            if (errores.Any())
                return ResultadoOperacion.Fallido("Error de validación", errores);

            cita.Estado = string.IsNullOrEmpty(cita.Estado) ? "Programada" : cita.Estado;

            try
            {
                // Tu lógica que guarda en la base de datos
                await _citaRepository.AddAsync(cita);
            }
            catch (Exception ex)
            {
                string err = ex.Message;
                if (ex.InnerException != null)
                    err += "\nInner: " + ex.InnerException.Message;

                MessageBox.Show(err);
            }

            return ResultadoOperacion.Exitoso("Cita creada correctamente");
        }

        public async Task<ResultadoOperacion> ActualizarAsync(Cita cita)
        {
            var errores = new List<string>();

            if (cita == null)
                return ResultadoOperacion.Fallido("La cita no puede ser nula");

            var citaExistente = await _citaRepository.GetByIdAsync(cita.Id);
            if (citaExistente == null)
                return ResultadoOperacion.Fallido("La cita no existe");

            if (citaExistente.Estado == "Completada")
                return ResultadoOperacion.Fallido("No se puede modificar una cita ya completada");

            if (citaExistente.Estado == "Cancelada")
                return ResultadoOperacion.Fallido("No se puede modificar una cita cancelada");

            if (cita.FechaHora != citaExistente.FechaHora)
            {
                if (cita.FechaHora < DateTime.Now)
                    errores.Add("No se pueden reprogramar citas a fechas pasadas");

                if (await _citaRepository.ExisteSolapamientoAsync(cita.FechaHora, cita.MedicoId, cita.Id))
                    errores.Add("El médico ya tiene una cita programada para ese nuevo horario");

                var hora = cita.FechaHora.TimeOfDay;
                if (hora < TimeSpan.FromHours(8) || hora > TimeSpan.FromHours(18))
                    errores.Add("Las citas solo pueden programarse entre 8:00 AM y 6:00 PM");

                if (cita.FechaHora.DayOfWeek == DayOfWeek.Sunday)
                    errores.Add("No se pueden programar citas los domingos");
            }

            if (string.IsNullOrWhiteSpace(cita.Motivo))
                errores.Add("El motivo de la cita es requerido");

            if (cita.PacienteId <= 0)
                errores.Add("Debe especificar un paciente válido");

            if (cita.MedicoId <= 0)
                errores.Add("Debe especificar un médico válido");

            if (errores.Any())
                return ResultadoOperacion.Fallido("Error de validación", errores);

            await _citaRepository.UpdateAsync(cita);
            return ResultadoOperacion.Exitoso("Cita actualizada correctamente");
        }

        public async Task<ResultadoOperacion> CancelarAsync(int id, string motivo)
        {
            if (id <= 0)
                return ResultadoOperacion.Fallido("ID de cita inválido");

            if (string.IsNullOrWhiteSpace(motivo))
                return ResultadoOperacion.Fallido("Debe especificar el motivo de la cancelación");

            var cita = await _citaRepository.GetByIdAsync(id);
            if (cita == null)
                return ResultadoOperacion.Fallido("Cita no encontrada");

            if (cita.Estado == "Cancelada")
                return ResultadoOperacion.Fallido("La cita ya está cancelada");

            if (cita.Estado == "Completada")
                return ResultadoOperacion.Fallido("No se puede cancelar una cita ya completada");

            var horasAntes = (cita.FechaHora - DateTime.Now).TotalHours;
            // Solo advertencia, no bloqueo

            cita.Estado = "Cancelada";
            var observacionCancelacion = $"\n--- CANCELACIÓN ---\n" +
                $"Fecha: {DateTime.Now:dd/MM/yyyy HH:mm}\n" +
                $"Usuario: issaeldev\n" +
                $"Motivo: {motivo}\n" +
                $"--- FIN CANCELACIÓN ---";

            cita.Observaciones = string.IsNullOrEmpty(cita.Observaciones)
                ? observacionCancelacion
                : cita.Observaciones + observacionCancelacion;

            await _citaRepository.UpdateAsync(cita);

            return ResultadoOperacion.Exitoso($"Cita cancelada correctamente. Motivo: {motivo}");
        }

        public async Task<ResultadoOperacion> EliminarAsync(int id)
        {
            if (id <= 0)
                return ResultadoOperacion.Fallido("ID de cita inválido");

            var cita = await _citaRepository.GetByIdAsync(id);
            if (cita == null)
                return ResultadoOperacion.Fallido("La cita no existe");

            var errores = new List<string>();

            if (cita.Estado == "Completada")
                errores.Add("No se pueden eliminar citas completadas. Use la cancelación.");

            if (cita.FechaHora < DateTime.Now.AddDays(-30))
                errores.Add("No se pueden eliminar citas de más de 30 días de antigüedad");

            if (cita.Resultados != null && cita.Resultados.Any())
                errores.Add("No se puede eliminar una cita que tiene resultados médicos asociados");

            if (errores.Any())
                return ResultadoOperacion.Fallido("No se puede eliminar la cita", errores);

            // Eliminado lógico
            cita.Activo = false;
            await _citaRepository.UpdateAsync(cita);

            return ResultadoOperacion.Exitoso($"Cita eliminada correctamente (ID: {id})");
        }
    }
}