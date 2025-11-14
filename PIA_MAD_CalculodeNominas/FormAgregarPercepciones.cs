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
            ConfigurarGrid(); // ¡Configura el grid ANTES de cargar datos!
            ConfigurarEstado(true);

            CargarConceptos(); // Carga los datos
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

        /// <summary>
        /// --- ¡¡AQUÍ ESTÁ LA CORRECCIÓN!! ---
        /// Agregamos la propiedad 'Name' a cada columna.
        /// </summary>
        private void ConfigurarGrid()
        {
            dgvConceptos.AutoGenerateColumns = false;
            dgvConceptos.Columns.Clear();

            dgvConceptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "idConcepto", // <-- ¡LA PIEZA FALTANTE!
                DataPropertyName = "idConcepto",
                HeaderText = "ID"
            });
            dgvConceptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombre", // <-- ¡LA PIEZA FALTANTE!
                DataPropertyName = "nombre",
                HeaderText = "Nombre"
            });
            dgvConceptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cuota", // <-- ¡LA PIEZA FALTANTE!
                DataPropertyName = "cuota",
                HeaderText = "Cuota"
            });
            dgvConceptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "porcentaje", // <-- ¡LA PIEZA FALTANTE!
                DataPropertyName = "porcentaje",
                HeaderText = "Porcentaje"
            });
            dgvConceptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "fechaCreacion", // <-- ¡LA PIEZA FALTANTE!
                DataPropertyName = "fechaCreacion",
                HeaderText = "Fecha de Creación"
            });
            dgvConceptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Tipo", // <-- ¡LA PIEZA FALTANTE!
                DataPropertyName = "Tipo",
                HeaderText = "Tipo"
            });
            dgvConceptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Metodo", // <-- ¡LA PIEZA FALTANTE!
                DataPropertyName = "Metodo",
                HeaderText = "Método"
            });
            dgvConceptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "EsProgramable", // <-- ¡LA PIEZA FALTANTE!
                DataPropertyName = "EsProgramable",
                HeaderText = "Fijo"
            });
        }

        private void CargarConceptos()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    // Usamos el SELECT * porque el grid ya está mapeado
                    string query = "SELECT * FROM dbo.Concepto";
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
            btnActualizar.Enabled = !esNuevo;
            btnIngresar.Enabled = esNuevo;
            btnEliminar.Enabled = !esNuevo;

            if (esNuevo)
            {
                txtId.Text = "";
                txtNombre.Text = "";
                txtValor.Text = "0.00";
                dtpFechaCreacion.Value = DateTime.Now;
                cmbTipoConcepto.SelectedIndex = 0;
                cmbCuotaPorcentaje.SelectedIndex = 0;
                cmbFijo.SelectedIndex = 0;
                lblValor.Text = "Cuota:";
                dgvConceptos.ClearSelection();
                txtNombre.Focus();
            }
        }

        // (Tu código de botones btnIngresar, btnLimpiar, btnEliminar, btnConsultar, btnActualizar...
        // ...se queda EXACTAMENTE IGUAL que en el script que me pegaste)

        // ... (pega aquí tus métodos btnIngresar_Click, btnLimpiar_Click, etc.) ...
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
                    using (SqlCommand checkCmd = new SqlCommand("SELECT COUNT(*) FROM Concepto WHERE nombre = @nombre", cnn))
                    {
                        checkCmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        if ((int)checkCmd.ExecuteScalar() > 0)
                        {
                            MessageBox.Show("Ya existe un concepto con ese nombre.", "Duplicado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }
                    }

                    using (SqlCommand cmd = new SqlCommand("sp_Concepto_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Tipo", cmbTipoConcepto.SelectedItem.ToString() == "PERCEPCION" ? "P" : "D");
                        cmd.Parameters.AddWithValue("@Metodo", cmbCuotaPorcentaje.SelectedItem.ToString() == "CUOTA" ? "F" : "%");
                        cmd.Parameters.AddWithValue("@EsProgramable", cmbFijo.SelectedItem.ToString() == "SI" ? 1 : 0);
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

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            CargarConceptos();
            ConfigurarEstado(true);
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtId.Text)) return;
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
                    using (SqlCommand cmd = new SqlCommand("sp_Concepto_Update", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        cmd.Parameters.AddWithValue("@idConcepto", Convert.ToInt32(txtId.Text));
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@Tipo", cmbTipoConcepto.SelectedItem.ToString() == "PERCEPCION" ? "P" : "D");
                        cmd.Parameters.AddWithValue("@Metodo", cmbCuotaPorcentaje.SelectedItem.ToString() == "CUOTA" ? "F" : "%");
                        cmd.Parameters.AddWithValue("@EsProgramable", cmbFijo.SelectedItem.ToString() == "SI" ? 1 : 0);
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

        /// <summary>
        /// --- ¡MÉTODO BLINDADO CONTRA NULLS Y CON NOMBRES CORREGIDOS! ---
        /// </summary>
        private void dgvConceptos_SelectionChanged(object sender, EventArgs e)
        {
            if (dgvConceptos.SelectedRows.Count > 0)
            {
                try
                {
                    DataGridViewRow row = dgvConceptos.SelectedRows[0];

                    // ¡¡AQUÍ ESTABA EL ERROR!!
                    // Usamos el 'Name' que definimos en ConfigurarGrid()
                    txtId.Text = row.Cells["idConcepto"].Value.ToString();
                    txtNombre.Text = row.Cells["nombre"].Value.ToString();

                    string tipo = row.Cells["Tipo"].Value.ToString();
                    cmbTipoConcepto.SelectedItem = (tipo == "P" ? "PERCEPCION" : "DEDUCCION");

                    bool esFijo = Convert.ToBoolean(row.Cells["EsProgramable"].Value);
                    cmbFijo.SelectedItem = (esFijo ? "SI" : "NO");

                    string metodo = row.Cells["Metodo"].Value.ToString();
                    if (metodo == "F")
                    {
                        cmbCuotaPorcentaje.SelectedItem = "CUOTA";
                        txtValor.Text = (row.Cells["cuota"].Value == DBNull.Value ? "0.00" : row.Cells["cuota"].Value.ToString());
                        lblValor.Text = "Cuota:";
                    }
                    else
                    {
                        cmbCuotaPorcentaje.SelectedItem = "PORCENTAJE";
                        txtValor.Text = (row.Cells["porcentaje"].Value == DBNull.Value ? "0.00" : row.Cells["porcentaje"].Value.ToString());
                        lblValor.Text = "Porcentaje:";
                    }

                    object fechaValor = row.Cells["fechaCreacion"].Value;
                    if (fechaValor != DBNull.Value && fechaValor != null)
                    {
                        dtpFechaCreacion.Value = Convert.ToDateTime(fechaValor);
                    }
                    else
                    {
                        dtpFechaCreacion.Value = DateTime.Now;
                    }

                    ConfigurarEstado(false);
                    btnActualizar.Enabled = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al leer la fila: " + ex.Message, "Error de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FormAgregarPercepciones_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form1.Show();
        }
    }
}