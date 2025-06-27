using EMR_SantaClotilde.Common;
using EMR_SantaClotilde.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Services
{
    public interface IResultadoService
    {
        Task<ResultadoOperacion> AgregarAsync(Resultado resultado);
        Task<ResultadoOperacion> ModificarAsync(Resultado resultado);
        Task<bool> EliminarAsync(int id);
        Task<Resultado?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Resultado>> ObtenerTodosAsync();
        Task<IEnumerable<Resultado>> BuscarPorPacienteAsync(int pacienteId);
        Task<IEnumerable<Resultado>> BuscarPorCitaAsync(int citaId);
        Task<IEnumerable<Resultado>> ObtenerPendientesAsync();
    }
}
