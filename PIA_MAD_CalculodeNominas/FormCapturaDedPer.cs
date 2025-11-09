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

            // --- ¡AÑADE ESTA LÍNEA! ---
            // Asumiendo que tu DateTimePicker se llama 'dtpFecha'
            this.dtpFecha.ValueChanged += new System.EventHandler(this.dtpFecha_ValueChanged);
        }

        // --- ¡MÉTODO NUEVO! ---
        private void dtpFecha_ValueChanged(object sender, EventArgs e)
        {
            // Llama al mismo método de actualización
            ActualizarConceptosDelEmpleado();
        }

        private void FormCapturaDedPer_Load(object sender, EventArgs e)
        {
            // Configurar y cargar grid de empleados
            ConfigurarGridEmpleados();
            CargarGridEmpleados();

            // --- ¡NUEVO! Cargar el ListBox consolidado ---
            //CargarConceptos();
        }

        #region Carga de Datos

        // --- ¡NUEVO! Método para cargar un único ListBox ---
        private void CargarConceptos(int idEmpleado, int mes, int anio)
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    // --- ¡CORRECCIÓN! ---
                    // Llamamos al SP que SÍ existe y que trae los conceptos manuales/programables
                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerConceptosProgramados", cnn))
                    {
                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        cmd.Parameters.AddWithValue("@Mes", mes);
                        cmd.Parameters.AddWithValue("@Anio", anio);
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dtConceptos = new DataTable();
                        cnn.Open();
                        da.Fill(dtConceptos);

                        // Crear columna combinada para mostrar tipo + nombre
                        // (Asumiendo que el SP devuelve 'Tipo' y 'Nombre')
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

        // --- ¡LÓGICA PRINCIPAL SIMPLIFICADA! ---
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // --- 1. Validaciones ---
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
                // Asumo que txtCantidad ahora guarda el MONTO (ej. 500.00 de un préstamo)
                MessageBox.Show("Por favor, ingresa un monto válido.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                // --- 2. Recolectar Datos ---
                int idEmpleado = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["idEmpleado"].Value);
                string nombreEmpleado = dgvEmpleados.SelectedRows[0].Cells["nombreCompleto"].Value.ToString();
                DateTime fecha = dtpFecha.Value;

                using (SqlConnection cnn = dal.GetConnection())
                {
                    cnn.Open();

                    // --- 3. Insertar CADA concepto seleccionado ---
                    foreach (object item in lstConceptos.SelectedItems)
                    {
                        DataRowView drv = (DataRowView)item;
                        int idConcepto = Convert.ToInt32(drv[lstConceptos.ValueMember]);

                        // --- ¡CORRECCIÓN DE ARQUITECTURA! ---
                        // Llamamos al SP que SÍ existe para esto
                        using (SqlCommand cmdInsert = new SqlCommand("sp_InsertarConceptoProgramado", cnn))
                        {
                            cmdInsert.CommandType = CommandType.StoredProcedure;
                            cmdInsert.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                            cmdInsert.Parameters.AddWithValue("@idConcepto", idConcepto);
                            cmdInsert.Parameters.AddWithValue("@Mes", fecha.Month);
                            cmdInsert.Parameters.AddWithValue("@Anio", fecha.Year);
                            cmdInsert.Parameters.AddWithValue("@MontoFijo", monto);

                            // También enviamos un valor NULO para @Porcentaje,
                            // ya que el SP probablemente también lo espera.
                            cmdInsert.Parameters.AddWithValue("@Porcentaje", DBNull.Value);
                            // (Asumo que tu SP 'sp_InsertarConceptoProgramado' recibe estos 5 parámetros)

                            cmdInsert.ExecuteNonQuery();
                        }
                    }
                }

                // --- 4. Mensaje Final ---
                MessageBox.Show($"Se agregaron {lstConceptos.SelectedItems.Count} conceptos a {nombreEmpleado} para el periodo {fecha.Month}/{fecha.Year}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar selecciones
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

            // Columna Oculta
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "idEmpleado",
                DataPropertyName = "idEmpleado", // Coincide con la tabla
                Visible = false
            });

            // Columna de Nombre Completo
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombreCompleto",
                HeaderText = "Nombre Completo", // Título del grid
                DataPropertyName = "nombreCompleto", // Coincide con la tabla
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Columna de Departamento (Asume que tu SP la devuelve)
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Departamento",
                HeaderText = "Departamento",
                DataPropertyName = "Departamento", // Asume que el SP usa este alias
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });

            // Columna de Puesto (Asume que tu SP la devuelve)
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Puesto",
                HeaderText = "Puesto",
                DataPropertyName = "Puesto", // Asume que el SP usa este alias
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
        // --- ¡MÉTODO NUEVO! ---
        // Este método se llamará cada vez que cambie el empleado O la fecha
        private void ActualizarConceptosDelEmpleado()
        {
            // 1. Verifica si hay un empleado seleccionado
            if (dgvEmpleados.SelectedRows.Count == 0)
            {
                // No hay empleado, así que limpiamos la lista
                lstConceptos.DataSource = null;
                return;
            }

            // 2. Si hay un empleado, obtenemos todos los datos
            try
            {
                int idEmpleado = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["idEmpleado"].Value);
                DateTime fechaSeleccionada = dtpFecha.Value;
                int mes = fechaSeleccionada.Month;
                int anio = fechaSeleccionada.Year;

                // 3. Llamamos al método CargarConceptos con todos los datos
                CargarConceptos(idEmpleado, mes, anio);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar actualizar conceptos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}