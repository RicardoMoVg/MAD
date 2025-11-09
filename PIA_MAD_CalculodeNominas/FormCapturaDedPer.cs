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
        // 1. Usamos la clase DAL, igual que en tu ejemplo
        private NominasDAL dal = new NominasDAL();

        // Variable para mantener la referencia al menú principal
        private FormPrincipal _form1;

        public FormCapturaDedPer(FormPrincipal menu)
        {
            InitializeComponent();
            _form1 = menu;
            this.FormClosing += new FormClosingEventHandler(this.FormCapturaDedPer_FormClosing);
        }

        private void FormCapturaDedPer_Load(object sender, EventArgs e)
        {
            // 2. Patrón de configuración y carga, igual que en tu ejemplo
            ConfigurarGridEmpleados();
            ConfigurarGridConceptos();
            CargarGridEmpleados();
            CargarGridConceptos();
        }

        #region Configuración de Grids (Estilo FormNomina)

        private void ConfigurarGridEmpleados()
        {
            dgvEmpleados.AutoGenerateColumns = false;
            dgvEmpleados.Columns.Clear();

            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "idEmpleado",
                DataPropertyName = "idEmpleado",
                Visible = false // Oculto
            });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "nombres",
                HeaderText = "Nombres",
                DataPropertyName = "nombres",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "apellidoP",
                HeaderText = "Apellido Paterno",
                DataPropertyName = "apellidoP",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "apellidoM",
                HeaderText = "Apellido Materno",
                DataPropertyName = "apellidoM",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Departamento",
                HeaderText = "Departamento",
                DataPropertyName = "Departamento",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvEmpleados.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Puesto",
                HeaderText = "Puesto",
                DataPropertyName = "Puesto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
        }

        private void ConfigurarGridConceptos()
        {
            dgvConceptos.AutoGenerateColumns = false;
            dgvConceptos.Columns.Clear();

            dgvConceptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "idConcepto",
                DataPropertyName = "idConcepto",
                Visible = false // Oculto
            });
            dgvConceptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreConcepto",
                HeaderText = "Nombre del Concepto",
                DataPropertyName = "NombreConcepto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });
            dgvConceptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "tipoConcepto",
                HeaderText = "Tipo",
                DataPropertyName = "tipoConcepto",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            dgvConceptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "cuota",
                HeaderText = "Cuota",
                DataPropertyName = "cuota",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
            dgvConceptos.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "porcentaje",
                HeaderText = "Porcentaje",
                DataPropertyName = "porcentaje",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "P0" }, // Formato Porcentaje
                AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells
            });
        }

        #endregion

        #region Carga de Datos (Estilo FormNomina)

        private void CargarGridEmpleados()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // Usamos la conexión de nuestra clase DAL
                using (SqlConnection cnn = dal.GetConnection())
                {
                    // Reemplazamos EnlaceDB.ObtenerEmpleadosActivos()
                    string query = "SELECT idEmpleado, nombres, apellidoP, apellidoM, Departamento, Puesto FROM v_EmpleadosActivos";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
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
                MessageBox.Show($"Error al cargar empleados: {ex.Message}", "Error de Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void CargarGridConceptos()
        {
            this.Cursor = Cursors.WaitCursor;
            try
            {
                // Usamos la conexión de nuestra clase DAL
                using (SqlConnection cnn = dal.GetConnection())
                {
                    // Reemplazamos EnlaceDB.ObtenerCatalogoConceptos()
                    string query = "SELECT idConcepto, NombreConcepto, tipoConcepto, cuota, porcentaje FROM v_CatalogoConceptos";
                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        cmd.CommandType = CommandType.Text;
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
                MessageBox.Show($"Error al cargar conceptos: {ex.Message}", "Error de Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        #endregion

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            // 1. Validar que haya selecciones
            if (dgvConceptos.SelectedRows.Count == 0 || dgvEmpleados.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, selecciona un concepto y un empleado.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Validar cantidad
            if (!int.TryParse(txtCantidad.Text, out int cantidad) || cantidad <= 0)
            {
                MessageBox.Show("Por favor, ingresa una cantidad válida (número entero mayor a 0).", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            this.Cursor = Cursors.WaitCursor;

            try
            {
                // 3. Obtener IDs y datos
                int idConcepto = Convert.ToInt32(dgvConceptos.SelectedRows[0].Cells["idConcepto"].Value);
                int idEmpleado = Convert.ToInt32(dgvEmpleados.SelectedRows[0].Cells["idEmpleado"].Value);
                DateTime fecha = dtpFecha.Value;
                int mes = fecha.Month;
                int anio = fecha.Year;

                // 4. Lógica de BD usando el patrón DAL
                using (SqlConnection cnn = dal.GetConnection())
                {
                    cnn.Open();
                    int idNomina = 0;

                    // --- Reemplazo de EnlaceDB.ObtenerIdNomina() ---
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

                    // --- Reemplazo de EnlaceDB.CrearNomina() ---
                    if (idNomina == 0)
                    {
                        string queryCreateNomina = "INSERT INTO Nomina (idEmpleado, Mes, Anio, FechaCreacion, Estatus) OUTPUT INSERTED.idNomina VALUES (@idEmp, @Mes, @Anio, @Fecha, 'PENDIENTE');";
                        using (SqlCommand cmdCreateNom = new SqlCommand(queryCreateNomina, cnn))
                        {
                            cmdCreateNom.Parameters.AddWithValue("@idEmp", idEmpleado);
                            cmdCreateNom.Parameters.AddWithValue("@Mes", mes);
                            cmdCreateNom.Parameters.AddWithValue("@Anio", anio);
                            cmdCreateNom.Parameters.AddWithValue("@Fecha", fecha); // Usamos la fecha de captura

                            idNomina = (int)cmdCreateNom.ExecuteScalar();
                        }
                    }

                    // --- Reemplazo de EnlaceDB.CrearDetalleNomina() ---
                    string queryCreateDetalle = "INSERT INTO DetalleNomina (idNomina, idConcepto, Cantidad, FechaCreacion) VALUES (@idNom, @idConc, @Cant, @Fecha)";
                    using (SqlCommand cmdCreateDet = new SqlCommand(queryCreateDetalle, cnn))
                    {
                        cmdCreateDet.Parameters.AddWithValue("@idNom", idNomina);
                        cmdCreateDet.Parameters.AddWithValue("@idConc", idConcepto);
                        cmdCreateDet.Parameters.AddWithValue("@Cant", cantidad);
                        cmdCreateDet.Parameters.AddWithValue("@Fecha", fecha);

                        cmdCreateDet.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Concepto agregado a la nómina del empleado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCantidad.Text = "1"; // Limpiar campo
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de SQL al guardar el detalle: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error de Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void FormCapturaDedPer_FormClosing(object sender, FormClosingEventArgs e)
        {
            _form1.Show();
        }
    }
}
