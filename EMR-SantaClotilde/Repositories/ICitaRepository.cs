using EMR_SantaClotilde.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Repositories
{
    public interface ICitaRepository
    {
        Task<List<Cita>> GetAllAsync();
        Task<Cita?> GetByIdAsync(int id);
        Task AddAsync(Cita cita);
        Task UpdateAsync(Cita cita);
        Task DeleteAsync(int id);

        Task<List<Cita>> GetByFechaAsync(DateTime fecha);
        Task<List<Cita>> GetByMedicoAsync(int medicoId, DateTime? fecha = null);
        Task<List<Cita>> GetByPacienteIdAsync(int pacienteId);
        Task<List<Cita>> SearchByMotivoAsync(string texto);
        Task<bool> ExisteSolapamientoAsync(DateTime fechaHora, int medicoId, int? excludeId = null);
        Task<List<Cita>> GetByEstadoAsync(string estado, DateTime? fecha = null);
        Task<List<Cita>> GetProximasCitasAsync(int horas = 24);
        Task<Dictionary<string, int>> GetEstadisticasPorMedicoAsync(DateTime fechaInicio, DateTime fechaFin);
        Task<List<Cita>> BuscarTextoLibreAsync(string texto);
    }
}