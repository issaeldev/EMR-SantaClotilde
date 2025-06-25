using EMR_SantaClotilde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Repositories
{
    public interface IPacienteRepository
    {
        Paciente GetById(int id);
        List<Paciente> GetAll();
        Paciente GetByDni(string dni);
        List<Paciente> SearchByNombre(string nombre);
        void Add(Paciente paciente);
        void Update(Paciente paciente);
        void Delete(int id);
    }
}
