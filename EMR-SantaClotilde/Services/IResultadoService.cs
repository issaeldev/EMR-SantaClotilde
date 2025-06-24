using EMR_SantaClotilde.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Services
{
    public class ResultadoOperacion
    {
        public bool Exito { get; set; }
        public Resultado? Datos { get; set; }
        public string? MensajeError { get; set; }
    }

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
