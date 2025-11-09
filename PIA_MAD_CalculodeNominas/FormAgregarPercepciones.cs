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
                    string query = "SELECT * FROM v_CatalogoConceptosCompleto";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
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
        }

        private void ConfigurarEstado(bool esNuevo)
        {
            txtId.Enabled = false;
            txtNombre.Enabled = true;
            cmbTipoConcepto.Enabled = true;
            cmbCuotaPorcentaje.Enabled = true;
            cmbFijo.Enabled = true;
            txtValor.Enabled = true;

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
                    using (SqlCommand cmd = new SqlCommand("sp_Concepto_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@NombreConcepto", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@tipoConcepto", cmbTipoConcepto.SelectedItem.ToString());

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

                        cmd.Parameters.AddWithValue("@fijo", cmbFijo.SelectedItem.ToString());
                        cmd.Parameters.AddWithValue("@fechaCreacion", dtpFechaCreacion.Value);

                        cnn.Open();
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
                txtNombre.Text = row.Cells["NombreConcepto"].Value.ToString();

                cmbTipoConcepto.SelectedItem = row.Cells["tipoConcepto"].Value.ToString();
                cmbFijo.SelectedItem = row.Cells["fijo"].Value.ToString();

                if (row.Cells["cuota"].Value != DBNull.Value && Convert.ToDecimal(row.Cells["cuota"].Value) > 0)
                {
                    cmbCuotaPorcentaje.SelectedItem = "CUOTA";
                    txtValor.Text = row.Cells["cuota"].Value.ToString();
                    lblValor.Text = "Cuota:";
                }
                else
                {
                    cmbCuotaPorcentaje.SelectedItem = "PORCENTAJE";
                    txtValor.Text = row.Cells["porcentaje"].Value.ToString();
                    lblValor.Text = "Porcentaje:";
                }

                dtpFechaCreacion.Value = Convert.ToDateTime(row.Cells["fechaCreacion"].Value);

                ConfigurarEstado(false);
            }
        }

        private void FormAgregarPercepciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form1.Show();
        }
    }
}