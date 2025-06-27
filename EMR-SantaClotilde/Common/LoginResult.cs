using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMR_SantaClotilde.Common
{
    public class LoginResult
    {
        public bool Exito { get; set; }
        public string? Mensaje { get; set; }
        public Models.Usuario? Usuario { get; set; }

        public static LoginResult Exitoso(Models.Usuario usuario)
        {
            return new LoginResult
            {
                Exito = true,
                Usuario = usuario,
                Mensaje = "Autenticación exitosa"
            };
        }

        public static LoginResult Fallido(string mensaje)
        {
            return new LoginResult
            {
                Exito = false,
                Usuario = null,
                Mensaje = mensaje
            };
        }
    }
}
