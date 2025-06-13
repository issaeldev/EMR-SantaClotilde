using EMR_SantaClotilde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Repositories
{
    public interface ICitaRepository
    {
        List<Cita> GetCitasDelDia(DateTime fecha);
        List<Cita> GetCitasByMedico(int medicoId, DateTime? fecha = null);
        List<Cita> GetCitasByPaciente(int pacienteId);
        Cita GetCitaById(int id);
        void Add(Cita cita);
        void Update(Cita cita);
        void Delete(int id);
    }
}
