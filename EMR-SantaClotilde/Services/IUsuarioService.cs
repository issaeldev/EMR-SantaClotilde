using EMR_SantaClotilde.Common;
using EMR_SantaClotilde.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuarios>> ObtenerTodosAsync();
        Task<Usuarios?> ObtenerPorIdAsync(int id);
        Task<Usuarios?> ObtenerPorUsernameAsync(string username);
        Task<IEnumerable<Usuarios>> BuscarPorNombreAsync(string nombre);
        Task<ResultadoOperacion> CrearAsync(Usuarios usuario);
        Task<ResultadoOperacion> ActualizarAsync(Usuarios usuario);
        Task<ResultadoOperacion> EliminarAsync(int id);
    }
}

