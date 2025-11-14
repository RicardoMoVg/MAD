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

        public class RenglonISR
        {
            public decimal LimiteInferior { get; set; }
            public decimal CuotaFija { get; set; }
            public decimal PorcentajeSobreExcedente { get; set; }
        }

        // Para guardar el resultado del cálculo de cada empleado
        public class ResultadoCalculo
        {
            // Datos de identificación
            public int NumEmpleado { get; set; }
            public string Nombre { get; set; }

            // Columnas del DataGridView
            public decimal Sueldo { get; set; }
            public decimal BonoProductividad { get; set; }
            public decimal BonoAsistencia { get; set; }
            public decimal BonoPuntualidad { get; set; }
            public decimal IMSS { get; set; }
            public decimal ISR { get; set; }
            public decimal Retenciones { get; set; }
            public decimal Despensa { get; set; } // La necesitamos para el cálculo

            // Totales (para el recibo)
            public decimal TotalPercepciones { get; set; }
            public decimal TotalDeducciones { get; set; }
        }
        public FormNomina()
        {
            InitializeComponent();
        }

        private void FormNomina_Load(object sender, EventArgs e)
        {
            ConfigurarDataGridView(); // ¡Llama al método CORREGIDO!
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
                case "Autorizado":
                    btnCalcular.Enabled = (estatusPeriodo == "Calculado");
                    btnAutorizar.Enabled = (estatusPeriodo == "Calculado");
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
                    using (SqlCommand cmd = new SqlCommand("sp_Empleados_GetLista_Vacia", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
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
                    using (SqlCommand cmd = new SqlCommand("sp_ProcesarNominaPeriodo", cnn))
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

        /// <summary>
        /// --- ¡¡AQUÍ ESTÁ LA CORRECCIÓN!! ---
        /// Se ha quitado 'Frozen = true' de la columna "NombreCompleto" Y
        /// Se ha añadido 'AutoSizeColumnsMode = None' al DataGridView.
        /// </summary>
        private void ConfigurarDataGridView()
        {
            dgvNomina.AutoGenerateColumns = false;
            dgvNomina.Columns.Clear();

            // --- ¡¡LA CORRECCIÓN DEL CRASH!! ---
            // Le decimos al grid que no intente ajustar todas las columnas
            dgvNomina.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // 1. CÓDIGO EMPLEADO
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "idEmpleado",
                HeaderText = "CÓDIGO EMPLEADO",
                DataPropertyName = "NumEmpleado",
                Frozen = true, // Inmoviliza esta columna (¡BIEN!)
                Width = 80
            });

            // 2. NOMBRE DEL EMPLEADO
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "NombreCompleto",
                HeaderText = "NOMBRE DEL EMPLEADO",
                DataPropertyName = "Nombre",
                AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill, // ¡BIEN!
                // Frozen = true, // <-- ¡ESTA LÍNEA CAUSABA EL ERROR!! (Eliminada)
                MinimumWidth = 200
            });

            // 3. SUELDO (Bruto)
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Sueldo",
                HeaderText = "SUELDO",
                DataPropertyName = "Sueldo",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 100
            });

            // 4. BONO DE PRODUCTIVIDAD
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BonoProductividad",
                HeaderText = "B. PRODUCTIVIDAD",
                DataPropertyName = "BonoProductividad",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 100
            });

            // 5. BONO DE ASISTENCIA
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BonoAsistencia",
                HeaderText = "B. ASISTENCIA",
                DataPropertyName = "BonoAsistencia",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 100
            });

            // 6. BONO DE PUNTUALIDAD
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "BonoPuntualidad",
                HeaderText = "B. PUNTUALIDAD",
                DataPropertyName = "BonoPuntualidad",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 100
            });

            // 7. IMSS
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "IMSS",
                HeaderText = "IMSS",
                DataPropertyName = "IMSS",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 100
            });

            // 8. ISR
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "ISR",
                HeaderText = "ISR",
                DataPropertyName = "ISR",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 100
            });

            // 9. RETENCIONES (FALTA-RETARDO)
            dgvNomina.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "Retenciones",
                HeaderText = "RETENCIONES",
                DataPropertyName = "Retenciones",
                DefaultCellStyle = new DataGridViewCellStyle { Format = "C2" },
                Width = 100
            });

            // (La columna Despensa no se agrega, cumpliendo con la lista)
        }

        private async void btnCalcular_Click(object sender, EventArgs e)
        {
            if (cmbPeriodo.SelectedValue == null) return;
            this.Cursor = Cursors.WaitCursor;
            btnCalcular.Enabled = false;
            btnAutorizar.Enabled = false;
            dgvNomina.DataSource = null;
            dtReporteNomina = null;

            // Preparamos el DataTable de salida. Las columnas deben
            // coincidir con el 'DataPropertyName' que pusiste en ConfigurarDataGridView()
            dtReporteNomina = new DataTable();
            dtReporteNomina.Columns.Add("NumEmpleado", typeof(int));
            dtReporteNomina.Columns.Add("Nombre", typeof(string));
            dtReporteNomina.Columns.Add("Sueldo", typeof(decimal));
            dtReporteNomina.Columns.Add("BonoProductividad", typeof(decimal));
            dtReporteNomina.Columns.Add("BonoAsistencia", typeof(decimal));
            dtReporteNomina.Columns.Add("BonoPuntualidad", typeof(decimal));
            dtReporteNomina.Columns.Add("IMSS", typeof(decimal));
            dtReporteNomina.Columns.Add("ISR", typeof(decimal));
            dtReporteNomina.Columns.Add("Retenciones", typeof(decimal));
            dtReporteNomina.Columns.Add("Despensa", typeof(decimal));
            dtReporteNomina.Columns.Add("TotalPercepciones", typeof(decimal));
            dtReporteNomina.Columns.Add("TotalDeducciones", typeof(decimal));
            // (Despensa no se añade porque no está en el grid)

            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_GetDatosParaCalculo", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDPeriodo", idPeriodoActual);

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        // Usamos Task.Run para no congelar la UI
                        await Task.Run(() =>
                        {
                            da.Fill(ds);
                        });
                    }
                }

                // 1. Extraer los datos del DataSet
                if (ds.Tables.Count < 4)
                    throw new Exception("El SP no devolvió todos los datos necesarios.");

                DataTable dtPeriodo = ds.Tables[0];
                DataTable dtEmpleados = ds.Tables[1];
                DataTable dtIncidencias = ds.Tables[2];
                DataTable dtTablaISR = ds.Tables[3];

                // 2. Extraer info del periodo
                int diasPeriodo = Convert.ToInt32(dtPeriodo.Rows[0]["DiasPeriodo"]);
                int diasMesReal = Convert.ToInt32(dtPeriodo.Rows[0]["DiasMesReal"]);

                // 3. Convertir la tabla ISR a una Lista (más fácil de usar)
                List<RenglonISR> tablaISR = dtTablaISR.AsEnumerable().Select(row => new RenglonISR
                {
                    LimiteInferior = row.Field<decimal>("LimiteInferior"),
                    CuotaFija = row.Field<decimal>("CuotaFija"),
                    PorcentajeSobreExcedente = row.Field<decimal>("PorcentajeSobreExcedente")
                }).ToList();

                // 4. Bucle de Cálculo (La magia en C#)
                foreach (DataRow empleado in dtEmpleados.Rows)
                {
                    // 5. Llamar a nuestro método de C#
                    ResultadoCalculo res = CalcularNominaEmpleado(empleado, idPeriodoActual, diasPeriodo, diasMesReal, dtIncidencias, tablaISR);

                    // 6. Añadir el resultado al DataTable de salida
                    dtReporteNomina.Rows.Add(
                        res.NumEmpleado,
                        res.Nombre,
                        res.Sueldo,
                        res.BonoProductividad,
                        res.BonoAsistencia,
                        res.BonoPuntualidad,
                        res.IMSS,
                        res.ISR,
                        res.Retenciones,
                        res.Despensa,
                        res.TotalPercepciones,
                        res.TotalDeducciones
                    );
                }

                // 7. Mostrar resultados
                dgvNomina.DataSource = dtReporteNomina;
                MessageBox.Show($"Nómina para el periodo {numPeriodo}-{anioPeriodo} calculada (en C#).", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // ¡OJO! ¡ESTO NO GUARDA EN LA BD!
                // Debemos habilitar Autorizar para que se pueda guardar.
                btnAutorizar.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la nómina en C#: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnCalcular.Enabled = true; // Dejamos recalcular
                this.Cursor = Cursors.Default;
            }
        }

        // --- REEMPLAZA TU btnAutorizar_Click CON ESTE ---

        private async void btnAutorizar_Click(object sender, EventArgs e)
        {
            // 1. Validaciones (¡Las tuyas estaban perfectas!)
            if (cmbPeriodo.SelectedValue == null) return;
            if (dtReporteNomina == null || dtReporteNomina.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos de nómina calculados para autorizar.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (MessageBox.Show($"¿Estás seguro de GUARDAR y AUTORIZAR el periodo {numPeriodo}-{anioPeriodo}?\n\n¡¡ACCION IRREVERSIBLE!!", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            this.Cursor = Cursors.WaitCursor;
            btnCalcular.Enabled = false;
            btnAutorizar.Enabled = false;

            // 2. Preparar el TVP (Tu lógica estaba perfecta)
            DataTable tvpData = dtReporteNomina.Copy();
            try
            {
                // Renombrar las columnas para que coincidan con el TVP 'dbo.NominaCalculadaTVP'
                tvpData.Columns["NumEmpleado"].ColumnName = "idEmpleado";
                tvpData.Columns["Retenciones"].ColumnName = "RetencionesFaltas";

                // Quitar columnas que no están en el TVP (como 'Nombre')
                tvpData.Columns.Remove("Nombre");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al preparar los datos para la BD (Mapeo de TVP): " + ex.Message);
                this.Cursor = Cursors.Default;
                btnCalcular.Enabled = true; // Re-habilitamos
                btnAutorizar.Enabled = true; // Re-habilitamos
                return;
            }


            // 3. LLAMADA AL DAL (Aquí está el cambio)
            try
            {
                // Ya no usamos 'using (SqlConnection...)' aquí.
                // Llamamos directamente a la capa de datos (DAL)
                // Usamos Task.Run para que la llamada a la BD no congele la UI

                bool seGeneroNuevoAnio = await Task.Run(() =>
                    dal.GuardarYAutorizarPeriodo(idPeriodoActual, tvpData)
                );

                // 4. INFORMAR EL RESULTADO (¡Lógica mejorada!)
                if (seGeneroNuevoAnio)
                {
                    // Mensaje especial si se generó el año
                    MessageBox.Show(
                        $"¡Período {numPeriodo}-{anioPeriodo} autorizado correctamente!\n\n" +
                        "Se detectó que este era el último período del año. " +
                        $"Se han generado automáticamente los períodos para el ejercicio {anioPeriodo + 1}.",
                        "Proceso Completado",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information
                    );
                }
                else
                {
                    // Mensaje normal
                    MessageBox.Show($"Periodo {numPeriodo}-{anioPeriodo} guardado y autorizado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                // 5. Recargar la lista de periodos (¡Perfecto!)
                CargarPeriodosDisponibles();
            }
            catch (Exception ex)
            {
                // El MessageBox de error ya se mostró en el DAL
                // Solo recargamos el combo para ver el estado actual
                CargarPeriodosDisponibles();
            }
            finally
            {
                // 6. Limpieza final
                this.Cursor = Cursors.Default;
                // Los botones se reactivarán (o no) cuando CargarPeriodosDisponibles()
                // llame al evento 'cmbPeriodo_SelectedIndexChanged'
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
            if (e.RowIndex < 0) return;
            if (estatusPeriodo == "Autorizado")
            {
                MessageBox.Show("No se pueden registrar incidencias en un periodo autorizado.", "Periodo Cerrado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idEmpleado = Convert.ToInt32(dgvNomina.Rows[e.RowIndex].Cells["idEmpleado"].Value);
            FormIncidencias formFaltas = new FormIncidencias(idEmpleado, idPeriodoActual);
            formFaltas.ShowDialog();

            if (estatusPeriodo == "Abierto")
            {
                CargarEmpleadosDelPeriodo(idPeriodoActual);
            }
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
                        if (dtEncabezado.Rows.Count == 0) { throw new Exception("No se encontraron datos del recibo. Asegúrese de que la nómina esté CALCULA."); }
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
                            tabla.AddCell(new PdfPCell(new iTextSharp.text.Phrase("", fontNormal)));
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

        /// <summary>
        /// Calcula el ISR basado en la lógica de la tabla
        /// </summary>
        private decimal CalcularISR(decimal baseGravable, List<RenglonISR> tablaISR)
        {
            if (baseGravable <= 0) return 0;

            // 1. Encontrar el renglón correcto
            RenglonISR renglon = tablaISR.Where(r => r.LimiteInferior <= baseGravable)
                                        .OrderByDescending(r => r.LimiteInferior)
                                        .FirstOrDefault();

            if (renglon == null) return 0; // No se encontró (o es negativo)

            // 2. Aplicar la fórmula
            decimal excedente = baseGravable - renglon.LimiteInferior;
            decimal impuestoMarginal = excedente * (renglon.PorcentajeSobreExcedente / 100.0m);
            decimal montoISR = impuestoMarginal + renglon.CuotaFija;

            return montoISR;
        }

        /// <summary>
        /// Éste es el reemplazo de 'sp_CalcularConceptos', pero en C#
        /// </summary>
        private ResultadoCalculo CalcularNominaEmpleado(DataRow empleado, int idPeriodo, int diasPeriodo, int diasMesReal, DataTable dtIncidencias, List<RenglonISR> tablaISR)
        {
            // --- 0. MAPA DE IDs ---
            int idFaltas = 8;
            int idRetraso = 9; // ¡Lo usaremos!

            // --- 1. DATOS INICIALES ---
            int idEmpleado = Convert.ToInt32(empleado["idEmpleado"]);
            decimal salarioDiario = Convert.ToDecimal(empleado["SalarioDiario"]);

            var resultado = new ResultadoCalculo
            {
                NumEmpleado = idEmpleado,
                Nombre = empleado["nombreCompleto"].ToString()
            };

            // --- 2. CÁLCULO DE INCIDENCIAS ---
            int conteoFaltas = dtIncidencias.AsEnumerable()
                .Count(row => row.Field<int>("idEmpleado") == idEmpleado &&
                                row.Field<int>("idConcepto") == idFaltas &&
                                row.Field<bool>("Justificada") == false);

            // (Lógica para retrasos, si la tuvieras)
            // int conteoRetrasos = dtIncidencias.AsEnumerable()...

            // --- 3. CÁLCULOS BASE ---
            decimal pagoMensual = salarioDiario * 30; // Regla: 30 días
            decimal sdi = salarioDiario * 1.0493m; // Regla: factor 1.0493
            int diasTrabajados = diasPeriodo - conteoFaltas;

            // --- 4. PERCEPCIONES ---
            decimal totalPercepciones = 0;

            // A. SUELDO
            resultado.Sueldo = pagoMensual;
            totalPercepciones += resultado.Sueldo;

            // B. BONO PUNTUALIDAD (6% Mensual)
            resultado.BonoPuntualidad = pagoMensual * 0.06m;
            if (conteoFaltas > 0)
                resultado.BonoPuntualidad = (resultado.BonoPuntualidad / 30) * diasTrabajados; // Prorrateo
            totalPercepciones += resultado.BonoPuntualidad;

            // C. DESPENSA (14% Mensual)
            resultado.Despensa = pagoMensual * 0.14m;
            totalPercepciones += resultado.Despensa;

            // D. BONO ASISTENCIA (10% Mensual)
            resultado.BonoAsistencia = pagoMensual * 0.10m;
            if (conteoFaltas > 0)
                resultado.BonoAsistencia = (resultado.BonoAsistencia / 30) * diasTrabajados; // Prorrateo
            totalPercepciones += resultado.BonoAsistencia;

            // E. BONO PRODUCTIVIDAD (8% Mensual, si falta NO se entrega)
            resultado.BonoProductividad = 0;
            if (conteoFaltas == 0)
            {
                resultado.BonoProductividad = pagoMensual * 0.08m;
                totalPercepciones += resultado.BonoProductividad;
            }

            resultado.TotalPercepciones = totalPercepciones;

            // --- 5. DEDUCCIONES ---
            decimal totalDeducciones = 0;

            // A. FALTAS (Regla compleja)
            if (conteoFaltas > 0)
            {
                int diasAjuste = diasPeriodo - diasMesReal;
                int diasDescuento = conteoFaltas + diasAjuste;
                if (diasDescuento < 0) diasDescuento = 0;

                decimal montoFaltas = salarioDiario * diasDescuento;
                if (montoFaltas > 0)
                {
                    resultado.Retenciones += montoFaltas; // Sumamos a retenciones
                    totalDeducciones += montoFaltas;
                }
            }

            resultado.IMSS = (sdi * 30) * 0.04m;
            totalDeducciones += resultado.IMSS;

            decimal baseGravable =
                resultado.Sueldo +
                resultado.BonoProductividad +
                resultado.BonoAsistencia +
                resultado.BonoPuntualidad - 
                resultado.IMSS;

            resultado.ISR = CalcularISR(baseGravable, tablaISR);
            totalDeducciones += resultado.ISR;

            resultado.TotalDeducciones = totalDeducciones;

            return resultado;
        }

        private class PeriodoInfo
        {
            public int NumPeriodo { get; set; }
            public int Anio { get; set; }
            public string Estatus { get; set; }
        }
    }
}