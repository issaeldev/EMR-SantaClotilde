using EMR_SantaClotilde.Common;
using EMR_SantaClotilde.Models;
using EMR_SantaClotilde.Repositories;
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

        public async Task<IEnumerable<Usuarios>> ObtenerTodosAsync()
        {
            return await Task.Run(() => _usuarioRepository.GetAll());
        }

        public async Task<Usuarios?> ObtenerPorIdAsync(int id)
        {
            return await Task.Run(() => _usuarioRepository.GetById(id));
        }

        public async Task<Usuarios?> ObtenerPorUsernameAsync(string username)
        {
            return await Task.Run(() => _usuarioRepository.GetByUsername(username));
        }

        public async Task<IEnumerable<Usuarios>> BuscarPorNombreAsync(string nombre)
        {
            return await Task.Run(() => _usuarioRepository.SearchByNombre(nombre));
        }

        public async Task<ResultadoOperacion> CrearAsync(Usuarios usuario)
        {
            return await Task.Run(() => Crear(usuario));
        }

        public async Task<ResultadoOperacion> ActualizarAsync(Usuarios usuario)
        {
            return await Task.Run(() => Actualizar(usuario));
        }

        public async Task<ResultadoOperacion> EliminarAsync(int id)
        {
            return await Task.Run(() => Eliminar(id));
        }

        // Lógica interna
        private ResultadoOperacion Crear(Usuarios usuario)
        {
            try
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

                if (_usuarioRepository.GetByUsername(usuario.Username) != null)
                    errores.Add("Ya existe un usuario con ese nombre de usuario");

                if (errores.Any())
                    return ResultadoOperacion.Fallido("Error de validación", errores);

                usuario.Activo = true;
                _usuarioRepository.Add(usuario);

                return ResultadoOperacion.Exitoso("Usuario creado correctamente");
            }
            catch (Exception ex)
            {
                return ResultadoOperacion.Fallido("Error al crear el usuario", ex.Message);
            }
        }

        private ResultadoOperacion Actualizar(Usuarios usuario)
        {
            try
            {
                var errores = new List<string>();

                var usuarioExistente = _usuarioRepository.GetById(usuario.Id);
                if (usuarioExistente == null)
                    return ResultadoOperacion.Fallido("El usuario no existe");

                if (string.IsNullOrWhiteSpace(usuario.NombreCompleto))
                    errores.Add("El nombre completo es requerido");

                if (string.IsNullOrWhiteSpace(usuario.Rol))
                    errores.Add("El rol es requerido");

                if (errores.Any())
                    return ResultadoOperacion.Fallido("Error de validación", errores);

                _usuarioRepository.Update(usuario);
                return ResultadoOperacion.Exitoso("Usuario actualizado correctamente");
            }
            catch (Exception ex)
            {
                return ResultadoOperacion.Fallido("Error al actualizar el usuario", ex.Message);
            }
        }

        private ResultadoOperacion Eliminar(int id)
        {
            try
            {
                var usuario = _usuarioRepository.GetById(id);
                if (usuario == null)
                    return ResultadoOperacion.Fallido("El usuario no existe");

                if (!usuario.Activo)
                    return ResultadoOperacion.Fallido("El usuario ya se encuentra inactivo");

                _usuarioRepository.Delete(id);

                return ResultadoOperacion.Exitoso($"Usuario eliminado correctamente (ID: {id})");
            }
            catch (Exception ex)
            {
                return ResultadoOperacion.Fallido("Error al eliminar el usuario", ex.Message);
            }
        }

        Task IUsuarioService.CrearAsync(Usuarios usuario)
        {
            throw new NotImplementedException();
        }
    }
}
