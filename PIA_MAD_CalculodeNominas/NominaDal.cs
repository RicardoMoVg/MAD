using Microsoft.Data.SqlClient; 
using System;
using System.Configuration;
using System.Data; 
namespace PIA_MAD_CalculodeNominas 
{
    public class NominasDAL
    {
        private readonly string _connectionString;

        public NominasDAL()
        {
            _connectionString = ConfigurationManager.ConnectionStrings["db_preparatoria_hsr"].ConnectionString;

        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }

        public bool TestConnection()
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException ex)
                {
                    // Manejo de errores de conexión
                    System.Diagnostics.Debug.WriteLine("Error de conexión SQL: " + ex.Message);
                    return false;
                }
            }
        }

        // **MÉTODO FALTANTE:** Autenticación para FormLogIn.cs
        public bool ValidarUsuario(string usuario, string contrasena)
        {
            // 1. LA CONSULTA (AHORA TRAEMOS LOS DATOS, NO UN COUNT)
            // Asegúrate que tu tabla se llame 'usuario' (como en tu script original)
            string query = "SELECT idUsuario, nombres, tipoUsuario FROM usuario " +
                           "WHERE nombres = @Usuario AND contra = @Contrasena AND activo = 1";

            // Usamos tu método GetConnection()
            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Los parámetros (esto estaba bien en tu código)
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Contrasena", contrasena);

                    try
                    {
                        connection.Open();

                        // 2. LA EJECUCIÓN (USAMOS ExecuteReader PARA LEER FILAS)
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // 3. EL RESULTADO (VERIFICAMOS SI 'reader.Read()' ENCONTRÓ ALGO)
                            if (reader.Read())
                            {
                                // ¡Usuario encontrado! Obtenemos sus datos
                                int id = (int)reader["idUsuario"];
                                string nombre = reader["nombres"].ToString();
                                string rol = reader["tipoUsuario"].ToString();

                                // 4. ¡EL PASO CRUCIAL!
                                // Guardamos los datos en la sesión global
                                SesionUsuario.IniciarSesion(id, nombre, rol);

                                return true; // Login EXITOSO
                            }
                            else
                            {
                                // No se encontró ninguna fila que coincida
                                return false; // Login FALLIDO
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Manejo de error
                        System.Diagnostics.Debug.WriteLine("Error de autenticación: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}