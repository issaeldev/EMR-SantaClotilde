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
        List<Cita> ObtenerCitasDelDia(DateTime fecha);
        Cita ObtenerCitaPorId(int id);
        ResultadoOperacion CrearCita(Cita cita);
        ResultadoOperacion ActualizarCita(Cita cita);
        ResultadoOperacion CancelarCita(int id, string motivo);
    }

    public class CitaService : ICitaService
    {
        private readonly ICitaRepository _citaRepository;

        public CitaService(ICitaRepository citaRepository)
        {
            _citaRepository = citaRepository;
        }

        public List<Cita> ObtenerCitasDelDia(DateTime fecha)
        {
            return _citaRepository.GetCitasDelDia(fecha);
        }

        public Cita ObtenerCitaPorId(int id)
        {
            return _citaRepository.GetCitaById(id);
        }

        public List<Cita> ObtenerCitasPorMedico(DateTime fecha)
        {
            return _citaRepository.GetCitasByMedico(1, fecha);
        }

        public ResultadoOperacion CrearCita(Cita cita)
        {
            // Validación de negocio
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

        public ResultadoOperacion ActualizarCita(Cita cita)
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

        public ResultadoOperacion CancelarCita(int id, string motivo)
        {
            try
            {
                var cita = _citaRepository.GetCitaById(id);
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
    }
}
