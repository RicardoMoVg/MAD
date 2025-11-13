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
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace PIA_MAD_CalculodeNominas
{
    public partial class FormNomina : Form
    {
        private NominasDAL dal = new NominasDAL();
        private DataTable dtReporteNomina;

        private int idPeriodoActual;
        private int numPeriodo;
        private int anioPeriodo;
        private string estatusPeriodo;

        private Dictionary<int, PeriodoInfo> periodosCache = new Dictionary<int, PeriodoInfo>();

        public FormNomina()
        {
            InitializeComponent();
        }

        private void FormNomina_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView();
            CargarPeriodosDisponibles(true);
        }

        private void CargarPeriodosDisponibles(bool esCargaInicial = false)
        {
            object idSeleccionado = cmbPeriodo.SelectedValue;
            cmbPeriodo.DataSource = null;
            periodosCache.Clear();

            var dataSource = new List<object>();

            using (SqlConnection conn = dal.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_Periodos_GetParaCombo", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    try
                    {
                        conn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();
                        while (reader.Read())
                        {
                            int id = (int)reader["idPeriodo"];
                            string nombre = $"{reader["NumPeriodo"]} - {reader["Anio"]} ({reader["Estatus"]})";
                            periodosCache[id] = new PeriodoInfo
                            {
                                NumPeriodo = (int)reader["NumPeriodo"],
                                Anio = (int)reader["Anio"],
                                Estatus = reader["Estatus"].ToString()
                            };
                            dataSource.Add(new { Display = nombre, Value = id });
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error fatal al cargar lista de periodos: " + ex.Message);
                    }
                }
            }

            if (dataSource.Count > 0)
            {
                cmbPeriodo.DisplayMember = "Display";
                cmbPeriodo.ValueMember = "Value";
                cmbPeriodo.DataSource = dataSource;

                if (idSeleccionado != null)
                {
                    cmbPeriodo.SelectedValue = idSeleccionado;
                }
                else if (esCargaInicial)
                {
                    var primerAbierto = periodosCache.FirstOrDefault(p => p.Value.Estatus == "Abierto");
                    if (primerAbierto.Key != 0)
                        cmbPeriodo.SelectedValue = primerAbierto.Key;
                    else
                        cmbPeriodo.SelectedIndex = 0;
                }
            }
            else
            {
                MessageBox.Show("No se encontraron periodos en la base de datos.", "Error Crítico", MessageBoxButtons.OK, MessageBoxIcon.Error);
                btnCalcular.Enabled = false;
                btnAutorizar.Enabled = false;
                btnVerRecibo.Enabled = false;
                btnExportar.Enabled = false;
            }
        }

        private void cmbPeriodo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPeriodo.SelectedValue == null || !periodosCache.ContainsKey((int)cmbPeriodo.SelectedValue)) return;

            idPeriodoActual = (int)cmbPeriodo.SelectedValue;
            PeriodoInfo info = periodosCache[idPeriodoActual];
            estatusPeriodo = info.Estatus;
            numPeriodo = info.NumPeriodo;
            anioPeriodo = info.Anio;

            switch (estatusPeriodo)
            {
                case "Abierto":
                    btnCalcular.Enabled = true;
                    btnAutorizar.Enabled = false;
                    btnVerRecibo.Enabled = false;
                    btnExportar.Enabled = false;
                    CargarEmpleadosDelPeriodo(idPeriodoActual);
                    break;
                case "Calculado":
                    btnCalcular.Enabled = true;
                    btnAutorizar.Enabled = true;
                    btnVerRecibo.Enabled = true;
                    btnExportar.Enabled = true;
                    CargarNominaCalculada(idPeriodoActual);
                    break;
                case "Autorizado":
                    btnCalcular.Enabled = false;
                    btnAutorizar.Enabled = false;
                    btnVerRecibo.Enabled = true;
                    btnExportar.Enabled = true;
                    CargarNominaCalculada(idPeriodoActual);
                    break;
                default:
                    btnCalcular.Enabled = false;
                    btnAutorizar.Enabled = false;
                    btnVerRecibo.Enabled = false;
                    btnExportar.Enabled = false;
                    break;
            }
        }

        private async void CargarEmpleadosDelPeriodo(int idPeriodo)
        {
            this.Cursor = Cursors.WaitCursor;
            dgvNomina.DataSource = null;
            dtReporteNomina = null;

            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Empleados_GetListaParaCalculo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDPeriodo", idPeriodo);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dtReporteNomina = new DataTable();
                        await Task.Run(() =>
                        {
                            cnn.Open();
                            da.Fill(dtReporteNomina);
                        });
                        dgvNomina.DataSource = dtReporteNomina;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la lista de empleados: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void CargarNominaCalculada(int idPeriodo)
        {
            this.Cursor = Cursors.WaitCursor;
            dgvNomina.DataSource = null;
            dtReporteNomina = null;

            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_Nomina_GetCalculadaPorPeriodo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDPeriodo", idPeriodo);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dtReporteNomina = new DataTable();
                        await Task.Run(() =>
                        {
                            cnn.Open();
                            da.Fill(dtReporteNomina);
                        });
                        dgvNomina.DataSource = dtReporteNomina;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar la nómina pre-calculada: " + ex.Message);
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void ConfigurarDataGridView()
        {
            dgvNomina.AutoGenerateColumns = false;
            dgvNomina.Columns.Clear();
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn { Name = "idEmpleado", HeaderText = "No. Empleado", DataPropertyName = "NumEmpleado", Visible = true });
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn { Name = "NombreCompleto", HeaderText = "Nombre del Empleado", DataPropertyName = "Nombre", AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill });
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn { Name = "Fecha", HeaderText = "Fecha", DataPropertyName = "Fecha", DefaultCellStyle = new DataGridViewCellStyle { Format = "yyyy-MM-dd" } });
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn { Name = "SalarioNeto", HeaderText = "Sueldo Neto a Pagar", DataPropertyName = "NetoAPagar", DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" } });
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn { Name = "Banco", HeaderText = "Banco", DataPropertyName = "Banco" });

            // --- ¡¡¡AQUÍ ESTÁ LA CORRECCIÓN!!! ---
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn { Name = "CuentaBancaria", HeaderText = "Cuenta Bancaria", DataPropertyName = "Cuenta" });
        }

        private async void btnCalcular_Click(object sender, EventArgs e)
        {
            if (cmbPeriodo.SelectedValue == null) return;
            this.Cursor = Cursors.WaitCursor;
            btnCalcular.Enabled = false;
            btnAutorizar.Enabled = false;
            dgvNomina.DataSource = null;
            dtReporteNomina = null;

            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ProcesarNominaPeriodo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDPeriodo", idPeriodoActual);
                        cmd.CommandTimeout = 300;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        dtReporteNomina = new DataTable();
                        await Task.Run(() =>
                        {
                            cnn.Open();
                            da.Fill(dtReporteNomina);
                        });

                        dgvNomina.DataSource = dtReporteNomina;
                        MessageBox.Show($"Nómina para el periodo {numPeriodo}-{anioPeriodo} calculada.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarPeriodosDisponibles();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la nómina: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                CargarPeriodosDisponibles();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnAutorizar_Click(object sender, EventArgs e)
        {
            if (cmbPeriodo.SelectedValue == null) return;
            if (MessageBox.Show($"¿Estás seguro de autorizar el periodo {numPeriodo}-{anioPeriodo}?\n\n¡¡ACCION IRREVERSIBLE!!", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }
            this.Cursor = Cursors.WaitCursor;
            btnCalcular.Enabled = false;
            btnAutorizar.Enabled = false;

            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_AutorizarPeriodo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDPeriodoActual", idPeriodoActual);
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }
                MessageBox.Show($"Periodo {numPeriodo}-{anioPeriodo} autorizado y cerrado.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarPeriodosDisponibles();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al autorizar el periodo: " + ex.Message);
                CargarPeriodosDisponibles();
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void btnExportar_Click(object sender, EventArgs e)
        {
            if (dtReporteNomina == null || dtReporteNomina.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "CSV files (*.csv)|*.csv";
            sfd.Title = "Guardar Reporte de Nómina";
            sfd.FileName = $"Nomina_{numPeriodo}_{anioPeriodo}.csv";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    StringBuilder sb = new StringBuilder();
                    IEnumerable<string> headers = dtReporteNomina.Columns.Cast<DataColumn>().Select(col => col.ColumnName);
                    sb.AppendLine(string.Join(",", headers));
                    foreach (DataRow row in dtReporteNomina.Rows)
                    {
                        IEnumerable<string> fields = row.ItemArray.Select(field => field.ToString().Replace(",", ""));
                        sb.AppendLine(string.Join(",", fields));
                    }
                    System.IO.File.WriteAllText(sfd.FileName, sb.ToString(), Encoding.UTF8);
                    MessageBox.Show("Reporte exportado a CSV exitosamente.", "Exportación", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ocurrió un error al exportar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void dgvNomina_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            // 1. Asegurarnos de que no sea el encabezado
            if (e.RowIndex < 0) return;

            // 2. Solo podemos registrar incidencias si el periodo NO está cerrado
            if (estatusPeriodo == "Autorizado")
            {
                MessageBox.Show("No se pueden registrar incidencias en un periodo autorizado.", "Periodo Cerrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Obtener el ID del empleado de la fila
            int idEmpleado = Convert.ToInt32(dgvNomina.Rows[e.RowIndex].Cells["idEmpleado"].Value);

            // 4. ¡ABRIR EL ATAJO!
            // Creamos el formulario de Incidencias pasándole los IDs
            FormIncidencias formFaltas = new FormIncidencias(idEmpleado, idPeriodoActual);

            // Lo mostramos como un diálogo (obliga al usuario a cerrarlo)
            formFaltas.ShowDialog();

            // 5. Opcional: Refrescamos la lógica de botones
            cmbPeriodo_SelectedIndexChanged(sender, e);
        }


        private void btnVerRecibo_Click(object sender, EventArgs e)
        {
            if (dgvNomina.SelectedRows.Count == 0)
            {
                MessageBox.Show("Por favor, seleccione un empleado de la lista.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int idEmpleado = Convert.ToInt32(dgvNomina.SelectedRows[0].Cells["idEmpleado"].Value);
            string nombreEmpleado = dgvNomina.SelectedRows[0].Cells["NombreCompleto"].Value.ToString();

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF files (*.pdf)|*.pdf";
            sfd.Title = "Guardar Recibo de Nómina";
            sfd.FileName = $"Recibo_{nombreEmpleado.Replace(" ", "_")}_{numPeriodo}_{anioPeriodo}.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                this.Cursor = Cursors.WaitCursor;
                try
                {
                    DataTable dtEncabezado = new DataTable();
                    DataTable dtDetalle = new DataTable();
                    int idNomina = 0;
                    DataRow drEnc;

                    using (SqlConnection cnn = dal.GetConnection())
                    {
                        cnn.Open();
                        using (SqlCommand cmd = new SqlCommand("sp_ObtenerRecibo_Encabezado", cnn))
                        {
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                            cmd.Parameters.AddWithValue("@IDPeriodo", idPeriodoActual);
                            SqlDataAdapter da = new SqlDataAdapter(cmd);
                            da.Fill(dtEncabezado);
                        }

                        if (dtEncabezado.Rows.Count == 0)
                        {
                            throw new Exception("No se encontraron datos del recibo.");
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

                    // --- INICIO CÓDIGO PDF ---
                    iTextSharp.text.Document doc = new iTextSharp.text.Document(iTextSharp.text.PageSize.LETTER);
                    PdfWriter writer = PdfWriter.GetInstance(doc, new FileStream(sfd.FileName, FileMode.Create));
                    doc.Open();
                    iTextSharp.text.Font fontTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 18);
                    iTextSharp.text.Font fontSubTitulo = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);
                    iTextSharp.text.Font fontNormal = FontFactory.GetFont(FontFactory.HELVETICA, 10);
                    iTextSharp.text.Font fontBold = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 10);
                    doc.Add(new iTextSharp.text.Paragraph("Recibo de Nómina", fontTitulo) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                    doc.Add(new iTextSharp.text.Paragraph($"Periodo: {Convert.ToDateTime(drEnc["fechaInicio"]).ToString("dd/MM/yyyy")} - {Convert.ToDateTime(drEnc["fechaFin"]).ToString("dd/MM/yyyy")}", fontSubTitulo) { Alignment = iTextSharp.text.Element.ALIGN_CENTER });
                    doc.Add(iTextSharp.text.Chunk.NEWLINE);
                    doc.Add(new iTextSharp.text.Paragraph("Datos del Empleado", fontSubTitulo));
                    doc.Add(new iTextSharp.text.Paragraph($"No. Empleado: {drEnc["idEmpleado"]}", fontNormal));
                    doc.Add(new iTextSharp.text.Paragraph($"Nombre: {drEnc["nombreCompleto"]}", fontNormal));
                    doc.Add(new iTextSharp.text.Paragraph($"Puesto: {drEnc["Puesto"]}", fontNormal));
                    doc.Add(new iTextSharp.text.Paragraph($"RFC: {drEnc["RFC"]}   |   NSS: {drEnc["NSS"]}", fontNormal));
                    doc.Add(iTextSharp.text.Chunk.NEWLINE);
                    PdfPTable tabla = new PdfPTable(3);
                    tabla.WidthPercentage = 100;
                    tabla.SetWidths(new float[] { 50f, 25f, 25f });
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
                            decimal monto = row["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(row["Monto"]);
                            tabla.AddCell(new PdfPCell(new iTextSharp.text.Phrase(monto.ToString("C2"), fontNormal)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });
                            tabla.AddCell(new iTextSharp.text.Phrase("", fontNormal));
                            totalPercepciones += monto;
                        }
                        else
                        {
                            decimal monto = row["Monto"] == DBNull.Value ? 0 : Convert.ToDecimal(row["Monto"]);
                            tabla.AddCell(new iTextSharp.text.Phrase("", fontNormal));
                            tabla.AddCell(new PdfPCell(new iTextSharp.text.Phrase(monto.ToString("C2"), fontNormal)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });
                            totalDeducciones += monto;
                        }
                    }
                    tabla.AddCell(new PdfPCell(new iTextSharp.text.Phrase("TOTALES", fontBold)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });
                    tabla.AddCell(new PdfPCell(new iTextSharp.text.Phrase(totalPercepciones.ToString("C2"), fontBold)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });
                    tabla.AddCell(new PdfPCell(new iTextSharp.text.Phrase(totalDeducciones.ToString("C2"), fontBold)) { HorizontalAlignment = iTextSharp.text.Element.ALIGN_RIGHT });
                    doc.Add(tabla);
                    doc.Add(iTextSharp.text.Chunk.NEWLINE);
                    decimal neto = totalPercepciones - totalDeducciones;
                    doc.Add(new iTextSharp.text.Paragraph($"SUELDO NETO A PAGAR: {neto.ToString("C2")}", fontSubTitulo) { Alignment = iTextSharp.text.Element.ALIGN_RIGHT });
                    doc.Close();
                    writer.Close();
                    // --- FIN CÓDIGO PDF ---

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

        // Clase interna para el cache del ComboBox
        private class PeriodoInfo
        {
            public int NumPeriodo { get; set; }
            public int Anio { get; set; }
            public string Estatus { get; set; }
        }
    }
}