using EMR_SantaClotilde.Common;
using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Repositories;
using BCrypt.Net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<IEnumerable<Usuario>> ObtenerTodosAsync()
        {
            return await _usuarioRepository.GetAllAsync();
        }

        public async Task<Usuario?> ObtenerPorIdAsync(int id)
        {
            return await _usuarioRepository.GetByIdAsync(id);
        }

        public async Task<Usuario?> ObtenerPorUsernameAsync(string username)
        {
            return await _usuarioRepository.GetByUsernameAsync(username);
        }

        public async Task<IEnumerable<Usuario>> BuscarPorNombreAsync(string nombre)
        {
            return await _usuarioRepository.SearchByNombreAsync(nombre);
        }

        public async Task<ResultadoOperacion> CrearAsync(Usuario usuario)
        {
            var errores = new List<string>();

            if (usuario == null)
                return ResultadoOperacion.Fallido("El usuario no puede ser nulo");

            if (string.IsNullOrWhiteSpace(usuario.Username))
                errores.Add("El nombre de usuario es requerido");

            if (string.IsNullOrWhiteSpace(usuario.PasswordHash))
                errores.Add("La contraseña es requerida");

            if (string.IsNullOrWhiteSpace(usuario.NombreCompleto))
                errores.Add("El nombre completo es requerido");

            if (string.IsNullOrWhiteSpace(usuario.Rol))
                errores.Add("El rol es requerido");

            if (await _usuarioRepository.GetByUsernameAsync(usuario.Username) != null)
                errores.Add("Ya existe un usuario con ese nombre de usuario");

            if (errores.Any())
                return ResultadoOperacion.Fallido(
                    "Error de validación",
                    string.Join("\n", errores)
                );

            usuario.PasswordHash = BCrypt.Net.BCrypt.HashPassword(usuario.PasswordHash);
            usuario.Activo = true;

            try
            {
                await _usuarioRepository.AddAsync(usuario);
                return ResultadoOperacion.Exitoso("Usuario creado correctamente");
            }
            catch (Exception ex)
            {
                Exception inner = ex;
                string detalles = "";
                while (inner != null)
                {
                    detalles += inner.Message + "\n";
                    inner = inner.InnerException;
                }
                return ResultadoOperacion.Fallido("Error al crear el usuario", detalles);
            }
        }

        public async Task<ResultadoOperacion> ActualizarAsync(Usuario usuario)
        {
            var errores = new List<string>();

            var usuarioExistente = await _usuarioRepository.GetByIdAsync(usuario.Id);
            if (usuarioExistente == null)
                return ResultadoOperacion.Fallido("El usuario no existe");

            if (string.IsNullOrWhiteSpace(usuario.NombreCompleto))
                errores.Add("El nombre completo es requerido");

            if (string.IsNullOrWhiteSpace(usuario.Rol))
                errores.Add("El rol es requerido");

            if (errores.Any())
                return ResultadoOperacion.Fallido("Error de validación", errores);

            // Si quieres actualizar la contraseña solo si se envía una nueva
            if (!string.IsNullOrWhiteSpace(usuario.PasswordHash))
            {
                usuarioExistente.PasswordHash = BCrypt.Net.BCrypt.HashPassword(usuario.PasswordHash);
            }

            usuarioExistente.Username = usuario.Username;
            usuarioExistente.NombreCompleto = usuario.NombreCompleto;
            usuarioExistente.Rol = usuario.Rol;
            usuarioExistente.Especialidad = usuario.Especialidad;

            try
            {
                await _usuarioRepository.UpdateAsync(usuarioExistente);
                return ResultadoOperacion.Exitoso("Usuario actualizado correctamente");
            }
            catch (Exception ex)
            {
                return ResultadoOperacion.Fallido("Error al actualizar el usuario", ex.Message);
            }
        }

        public async Task<ResultadoOperacion> EliminarAsync(int id)
        {
            var usuario = await _usuarioRepository.GetByIdAsync(id);
            if (usuario == null)
                return ResultadoOperacion.Fallido("El usuario no existe");

            if (!usuario.Activo)
                return ResultadoOperacion.Fallido("El usuario ya se encuentra inactivo");

            usuario.Activo = false;

            try
            {
                await _usuarioRepository.UpdateAsync(usuario);
                return ResultadoOperacion.Exitoso($"Usuario eliminado correctamente (ID: {id})");
            }
            catch (Exception ex)
            {
                return ResultadoOperacion.Fallido("Error al eliminar el usuario", ex.Message);
            }
        }

        private bool VerificarPassword(string plainPassword, string passwordHash)
        {
            return BCrypt.Net.BCrypt.Verify(plainPassword, passwordHash);
        }

        async Task<LoginResult> IUsuarioService.AutenticarUsuario(string username, string password)
        {
            var usuario = await _usuarioRepository.GetByUsernameAsync(username);

            if (usuario == null || !usuario.Activo)
                return LoginResult.Fallido("Usuario no encontrado o inactivo");

            if (!VerificarPassword(password, usuario.PasswordHash))
                return LoginResult.Fallido("Contraseña incorrecta");

            return LoginResult.Exitoso(usuario);
        }

        bool IUsuarioService.EsMedico(Usuario usuario)
        {
            if (usuario == null) return false;
            return string.Equals(usuario.Rol, "Medico", StringComparison.OrdinalIgnoreCase)
                || string.Equals(usuario.Rol, "Médico", StringComparison.OrdinalIgnoreCase);
        }

        public async Task<IEnumerable<Usuario>> ObtenerMedicosAsync()
        {
            var todos = await _usuarioRepository.GetAllAsync();
            return todos.Where(u =>
                (u.Rol != null) &&
                (u.Rol.Equals("Medico", StringComparison.OrdinalIgnoreCase) || u.Rol.Equals("Médico", StringComparison.OrdinalIgnoreCase))
                && u.Activo
            ).ToList();
        }
    }
}