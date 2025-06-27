using EMR_SantaClotilde.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EMR_SantaClotilde.Repositories
{
    internal class CitaRepository : ICitaRepository
    {
        private readonly EmrSantaClotildeContext _context;

        public CitaRepository(EmrSantaClotildeContext context)
        {
            _context = context;
        }

        // Obtener todas las citas
        public List<Cita> GetAll()
        {
            return _context.Set<Cita>()
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .OrderByDescending(c => c.FechaHora)
                .ToList();
        }

        // Obtener una cita por ID
        public Cita GetById(int id)
        {
            return _context.Set<Cita>()
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Include(c => c.Resultados)
                .FirstOrDefault(c => c.Id == id);
        }

        // Agregar nueva cita
        public void Add(Cita cita)
        {
            _context.Set<Cita>().Add(cita);
            _context.SaveChanges();
        }

        // Actualizar cita existente
        public void Update(Cita cita)
        {
            _context.Set<Cita>().Update(cita);
            _context.SaveChanges();
        }

        // Eliminar cita por ID
        public void Delete(int id)
        {
            var cita = _context.Set<Cita>().Find(id);
            if (cita != null)
            {
                _context.Set<Cita>().Remove(cita);
                _context.SaveChanges();
            }
        }

        // Obtener citas de un día específico
        public List<Cita> GetByFecha(DateTime fecha)
        {
            var inicio = fecha.Date;
            var fin = inicio.AddDays(1).AddSeconds(-1);

            return _context.Set<Cita>()
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Where(c => c.FechaHora >= inicio && c.FechaHora <= fin)
                .OrderBy(c => c.FechaHora)
                .ToList();
        }

        // Obtener citas de un médico, opcionalmente filtradas por fecha
        public List<Cita> GetByMedico(int medicoId, DateTime? fecha = null)
        {
            var query = _context.Set<Cita>()
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Where(c => c.MedicoId == medicoId);

            if (fecha.HasValue)
            {
                var inicio = fecha.Value.Date;
                var fin = inicio.AddDays(1).AddSeconds(-1);
                query = query.Where(c => c.FechaHora >= inicio && c.FechaHora <= fin);
            }

            return query.OrderBy(c => c.FechaHora).ToList();
        }

        // Obtener citas por paciente
        public List<Cita> GetByPacienteId(int pacienteId)
        {
            return _context.Set<Cita>()
                .Include(c => c.Medico)
                .Where(c => c.PacienteId == pacienteId)
                .OrderByDescending(c => c.FechaHora)
                .ToList();
        }

        // Buscar por motivo o texto libre
        public List<Cita> SearchByMotivo(string texto)
        {
            return _context.Set<Cita>()
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Where(c => c.Motivo.Contains(texto) || c.Observaciones.Contains(texto))
                .OrderByDescending(c => c.FechaHora)
                .ToList();
        }

        public List<Cita> GetCitasDelDia(DateTime fecha)
        {
            return GetByFecha(fecha); 
        }

        public List<Cita> GetCitasByMedico(int medicoId, DateTime? fecha = null)
        {
            return GetByMedico(medicoId, fecha); 
        }

        public List<Cita> GetCitasByPaciente(int pacienteId)
        {
            return GetByPacienteId(pacienteId); 
        }

        public Cita GetCitaById(int id)
        {
            return GetById(id); 
        }
        // (opcionales)
        public bool ExisteSolapamiento(DateTime fechaHora, int medicoId, int? excludeId = null)
        {
            var rangoInicio = fechaHora.AddMinutes(-30);
            var rangoFin = fechaHora.AddMinutes(30);

            var query = _context.Set<Cita>()
                .Where(c => c.MedicoId == medicoId)
                .Where(c => c.FechaHora >= rangoInicio && c.FechaHora <= rangoFin)
                .Where(c => c.Estado != "Cancelada");

            if (excludeId.HasValue)
                query = query.Where(c => c.Id != excludeId.Value);

            return query.Any();
        }

        // Obtener citas por estado
        public List<Cita> GetByEstado(string estado, DateTime? fecha = null)
        {
            var query = _context.Set<Cita>()
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Where(c => c.Estado == estado);

            if (fecha.HasValue)
            {
                var inicio = fecha.Value.Date;
                var fin = inicio.AddDays(1).AddSeconds(-1);
                query = query.Where(c => c.FechaHora >= inicio && c.FechaHora <= fin);
            }

            return query.OrderBy(c => c.FechaHora).ToList();
        }

        // Obtener próximas citas (útil para recordatorios)
        public List<Cita> GetProximasCitas(int horas = 24)
        {
            var ahora = DateTime.Now;
            var limite = ahora.AddHours(horas);

            return _context.Set<Cita>()
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Where(c => c.FechaHora >= ahora && c.FechaHora <= limite)
                .Where(c => c.Estado == "Programada")
                .OrderBy(c => c.FechaHora)
                .ToList();
        }

        // Obtener estadísticas de citas por médico
        public Dictionary<string, int> GetEstadisticasPorMedico(DateTime fechaInicio, DateTime fechaFin)
        {
            return _context.Set<Cita>()
                .Include(c => c.Medico)
                .Where(c => c.FechaHora >= fechaInicio && c.FechaHora <= fechaFin)
                .GroupBy(c => c.Medico.NombreCompleto)
                .ToDictionary(g => g.Key, g => g.Count());
        }

        // Buscar citas con texto libre (búsqueda más amplia)
        public List<Cita> BuscarTextoLibre(string texto)
        {
            var textoLower = texto.ToLower();

            return _context.Set<Cita>()
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Where(c =>
                    c.Motivo.ToLower().Contains(textoLower) ||
                    c.Observaciones.ToLower().Contains(textoLower) ||
                    c.Paciente.Nombres.ToLower().Contains(textoLower) ||
                    c.Medico.NombreCompleto.ToLower().Contains(textoLower) ||
                    c.Tipo.ToLower().Contains(textoLower))
                .OrderByDescending(c => c.FechaHora)
                .ToList();
        }
    }
}
