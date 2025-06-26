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
        List<Cita> GetAll();
        Cita GetById(int id);
        void Add(Cita cita);
        void Update(Cita cita);
        void Delete(int id);
        List<Cita> GetByFecha(DateTime fecha);
        List<Cita> GetByMedico(int medicoId, DateTime? fecha = null);
        List<Cita> GetByPacienteId(int pacienteId);
        List<Cita> SearchByMotivo(string texto);
    }
}
