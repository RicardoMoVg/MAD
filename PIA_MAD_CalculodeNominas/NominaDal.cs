// Tus 'usings' están perfectos
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Windows.Forms; // ¡OJO! Añadí este 'using' para el MessageBox

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
            // ... (Tu código de TestConnection va aquí, está perfecto) ...
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                try
                {
                    connection.Open();
                    return true;
                }
                catch (SqlException ex)
                {
                    System.Diagnostics.Debug.WriteLine("Error de conexión SQL: " + ex.Message);
                    return false;
                }
            }
        }

        public bool ValidarUsuario(string usuario, string contrasena)
        {
            // ... (Tu código de ValidarUsuario va aquí, está perfecto) ...
            string query = "SELECT idUsuario, nombres, tipoUsuario FROM usuario " +
                           "WHERE nombres = @Usuario AND contra = @Contrasena AND activo = 1";

            using (SqlConnection connection = GetConnection())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Usuario", usuario);
                    command.Parameters.AddWithValue("@Contrasena", contrasena);

                    try
                    {
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                int id = (int)reader["idUsuario"];
                                string nombre = reader["nombres"].ToString();
                                string rol = reader["tipoUsuario"].ToString();
                                SesionUsuario.IniciarSesion(id, nombre, rol);
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                    catch (SqlException ex)
                    {
                        System.Diagnostics.Debug.WriteLine("Error de autenticación: " + ex.Message);
                        return false;
                    }
                }
            }
        }

        /// <summary>
        /// Guarda los datos calculados de la nómina (TVP) y autoriza el período.
        /// </summary>
        /// <param name="periodoId">ID del período a autorizar</param>
        /// <param name="tvpData">El DataTable con los cálculos (debe coincidir con el TVP)</param>
        /// <returns>True si esta acción disparó la generación del siguiente año</returns>
        public bool GuardarYAutorizarPeriodo(int periodoId, DataTable tvpData)
        {
            bool anioGenerado = false;

            // Usamos TU método GetConnection()
            using (SqlConnection conn = GetConnection())
            {
                // Llamamos al SP modificado 'sp_GuardarNominaCalculada'
                using (SqlCommand cmd = new SqlCommand("sp_GuardarNominaCalculada", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Parámetro 1: ENTRADA (ID Periodo)
                    cmd.Parameters.AddWithValue("@IDPeriodo", periodoId);

                    // Parámetro 2: ENTRADA (El TVP)
                    SqlParameter tvpParam = cmd.Parameters.AddWithValue("@NominaData", tvpData);
                    tvpParam.SqlDbType = SqlDbType.Structured;
                    // ¡OJO! Asegúrate que el TypeName sea exacto al de tu BD
                    tvpParam.TypeName = "dbo.NominaCalculadaTVP";

                    // Parámetro 3: SALIDA (El booleano)
                    SqlParameter outputParam = new SqlParameter("@SiguienteAnioGenerado", SqlDbType.Bit)
                    {
                        Direction = ParameterDirection.Output
                    };
                    cmd.Parameters.Add(outputParam);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery(); // Ejecuta el SP

                        // Recuperar el valor del parámetro de salida
                        if (outputParam.Value != DBNull.Value)
                        {
                            anioGenerado = (bool)outputParam.Value;
                        }
                    }
                    catch (SqlException ex)
                    {
                        // Mostramos el RAISERROR de SQL
                        MessageBox.Show(
                            $"Error al guardar y autorizar el período: \n{ex.Message}",
                            "Error de Base de Datos",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error
                        );
                        // Relanzamos para que el Form sepa que algo falló
                        throw;
                    }
                }
            }

            return anioGenerado; // Devuelve true o false
        }

    } // Fin de la clase NominasDAL
}