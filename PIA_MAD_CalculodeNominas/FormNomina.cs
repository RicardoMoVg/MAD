using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // Para conectar a SQL Server
using System.IO; // <-- AÑADE ESTE
using iTextSharp.text; // <-- Asegúrate de tener este
using iTextSharp.text.pdf;

namespace PIA_MAD_CalculodeNominas
{
    public partial class FormNomina : Form
    {
        // Usamos la clase DAL que ya existe en tu proyecto
        private NominasDAL dal = new NominasDAL();

        // Variable para guardar los datos del grid para exportar
        private DataTable dtReporteNomina;

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
            // Tu código para llenar cmbMes y cmbAnio está perfecto
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

        private void ConfigurarDataGridView()
        {
            // Este método define las columnas que coinciden con la salida
            // de nuestro SP maestro sp_ProcesarNominaMensual

            dgvNomina.AutoGenerateColumns = false;
            dgvNomina.Columns.Clear();

            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "idEmpleado",
                HeaderText = "No. Empleado",
                DataPropertyName = "NumEmpleado", // Mapea a la columna "NumEmpleado" del SP
                Visible = true // Lo hacemos visible
            });

            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreCompleto",
                HeaderText = "Nombre del Empleado",
                DataPropertyName = "Nombre", // Mapea a la columna "Nombre" del SP
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill
            });

            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "SalarioNeto",
                HeaderText = "Sueldo Neto a Pagar",
                DataPropertyName = "NetoAPagar", // Mapea a la columna "NetoAPagar" del SP
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } // Formato Moneda
            });

            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Banco",
                HeaderText = "Banco",
                DataPropertyName = "Banco" // Mapea a la columna "Banco" del SP
            });

            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "CuentaBancaria",
                HeaderText = "Cuenta Bancaria",
                DataPropertyName = "Cuenta" // Mapea a la columna "Cuenta" del SP
            });
        }

        // --- ¡¡ESTE ES EL CÓDIGO FINAL PARA CALCULAR!! ---
        // Llamamos al SP Maestro (sp_ProcesarNominaMensual)
        // --- ¡CAMBIO 1: Añade la palabra 'async' aquí! ---
        private async void btnCalcularNomina_Click(object sender, EventArgs e)
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
            btnCalcularNomina.Enabled = false; // Deshabilitar el botón mientras trabaja
            dgvNomina.DataSource = null;
            dtReporteNomina = null;

            try
            {
                // Usamos la conexión de nuestra clase DAL
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ProcesarNominaMensual", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Mes", mes);
                        cmd.Parameters.AddWithValue("@Anio", anio);
                        cmd.CommandTimeout = 300; // 5 minutos

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dtReporteNomina = new DataTable();

                        // --- ¡CAMBIO 2: Hacemos el trabajo pesado en un hilo separado! ---
                        // "await Task.Run" mueve el da.Fill a un hilo secundario,
                        // liberando el hilo de la UI y evitando el "Deadlock".
                        await Task.Run(() =>
                        {
                            cnn.Open();
                            da.Fill(dtReporteNomina); // Esta es la parte lenta
                        });

                        // --- (El código vuelve al hilo de la UI automáticamente) ---

                        // 4. Mostrar resultados en el grid
                        dgvNomina.DataSource = dtReporteNomina;

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
                btnCalcularNomina.Enabled = true; // Volver a habilitar el botón
            }
        }

        // --- (Tus métodos btnExportar_Click y btnVerRecibo_Click están bien, los dejas) ---
        private void btnExportar_Click(object sender, EventArgs e)
        {
            // ¡MEJORA! Usamos la variable dtReporteNomina en lugar de leer el grid.
            // Es más rápido y seguro.
            if (dtReporteNomina == null || dtReporteNomina.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar. Por favor, calcule la nómina primero.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            sfd.Title = "Guardar Reporte de Nómina";
            sfd.FileName = $"Nomina_{cmbMes.SelectedItem}_{cmbAnio.SelectedItem}.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();

                    // Encabezados
                    IEnumerable<string> headers = dtReporteNomina.Columns.Cast<DataColumn>().Select(col => col.ColumnName);
                    sb.AppendLine(string.Join(",", headers));

                    // Datos
                    foreach (DataRow row in dtReporteNomina.Rows)
                    {
                        IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString().Replace(",", ""));
                        sb.AppendLine(string.Join(",", fields));
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
            // --- 1. VALIDAR SELECCIÓN ---
            if (dgvNomina.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un empleado de la lista para ver su recibo.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- 2. OBTENER DATOS DE LA FILA Y COMBOS ---
            int idEmpleado = Convert.ToInt32(dgvNomina.SelectedRows[0].Cells["idEmpleado"].Value);
            string nombreEmpleado = dgvNomina.SelectedRows[0].Cells["NombreCompleto"].Value.ToString();
            int mes = cmbMes.SelectedIndex + 1;
            int anio = (int)cmbAnio.SelectedItem;

            // --- 3. MOSTRAR DIÁLOGO DE GUARDAR ---
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF files (*.pdf)|*.pdf";
            sfd.Title = "Guardar Recibo de Nómina";
            sfd.FileName = $"Recibo_{nombreEmpleado.Replace(" ", "_")}_{cmbMes.SelectedItem}_{anio}.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    // --- 4. OBTENER DATOS DEL RECIBO DESDE SQL ---
                    DataTable dtEncabezado = new DataTable();
                    DataTable dtDetalle = new DataTable();
                    int idNomina = 0;
                    DataRow drEnc; // Declarada aquí para que tenga alcance

                    using (SqlConnection cnn = dal.GetConnection())
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand("sp_ObtenerRecibo_Encabezado", cnn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                            cmd.Parameters.AddWithValue("@Mes", mes);
                            cmd.Parameters.AddWithValue("@Anio", anio);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dtEncabezado);
                        }

                        if (dtEncabezado.Rows.Count == 0)
                        {
                            throw new Exception("No se encontraron datos del recibo. Verifique que la nómina esté calculada y que el empleado tenga un puesto asignado.");
                        }

                        drEnc = dtEncabezado.Rows[0];
                        idNomina = Convert.ToInt32(drEnc["idNomina"]);

                        using (SqlCommand cmd = new SqlCommand("sp_ObtenerRecibo_Detalle", cnn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idNomina", idNomina);
                            cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dtDetalle);
                        }
                    }

                    // --- 5. CREAR EL DOCUMENTO PDF (SINTAXIS CORREGIDA) ---
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER);
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();

                    // --- CORRECCIÓN DE FUENTES ---
                    // Usamos FontFactory para evitar errores de sintaxis
                    iTextSharp.text.Font fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                    iTextSharp.text.Font fontSubTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                    iTextSharp.text.Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                    iTextSharp.text.Font fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);

                    // Título
                    doc.Add(new iTextSharp.text.Paragraph("Recibo de Nómina", fontTitulo) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                    doc.Add(new iTextSharp.text.Paragraph($"Periodo: {Convert.ToDateTime(drEnc["fechaInicio"]).ToString("dd/MM/yyyy")} - {Convert.ToDateTime(drEnc["fechaFin"]).ToString("dd/MM/yyyy")}", fontSubTitulo) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                    doc.Add(iTextSharp.text.Chunk.NEWLINE);

                    // Datos del Empleado
                    doc.Add(new iTextSharp.text.Paragraph("Datos del Empleado", fontSubTitulo));
                    doc.Add(new iTextSharp.text.Paragraph($"No. Empleado: {drEnc["idEmpleado"]}", fontNormal));
                    doc.Add(new iTextSharp.text.Paragraph($"Nombre: {drEnc["nombreCompleto"]}", fontNormal));
                    doc.Add(new iTextSharp.text.Paragraph($"Puesto: {drEnc["Puesto"]}", fontNormal));
                    doc.Add(new iTextSharp.text.Paragraph($"RFC: {drEnc["RFC"]}  |  NSS: {drEnc["NSS"]}", fontNormal));
                    doc.Add(iTextSharp.text.Chunk.NEWLINE);

                    // --- Tabla de Percepciones y Deducciones ---
                    PdfPTable tabla = new PdfPTable(3);
                    tabla.WidthPercentage = 100;
                    tabla.SetWidths(new float[] { 50f, 25f, 25f });

                    // Asignamos ese color
                    // --- DESPUÉS (CORREGIDO Y SIN COLOR) ---
                    // Simplemente añadimos las celdas sin la propiedad BackgroundColor
                    tabla.AddCell(new PdfPCell(new iTextSharp.text.Phrase("Concepto", fontBold)));
                    tabla.AddCell(new PdfPCell(new iTextSharp.text.Phrase("Percepciones", fontBold)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });
                    tabla.AddCell(new PdfPCell(new iTextSharp.text.Phrase("Deducciones", fontBold)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                    decimal totalPercepciones = 0;
                    decimal totalDeducciones = 0;

                    foreach (DataRow row in dtDetalle.Rows)
                    {
                        tabla.AddCell(new iTextSharp.text.Phrase(row["Concepto"].ToString(), fontNormal));
                        if (row["Tipo"].ToString() == "P")
                        {
                            decimal monto = Convert.ToDecimal(row["Monto"]);
                            tabla.AddCell(new PdfPCell(new iTextSharp.text.Phrase(monto.ToString("C2"), fontNormal)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });
                            tabla.AddCell(new iTextSharp.text.Phrase("", fontNormal));
                            totalPercepciones += monto;
                        }
                        else
                        {
                            decimal monto = Convert.ToDecimal(row["Monto"]);
                            tabla.AddCell(new iTextSharp.text.Phrase("", fontNormal));
                            tabla.AddCell(new PdfPCell(new iTextSharp.text.Phrase(monto.ToString("C2"), fontNormal)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });
                            totalDeducciones += monto;
                        }
                    }

                    // Fila de Totales
                    tabla.AddCell(new PdfPCell(new iTextSharp.text.Phrase("TOTALES", fontBold)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });
                    tabla.AddCell(new PdfPCell(new iTextSharp.text.Phrase(totalPercepciones.ToString("C2"), fontBold)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });
                    tabla.AddCell(new PdfPCell(new iTextSharp.text.Phrase(totalDeducciones.ToString("C2"), fontBold)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });

                    doc.Add(tabla);
                    doc.Add(iTextSharp.text.Chunk.NEWLINE);

                    // Neto a Pagar
                    decimal neto = totalPercepciones - totalDeducciones;
                    doc.Add(new iTextSharp.text.Paragraph($"SUELDO NETO A PAGAR: {neto.ToString("C2")}", fontSubTitulo) { Alignment = iTextSharp.text.Element.ALIGN_RIGHT });

                    doc.Close();
                    writer.Close();

                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Recibo PDF generado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    System.Diagnostics.Process.Start(sfd.FileName);
                }
                catch (Exception ex)
                {
                    this.Cursor = Cursors.Default;
                    MessageBox.Show("Ocurrió un error al generar el PDF: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        // --- (TODOS LOS MÉTODOS AYUDANTES COMO CalcularISR, ObtenerFaltas, etc. SE HAN ELIMINADO) ---
        // --- (Porque el SP 'sp_ProcesarNominaMensual' ya hace todo ese trabajo) ---
    }
}