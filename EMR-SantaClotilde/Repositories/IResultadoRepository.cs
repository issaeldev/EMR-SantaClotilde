using EMR_SantaClotilde.Models;

namespace EMR_SantaClotilde.Repositories
{
    public interface IResultadoRepository
    {
        Task<Resultado?> ObtenerPorIdAsync(int id);
        Task<IEnumerable<Resultado>> ObtenerTodosAsync();
        Task<IEnumerable<Resultado>> BuscarPorPacienteAsync(int pacienteId);
        Task<IEnumerable<Resultado>> BuscarPorCitaAsync(int citaId);
        Task<IEnumerable<Resultado>> ObtenerPendientesAsync();
        Task AgregarAsync(Resultado resultado);
        Task ModificarAsync(Resultado resultado);
        Task<bool> EliminarAsync(int id);
    }
}