using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace PIA_MAD_CalculodeNominas
{
    public partial class FormUsuarios : Form
    {
        private NominasDAL dal = new NominasDAL();

        public FormUsuarios()
        {
            InitializeComponent();
        }

        // 1. Convertir el Load en Asíncrono
        private async void FormUsuarios_Load(object sender, EventArgs e)
        {
            // 3. Llamar al método asíncrono usando await
            await CargarUsuariosAsync();
        }

        private async Task CargarUsuariosAsync()
        {
            string query = "SELECT nombres, tipoUsuario FROM dbo.USUARIO WHERE activo = 1";

            using (SqlConnection connection = dal.GetConnection())
            {
                try
                {
                    // 4. Usar el método OpenAsync() en lugar de Open()
                    await connection.OpenAsync();

                    // Nota: SqlDataAdapter.Fill no tiene una versión async oficial que devuelva Task.
                    // Para lograr asincronía real con el DataAdapter, debemos envolver la ejecución
                    // en un Task.Run, o usar un SqlDataReader.

                    // Opción más simple y efectiva para DataAdapter en este contexto:
                    DataTable dataTable = await Task.Run(() =>
                    {
                        SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                        DataTable dt = new DataTable();
                        dataAdapter.Fill(dt); // Esta es la parte que ejecuta la consulta en otro hilo
                        return dt;
                    });


                    // Esto se ejecuta de vuelta en el hilo de la UI
                    dgvUsuarios.DataSource = dataTable;

                    if (dgvUsuarios.Columns.Contains("nombres"))
                    {
                        dgvUsuarios.Columns["nombres"].HeaderText = "Nombre Completo";
                    }
                    if (dgvUsuarios.Columns.Contains("tipoUsuario"))
                    {
                        dgvUsuarios.Columns["tipoUsuario"].HeaderText = "Tipo de Usuario";
                    }

                    dgvUsuarios.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al cargar los datos: " + ex.Message, "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    // lblEstado.Text = "Datos cargados.";
                }
            }
        }
    }
}
