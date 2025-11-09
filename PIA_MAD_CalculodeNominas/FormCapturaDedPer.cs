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
        }

        private void FormCapturaDedPer_Load(object sender, EventArgs e)
        {
            // Configurar y cargar grid de empleados
            ConfigurarGridEmpleados();
            CargarGridEmpleados();

            // --- ¡NUEVO! Cargar el ListBox consolidado ---
            CargarConceptos();
        }

        #region Carga de Datos

        // --- ¡NUEVO! Método para cargar un único ListBox ---
        private void CargarConceptos()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    // Traemos todo y opcionalmente ordenamos por tipo
                    string query = "SELECT idConcepto, NombreConcepto, tipoConcepto FROM v_CatalogoConceptos ORDER BY tipoConcepto, NombreConcepto";

                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dtConceptos = new DataTable();
                        cnn.Open();
                        da.Fill(dtConceptos);

                        // --- Opcional: Crear una columna "Display" ---
                        // Para que se vea "PERCEPCION: Bono"
                        dtConceptos.Columns.Add("NombreDisplay", typeof(string));
                        foreach (DataRow row in dtConceptos.Rows)
                        {
                            row["NombreDisplay"] = $"{row["tipoConcepto"].ToString().ToUpper()}: {row["NombreConcepto"]}";
                        }

                        lstConceptos.DataSource = dtConceptos;
                        lstConceptos.DisplayMember = "NombreDisplay";  // <-- Mostrar el nombre combinado
                        lstConceptos.ValueMember = "idConcepto";       // <-- El ID oculto
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar conceptos: {ex.Message}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                lstConceptos.ClearSelected(); // Empezar sin nada seleccionado
            }
        }

        private void CargarGridEmpleados()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    string query = "SELECT idEmpleado, nombres, apellidoP, apellidoM, Departamento, Puesto FROM v_EmpleadosActivos";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dtEmpleados = new DataTable();
                        cnn.Open();
                        da.Fill(dtEmpleados);
                        dgvEmpleados.DataSource = dtEmpleados;
                    }
                }
            }
            catch (Exception ex) { MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }
            finally { this.Cursor = Cursors.Default; }
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
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Por favor, ingresa una cantidad válida (ej. 1).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- 2. Recolectar todos los conceptos seleccionados ---
            List<int> conceptosA_Agregar = new List<int>();

            foreach (object item in lstConceptos.SelectedItems)
            {
                DataRowView drv = (DataRowView)item;
                conceptosA_Agregar.Add(Convert.ToInt32(drv[lstConceptos.ValueMember]));
            }

            if (conceptosA_Agregar.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona al menos un concepto de la lista.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                // --- 3. Obtener Datos del Empleado y Nómina ---
                int idEmpleado = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["idEmpleado"].Value);
                string nombreEmpleado = dgvEmpleados.SelectedRows[0].Cells["nombres"].Value.ToString();
                DateTime fecha = dtpFecha.Value;
                int mes = fecha.Month;
                int anio = fecha.Year;
                int idNomina = 0;

                using (SqlConnection cnn = dal.GetConnection())
                {
                    cnn.Open();

                    // --- 4. Buscar o Crear el Encabezado de Nómina (se hace UNA vez) ---
                    string queryFindNomina = "SELECT idNomina FROM Nomina WHERE idEmpleado = @idEmp AND Mes = @Mes AND Anio = @Anio";
                    using (SqlCommand cmdFind = new SqlCommand(queryFindNomina, cnn))
                    {
                        cmdFind.Parameters.AddWithValue("@idEmp", idEmpleado);
                        cmdFind.Parameters.AddWithValue("@Mes", mes);
                        cmdFind.Parameters.AddWithValue("@Anio", anio);
                        object result = cmdFind.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            idNomina = Convert.ToInt32(result);
                        }
                    }

                    if (idNomina == 0)
                    {
                        string queryCreateNomina = "INSERT INTO Nomina (idEmpleado, Mes, Anio, FechaCreacion, Estatus) OUTPUT INSERTED.idNomina VALUES (@idEmp, @Mes, @Anio, @Fecha, 'PENDIENTE');";
                        using (SqlCommand cmdCreateNom = new SqlCommand(queryCreateNomina, cnn))
                        {
                            cmdCreateNom.Parameters.AddWithValue("@idEmp", idEmpleado);
                            cmdCreateNom.Parameters.AddWithValue("@Mes", mes);
                            cmdCreateNom.Parameters.AddWithValue("@Anio", anio);
                            cmdCreateNom.Parameters.AddWithValue("@Fecha", fecha);
                            idNomina = (int)cmdCreateNom.ExecuteScalar();
                        }
                    }

                    // --- 5. Insertar TODOS los detalles (se hace en BUCLE) ---
                    string queryCreateDetalle = "INSERT INTO DetalleNomina (idNomina, idConcepto, Cantidad, FechaCreacion) VALUES (@idNom, @idConc, @Cant, @Fecha)";

                    foreach (int idConcepto in conceptosA_Agregar)
                    {
                        using (SqlCommand cmdCreateDet = new SqlCommand(queryCreateDetalle, cnn))
                        {
                            cmdCreateDet.Parameters.AddWithValue("@idNom", idNomina);
                            cmdCreateDet.Parameters.AddWithValue("@idConc", idConcepto);
                            cmdCreateDet.Parameters.AddWithValue("@Cant", cantidad);
                            cmdCreateDet.Parameters.AddWithValue("@Fecha", fecha);
                            cmdCreateDet.ExecuteNonQuery();
                        }
                    }
                }

                // --- 6. Mensaje Final ---
                MessageBox.Show($"Se agregaron {conceptosA_Agregar.Count} conceptos a {nombreEmpleado} para el periodo {mes}/{anio}.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Limpiar selecciones
                txtCantidad.Text = "1";
                lstConceptos.ClearSelected();
                dgvEmpleados.ClearSelection();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de SQL al guardar los detalles: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { Name = "idEmpleado", DataPropertyName = "idEmpleado", Visible = false });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { Name = "nombres", HeaderText = "Nombres", DataPropertyName = "nombres", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { Name = "apellidoP", HeaderText = "Apellido Paterno", DataPropertyName = "apellidoP", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { Name = "apellidoM", HeaderText = "Apellido Materno", DataPropertyName = "apellidoM", AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { Name = "Departamento", HeaderText = "Departamento", DataPropertyName = "Departamento", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn { Name = "Puesto", HeaderText = "Puesto", DataPropertyName = "Puesto", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
        }

        #endregion

        private void FormCapturaDedPer_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form1.Show();
        }
    }
}