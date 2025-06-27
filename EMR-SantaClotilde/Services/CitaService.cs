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
            return await Task.Run(() => _citaRepository.GetAll());
        }

        public async Task<Cita?> ObtenerPorIdAsync(int id)
        {
            return await Task.Run(() => _citaRepository.GetById(id));
        }

        public async Task<IEnumerable<Cita>> ObtenerPorFechaAsync(DateTime fecha)
        {
            return await Task.Run(() => _citaRepository.GetByFecha(fecha));
        }

        public async Task<IEnumerable<Cita>> ObtenerPorMedicoAsync(int medicoId, DateTime? fecha = null)
        {
            return await Task.Run(() => _citaRepository.GetByMedico(medicoId, fecha));
        }

        public async Task<IEnumerable<Cita>> ObtenerPorPacienteAsync(int pacienteId)
        {
            return await Task.Run(() => _citaRepository.GetByPacienteId(pacienteId));
        }

        public async Task<IEnumerable<Cita>> BuscarPorMotivoAsync(string texto)
        {
            return await Task.Run(() => _citaRepository.SearchByMotivo(texto));
        }

        public async Task<ResultadoOperacion> CrearAsync(Cita cita)
        {
            return await Task.Run(() => Crear(cita));
        }

        public async Task<ResultadoOperacion> ActualizarAsync(Cita cita)
        {
            return await Task.Run(() => Actualizar(cita));
        }

        public async Task<ResultadoOperacion> CancelarAsync(int id, string motivo)
        {
            return await Task.Run(() => Cancelar(id, motivo));
        }

        public async Task<ResultadoOperacion> EliminarAsync(int id)
        {
            return await Task.Run(() => Eliminar(id));
        }

        // Métodos síncronos originales (puedes mantenerlos privados o eliminarlos si no los necesitas)
        private ResultadoOperacion Crear(Cita cita)
        {
            try
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

                if (_citaRepository.ExisteSolapamiento(cita.FechaHora, cita.MedicoId))
                    errores.Add("El médico ya tiene una cita programada para ese horario");

                if (errores.Any())
                    return ResultadoOperacion.Fallido("Error de validación", errores);

                cita.Estado = string.IsNullOrEmpty(cita.Estado) ? "Programada" : cita.Estado;
                _citaRepository.Add(cita);

                return ResultadoOperacion.Exitoso("Cita creada correctamente");
            }
            catch (Exception ex)
            {
                return ResultadoOperacion.Fallido("Error al crear la cita", ex.Message);
            }
        }

        private ResultadoOperacion Actualizar(Cita cita)
        {
            try
            {
                var errores = new List<string>();

                if (cita == null)
                    return ResultadoOperacion.Fallido("La cita no puede ser nula");

                var citaExistente = _citaRepository.GetById(cita.Id);
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

                    if (_citaRepository.ExisteSolapamiento(cita.FechaHora, cita.MedicoId, cita.Id))
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

                _citaRepository.Update(cita);
                return ResultadoOperacion.Exitoso("Cita actualizada correctamente");
            }
            catch (Exception ex)
            {
                return ResultadoOperacion.Fallido("Error al actualizar la cita", ex.Message);
            }
        }

        private ResultadoOperacion Cancelar(int id, string motivo)
        {
            try
            {
                if (id <= 0)
                    return ResultadoOperacion.Fallido("ID de cita inválido");

                if (string.IsNullOrWhiteSpace(motivo))
                    return ResultadoOperacion.Fallido("Debe especificar el motivo de la cancelación");

                var cita = _citaRepository.GetById(id);
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

                _citaRepository.Update(cita);

                return ResultadoOperacion.Exitoso($"Cita cancelada correctamente. Motivo: {motivo}");
            }
            catch (Exception ex)
            {
                return ResultadoOperacion.Fallido("Error al cancelar la cita", ex.Message);
            }
        }
        private ResultadoOperacion Eliminar(int id)
        {
            try
            {
                if (id <= 0)
                    return ResultadoOperacion.Fallido("ID de cita inválido");

                var cita = _citaRepository.GetById(id);
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
                _citaRepository.Update(cita);

                return ResultadoOperacion.Exitoso($"Cita eliminada correctamente (ID: {id})");
            }
            catch (Exception ex)
            {
                return ResultadoOperacion.Fallido("Error al eliminar la cita", ex.Message);
            }
        }
    }
}