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
            // Query: Asume una tabla 'Usuarios' con columnas 'NombreUsuario' y 'Contrasena'
            
            string query = "SELECT COUNT(1) FROM Usuario WHERE nombres = @Usuario AND contra = @Contrasena AND activo = 1";

            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Usar parámetros es OBLIGATORIO para evitar Inyección SQL.
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Contrasena", contrasena);

                    try
                    {
                        connection.Open();
                        // ExecuteScalar devuelve el primer valor (el COUNT en este caso).
                        int count = (int)command.ExecuteScalar();
                        return count > 0; // Si count es 1 o más, el login es exitoso.
                    }
                    catch (SqlException ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error de autenticación: " + ex.Message);
                        return false;
                    }
                }
            }
        }
    }
}