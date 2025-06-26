using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Services
{
    public class ResultadoOperacion
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
    }

    public interface ICitaService
    {
        List<Cita> ObtenerTodas();
        Cita ObtenerPorId(int id);
        List<Cita> ObtenerPorFecha(DateTime fecha);
        List<Cita> ObtenerPorMedico(int medicoId, DateTime? fecha = null);
        List<Cita> ObtenerPorPaciente(int pacienteId);
        List<Cita> BuscarPorMotivo(string texto);
        ResultadoOperacion Crear(Cita cita);
        ResultadoOperacion Actualizar(Cita cita);
        ResultadoOperacion Cancelar(int id, string motivo);
        ResultadoOperacion Eliminar(int id);
    }

    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _citaRepository;

        public CitaService(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        public List<Cita> ObtenerTodas()
        {
            return _citaRepository.GetAll();
        }

        public Cita ObtenerPorId(int id)
        {
            return _citaRepository.GetById(id);
        }

        public List<Cita> ObtenerPorFecha(DateTime fecha)
        {
            return _citaRepository.GetByFecha(fecha);
        }

        public List<Cita> ObtenerPorMedico(int medicoId, DateTime? fecha = null)
        {
            return _citaRepository.GetByMedico(medicoId, fecha);
        }

        public List<Cita> ObtenerPorPaciente(int pacienteId)
        {
            return _citaRepository.GetByPacienteId(pacienteId);
        }

        public List<Cita> BuscarPorMotivo(string texto)
        {
            return _citaRepository.SearchByMotivo(texto);
        }

        public ResultadoOperacion Crear(Cita cita)
        {
            if (cita.FechaHora < DateTime.Now)
            {
                return new ResultadoOperacion
                {
                    Exito = false,
                    Mensaje = "No se pueden programar citas en fechas pasadas"
                };
            }

            try
            {
                _citaRepository.Add(cita);
                return new ResultadoOperacion
                {
                    Exito = true,
                    Mensaje = "Cita creada correctamente"
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion
                {
                    Exito = false,
                    Mensaje = $"Error al crear la cita: {ex.Message}"
                };
            }
        }

        public ResultadoOperacion Actualizar(Cita cita)
        {
            try
            {
                _citaRepository.Update(cita);
                return new ResultadoOperacion
                {
                    Exito = true,
                    Mensaje = "Cita actualizada correctamente"
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion
                {
                    Exito = false,
                    Mensaje = $"Error al actualizar la cita: {ex.Message}"
                };
            }
        }

        public ResultadoOperacion Cancelar(int id, string motivo)
        {
            try
            {
                var cita = _citaRepository.GetById(id);
                if (cita == null)
                {
                    return new ResultadoOperacion
                    {
                        Exito = false,
                        Mensaje = "Cita no encontrada"
                    };
                }

                cita.Estado = "Cancelada";
                cita.Observaciones = $"{cita.Observaciones}\nCancelación: {motivo} - {DateTime.Now}";

                _citaRepository.Update(cita);

                return new ResultadoOperacion
                {
                    Exito = true,
                    Mensaje = "Cita cancelada correctamente"
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion
                {
                    Exito = false,
                    Mensaje = $"Error al cancelar la cita: {ex.Message}"
                };
            }
        }

        public ResultadoOperacion Eliminar(int id)
        {
            try
            {
                _citaRepository.Delete(id);
                return new ResultadoOperacion
                {
                    Exito = true,
                    Mensaje = "Cita eliminada correctamente"
                };
            }
            catch (Exception ex)
            {
                return new ResultadoOperacion
                {
                    Exito = false,
                    Mensaje = $"Error al eliminar la cita: {ex.Message}"
                };
            }
        }
    }
}
