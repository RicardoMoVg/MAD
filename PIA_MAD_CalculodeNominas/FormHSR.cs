using System;
using System.Data;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using System.Drawing;

namespace PIA_MAD_CalculodeNominas
{
    public partial class FormHSR : Form
    {
        
        private NominasDAL dal = new NominasDAL();

        private int idEmpresa = 1; 

        public FormHSR()
        {
            InitializeComponent();
        }

        private void FormHSR_Load(object sender, EventArgs e)
        {
            CargarDatosEmpresa();
            AlternarEstadoControles(false); 
            
            if (SesionUsuario.Rol == "Admin")
            {
                btnEditar.Enabled = true;
                btnGuardar.Enabled = false;
            }
            else
            {
                btnEditar.Enabled = false;
                btnGuardar.Enabled = false;
            }
        }

        private void AlternarEstadoControles(bool habilitado)
        {
            txtNombre.ReadOnly = !habilitado;
            txtRFC.ReadOnly = !habilitado;
            txtClaveCCT.ReadOnly = !habilitado;
            txtTelefono.ReadOnly = !habilitado;
            txtRegistroPatronal.ReadOnly = !habilitado;
            txtCalle.ReadOnly = !habilitado;
            txtNumExt.ReadOnly = !habilitado;
            txtNumInt.ReadOnly = !habilitado;
            txtColonia.ReadOnly = !habilitado;
            txtMunicipio.ReadOnly = !habilitado;
            txtEstado.ReadOnly = !habilitado;
            txtCodigoPostal.ReadOnly = !habilitado;
        }

        /// <summary>
        /// Carga los datos de la BD y los pone en los TextBoxes
        /// </summary>
        private void CargarDatosEmpresa()
        {
            string query = "SELECT * FROM preparatoria WHERE idPrepa = @ID";

            // <--- CAMBIO: Obtenemos la conexión desde la clase DAL
            using (SqlConnection conn = dal.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@ID", idEmpresa);

                    try
                    {
                        conn.Open(); // Abrimos la conexión que nos dio el DAL
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            txtNombre.Text = reader["nombre"].ToString();
                            txtRFC.Text = reader["RFC"].ToString();
                            txtClaveCCT.Text = reader["claveCCT"].ToString();
                            txtTelefono.Text = reader["Telefono"].ToString();
                            txtRegistroPatronal.Text = reader["RegistroPatronal"].ToString();
                            txtCalle.Text = reader["Calle"].ToString();
                            txtNumExt.Text = reader["NumExt"].ToString();
                            txtNumInt.Text = reader["NumInt"].ToString();
                            txtColonia.Text = reader["Colonia"].ToString();
                            txtMunicipio.Text = reader["Municipio"].ToString();
                            txtEstado.Text = reader["Estado"].ToString();
                            txtCodigoPostal.Text = reader["CodigoPostal"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Error: No se encontró la fila de configuración de la empresa (ID=1).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al cargar los datos de la empresa: " + ex.Message, "Error de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        // --- Eventos de Botones ---

        private void btnEditar_Click(object sender, EventArgs e)
        {
            AlternarEstadoControles(true);
            btnGuardar.Enabled = true;
            btnEditar.Enabled = false;
            txtNombre.Focus();
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            string query = @"
                UPDATE preparatoria 
                SET 
                    nombre = @nombre, 
                    RFC = @rfc, 
                    claveCCT = @claveCCT, 
                    Telefono = @telefono, 
                    RegistroPatronal = @regPatronal,
                    Calle = @calle,
                    NumExt = @numExt,
                    NumInt = @numInt,
                    Colonia = @colonia,
                    Municipio = @municipio,
                    Estado = @estado,
                    CodigoPostal = @cp
                WHERE idPrepa = @idPrepa";

            // <--- CAMBIO: Obtenemos la conexión desde la clase DAL
            using (SqlConnection conn = dal.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@rfc", txtRFC.Text);
                    cmd.Parameters.AddWithValue("@claveCCT", txtClaveCCT.Text);
                    cmd.Parameters.AddWithValue("@telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@regPatronal", txtRegistroPatronal.Text);
                    cmd.Parameters.AddWithValue("@calle", txtCalle.Text);
                    cmd.Parameters.AddWithValue("@numExt", txtNumExt.Text);

                    // Manejo de nulos para campos opcionales como NumInt
                    if (string.IsNullOrWhiteSpace(txtNumInt.Text))
                        cmd.Parameters.AddWithValue("@numInt", DBNull.Value);
                    else
                        cmd.Parameters.AddWithValue("@numInt", txtNumInt.Text);

                    cmd.Parameters.AddWithValue("@colonia", txtColonia.Text);
                    cmd.Parameters.AddWithValue("@municipio", txtMunicipio.Text);
                    cmd.Parameters.AddWithValue("@estado", txtEstado.Text);
                    cmd.Parameters.AddWithValue("@cp", txtCodigoPostal.Text);

                    cmd.Parameters.AddWithValue("@idPrepa", idEmpresa); // El WHERE

                    try
                    {
                        conn.Open(); // Abrimos la conexión
                        int filasAfectadas = cmd.ExecuteNonQuery();

                        if (filasAfectadas > 0)
                        {
                            MessageBox.Show("¡Datos de la empresa actualizados con éxito!", "Guardado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            AlternarEstadoControles(false);
                            btnGuardar.Enabled = false;
                            btnEditar.Enabled = true;
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al guardar los datos: " + ex.Message, "Error de Guardado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}