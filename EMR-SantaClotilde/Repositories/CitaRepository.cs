using EMR_SantaClotilde.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Repositories
{
    public class CitaRepository : ICitaRepository
    {
        private readonly EmrSantaClotildeContext _context;

        public CitaRepository(EmrSantaClotildeContext context)
        {
            _context = context;
        }

        public List<Cita> GetCitasDelDia(DateTime fecha)
        {
            var fechaInicio = fecha.Date;
            var fechaFin = fechaInicio.AddDays(1).AddSeconds(-1);

            return _context.Set<Cita>()
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .Where(c => c.FechaHora >= fechaInicio && c.FechaHora <= fechaFin)
                .OrderBy(c => c.FechaHora)
                .ToList();
        }

        public List<Cita> GetCitasByMedico(int medicoId, DateTime? fecha = null)
        {
            var query = _context.Set<Cita>()
                .Include(c => c.Paciente)
                .Where(c => c.MedicoId == medicoId);

            if (fecha.HasValue)
            {
                var fechaInicio = fecha.Value.Date;
                var fechaFin = fechaInicio.AddDays(1).AddSeconds(-1);
                query = query.Where(c => c.FechaHora >= fechaInicio && c.FechaHora <= fechaFin);
            }

            return query.OrderBy(c => c.FechaHora).ToList();
        }

        public List<Cita> GetCitasByPaciente(int pacienteId)
        {
            return _context.Set<Cita>()
                .Include(c => c.Medico)
                .Where(c => c.PacienteId == pacienteId)
                .OrderByDescending(c => c.FechaHora)
                .ToList();
        }

        public Cita GetCitaById(int id)
        {
            return _context.Set<Cita>()
                .Include(c => c.Paciente)
                .Include(c => c.Medico)
                .FirstOrDefault(c => c.Id == id);
        }

        public void Add(Cita cita)
        {
            _context.Set<Cita>().Add(cita);
            _context.SaveChanges();
        }

        public void Update(Cita cita)
        {
            _context.Set<Cita>().Update(cita);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cita = _context.Set<Cita>().Find(id);
            if (cita != null)
            {
                _context.Set<Cita>().Remove(cita);
                _context.SaveChanges();
            }
        }

    }
}
