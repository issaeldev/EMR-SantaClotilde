using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Services
{
    public interface IPacienteService
    {
        Task<IEnumerable<Paciente>> ObtenerTodosAsync();
        Task<Paciente?> ObtenerPorIdAsync(int id);
        Task<Paciente?> ObtenerPorDniAsync(string dni);
        Task<IEnumerable<Paciente>> BuscarPorNombreAsync(string nombre);
        Task<ResultadoOperacion> CrearPacienteAsync(Paciente paciente);
        Task<ResultadoOperacion> ActualizarPacienteAsync(Paciente paciente);
        Task<ResultadoOperacion> EliminarPacienteAsync(int id);
    }
}