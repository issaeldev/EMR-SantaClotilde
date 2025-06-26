using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace EMR_SantaClotilde.Common
{
    public class ResultadoOperacion
    {
        public bool Exito { get; set; }
        public string Mensaje { get; set; }
        public List<string> Errores { get; set; } = new List<string>();

        // Métodos estáticos para facilitar la creación
        public static ResultadoOperacion Exitoso(string mensaje = "Operación exitosa")
        {
            return new ResultadoOperacion
            {
                Exito = true,
                Mensaje = mensaje
            };
        }

        public static ResultadoOperacion Fallido(string mensaje, List<string> errores = null)
        {
            return new ResultadoOperacion
            {
                Exito = false,
                Mensaje = mensaje,
                Errores = errores ?? new List<string>()
            };
        }

        public static ResultadoOperacion Fallido(string mensaje, string error)
        {
            return new ResultadoOperacion
            {
                Exito = false,
                Mensaje = mensaje,
                Errores = new List<string> { error }
            };
        }
    }

    public class ResultadoOperacion<T> : ResultadoOperacion
    {
        public T Datos { get; set; }

        public static ResultadoOperacion<T> Exitoso(T datos, string mensaje = "Operación exitosa")
        {
            return new ResultadoOperacion<T>
            {
                Exito = true,
                Mensaje = mensaje,
                Datos = datos
            };
        }

        public static new ResultadoOperacion<T> Fallido(string mensaje, List<string> errores = null)
        {
            return new ResultadoOperacion<T>
            {
                Exito = false,
                Mensaje = mensaje,
                Errores = errores ?? new List<string>()
            };
        }

        public static new ResultadoOperacion<T> Fallido(string mensaje, string error)
        {
            return new ResultadoOperacion<T>
            {
                Exito = false,
                Mensaje = mensaje,
                Errores = new List<string> { error }
            };
        }
    }
}