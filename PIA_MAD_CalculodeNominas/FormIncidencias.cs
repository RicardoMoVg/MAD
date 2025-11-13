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
    public partial class FormIncidencias : Form
    {
        private NominasDAL dal = new NominasDAL();

        private int idEmpleadoPreseleccionado = 0;
        private int idPeriodoPreseleccionado = 0;

        public FormIncidencias(int idEmpleado = 0, int idPeriodo = 0)
        {
            InitializeComponent();
            this.idEmpleadoPreseleccionado = idEmpleado;
            this.idPeriodoPreseleccionado = idPeriodo;
        }

        private void FormIncidencias_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarPeriodosAbiertos();
            CargarConceptos();
            // AplicarSeguridad(); // Temporalmente deshabilitado para pruebas

            if (idEmpleadoPreseleccionado > 0)
            {
                cmbEmpleado.SelectedValue = idEmpleadoPreseleccionado;
            }
            if (idPeriodoPreseleccionado > 0)
            {
                cmbPeriodo.SelectedValue = idPeriodoPreseleccionado;
            }

            lblMonto.Visible = false;
            numMonto.Visible = false;
        }

        private void AplicarSeguridad()
        {
            if (SesionUsuario.Rol != "Admin")
            {
                btnRegistrarIncidencia.Enabled = false;
                btnEliminarIncidencia.Enabled = false; // ¡Nuevo!
                cmbEmpleado.Enabled = false;
                cmbPeriodo.Enabled = false;
                dtpFechaFalta.Enabled = false;
                cmbConcepto.Enabled = false;
                numMonto.Enabled = false;
            }
        }

        private void CargarEmpleados()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Empleados_GetCombo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbEmpleado.DataSource = dt;
                        cmbEmpleado.DisplayMember = "nombreCompleto";
                        cmbEmpleado.ValueMember = "idEmpleado";
                        if (idEmpleadoPreseleccionado == 0)
                            cmbEmpleado.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message);
            }
        }

        private void CargarPeriodosAbiertos()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Periodos_GetAbiertos", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbPeriodo.DataSource = dt;
                        cmbPeriodo.DisplayMember = "NombrePeriodo";
                        cmbPeriodo.ValueMember = "idPeriodo";
                        if (idPeriodoPreseleccionado == 0)
                            cmbPeriodo.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar periodos: " + ex.Message);
            }
        }

        private void CargarConceptos()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    string query = "SELECT idConcepto, nombre, Tipo FROM dbo.Concepto WHERE EsProgramable = 1 AND activo = 1";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        cmbConcepto.DataSource = dt;
                        cmbConcepto.DisplayMember = "nombre";
                        cmbConcepto.ValueMember = "idConcepto";
                        cmbConcepto.SelectedIndex = -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar conceptos: " + ex.Message);
            }
        }

        private void CargarIncidenciasDelPeriodo()
        {
            if (cmbPeriodo.SelectedItem == null)
            {
                dgvFaltasRegistradas.DataSource = null;
                return;
            }

            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Incidencias_GetByPeriodo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        DataRowView drv = (DataRowView)cmbPeriodo.SelectedItem;
                        int idPeriodo = Convert.ToInt32(drv["idPeriodo"]);
                        cmd.Parameters.AddWithValue("@IDPeriodo", idPeriodo);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvFaltasRegistradas.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar las incidencias del periodo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            CargarIncidenciasDelPeriodo();
        }

        private void btnRegistrarIncidencia_Click(object sender, EventArgs e)
        {
            if (cmbPeriodo.SelectedValue == null || cmbEmpleado.SelectedValue == null || cmbConcepto.SelectedValue == null)
            {
                MessageBox.Show("Debe seleccionar un periodo, un empleado y un concepto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (numMonto.Visible && numMonto.Value <= 0)
            {
                MessageBox.Show("Debe ingresar un monto mayor a cero para este concepto.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Incidencias_Insert", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idEmpleado", Convert.ToInt32(cmbEmpleado.SelectedValue));
                        cmd.Parameters.AddWithValue("@idPeriodo", Convert.ToInt32(cmbPeriodo.SelectedValue));
                        cmd.Parameters.AddWithValue("@idConcepto", Convert.ToInt32(cmbConcepto.SelectedValue));
                        cmd.Parameters.AddWithValue("@Fecha", dtpFechaFalta.Value);

                        if (!numMonto.Visible)
                        {
                            cmd.Parameters.AddWithValue("@Monto", DBNull.Value);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@Monto", numMonto.Value);
                        }

                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("¡Incidencia registrada con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarIncidenciasDelPeriodo();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error al registrar la incidencia:\n" + ex.Message, "Error de SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbConcepto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbConcepto.SelectedItem == null) return;

            DataRowView drv = (DataRowView)cmbConcepto.SelectedItem;
            string nombreConcepto = drv["nombre"].ToString();

            if (nombreConcepto.Equals("Faltas", StringComparison.OrdinalIgnoreCase) ||
                nombreConcepto.Equals("Retraso", StringComparison.OrdinalIgnoreCase))
            {
                lblMonto.Visible = false;
                numMonto.Visible = false;
                numMonto.Value = 0;
            }
            else
            {
                lblMonto.Visible = true;
                numMonto.Visible = true;
            }
        }

        /// <summary>
        /// ¡¡NUEVO!! Llama al SP para Eliminar la incidencia seleccionada.
        /// </summary>
        private void btnEliminarIncidencia_Click(object sender, EventArgs e)
        {
            // 1. Validar que haya una fila seleccionada
            if (dgvFaltasRegistradas.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione la incidencia que desea eliminar de la lista.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Confirmar con el usuario
            if (MessageBox.Show("¿Está seguro de que desea eliminar esta incidencia? Esta acción es irreversible.", "Confirmar Eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                // 3. Obtener el ID de la incidencia
                int idIncidencia = Convert.ToInt32(dgvFaltasRegistradas.SelectedRows[0].Cells["ID"].Value);

                // 4. Llamar al SP
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Incidencias_Delete", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idIncidencia", idIncidencia);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                // 5. Refrescar
                MessageBox.Show("Incidencia eliminada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarIncidenciasDelPeriodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar la incidencia: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}