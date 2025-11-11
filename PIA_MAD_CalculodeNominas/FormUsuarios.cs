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
        // ⚠️ IMPORTANTE: Reemplaza esta cadena con tu ConnectionString real.
        // Asumiendo autenticación de Windows para el ejemplo.
        private const string ConnectionString = "Data Source=YourServerName;Initial Catalog=db_preparatoria_hsr;Integrated Security=True";

        public FormUsuarios()
        {
            InitializeComponent();
        }

        private void FormUsuarios_Load(object sender, EventArgs e)
        {
            CargarUsuarios();
        }

        private void CargarUsuarios()
        {
            // Query para seleccionar solo los nombres y el tipo de usuario.
            string query = "SELECT nombres, tipoUsuario FROM dbo.USUARIO WHERE activo = 1"; // Solo usuarios activos

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                try
                {
                    connection.Open();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                    DataTable dataTable = new DataTable();

                    // Rellena el DataTable con los datos de la consulta
                    dataAdapter.Fill(dataTable);

                    // Asigna el DataTable como fuente de datos del DataGridView
                    dgvUsuarios.DataSource = dataTable;

                    // Opcional: Establecer nombres de encabezado más amigables
                    if (dgvUsuarios.Columns.Contains("nombres"))
                    {
                        dgvUsuarios.Columns["nombres"].HeaderText = "Nombre Completo";
                    }
                    if (dgvUsuarios.Columns.Contains("tipoUsuario"))
                    {
                        dgvUsuarios.Columns["tipoUsuario"].HeaderText = "Tipo de Usuario";
                    }

                    // Opcional: Auto-ajustar las columnas
                    dgvUsuarios.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.AllCells);

                }
                catch (SqlException ex)
                {
                    MessageBox.Show("Error al conectar o cargar los datos de la base de datos:\n" + ex.Message,
                                    "Error de Conexión",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error inesperado:\n" + ex.Message,
                                    "Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
            }
        }
    }
}
