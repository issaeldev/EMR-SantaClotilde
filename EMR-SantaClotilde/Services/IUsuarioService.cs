using EMR_SantaClotilde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Services
{
    public class LoginResult
    {
        public bool Success { get; set; }
        public Usuario User { get; set; }
        public string ErrorMessage { get; set; }
    }

    public interface IUsuarioService
    {
        Task<LoginResult> AutenticarUsuario(string username, string password);
        bool EsMedico(Usuario usuario);
    }
}
