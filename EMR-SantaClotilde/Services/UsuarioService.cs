using BCrypt.Net;
using EMR_SantaClotilde.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly EmrSantaClotildeContext _context;

        public UsuarioService(EmrSantaClotildeContext context)
        {
            _context = context;
        }

        public async Task<LoginResult> AutenticarUsuario(string username, string password)
        {
            // Buscar el usuario por nombre de usuario
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Username == username && u.Activo);

            if (usuario == null)
            {
                return new LoginResult { Success = false, ErrorMessage = "Usuario no encontrado o inactivo" };
            }

            // Verificar la contraseña usando BCrypt
            if (VerificarPasswordBCrypt(password, usuario.PasswordHash))
            {
                return new LoginResult { Success = true, User = usuario };
            }

            return new LoginResult { Success = false, ErrorMessage = "Credenciales incorrectas" };
        }

        public bool EsMedico(Usuario usuario)
        {
            return usuario.Rol.Equals("Medico", StringComparison.OrdinalIgnoreCase) &&
                   !string.IsNullOrEmpty(usuario.Especialidad);
        }

        private bool VerificarPasswordBCrypt(string password, string storedHash)
        {
            // BCrypt verifica automáticamente incluyendo el salt
            try
            {
                return BCrypt.Net.BCrypt.Verify(password, storedHash);
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Método para generar nuevo hash BCrypt - úsalo cuando crees o cambies contraseñas
        public string HashPasswordBCrypt(string password)
        {
            return BCrypt.Net.BCrypt.HashPassword(password, workFactor: 12);
        }
    }
}
