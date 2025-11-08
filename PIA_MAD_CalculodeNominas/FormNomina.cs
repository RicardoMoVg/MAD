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
    public partial class FormNomina : Form
    {
        // Usamos la clase DAL que ya existe en tu proyecto
        private NominasDAL dal = new NominasDAL();

        public FormNomina()
        {
            InitializeComponent();
        }

        private void FormNomina_Load(object sender, EventArgs e)
        {
            LlenarCombos();
            ConfigurarDataGridView(); // Configuramos el grid al cargar
        }

        private void LlenarCombos()
        {
            // (Tu código para llenar cmbMes y cmbAnio está perfecto)
            string[] meses = {
                "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            };
            cmbMes.Items.AddRange(meses);
            cmbMes.SelectedIndex = DateTime.Now.Month - 1;

            int anioActual = DateTime.Now.Year;
            for (int i = anioActual - 5; i <= anioActual + 5; i++)
            {
                cmbAnio.Items.Add(i);
            }
            cmbAnio.SelectedItem = anioActual;
        }

        // --- MÉTODO MODIFICADO ---
        // Aquí le decimos al DataGridView cómo "mapear" los resultados
        // que devuelve tu SP maestro (sp_ProcesarNominaMensual)
        private void ConfigurarDataGridView()
        {
            dgvNomina.AutoGenerateColumns = false; // ¡Importante! Controlamos las columnas
            dgvNomina.Columns.Clear();

            // Columna 1: ID (Oculta)
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "idEmpleado",
                HeaderText = "No. Empleado",
                DataPropertyName = "NumEmpleado", // Mapea a la columna "NumEmpleado" del SP
                Visible = false
            });

            // Columna 2: Nombre
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreCompleto",
                HeaderText = "Nombre del Empleado",
                DataPropertyName = "Nombre", // Mapea a la columna "Nombre" del SP
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            // Columna 3: Neto a Pagar
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SalarioNeto",
                HeaderText = "Sueldo Neto a Pagar",
                DataPropertyName = "NetoAPagar", // Mapea a la columna "NetoAPagar" del SP
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } // Formato Moneda
            });

            // Columna 4: Banco
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Banco",
                HeaderText = "Banco",
                DataPropertyName = "Banco" // Mapea a la columna "Banco" del SP
            });

            // Columna 5: Cuenta
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CuentaBancaria",
                HeaderText = "Cuenta Bancaria",
                DataPropertyName = "Cuenta" // Mapea a la columna "Cuenta" del SP
            });
        }

        // --- ¡¡ESTE ES EL CÓDIGO FINAL PARA CALCULAR!! ---
        // Llamamos al SP Maestro (sp_ProcesarNominaMensual)
        private void btnCalcularNomina_Click(object sender, EventArgs e)
        {
            // 1. Validar entradas
            if (cmbMes.SelectedItem == null || cmbAnio.SelectedItem == null)
            {
                MessageBox.Show("Por favor, seleccione un mes y un año.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int mes = cmbMes.SelectedIndex + 1;
            int anio = (int)cmbAnio.SelectedItem;

            this.Cursor = Cursors.WaitCursor; // Poner cursor de espera
            dgvNomina.DataSource = null; // Limpiar datos viejos

            try
            {
                // Usamos la conexión de nuestra clase DAL
                using (SqlConnection cnn = dal.GetConnection())
                {
                    // 2. Llamar al SP MAESTRO
                    using (SqlCommand cmd = new SqlCommand("sp_ProcesarNominaMensual", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Mes", mes);
                        cmd.Parameters.AddWithValue("@Anio", anio);

                        // ¡Importante! Darle más tiempo al SP para que trabaje.
                        // El cálculo de N empleados puede tardar más de 30 seg.
                        cmd.CommandTimeout = 300; // 5 minutos

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dtReporte = new DataTable();

                        cnn.Open();
                        da.Fill(dtReporte); // El SP devuelve la tabla del reporte final

                        // 4. Mostrar resultados en el grid
                        dgvNomina.DataSource = dtReporte;

                        MessageBox.Show($"Nómina para {cmbMes.SelectedItem} {anio} calculada y guardada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de SQL al procesar la nómina: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error de Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                this.Cursor = Cursors.Default; // Devolver el cursor a la normalidad
            }
        }

        // --- (Tus métodos btnExportar_Click y btnVerRecibo_Click están bien, los dejas) ---
        private void btnExportar_Click(object sender, EventArgs e)
        {
            // Lógica para exportar el DataGridView a un archivo CSV
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            sfd.Title = "Guardar Reporte de Nómina";
            sfd.FileName = $"Nomina_{cmbMes.SelectedItem}_{cmbAnio.SelectedItem}.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    // Encabezados (usando las columnas visibles)
                    List<string> headers = new List<string>();
                    foreach (DataGridViewColumn col in dgvNomina.Columns)
                    {
                        if (col.Visible)
                        {
                            headers.Add(col.HeaderText);
                        }
                    }
                    sb.AppendLine(string.Join(",", headers));

                    // Datos
                    foreach (DataGridViewRow row in dgvNomina.Rows)
                    {
                        List<string> cells = new List<string>();
                        foreach (DataGridViewCell cell in row.Cells)
                        {
                            if (dgvNomina.Columns[cell.ColumnIndex].Visible)
                            {
                                // Asegurarse de que el valor no sea nulo antes de llamar a ToString
                                string cellValue = cell.Value != null ? cell.Value.ToString() : "";
                                cells.Add(cellValue.Replace(",", "")); // Quitar comas para CSV
                            }
                        }
                        sb.AppendLine(string.Join(",", cells));
                    }

                    // Escribir el archivo
                    System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);

                    MessageBox.Show("Reporte exportado a CSV exitosamente.", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnVerRecibo_Click(object sender, EventArgs e)
        {
            if (dgvNomina.SelectedRows.Count > 0)
            {
                // Obtenemos el ID del empleado de la fila oculta
                int idEmpleado = Convert.ToInt32(dgvNomina.SelectedRows[0].Cells["idEmpleado"].Value);

                MessageBox.Show($"Simulando generación de recibo para el Empleado ID: {idEmpleado}");
                // (Aquí abrirías tu formulario de recibo)
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado de la lista para ver su recibo.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}