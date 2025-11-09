using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// Nuevos Usings
using System.Data.SqlClient;
using System.Configuration;

namespace PIA_MAD_CalculodeNominas
{
    public partial class FormCapturaEspeciales : Form
    {
        // Variable para evitar que los eventos SelectedIndexChanged se disparen durante la carga
        private bool isLoading = true;

        public FormCapturaEspeciales()
        {
            InitializeComponent();
        }

        private void FormCapturaEspeciales_Load(object sender, EventArgs e)
        {
            isLoading = true;
            LlenarCombosFechas();
            LlenarComboEmpleados();
            LlenarComboConceptos();
            isLoading = false;

            // Carga inicial del DataGridView
            CargarConceptosProgramados();
        }

        private string GetConnectionString()
        {
            // Usamos el nombre que SÍ existe en tu App.config
            return ConfigurationManager.ConnectionStrings["db_preparatoria_hsr"].ConnectionString;
        }

        #region === Llenado de ComboBoxes ===

        private void LlenarCombosFechas()
        {
            // Llenar ComboBox de Meses
            string[] meses = {
                "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            };
            cmbMes.Items.AddRange(meses);
            cmbMes.SelectedIndex = DateTime.Now.Month - 1; // Mes actual

            // Llenar ComboBox de Años
            int anioActual = DateTime.Now.Year;
            for (int i = anioActual - 2; i <= anioActual + 2; i++)
            {
                cmbAnio.Items.Add(i);
            }
            cmbAnio.SelectedItem = anioActual; // Año actual
        }

        private void LlenarComboEmpleados()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    string query = "SELECT idEmpleado, nombreCompleto FROM dbo.Empleado WHERE activo = 1 ORDER BY nombreCompleto";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbEmpleado.DisplayMember = "nombreCompleto";
                    cmbEmpleado.ValueMember = "idEmpleado";
                    cmbEmpleado.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LlenarComboConceptos()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    // Usamos la nueva columna "EsProgramable"
                    string query = "SELECT idConcepto, nombre FROM dbo.Concepto WHERE activo = 1 AND EsProgramable = 1 ORDER BY nombre";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    cmbConcepto.DisplayMember = "nombre";
                    cmbConcepto.ValueMember = "idConcepto";
                    cmbConcepto.DataSource = dt;
                    cmbConcepto.SelectedIndex = -1; // Dejarlo sin selección
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar conceptos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region === Lógica del Formulario ===

        private void CargarConceptosProgramados()
        {
            // Si los combos no están listos (durante la carga), no hagas nada
            if (isLoading || cmbEmpleado.SelectedValue == null)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerConceptosProgramados", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idEmpleado", (int)cmbEmpleado.SelectedValue);
                        cmd.Parameters.AddWithValue("@Mes", cmbMes.SelectedIndex + 1);
                        cmd.Parameters.AddWithValue("@Anio", (int)cmbAnio.SelectedItem);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvConceptos.DataSource = dt;

                        // Ajustar columnas del DataGridView
                        if (dgvConceptos.Columns.Contains("ID"))
                            dgvConceptos.Columns["ID"].Width = 50;
                        if (dgvConceptos.Columns.Contains("Tipo"))
                            dgvConceptos.Columns["Tipo"].Width = 60;
                        if (dgvConceptos.Columns.Contains("MontoFijo"))
                            dgvConceptos.Columns["MontoFijo"].DefaultCellStyle.Format = "C2";
                        if (dgvConceptos.Columns.Contains("Porcentaje"))
                            dgvConceptos.Columns["Porcentaje"].DefaultCellStyle.Format = "N2";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar conceptos programados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Este evento se dispara si cambia el Empleado, Mes o Año
        private void Filtro_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarConceptosProgramados();
        }

        // Cambia la etiqueta del NumericUpDown
        private void rbTipoCalculo_CheckedChanged(object sender, EventArgs e)
        {
            if (rbMontoFijo.Checked)
            {
                lblValor.Text = "Monto Fijo ($):";
                numMonto.DecimalPlaces = 2;
                numMonto.Value = 0;
            }
            else if (rbPorcentaje.Checked)
            {
                lblValor.Text = "Porcentaje (%):";
                numMonto.DecimalPlaces = 2; // Mantener 2 para %
                numMonto.Value = 0;
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // --- Validaciones ---
            if (cmbEmpleado.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un empleado.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cmbConcepto.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un concepto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (numMonto.Value <= 0)
            {
                MessageBox.Show("El valor (monto o porcentaje) debe ser mayor a cero.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- Recolección de Datos ---
            try
            {
                int idEmpleado = (int)cmbEmpleado.SelectedValue;
                int idConcepto = (int)cmbConcepto.SelectedValue;
                int mes = cmbMes.SelectedIndex + 1;
                int anio = (int)cmbAnio.SelectedItem;

                decimal? montoFijo = null; // Nullable decimal
                decimal? porcentaje = null; // Nullable decimal

                if (rbMontoFijo.Checked)
                {
                    montoFijo = numMonto.Value;
                }
                else
                {
                    porcentaje = numMonto.Value;
                }

                // --- Guardado en BD ---
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    using (SqlCommand cmd = new SqlCommand("sp_InsertarConceptoProgramado", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        cmd.Parameters.AddWithValue("@idConcepto", idConcepto);
                        cmd.Parameters.AddWithValue("@Mes", mes);
                        cmd.Parameters.AddWithValue("@Anio", anio);

                        // Manejo de valores nulos
                        cmd.Parameters.AddWithValue("@MontoFijo", (object)montoFijo ?? DBNull.Value);
                        cmd.Parameters.AddWithValue("@Porcentaje", (object)porcentaje ?? DBNull.Value);

                        conn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Concepto programado guardado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // --- Actualizar y Limpiar ---
                CargarConceptosProgramados(); // Refresca el grid
                cmbConcepto.SelectedIndex = -1;
                numMonto.Value = 0;
                rbMontoFijo.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar el concepto: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion
    }
}