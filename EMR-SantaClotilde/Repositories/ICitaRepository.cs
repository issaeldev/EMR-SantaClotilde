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
        List<Cita> GetAll();
        Cita GetById(int id);
        List<Cita> GetByFecha(DateTime fecha);
        List<Cita> GetByMedico(int medicoId, DateTime? fecha);
        List<Cita> GetByPacienteId(int pacienteId);
        List<Cita> SearchByMotivo(string texto);
        bool ExisteSolapamiento(DateTime fechaHora, int medicoId, int? excludeId = null);
    }
}
