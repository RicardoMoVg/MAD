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
    public partial class FormAgregarPercepciones : Form
    {
        private NominasDAL dal = new NominasDAL();
        private FormPrincipal _form1;

        public FormAgregarPercepciones(FormPrincipal menu)
        {
            InitializeComponent();
            _form1 = menu;
            this.FormClosing += new FormClosingEventHandler(this.FormAgregarPercepciones_FormClosing);
        }

        private void FormAgregarPercepciones_Load(object sender, EventArgs e)
        {
            InicializarCombos();
            ConfigurarEstado(true);
            CargarConceptos();
            cmbCuotaPorcentaje_SelectedIndexChanged(null, null);
        }

        private void InicializarCombos()
        {
            cmbTipoConcepto.Items.Clear();
            cmbTipoConcepto.Items.Add("PERCEPCION");
            cmbTipoConcepto.Items.Add("DEDUCCION");
            cmbTipoConcepto.SelectedIndex = 0;

            cmbCuotaPorcentaje.Items.Clear();
            cmbCuotaPorcentaje.Items.Add("CUOTA");
            cmbCuotaPorcentaje.Items.Add("PORCENTAJE");
            cmbCuotaPorcentaje.SelectedIndex = 0;

            cmbFijo.Items.Clear();
            cmbFijo.Items.Add("SI");
            cmbFijo.Items.Add("NO");
            cmbFijo.SelectedIndex = 0;
        }

        private void CargarConceptos()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Concepto_Consultar", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dtConceptos = new DataTable();
                        cnn.Open();
                        da.Fill(dtConceptos);
                        dgvConceptos.DataSource = dtConceptos;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar conceptos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            dgvConceptos.Columns["idConcepto"].HeaderText = "ID";
            dgvConceptos.Columns["nombre"].HeaderText = "Nombre";
            dgvConceptos.Columns["cuota"].HeaderText = "Cuota";
            dgvConceptos.Columns["porcentaje"].HeaderText = "Porcentaje";
            dgvConceptos.Columns["fechaCreacion"].HeaderText = "Fecha de Creación";
            dgvConceptos.Columns["Tipo"].HeaderText = "Tipo";                 
            dgvConceptos.Columns["Metodo"].HeaderText = "Método";             
            dgvConceptos.Columns["EsProgramable"].HeaderText = "Fijo";

        }

        private void ConfigurarEstado(bool esNuevo)
        {
            txtId.Enabled = false;
            txtNombre.Enabled = true;
            cmbTipoConcepto.Enabled = true;
            cmbCuotaPorcentaje.Enabled = true;
            cmbFijo.Enabled = true;
            txtValor.Enabled = true;
            btnActualizar.Enabled = false;


            btnIngresar.Enabled = esNuevo;
            btnEliminar.Enabled = !esNuevo;

            if (esNuevo)
            {
                txtId.Text = "";
                txtNombre.Text = "";
                txtValor.Text = "0";
                dtpFechaCreacion.Value = DateTime.Now;
                cmbTipoConcepto.SelectedIndex = 0;
                cmbCuotaPorcentaje.SelectedIndex = 0;
                cmbFijo.SelectedIndex = 0;
                lblValor.Text = "Cuota:";
                dgvConceptos.ClearSelection();
                txtNombre.Focus();
            }
        }

        private void btnIngresar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtValor.Text, out decimal valor) || valor < 0)
            {
                MessageBox.Show("El valor (cuota/porcentaje) debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    cnn.Open();

                    // Verificar si ya existe el concepto
                    using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Concepto WHERE nombre = @nombre AND activo = 1", cnn))
                    {
                        checkCmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        int existe = (int)checkCmd.ExecuteScalar();

                        if (existe > 0)
                        {
                            MessageBox.Show("Ya existe un concepto con ese nombre.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    // Insertar el nuevo concepto
                    using (SqlCommand cmd = new SqlCommand("sp_Concepto_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // --- SECCIÓN CORREGIDA ---
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text); // CORREGIDO
                        cmd.Parameters.AddWithValue("@Tipo", cmbTipoConcepto.SelectedItem.ToString() == "PERCEPCION" ? "P" : "D"); // CORREGIDO
                        cmd.Parameters.AddWithValue("@Metodo", cmbCuotaPorcentaje.SelectedItem.ToString() == "CUOTA" ? "F" : "%"); // CORREGIDO
                        cmd.Parameters.AddWithValue("@EsProgramable", cmbFijo.SelectedItem.ToString() == "SI" ? 1 : 0); // CORREGIDO
                        cmd.Parameters.AddWithValue("@fechaCreacion", dtpFechaCreacion.Value);

                        if (cmbCuotaPorcentaje.SelectedItem.ToString() == "CUOTA")
                        {
                            cmd.Parameters.AddWithValue("@cuota", valor);
                            cmd.Parameters.AddWithValue("@porcentaje", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@cuota", DBNull.Value);
                            cmd.Parameters.AddWithValue("@porcentaje", valor);
                        }

                        

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Concepto agregado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarConceptos();
                        ConfigurarEstado(true);
                    }
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show($"Error al ingresar el concepto: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            ConfigurarEstado(true);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvConceptos.SelectedRows.Count == 0 || string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Por favor, seleccione un concepto del grid para eliminar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idConcepto = Convert.ToInt32(txtId.Text);
            string nombreConcepto = txtNombre.Text;

            if (MessageBox.Show($"¿Está seguro de que desea eliminar el concepto '{nombreConcepto}'?", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Concepto_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idConcepto", idConcepto);

                        cnn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Concepto eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarConceptos();
                        ConfigurarEstado(true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el concepto: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // --- ¡AQUÍ ESTÁ EL BOTÓN AGREGADO! ---
        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarConceptos();
            ConfigurarEstado(true); // Limpia y resetea el formulario
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text))
            {
                MessageBox.Show("Seleccione un concepto para actualizar.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtValor.Text, out decimal valor) || valor < 0)
            {
                MessageBox.Show("El valor (cuota/porcentaje) debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow row = dgvConceptos.SelectedRows[0];
            bool hayCambios =
    txtNombre.Text != row.Cells["nombre"].Value.ToString() || // CORREGIDO
    cmbTipoConcepto.SelectedItem.ToString() != (row.Cells["Tipo"].Value.ToString() == "P" ? "PERCEPCION" : "DEDUCCION") || // CORREGIDO
    cmbCuotaPorcentaje.SelectedItem.ToString() != (row.Cells["Metodo"].Value.ToString() == "F" ? "CUOTA" : "PORCENTAJE") || // CORREGIDO
    cmbFijo.SelectedItem.ToString() != (Convert.ToBoolean(row.Cells["EsProgramable"].Value) ? "SI" : "NO") || // CORREGIDO
    txtValor.Text != (cmbCuotaPorcentaje.SelectedItem.ToString() == "CUOTA"
        ? (row.Cells["cuota"].Value == DBNull.Value ? "0" : row.Cells["cuota"].Value.ToString())
        : (row.Cells["porcentaje"].Value == DBNull.Value ? "0" : row.Cells["porcentaje"].Value.ToString()));


            if (!hayCambios)
            {
                MessageBox.Show("No se detectaron cambios en el concepto.", "Sin cambios", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Concepto_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idConcepto", Convert.ToInt32(txtId.Text));
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text); // CORREGIDO
                        cmd.Parameters.AddWithValue("@Tipo", cmbTipoConcepto.SelectedItem.ToString() == "PERCEPCION" ? "P" : "D"); // CORREGIDO
                        cmd.Parameters.AddWithValue("@Metodo", cmbCuotaPorcentaje.SelectedItem.ToString() == "CUOTA" ? "F" : "%"); // CORREGIDO
                        cmd.Parameters.AddWithValue("@EsProgramable", cmbFijo.SelectedItem.ToString() == "SI" ? 1 : 0); // CORREGIDO
                        cmd.Parameters.AddWithValue("@fechaCreacion", dtpFechaCreacion.Value);

                        if (cmbCuotaPorcentaje.SelectedItem.ToString() == "CUOTA")
                        {
                            cmd.Parameters.AddWithValue("@cuota", valor);
                            cmd.Parameters.AddWithValue("@porcentaje", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@cuota", DBNull.Value);
                            cmd.Parameters.AddWithValue("@porcentaje", valor);
                        }

                        cnn.Open();
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Concepto actualizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        CargarConceptos();
                        ConfigurarEstado(true);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el concepto: {ex.Message}", "Error de BD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbCuotaPorcentaje_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCuotaPorcentaje.SelectedItem == null) return;

            if (cmbCuotaPorcentaje.SelectedItem.ToString() == "CUOTA")
            {
                lblValor.Text = "Cuota:";
            }
            else
            {
                lblValor.Text = "Porcentaje:";
            }
        }

        private void dgvConceptos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvConceptos.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvConceptos.SelectedRows[0];

                txtId.Text = row.Cells["idConcepto"].Value.ToString();
                txtNombre.Text = row.Cells["nombre"].Value.ToString(); // CORREGIDO

                // Mapeo de 'P'/'D' a 'PERCEPCION'/'DEDUCCION'
                string tipo = row.Cells["Tipo"].Value.ToString(); // CORREGIDO
                cmbTipoConcepto.SelectedItem = (tipo == "P" ? "PERCEPCION" : "DEDUCCION");

                // Mapeo de 'true'/'false' a 'SI'/'NO'
                bool esFijo = Convert.ToBoolean(row.Cells["EsProgramable"].Value); // CORREGIDO
                cmbFijo.SelectedItem = (esFijo ? "SI" : "NO");

                // Mapeo de 'F'/'%' a 'CUOTA'/'PORCENTAJE'
                string metodo = row.Cells["Metodo"].Value.ToString(); // CORREGIDO
                if (metodo == "F")
                {
                    cmbCuotaPorcentaje.SelectedItem = "CUOTA";
                    txtValor.Text = (row.Cells["cuota"].Value == DBNull.Value ? "0" : row.Cells["cuota"].Value.ToString());
                    lblValor.Text = "Cuota:";
                }
                else // Asumimos "%"
                {
                    cmbCuotaPorcentaje.SelectedItem = "PORCENTAJE";
                    txtValor.Text = (row.Cells["porcentaje"].Value == DBNull.Value ? "0" : row.Cells["porcentaje"].Value.ToString());
                    lblValor.Text = "Porcentaje:";
                }

                dtpFechaCreacion.Value = Convert.ToDateTime(row.Cells["fechaCreacion"].Value);

                ConfigurarEstado(false);
                btnActualizar.Enabled = true;
            }
        }

        private void FormAgregarPercepciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form1.Show();
        }
    }
}