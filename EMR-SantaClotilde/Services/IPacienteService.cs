using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Services
{
    public interface IPacienteService
    {
        List<Paciente> ObtenerTodos();
        Paciente ObtenerPorId(int id);
        Paciente ObtenerPorDni(string dni);
        List<Paciente> BuscarPorNombre(string nombre);
        ResultadoOperacion CrearPaciente(Paciente paciente);
        ResultadoOperacion ActualizarPaciente(Paciente paciente);
        ResultadoOperacion EliminarPaciente(int id);
    }

    public class PacienteService : IPacienteService
    {
        private readonly IPacienteRepository _pacienteRepository;

        public PacienteService(IPacienteRepository pacienteRepository)
        {
            _pacienteRepository = pacienteRepository;
        }

        public List<Paciente> ObtenerTodos()
        {
            return _pacienteRepository.GetAll();
        }

        public Paciente ObtenerPorId(int id)
        {
            return _pacienteRepository.GetById(id);
        }

        public Paciente ObtenerPorDni(string dni)
        {
            return _pacienteRepository.GetByDni(dni);
        }

        public List<Paciente> BuscarPorNombre(string nombre)
        {
            return _pacienteRepository.SearchByNombre(nombre);
        }

        public ResultadoOperacion CrearPaciente(Paciente paciente)
        {
            // Validaciones básicas
            if (string.IsNullOrWhiteSpace(paciente.Dni) || string.IsNullOrWhiteSpace(paciente.Nombres))
            {
                return new ResultadoOperacion
                {
                    Exito = false,
                    Mensaje = "DNI y Nombres son obligatorios"
                };
            }

            try
            {
                _pacienteRepository.Add(paciente);
                return new ResultadoOperacion
                {
                    Exito = true,
                    Mensaje = "Paciente creado correctamente"
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion
                {
                    Exito = false,
                    Mensaje = $"Error al crear el paciente: {ex.Message}"
                };
            }
        }

        public ResultadoOperacion ActualizarPaciente(Paciente paciente)
        {
            try
            {
                _pacienteRepository.Update(paciente);
                return new ResultadoOperacion
                {
                    Exito = true,
                    Mensaje = "Paciente actualizado correctamente"
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion
                {
                    Exito = false,
                    Mensaje = $"Error al actualizar el paciente: {ex.Message}"
                };
            }
        }

        public ResultadoOperacion EliminarPaciente(int id)
        {
            try
            {
                var paciente = _pacienteRepository.GetById(id);
                if (paciente == null)
                {
                    return new ResultadoOperacion
                    {
                        Exito = false,
                        Mensaje = "Paciente no encontrado"
                    };
                }

                _pacienteRepository.Delete(id);
                return new ResultadoOperacion
                {
                    Exito = true,
                    Mensaje = "Paciente eliminado correctamente"
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion
                {
                    Exito = false,
                    Mensaje = $"Error al eliminar el paciente: {ex.Message}"
                };
            }
        }
    }
}
