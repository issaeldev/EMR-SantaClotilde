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
        Task<Paciente?> GetByIdAsync(int id);
        Task<List<Paciente>> GetAllAsync();
        Task<Paciente?> GetByDniAsync(string dni);
        Task<List<Paciente>> SearchByNombreAsync(string nombre);
        Task AddAsync(Paciente paciente);
        Task UpdateAsync(Paciente paciente);
        Task DeleteAsync(int id);
    }
}
