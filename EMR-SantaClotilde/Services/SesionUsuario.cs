using EMR_SantaClotilde.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Services
{
    public class SesionUsuario
    {
        private static SesionUsuario _instance;
        private static readonly object _lock = new object();

        public Usuario UsuarioActual { get; private set; }

        private SesionUsuario() { }

        public static SesionUsuario Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new SesionUsuario();
                        }
                    }
                }
                return _instance;
            }
        }

        public void IniciarSesion(Usuario usuario)
        {
            UsuarioActual = usuario;
        }

        public void CerrarSesion()
        {
            UsuarioActual = null;
        }

        public bool EstaAutenticado()
        {
            return UsuarioActual != null;
        }
    }
}
