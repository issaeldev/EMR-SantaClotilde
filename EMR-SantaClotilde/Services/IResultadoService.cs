using System.Collections.Generic;
using EMR_SantaClotilde.Models;

namespace EMR_SantaClotilde.Services.Interfaces
{
    public interface IResultadoService
    {
        void Agregar(Resultado resultado);
        void Modificar(Resultado resultado);
        void Eliminar(int id);
        Resultado? ObtenerPorId(int id);
        IEnumerable<Resultado> ObtenerTodos();
        IEnumerable<Resultado> BuscarPorPaciente(int pacienteId);
    }
}
