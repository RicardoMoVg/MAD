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
    public partial class FormCapturaDedPer : Form
    {
        private NominasDAL dal = new NominasDAL();
        private FormPrincipal _form1;

        public FormCapturaDedPer(FormPrincipal menu)
        {
            InitializeComponent();
            _form1 = menu;
            this.FormClosing += new FormClosingEventHandler(this.FormCapturaDedPer_FormClosing);
            this.dgvEmpleados.SelectionChanged += new System.EventHandler(this.dgvEmpleados_SelectionChanged);
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
        
        }

        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {

            ActualizarConceptosDelEmpleado();
        }

        private void FormCapturaDedPer_Load(object sender, EventArgs e)
        {
            ConfigurarGridEmpleados();
            CargarGridEmpleados();

        }

        #region Carga de Datos

        private void CargarConceptos(int idEmpleado, int mes, int anio)
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    
                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerCatalogoConceptosProgramables", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dtConceptos = new DataTable();
                        cnn.Open();
                        da.Fill(dtConceptos);

                        
                        dtConceptos.Columns.Add("NombreDisplay", typeof(string));
                        foreach (DataRow row in dtConceptos.Rows)
                        {
                            
                            row["NombreDisplay"] = $"{row["Tipo"].ToString().ToUpper()}: {row["nombre"]}";
                        }

                        lstConceptos.DataSource = dtConceptos;
                        lstConceptos.DisplayMember = "NombreDisplay";
                        lstConceptos.ValueMember = "idConcepto";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar conceptos: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lstConceptos.ClearSelected();
            }
        }

        private void CargarGridEmpleados()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerEmpleadosActivos", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dtEmpleados = new DataTable();
                        cnn.Open();
                        da.Fill(dtEmpleados);
                        dgvEmpleados.DataSource = dtEmpleados;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

       
        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if (dgvEmpleados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (lstConceptos.SelectedItems.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona al menos un concepto de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(txtCantidad.Text, out decimal monto) || monto <= 0)
            {
                MessageBox.Show("Por favor, ingresa un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                
                int idEmpleado = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["idEmpleado"].Value);
                string nombreEmpleado = dgvEmpleados.SelectedRows[0].Cells["nombreCompleto"].Value.ToString();
                DateTime fecha = dtpFecha.Value;

                using (SqlConnection cnn = dal.GetConnection())
                {
                    cnn.Open();

                    
                    foreach (object item in lstConceptos.SelectedItems)
                    {
                        DataRowView drv = (DataRowView)item;
                        int idConcepto = Convert.ToInt32(drv[lstConceptos.ValueMember]);

                        
                        using (SqlCommand cmdInsert = new SqlCommand("sp_InsertarConceptoProgramado", cnn))
                        {
                            cmdInsert.CommandType = CommandType.StoredProcedure;
                            cmdInsert.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                            cmdInsert.Parameters.AddWithValue("@idConcepto", idConcepto);
                            cmdInsert.Parameters.AddWithValue("@Mes", fecha.Month);
                            cmdInsert.Parameters.AddWithValue("@Anio", fecha.Year);
                            cmdInsert.Parameters.AddWithValue("@MontoFijo", monto);
                            cmdInsert.Parameters.AddWithValue("@Porcentaje", DBNull.Value);
                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }

                MessageBox.Show($"Se agregaron {lstConceptos.SelectedItems.Count} conceptos a {nombreEmpleado} para el periodo {fecha.Month}/{fecha.Year}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCantidad.Text = "1";
                lstConceptos.ClearSelected();
                dgvEmpleados.ClearSelection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de SQL al guardar el concepto: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error inesperado: {ex.Message}", "Error de Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #region Métodos de Configuración de Grid (Sin cambios)

        private void ConfigurarGridEmpleados()
        {
            dgvEmpleados.AutoGenerateColumns = false;
            dgvEmpleados.Columns.Clear();

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "idEmpleado",
                DataPropertyName = "idEmpleado",
                Visible = false
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombreCompleto",
                HeaderText = "Nombre Completo",
                DataPropertyName = "nombreCompleto", 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Departamento",
                HeaderText = "Departamento",
                DataPropertyName = "Departamento",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Puesto",
                HeaderText = "Puesto",
                DataPropertyName = "Puesto", 
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
        }

        #endregion

        private void FormCapturaDedPer_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form1.Show();
        }

        private void dgvEmpleados_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarConceptosDelEmpleado();
        }

        private void ActualizarConceptosDelEmpleado()
        {

            if (dgvEmpleados.SelectedRows.Count == 0)
            {

                lstConceptos.DataSource = null;
                return;
            }

            try
            {
                int idEmpleado = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["idEmpleado"].Value);
                DateTime fechaSeleccionada = dtpFecha.Value;
                int mes = fechaSeleccionada.Month;
                int anio = fechaSeleccionada.Year;
                CargarConceptos(idEmpleado, mes, anio);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar actualizar conceptos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}