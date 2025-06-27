using EMR_SantaClotilde.Common;
using EMR_SantaClotilde.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Services
{
    public interface ICitaService
    {
        Task<IEnumerable<Cita>> ObtenerTodasAsync();
        Task<Cita?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Cita>> ObtenerPorFechaAsync(DateTime fecha);
        Task<IEnumerable<Cita>> ObtenerPorMedicoAsync(int medicoId, DateTime? fecha = null);
        Task<IEnumerable<Cita>> ObtenerPorPacienteAsync(int pacienteId);
        Task<IEnumerable<Cita>> BuscarPorMotivoAsync(string texto);
        Task<ResultadoOperacion> CrearAsync(Cita cita);
        Task<ResultadoOperacion> ActualizarAsync(Cita cita);
        Task<ResultadoOperacion> CancelarAsync(int id, string motivo);
        Task<ResultadoOperacion> EliminarAsync(int id);
    }
}