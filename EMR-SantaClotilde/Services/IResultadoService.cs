using System.Collections.Generic;
using System.Threading.Tasks;
using EMR_SantaClotilde.Models;

namespace EMR_SantaClotilde.Services.Interfaces
{
    public interface IResultadoService
    {
        Task<ResultadoOperacion> AgregarAsync(Resultado resultado);
        Task<ResultadoOperacion> ModificarAsync(Resultado resultado);
        Task<bool> EliminarAsync(int id);
        Task<Resultado?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Resultado>> ObtenerTodosAsync();
        Task<IEnumerable<Resultado>> BuscarPorPacienteAsync(int pacienteId);
    }
}
