using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PIA_MAD_CalculodeNominas
{
    public static class SesionUsuario
    {
        // Propiedades para guardar los datos del usuario logueado
        public static int UsuarioID { get; private set; }
        public static string NombreCompleto { get; private set; }
        public static string Rol { get; private set; } // Aquí guardamos el "tipoUsuario"

        // Método para guardar los datos al iniciar sesión
        public static void IniciarSesion(int id, string nombre, string rol)
        {
            UsuarioID = id;
            NombreCompleto = nombre;
            Rol = rol; // Ej: "Nómina", "RecursosHumanos", "Consulta"
        }

        // Método para limpiar los datos al cerrar sesión
        public static void CerrarSesion()
        {
            UsuarioID = 0;
            NombreCompleto = null;
            Rol = null;
        }

        // Un ayudante simple para verificar el rol
        public static bool EsRol(string nombreRol)
        {
            if (string.IsNullOrEmpty(Rol))
                return false;

            // Comparamos ignorando mayúsculas/minúsculas
            return Rol.Equals(nombreRol, StringComparison.OrdinalIgnoreCase);
        }
    }

}
