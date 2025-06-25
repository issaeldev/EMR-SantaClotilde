using EMR_SantaClotilde.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Repositories
{
    internal class PacienteRepository : IPacienteRepository
    {
        private readonly EmrSantaClotildeContext _context;

        public PacienteRepository(EmrSantaClotildeContext context)
        {
            _context = context;
        }

        public Paciente GetById(int id)
        {
            return _context.Set<Paciente>()
                .Include(p => p.Cita)
                .Include(p => p.Resultados)
                .FirstOrDefault(p => p.Id == id);
        }

        public List<Paciente> GetAll()
        {
            return _context.Set<Paciente>()
                .Include(p => p.Cita)
                .Include(p => p.Resultados)
                .OrderBy(p => p.Apellidos)
                .ThenBy(p => p.Nombres)
                .ToList();
        }

        public Paciente GetByDni(string dni)
        {
            return _context.Set<Paciente>()
                .Include(p => p.Cita)
                .Include(p => p.Resultados)
                .FirstOrDefault(p => p.Dni == dni);
        }

        public List<Paciente> SearchByNombre(string nombre)
        {
            return _context.Set<Paciente>()
                .Where(p =>
                    p.Nombres.Contains(nombre) ||
                    p.Apellidos.Contains(nombre))
                .OrderBy(p => p.Apellidos)
                .ThenBy(p => p.Nombres)
                .ToList();
        }

        public void Add(Paciente paciente)
        {
            _context.Set<Paciente>().Add(paciente);
            _context.SaveChanges();
        }

        public void Update(Paciente paciente)
        {
            _context.Set<Paciente>().Update(paciente);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var paciente = _context.Set<Paciente>().Find(id);
            if (paciente != null)
            {
                _context.Set<Paciente>().Remove(paciente);
                _context.SaveChanges();
            }
        }
    }
}
