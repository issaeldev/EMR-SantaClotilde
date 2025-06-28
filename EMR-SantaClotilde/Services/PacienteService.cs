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
            return await Task.Run(() => _pacienteRepository.GetAllAsync());
        }

        public async Task<Paciente?> ObtenerPorIdAsync(int id)
        {
            return await Task.Run(() => _pacienteRepository.GetByIdAsync(id));
        }

        public async Task<Paciente?> ObtenerPorDniAsync(string dni)
        {
            return await Task.Run(() => _pacienteRepository.GetByDniAsync(dni));
        }

        public async Task<IEnumerable<Paciente>> BuscarPorNombreAsync(string nombre)
        {
            return await Task.Run(() => _pacienteRepository.SearchByNombreAsync(nombre));
        }

        public async Task<ResultadoOperacion> CrearPacienteAsync(Paciente paciente)
        {
            // Validación de campos obligatorios
            if (string.IsNullOrWhiteSpace(paciente.Dni))
                return ResultadoOperacion.Fallido("El DNI es obligatorio.");
            if (string.IsNullOrWhiteSpace(paciente.Nombres))
                return ResultadoOperacion.Fallido("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(paciente.Apellidos))
                return ResultadoOperacion.Fallido("El apellido es obligatorio.");
            if (paciente.FechaNacimiento == default)
                return ResultadoOperacion.Fallido("La fecha de nacimiento es obligatoria.");
            if (string.IsNullOrWhiteSpace(paciente.Genero))
                return ResultadoOperacion.Fallido("El género es obligatorio.");
            if (string.IsNullOrWhiteSpace(paciente.Direccion))
                return ResultadoOperacion.Fallido("La dirección es obligatoria.");

            // Validación de género permitido
            var generosValidos = new[] { "M", "F", "Otro" };
            if (!generosValidos.Contains(paciente.Genero))
                return ResultadoOperacion.Fallido("El género debe ser 'M', 'F' u 'Otro'.");

            try
            {
                // Validar que el DNI no esté repetido
                var existente = await Task.Run(() => _pacienteRepository.GetByDniAsync(paciente.Dni));
                if (existente != null)
                    return ResultadoOperacion.Fallido("Ya existe un paciente con ese DNI.");

                await Task.Run(() => _pacienteRepository.AddAsync(paciente));
                return ResultadoOperacion.Exitoso("Paciente creado correctamente");
            }
            catch (Exception ex)
            {
                // Puedes analizar si ex es de tipo SqlException y el código de error si quieres un mensaje más detallado
                return ResultadoOperacion.Fallido($"Error al crear el paciente: {ex.Message}");
            }
        }

        public async Task<ResultadoOperacion> ActualizarPacienteAsync(Paciente paciente)
        {
            // Validación de campos obligatorios
            if (paciente.Id <= 0)
                return ResultadoOperacion.Fallido("El ID del paciente es obligatorio.");
            if (string.IsNullOrWhiteSpace(paciente.Dni))
                return ResultadoOperacion.Fallido("El DNI es obligatorio.");
            if (string.IsNullOrWhiteSpace(paciente.Nombres))
                return ResultadoOperacion.Fallido("El nombre es obligatorio.");
            if (string.IsNullOrWhiteSpace(paciente.Apellidos))
                return ResultadoOperacion.Fallido("El apellido es obligatorio.");
            if (paciente.FechaNacimiento == default)
                return ResultadoOperacion.Fallido("La fecha de nacimiento es obligatoria.");
            if (string.IsNullOrWhiteSpace(paciente.Genero))
                return ResultadoOperacion.Fallido("El género es obligatorio.");
            if (string.IsNullOrWhiteSpace(paciente.Direccion))
                return ResultadoOperacion.Fallido("La dirección es obligatoria.");

            // Validación de género permitido
            var generosValidos = new[] { "M", "F", "Otro" };
            if (!generosValidos.Contains(paciente.Genero))
                return ResultadoOperacion.Fallido("El género debe ser 'M', 'F' u 'Otro'.");

            try
            {
                // Verifica que el DNI no esté repetido por otro paciente
                var existente = await Task.Run(() => _pacienteRepository.GetByDniAsync(paciente.Dni));
                if (existente != null && existente.Id != paciente.Id)
                    return ResultadoOperacion.Fallido("Ya existe otro paciente con ese DNI.");

                await Task.Run(() => _pacienteRepository.UpdateAsync(paciente));
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
                var paciente = await Task.Run(() => _pacienteRepository.GetByIdAsync(id));
                if (paciente == null)
                {
                    return ResultadoOperacion.Fallido("Paciente no encontrado");
                }

                // Eliminado lógico: desactivar el registro
                paciente.Activo = false;
                await Task.Run(() => _pacienteRepository.UpdateAsync(paciente));

                return ResultadoOperacion.Exitoso("Paciente eliminado correctamente (eliminado lógico)");
            }
            catch (Exception ex)
            {
                return ResultadoOperacion.Fallido($"Error al eliminar el paciente: {ex.Message}");
            }
        }
    }
}