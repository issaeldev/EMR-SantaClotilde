using EMR_SantaClotilde.Models;
using System.Collections.Generic;
using System.Linq;

namespace EMR_SantaClotilde.Repositories
{
    public class PacienteRepository : IPacienteRepository
    {
        private readonly EmrSantaClotildeContext _context;

        public PacienteRepository(EmrSantaClotildeContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retorna un IQueryable con solo los pacientes activos.
        /// Puedes componer más filtros antes de ejecutar ToList(), FirstOrDefault(), etc.
        /// </summary>
        public IQueryable<Paciente> QueryActivos()
        {
            return _context.Pacientes.Where(p => p.Activo);
        }

        public List<Paciente> GetAll()
        {
            return QueryActivos().ToList();
        }

        public Paciente? GetById(int id)
        {
            return QueryActivos().FirstOrDefault(p => p.Id == id);
        }

        public Paciente? GetByDni(string dni)
        {
            return QueryActivos().FirstOrDefault(p => p.Dni == dni);
        }

        public List<Paciente> SearchByNombre(string nombre)
        {
            return QueryActivos()
                .Where(p => p.Nombres.Contains(nombre))
                .ToList();
        }

        public void Add(Paciente paciente)
        {
            paciente.Activo = true; // Por defecto activo al crear
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
        }

        public void Update(Paciente paciente)
        {
            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var paciente = _context.Pacientes.FirstOrDefault(p => p.Id == id);
            if (paciente != null)
            {
                paciente.Activo = false;            // ← Borrado lógico
                _context.Pacientes.Update(paciente);
                _context.SaveChanges();
            }
        }
    }
}