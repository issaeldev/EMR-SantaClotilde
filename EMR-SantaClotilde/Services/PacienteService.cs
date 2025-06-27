using EMR_SantaClotilde.Common;
using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Services
{
    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public async Task<IEnumerable<Paciente>> ObtenerTodosAsync()
        {
            return await Task.Run(() => _pacienteRepository.GetAll());
        }

        public async Task<Paciente?> ObtenerPorIdAsync(int id)
        {
            return await Task.Run(() => _pacienteRepository.GetById(id));
        }

        public async Task<Paciente?> ObtenerPorDniAsync(string dni)
        {
            return await Task.Run(() => _pacienteRepository.GetByDni(dni));
        }

        public async Task<IEnumerable<Paciente>> BuscarPorNombreAsync(string nombre)
        {
            return await Task.Run(() => _pacienteRepository.SearchByNombre(nombre));
        }

        public async Task<ResultadoOperacion> CrearPacienteAsync(Paciente paciente)
        {
            if (string.IsNullOrWhiteSpace(paciente.Dni) || string.IsNullOrWhiteSpace(paciente.Nombres))
            {
                return ResultadoOperacion.Fallido("DNI y Nombres son obligatorios");
            }

            try
            {
                await Task.Run(() => _pacienteRepository.Add(paciente));
                return ResultadoOperacion.Exitoso("Paciente creado correctamente");
            }
            catch (Exception ex)
            {
                return ResultadoOperacion.Fallido($"Error al crear el paciente: {ex.Message}");
            }
        }

        public async Task<ResultadoOperacion> ActualizarPacienteAsync(Paciente paciente)
        {
            try
            {
                await Task.Run(() => _pacienteRepository.Update(paciente));
                return ResultadoOperacion.Exitoso("Paciente actualizado correctamente");
            }
            catch (Exception ex)
            {
                return ResultadoOperacion.Fallido($"Error al actualizar el paciente: {ex.Message}");
            }
        }

        public async Task<ResultadoOperacion> EliminarPacienteAsync(int id)
        {
            try
            {
                var paciente = await Task.Run(() => _pacienteRepository.GetById(id));
                if (paciente == null)
                {
                    return ResultadoOperacion.Fallido("Paciente no encontrado");
                }

                // Eliminado lógico: desactivar el registro
                paciente.Activo = false;
                await Task.Run(() => _pacienteRepository.Update(paciente));

                return ResultadoOperacion.Exitoso("Paciente eliminado correctamente (eliminado lógico)");
            }
            catch (Exception ex)
            {
                return ResultadoOperacion.Fallido($"Error al eliminar el paciente: {ex.Message}");
            }
        }
    }
}