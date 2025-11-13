using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;

namespace PIA_MAD_CalculodeNominas
{
    public partial class FormCatalogos : Form
    {
        private NominasDAL dal = new NominasDAL();

        public FormCatalogos()
        {
            InitializeComponent();
        }

        private void FormCatalogos_Load(object sender, EventArgs e)
        {
            CargarDepartamentos();
            CargarPuestos();
            /*AplicarSeguridad()*/;
            LimpiarFormularioDepto();
            LimpiarFormularioPuesto();
        }

        /// <summary>
        /// Bloquea los controles si el usuario no es Admin
        /// </summary>
        private void AplicarSeguridad()
        {
            if (SesionUsuario.Rol != "Admin")
            {
                // Deshabilitamos todos los controles de edición
                HabilitarControles(pnlDeptoFields, false);
                HabilitarControles(pnlPuestosFields, false);
            }
        }

        #region Lógica de Departamentos

        private void CargarDepartamentos()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Departamento_GetActivos", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvDepartamentos.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar departamentos: " + ex.Message);
            }
        }

        private void dgvDepartamentos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtDeptoID.Text = dgvDepartamentos.Rows[e.RowIndex].Cells["idDepartamento"].Value.ToString();
            txtDeptoCodigo.Text = dgvDepartamentos.Rows[e.RowIndex].Cells["claveDepto"].Value.ToString();
            txtDeptoNombre.Text = dgvDepartamentos.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
        }

        private void LimpiarFormularioDepto()
        {
            txtDeptoID.Clear();
            txtDeptoCodigo.Clear();
            txtDeptoNombre.Clear();
            txtDeptoCodigo.Focus();
        }

        private void GuardarDepartamento()
        {
            if (string.IsNullOrWhiteSpace(txtDeptoCodigo.Text) || string.IsNullOrWhiteSpace(txtDeptoNombre.Text))
            {
                MessageBox.Show("Código y Nombre son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (string.IsNullOrEmpty(txtDeptoID.Text)) // INSERT
                    {
                        cmd.CommandText = "sp_Departamento_Insert";
                    }
                    else // UPDATE
                    {
                        cmd.CommandText = "sp_Departamento_Update";
                        cmd.Parameters.AddWithValue("@idDepartamento", Convert.ToInt32(txtDeptoID.Text));
                    }

                    cmd.Parameters.AddWithValue("@claveDepto", txtDeptoCodigo.Text);
                    cmd.Parameters.AddWithValue("@nombre", txtDeptoNombre.Text);

                    cnn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("¡Departamento guardado con éxito!");
                    CargarDepartamentos();
                    LimpiarFormularioDepto();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar departamento: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DarDeBajaDepartamento()
        {
            if (string.IsNullOrEmpty(txtDeptoID.Text))
            {
                MessageBox.Show("Seleccione un departamento de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Seguro que desea dar de baja este departamento?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Departamento_Baja", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idDepartamento", Convert.ToInt32(txtDeptoID.Text));
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Departamento dado de baja.");
                CargarDepartamentos();
                LimpiarFormularioDepto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar de baja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Eventos de Botones de Depto ---
        private void btnDeptoLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormularioDepto();
        }

        private void btnDeptoGuardar_Click(object sender, EventArgs e)
        {
            GuardarDepartamento();
        }

        private void btnDeptoBaja_Click(object sender, EventArgs e)
        {
            DarDeBajaDepartamento();
        }

        #endregion

        #region Lógica de Puestos

        private void CargarPuestos()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Puesto_GetActivos", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvPuestos.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar puestos: " + ex.Message);
            }
        }

        private void dgvPuestos_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            txtPuestoID.Text = dgvPuestos.Rows[e.RowIndex].Cells["idPuesto"].Value.ToString();
            txtPuestoCodigo.Text = dgvPuestos.Rows[e.RowIndex].Cells["Codigo"].Value.ToString();
            txtPuestoNombre.Text = dgvPuestos.Rows[e.RowIndex].Cells["nombre"].Value.ToString();
            txtPuestoDescripcion.Text = dgvPuestos.Rows[e.RowIndex].Cells["Descripcion"].Value.ToString();
        }

        private void LimpiarFormularioPuesto()
        {
            txtPuestoID.Clear();
            txtPuestoCodigo.Clear();
            txtPuestoNombre.Clear();
            txtPuestoDescripcion.Clear();
            txtPuestoCodigo.Focus();
        }

        private void GuardarPuesto()
        {
            if (string.IsNullOrWhiteSpace(txtPuestoCodigo.Text) || string.IsNullOrWhiteSpace(txtPuestoNombre.Text))
            {
                MessageBox.Show("Código y Nombre son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (string.IsNullOrEmpty(txtPuestoID.Text)) // INSERT
                    {
                        cmd.CommandText = "sp_Puesto_Insert";
                    }
                    else // UPDATE
                    {
                        cmd.CommandText = "sp_Puesto_Update";
                        cmd.Parameters.AddWithValue("@idPuesto", Convert.ToInt32(txtPuestoID.Text));
                    }

                    cmd.Parameters.AddWithValue("@Codigo", txtPuestoCodigo.Text);
                    cmd.Parameters.AddWithValue("@nombre", txtPuestoNombre.Text);
                    cmd.Parameters.AddWithValue("@Descripcion", txtPuestoDescripcion.Text);

                    cnn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("¡Puesto guardado con éxito!");
                    CargarPuestos();
                    LimpiarFormularioPuesto();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar puesto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DarDeBajaPuesto()
        {
            if (string.IsNullOrEmpty(txtPuestoID.Text))
            {
                MessageBox.Show("Seleccione un puesto de la lista.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Seguro que desea dar de baja este puesto?", "Confirmar", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
                return;

            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Puesto_Baja", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idPuesto", Convert.ToInt32(txtPuestoID.Text));
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Puesto dado de baja.");
                CargarPuestos();
                LimpiarFormularioPuesto();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar de baja: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- Eventos de Botones de Puesto ---
        private void btnPuestoLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormularioPuesto();
        }

        private void btnPuestoGuardar_Click(object sender, EventArgs e)
        {
            GuardarPuesto();
        }

        private void btnPuestoBaja_Click(object sender, EventArgs e)
        {
            DarDeBajaPuesto();
        }

        #endregion

        // Helper para aplicar seguridad
        private void HabilitarControles(Panel pnl, bool habilitar)
        {
            foreach (Control c in pnl.Controls)
            {
                if (c is TextBox)
                    ((TextBox)c).ReadOnly = !habilitar;
                if (c is Button)
                    ((Button)c).Enabled = habilitar;
            }
            // Habilitar/Deshabilitar el ID por separado
            txtDeptoID.ReadOnly = true;
            txtPuestoID.ReadOnly = true;
        }
    }
}