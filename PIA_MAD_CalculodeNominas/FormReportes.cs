using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PIA_MAD_CalculodeNominas
{
    public partial class FormReportes : Form
    {
        private NominasDAL dal = new NominasDAL();
        private DataTable dtReporteActual;

        public FormReportes()
        {
            InitializeComponent();
        }

        private void FormReportes_Load(object sender, EventArgs e)
        {
            // Ocultamos todos los filtros al iniciar
            MostrarPanelFiltros(null);
            // Llenamos los ComboBoxes que se reusan
            LlenarCombosGenerales();
        }

        /// <summary>
        /// Llena los ComboBoxes de Año y Departamento una sola vez al cargar.
        /// </summary>
        private void LlenarCombosGenerales()
        {
            // Llenar Años
            List<string> anios = ObtenerAniosDesdeBD();
            // Llenamos los 3 combos de año con los mismos datos
            cmbAnio_Gen.Items.AddRange(anios.ToArray());
            cmbAnio_HC.Items.AddRange(anios.ToArray());
            cmbAnio_Depto.Items.AddRange(anios.ToArray());

            // Llenar Departamentos
            List<string> deptos = ObtenerDepartamentos();
            cmbDepto_HC.Items.Add("Todos"); // Opción especial para este filtro
            cmbDepto_HC.Items.AddRange(deptos.ToArray());
            cmbDepto_HC.SelectedIndex = 0; // Inicia en "Todos"
        }

        /// <summary>
        /// Oculta todos los GroupBox de filtros y muestra solo el seleccionado.
        /// </summary>
        private void MostrarPanelFiltros(GroupBox panelAMostrar)
        {
            dgvReporte.DataSource = null; // Limpia el grid
            dtReporteActual = null; // Limpia los datos de exportación
            btnExportarCSV.Enabled = false;
            btnExportarPDF.Enabled = false;

            // Oculta todos los paneles de filtros
            gbFiltroGeneral.Visible = false;
            gbFiltroHeadcounter.Visible = false;
            gbFiltroNominaDepto.Visible = false;

            // Muestra solo el que queremos
            if (panelAMostrar != null)
            {
                panelAMostrar.Visible = true;
            }
        }

        #region Botones del Menú (Izquierda)

        private void btnReporteGeneral_Click(object sender, EventArgs e)
        {
            lblTituloReporte.Text = "Reporte General de Nómina";
            MostrarPanelFiltros(gbFiltroGeneral);
            // Llenamos el combo de mes (este es el único que lo usa así)
            cmbMes_Gen.Items.Clear();
            cmbMes_Gen.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            cmbMes_Gen.SelectedIndex = 0;
        }

        private void btnReporteHeadcounter_Click(object sender, EventArgs e)
        {
            lblTituloReporte.Text = "Reporte Headcounter";
            MostrarPanelFiltros(gbFiltroHeadcounter);
            // Llenamos el combo de mes
            cmbMes_HC.Items.Clear();
            cmbMes_HC.Items.AddRange(new string[] { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10", "11", "12" });
            cmbMes_HC.SelectedIndex = 0;
        }

        private void btnReporteNomina_Click(object sender, EventArgs e)
        {
            lblTituloReporte.Text = "Reporte de Nómina por Departamento";
            MostrarPanelFiltros(gbFiltroNominaDepto);
        }

        #endregion

        #region Botones de "Generar" (Dentro de los GroupBox)

        // Botón para Reporte General
        private void btnGenerar_Gen_Click(object sender, EventArgs e)
        {
            try
            {
                int mes = int.Parse(cmbMes_Gen.SelectedItem.ToString());
                int anio = int.Parse(cmbAnio_Gen.SelectedItem.ToString());

                dtReporteActual = EjecutarSP("sp_ReporteGeneralNomina",
                    new SqlParameter("@Mes", mes),
                    new SqlParameter("@Anio", anio));

                dgvReporte.DataSource = dtReporteActual;
                btnExportarCSV.Enabled = true;
                btnExportarPDF.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message);
            }
        }

        // Botón para Reporte Headcounter
        private void btnGenerar_HC_Click(object sender, EventArgs e)
        {
            try
            {
                int mes = int.Parse(cmbMes_HC.SelectedItem.ToString());
                int anio = int.Parse(cmbAnio_HC.SelectedItem.ToString());

                // Manejamos la opción "Todos"
                int? idDepto = null;
                if (cmbDepto_HC.SelectedItem.ToString() != "Todos")
                {
                    idDepto = ObtenerIdDepartamento(cmbDepto_HC.SelectedItem.ToString());
                }

                dtReporteActual = EjecutarSP("sp_ReporteHeadcounter",
                    new SqlParameter("@Mes", mes),
                    new SqlParameter("@Anio", anio),
                    new SqlParameter("@idDepartamento", idDepto ?? (object)DBNull.Value));

                dgvReporte.DataSource = dtReporteActual;
                btnExportarCSV.Enabled = true;
                btnExportarPDF.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message);
            }
        }

        // Botón para Reporte Nómina por Departamento
        private void btnGenerar_Depto_Click(object sender, EventArgs e)
        {
            try
            {
                int anio = int.Parse(cmbAnio_Depto.SelectedItem.ToString());

                dtReporteActual = EjecutarSP("sp_ReporteNominaPorDepartamento",
                    new SqlParameter("@Anio", anio));

                dgvReporte.DataSource = dtReporteActual;
                btnExportarCSV.Enabled = true;
                btnExportarPDF.Enabled = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar reporte: " + ex.Message);
            }
        }

        #endregion

        #region Métodos de Acceso a Datos (Usando DAL)

        // Método genérico para ejecutar SPs que devuelven una tabla
        private DataTable EjecutarSP(string nombreSP, params SqlParameter[] parametros)
        {
            DataTable dt = new DataTable();
            // ¡CORRECCIÓN! Usamos la clase DAL que ya funciona
            using (SqlConnection conn = dal.GetConnection())
            using (SqlCommand cmd = new SqlCommand(nombreSP, conn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddRange(parametros);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
            }
            return dt;
        }

        // Obtiene la lista de departamentos para el combo
        private List<string> ObtenerDepartamentos()
        {
            List<string> departamentos = new List<string>();
            // ¡CORRECCIÓN! Usamos la clase DAL que ya funciona
            using (SqlConnection conn = dal.GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT nombre FROM Departamento WHERE activo = 1", conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    departamentos.Add(reader.GetString(0));
                }
            }
            return departamentos;
        }

        // Obtiene el ID de un depto por su nombre
        private int ObtenerIdDepartamento(string nombreDepto)
        {
            // ¡CORRECCIÓN! Usamos la clase DAL que ya funciona
            using (SqlConnection conn = dal.GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT idDepartamento FROM Departamento WHERE nombre = @nombre", conn))
            {
                cmd.Parameters.AddWithValue("@nombre", nombreDepto);
                conn.Open();
                return (int)cmd.ExecuteScalar();
            }
        }

        // Obtiene los años donde hay nóminas
        private List<string> ObtenerAniosDesdeBD()
        {
            List<string> años = new List<string>();
            // ¡CORRECCIÓN! Usamos la clase DAL que ya funciona
            using (SqlConnection conn = dal.GetConnection())
            using (SqlCommand cmd = new SqlCommand("SELECT DISTINCT año FROM Nomina ORDER BY año", conn))
            {
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    años.Add(reader.GetInt32(0).ToString());
                }
            }
            // Si no hay nóminas, añade el año actual como opción
            if (años.Count == 0)
            {
                años.Add(DateTime.Now.Year.ToString());
            }
            return años;
        }

        #endregion

        #region Botones de Exportación

        private void btnExportarCSV_Click(object sender, EventArgs e)
        {
            if (dtReporteActual == null || dtReporteActual.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Archivo CSV (*.csv)|*.csv",
                FileName = $"{lblTituloReporte.Text.Replace(' ', '_')}.csv"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                using (StreamWriter sw = new StreamWriter(sfd.FileName))
                {
                    var headers = dtReporteActual.Columns.Cast<DataColumn>();
                    sw.WriteLine(string.Join(",", headers.Select(c => c.ColumnName)));

                    foreach (DataRow row in dtReporteActual.Rows)
                    {
                        var cells = row.ItemArray;
                        sw.WriteLine(string.Join(",", cells.Select(c => c.ToString().Replace(",", " "))));
                    }
                }
                MessageBox.Show("Archivo CSV exportado correctamente.");
            }
        }

        private void btnExportarPDF_Click(object sender, EventArgs e)
        {
            if (dtReporteActual == null || dtReporteActual.Rows.Count == 0)
            {
                MessageBox.Show("No hay datos para exportar.");
                return;
            }

            // --- ¡MEJORA 1: Mapeo de Nombres de Columna! ---
            // (Nombre de la BD  ->  Nombre amigable para el reporte)
            var headers = new Dictionary<string, string>
    {
        { "Departamento", "Departamento" },
        { "Puesto", "Puesto" },
        { "NombreEmpleado", "Nombre del Empleado" },
        { "FechaIngreso", "Fecha de Ingreso" },
        { "Edad", "Edad" },
        { "SalarioDiario", "Salario Diario" },
        { "CantidadEmpleados", "Cantidad de Empleados" },
        { "TotalEmpleados", "Total de Empleados" },
        { "año", "Año" },
        { "mes", "Mes" },
        { "SueldoBruto", "Sueldo Bruto" },
        { "SueldoNeto", "Sueldo Neto" }
        // ... (puedes agregar más si faltan)
    };

            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "Archivo PDF (*.pdf)|*.pdf",
                FileName = $"{lblTituloReporte.Text.Replace(' ', '_')}.pdf"
            };

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using (FileStream stream = new FileStream(sfd.FileName, FileMode.Create))
                    {
                        var doc = new Document(PageSize.A4.Rotate(), 10f, 10f, 10f, 0f); // Horizontal
                        var writer = PdfWriter.GetInstance(doc, stream);
                        doc.Open();

                        var fontTitulo = FontFactory.GetFont("Arial", 14, iTextSharp.text.Font.BOLD);
                        doc.Add(new Paragraph(lblTituloReporte.Text, fontTitulo));
                        doc.Add(new Paragraph(" "));

                        var table = new PdfPTable(dtReporteActual.Columns.Count);
                        table.WidthPercentage = 100;

                        // --- ¡MEJORA 2: Usar los Nombres Amigables! ---
                        foreach (DataColumn col in dtReporteActual.Columns)
                        {
                            // Busca el nombre amigable en el diccionario.
                            // Si no lo encuentra, usa el nombre de la BD como último recurso.
                            string headerText = headers.ContainsKey(col.ColumnName) ? headers[col.ColumnName] : col.ColumnName;

                            // (Opcional: Añadir fuente en negrita a los encabezados)
                            var fontHeader = FontFactory.GetFont("Arial", 10, iTextSharp.text.Font.BOLD);
                            table.AddCell(new Phrase(headerText, fontHeader));
                        }

                        // --- ¡MEJORA 3: Formatear los Datos! ---
                        foreach (DataRow row in dtReporteActual.Rows)
                        {
                            foreach (DataColumn col in dtReporteActual.Columns)
                            {
                                object cellValue = row[col];
                                string formattedValue = "";

                                // Formateo especial por tipo de dato
                                if (cellValue is DateTime)
                                {
                                    // Elimina la hora (12:00:00 a. m.)
                                    formattedValue = ((DateTime)cellValue).ToString("dd/MM/yyyy");
                                }
                                else if (cellValue is decimal)
                                {
                                    // Añade el formato de moneda
                                    formattedValue = ((decimal)cellValue).ToString("C2");
                                }
                                else
                                {
                                    // Valor por defecto
                                    formattedValue = cellValue?.ToString() ?? "";
                                }

                                table.AddCell(new Phrase(formattedValue));
                            }
                        }

                        doc.Add(table);
                        doc.Close();
                        writer.Close();
                    }
                    MessageBox.Show("Archivo PDF exportado correctamente.");
                }
                catch (Exception ex)
                {
                    // (Añadimos un Try-Catch que faltaba, por si el archivo está en uso)
                    MessageBox.Show($"Error al exportar PDF: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        #endregion

        private void pnlContenido_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}