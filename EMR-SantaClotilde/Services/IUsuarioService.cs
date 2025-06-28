using EMR_SantaClotilde.Common;
using EMR_SantaClotilde.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Services
{
    public interface IUsuarioService
    {
        Task<IEnumerable<Usuario>> ObtenerTodosAsync();
        Task<Usuario?> ObtenerPorIdAsync(int id);
        Task<Usuario?> ObtenerPorUsernameAsync(string username);
        Task<IEnumerable<Usuario>> BuscarPorNombreAsync(string nombre);
        Task<ResultadoOperacion> CrearAsync(Usuario usuario);
        Task<ResultadoOperacion> ActualizarAsync(Usuario usuario);
        Task<ResultadoOperacion> EliminarAsync(int id);
        Task<LoginResult> AutenticarUsuario(string username, string password);
        bool EsMedico(Usuario usuario);
        Task<IEnumerable<Usuario>> ObtenerMedicosAsync();
    }
}

