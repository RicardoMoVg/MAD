using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// --- NUEVOS USINGS ---
using System.Data.SqlClient; // Para conectar a SQL Server
using System.Configuration; // Para leer el App.config

namespace PIA_MAD_CalculodeNominas
{
    public partial class FormNomina : Form
    {
        public FormNomina()
        {
            InitializeComponent();
            LlenarCombos();
            ConfigurarDataGridView(); // Modificaremos esta función
        }

        // Obtenemos la cadena de conexión desde App.config
        private string GetConnectionString()
        {
            return ConfigurationManager.ConnectionStrings["MiConexion"].ConnectionString;
        }

        private void LlenarCombos()
        {
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
        // Simplificamos las columnas para mostrar totales. El desglose
        // se verá en el "Recibo".
        private void ConfigurarDataGridView()
        {
            dgvNomina.Columns.Clear(); // Limpiamos las columnas viejas
            dgvNomina.Columns.Add("idEmpleado", "No. Empleado");
            dgvNomina.Columns.Add("NombreCompleto", "Nombre del Empleado");
            dgvNomina.Columns.Add("FechaPago", "Fecha de Pago");
            dgvNomina.Columns.Add("SalarioBruto", "Sueldo Bruto");
            dgvNomina.Columns.Add("TotalPercepciones", "Total Percepciones");
            dgvNomina.Columns.Add("TotalDeducciones", "Total Deducciones");
            dgvNomina.Columns.Add("SalarioNeto", "Sueldo Neto a Pagar");
            dgvNomina.Columns.Add("Banco", "Banco");
            dgvNomina.Columns.Add("CuentaBancaria", "Cuenta Bancaria");

            // Ocultamos el ID, pero lo necesitamos para "Ver Recibo"
            dgvNomina.Columns["idEmpleado"].Visible = false;

            // Formato de moneda
            dgvNomina.Columns["SalarioBruto"].DefaultCellStyle.Format = "C2";
            dgvNomina.Columns["TotalPercepciones"].DefaultCellStyle.Format = "C2";
            dgvNomina.Columns["TotalDeducciones"].DefaultCellStyle.Format = "C2";
            dgvNomina.Columns["SalarioNeto"].DefaultCellStyle.Format = "C2";
        }

        // --- MÉTODO MODIFICADO ---
        // ¡Aquí ocurre la magia! Reemplazamos la simulación
        // --- REEMPLAZA TU MÉTODO EXISTENTE CON ESTE ---

        private void btnCalcularNomina_Click(object sender, EventArgs e)
        {
            try
            {
                dgvNomina.Rows.Clear(); // Limpiamos datos anteriores

                // 1. OBTENER FECHA Y DATOS GLOBALES
                int mes = cmbMes.SelectedIndex + 1;
                int anio = (int)cmbAnio.SelectedItem;
                DateTime fechaCalculo = new DateTime(anio, mes, DateTime.DaysInMonth(anio, mes));

                // --- NUEVO: Cargamos la tabla de ISR en memoria ---
                CargarTablaISR(fechaCalculo);
                if (tablaISRGlobal.Count == 0)
                {
                    MessageBox.Show("Error fatal: No se pudo cargar la tabla de ISR.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // --- NUEVO: Obtenemos el Salario Mínimo (Asumimos Zona 'A' General) ---
                decimal salarioMinimo = ObtenerSalarioMinimo("A", fechaCalculo);

                // 2. OBTENER EMPLEADOS ACTIVOS
                DataTable empleados = ObtenerEmpleadosActivos();
                if (empleados.Rows.Count == 0)
                {
                    MessageBox.Show("No se encontraron empleados activos.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // 3. INICIAR CÁLCULO POR EMPLEADO
                foreach (DataRow empRow in empleados.Rows)
                {
                    // --- A. OBTENER DATOS BÁSICOS DEL EMPLEADO ---
                    int idEmpleado = Convert.ToInt32(empRow["idEmpleado"]);
                    string nombre = empRow["nombreCompleto"].ToString();
                    string banco = empRow["banco"].ToString();
                    string cuenta = empRow["numCuenta"].ToString();
                    DateTime fechaContratacion = Convert.ToDateTime(empRow["FechaContratacion"]);
                    decimal salarioDiario = ObtenerSalarioDiario(idEmpleado, fechaCalculo);

                    // --- B. CÁLCULO DE DÍAS A PAGAR ---
                    int diasDelMes = DateTime.DaysInMonth(anio, mes);
                    int diasBase = diasDelMes; // Días base para cálculo de bonos

                    // Prorrateo por contratación reciente
                    if (fechaContratacion.Year == anio && fechaContratacion.Month == mes)
                    {
                        diasBase = diasDelMes - fechaContratacion.Day + 1;
                    }
                    else if (fechaContratacion > fechaCalculo)
                    {
                        continue; // Empleado aún no contratado. Saltar.
                    }

                    // --- NUEVO: Obtenemos faltas ---
                    int numFaltas = ObtenerFaltas(idEmpleado, mes, anio);
                    int diasPagados = diasBase - numFaltas;
                    if (diasPagados < 0) diasPagados = 0;

                    // --- C. CÁLCULO DE PERCEPCIONES ---
                    decimal sueldoBrutoPagado = salarioDiario * diasPagados; // Esta es la percepción "Sueldo"
                    decimal sueldoMensualBase = salarioDiario * diasDelMes; // Base para bonos

                    // Bonos y Despensa
                    decimal bonoPuntualidad = sueldoMensualBase * 0.06m;
                    decimal bonoAsistencia = sueldoMensualBase * 0.10m;
                    decimal bonoProductividad = sueldoMensualBase * 0.08m;
                    decimal despensa = sueldoMensualBase * 0.14m;

                    // Reglas de Faltas para Bonos
                    if (numFaltas > 0)
                    {
                        // Regla: ((bono / 30) * días trabajados)
                        bonoPuntualidad = (bonoPuntualidad / diasDelMes) * diasPagados;
                        bonoAsistencia = (bonoAsistencia / diasDelMes) * diasPagados;
                        // Regla: "si tiene falta no se entrega"
                        bonoProductividad = 0;
                    }

                    // Percepciones Anuales (Aguinaldo y Prima Vac.)
                    decimal aguinaldo = 0;
                    if (mes == 12) // Aguinaldo solo en Diciembre
                    {
                        aguinaldo = salarioDiario * 25; // Regla: 25 días
                    }

                    decimal primaVacacional = 0;
                    int antiguedadAnios = anio - fechaContratacion.Year;
                    if (fechaContratacion.AddYears(antiguedadAnios) > fechaCalculo) antiguedadAnios--;

                    // Si su aniversario es ESTE MES y tiene al menos 1 año
                    if (fechaContratacion.Month == mes && antiguedadAnios > 0)
                    {
                        int diasVacaciones = ObtenerDiasVacaciones(antiguedadAnios);
                        primaVacacional = (salarioDiario * diasVacaciones) * 0.28m; // Regla: 28%
                    }

                    // Conceptos Especiales (Préstamos, Bonos únicos)
                    (decimal perEspeciales, decimal dedEspeciales) = ObtenerConceptosProgramados(idEmpleado, mes, anio, sueldoBrutoPagado);

                    // Suma Total de Percepciones (para el DGV)
                    decimal totalPercepciones = bonoPuntualidad + bonoAsistencia + bonoProductividad + despensa + aguinaldo + primaVacacional + perEspeciales;

                    // --- D. CÁLCULO DE DEDUCCIONES ---
                    decimal deduccionIMSS = 0;
                    decimal deduccionISR = 0;
                    bool esSalarioMinimo = (salarioDiario <= salarioMinimo);

                    if (!esSalarioMinimo)
                    {
                        // Cálculo IMSS
                        decimal sdi = salarioDiario * 1.0493m; // Salario Diario Integrado
                        deduccionIMSS = (sdi * diasDelMes) * 0.04m; // Regla: (SDI * días) * 4%

                        // Cálculo ISR
                        // La base gravable es todo lo que suma, menos lo que resta (IMSS)
                        decimal baseGravableISR = (sueldoBrutoPagado + totalPercepciones) - deduccionIMSS;
                        if (baseGravableISR < 0) baseGravableISR = 0;

                        deduccionISR = CalcularISR(baseGravableISR);
                    }

                    // Suma Total de Deducciones (para el DGV)
                    decimal totalDeducciones = deduccionIMSS + deduccionISR + dedEspeciales;

                    // --- E. CÁLCULO FINAL ---
                    decimal sueldoNeto = (sueldoBrutoPagado + totalPercepciones) - totalDeducciones;

                    // --- F. AGREGAR AL DATAGRIDVIEW ---
                    dgvNomina.Rows.Add(
                        idEmpleado,
                        nombre,
                        fechaCalculo.ToString("dd/MM/yyyy"),
                        sueldoBrutoPagado,     // Columna "Sueldo Bruto"
                        totalPercepciones, // Columna "Total Percepciones"
                        totalDeducciones,  // Columna "Total Deducciones"
                        sueldoNeto,        // Columna "Sueldo Neto a Pagar"
                        banco,
                        cuenta
                    );
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al calcular la nómina: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #region === MÉTODOS DE ACCESO A DATOS (NUEVOS) ===

        private DataTable ObtenerEmpleadosActivos()
        {
            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerEmpleadosActivos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    da.Fill(dt);
                }
            }
            return dt;
        }

        private decimal ObtenerSalarioDiario(int idEmpleado, DateTime fechaCalculo)
        {
            decimal salario = 0;
            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerSalarioDiario", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                    cmd.Parameters.AddWithValue("@fechaCalculo", fechaCalculo);

                    conn.Open();
                    object result = cmd.ExecuteScalar(); // ExecuteScalar es perfecto para un solo valor
                    if (result != null && result != DBNull.Value)
                    {
                        salario = Convert.ToDecimal(result);
                    }
                }
            }
            return salario;
        }

        private (decimal TotalPercepciones, decimal TotalDeducciones) CalcularPercepcionesDeducciones(int idEmpleado, decimal sueldoBruto)
        {
            decimal totalPer = 0;
            decimal totalDed = 0;

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_CalcularConceptos", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                    cmd.Parameters.AddWithValue("@SueldoBruto", sueldoBruto);

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            totalPer = Convert.ToDecimal(reader["TotalPercepciones"]);
                            totalDed = Convert.ToDecimal(reader["TotalDeducciones"]);
                        }
                    }
                }
            }
            return (totalPer, totalDed); // Retorna una tupla con los dos valores
        }

        #endregion

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
                                cells.Add(cell.Value.ToString().Replace(",", "")); // Quitar comas para CSV
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

                // Aquí abrirías un nuevo formulario para el recibo
                MessageBox.Show($"Simulando generación de recibo para el Empleado ID: {idEmpleado}");

                // (Próximo paso)
                // FormRecibo recibo = new FormRecibo(idEmpleado, (int)cmbAnio.SelectedItem, cmbMes.SelectedIndex + 1);
                // recibo.ShowDialog();
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado de la lista para ver su recibo.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void FormNomina_Load(object sender, EventArgs e)
        {

        }

        // --- Pega esto dentro de tu clase FormNomina.cs ---

        // Variable global en el formulario para guardar la tabla de ISR y no leerla mil veces
        private List<RenglonISR> tablaISRGlobal = new List<RenglonISR>();

        /// <summary>
        /// Carga la tabla de ISR desde la BD y la guarda en la variable global.
        /// Debes llamar esto ANTES de empezar a calcular la nómina.
        /// </summary>
        private void CargarTablaISR(DateTime fechaCalculo)
        {
            tablaISRGlobal.Clear(); // Limpia datos anteriores

            using (SqlConnection conn = new SqlConnection(GetConnectionString()))
            {
                using (SqlCommand cmd = new SqlCommand("sp_ObtenerTablaISR", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    // Usamos el primer día del mes para asegurar la vigencia
                    cmd.Parameters.AddWithValue("@Vigencia", new DateTime(fechaCalculo.Year, fechaCalculo.Month, 1));

                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            tablaISRGlobal.Add(new RenglonISR
                            {
                                LimiteInferior = Convert.ToDecimal(reader["LimiteInferior"]),
                                CuotaFija = Convert.ToDecimal(reader["CuotaFija"]),
                                PorcentajeSobreExcedente = Convert.ToDecimal(reader["PorcentajeSobreExcedente"])
                            });
                        }
                    }
                }
            }

            // Es vital que la tabla esté ordenada de Menor a Mayor Límite Inferior
            tablaISRGlobal = tablaISRGlobal.OrderBy(r => r.LimiteInferior).ToList();
        }


        /// <summary>
        /// Calcula el ISR basado en la tabla progresiva.
        /// </summary>
        /// <param name="baseGravable">Es el Sueldo Bruto MENOS las deducciones que no juegan para ISR (como IMSS)</param>
        /// <returns>El impuesto a retener</returns>
        private decimal CalcularISR(decimal baseGravable)
        {
            if (tablaISRGlobal.Count == 0)
            {
                // Error: La tabla no se cargó
                throw new Exception("La tabla de ISR no se ha cargado en memoria.");
            }

            // 1. Encontrar el renglón (nivel) correcto en la tabla
            // Buscamos el último renglón donde la base gravable sea MAYOR al límite inferior
            RenglonISR renglon = tablaISRGlobal
                .Where(r => baseGravable >= r.LimiteInferior)
                .OrderByDescending(r => r.LimiteInferior)
                .FirstOrDefault();

            if (renglon == null)
            {
                // Esto pasa si la base gravable es 0 o negativa
                return 0;
            }

            // 2. Aplicar la fórmula de la tabla
            // (Base Gravable - Límite Inferior) * (% Sobre Excedente) + Cuota Fija

            // (Paso 1: Base - Límite Inferior)
            decimal excedente = baseGravable - renglon.LimiteInferior;

            // (Paso 2: ... * Porcentaje)
            // (Dividimos entre 100 porque en la BD está como 6.40, 10.88, etc.)
            decimal impuestoMarginal = excedente * (renglon.PorcentajeSobreExcedente / 100.0m);

            // (Paso 3: ... + Cuota Fija)
            decimal impuestoTotal = impuestoMarginal + renglon.CuotaFija;

            return impuestoTotal;
        }

        // --- REEMPLAZA ESTAS 4 FUNCIONES EN FormNomina.cs ---

        private decimal ObtenerSalarioMinimo(string zona, DateTime fecha)
        {
            decimal monto = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    // MODIFICADO: Llama al Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerSalarioMinimo", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // <- Importante
                        cmd.Parameters.AddWithValue("@Zona", zona);
                        cmd.Parameters.AddWithValue("@Fecha", fecha);
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            monto = Convert.ToDecimal(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener Salario Mínimo: " + ex.Message);
            }
            return monto;
        }

        private int ObtenerFaltas(int idEmpleado, int mes, int anio)
        {
            int faltas = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    // MODIFICADO: Llama al Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerFaltas", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // <- Importante
                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        cmd.Parameters.AddWithValue("@Mes", mes);
                        cmd.Parameters.AddWithValue("@Anio", anio);
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            faltas = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener Faltas: " + ex.Message);
            }
            return faltas;
        }

        private int ObtenerDiasVacaciones(int antiguedadEnAnios)
        {
            int dias = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    // MODIFICADO: Llama al Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerDiasVacaciones", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // <- Importante
                        cmd.Parameters.AddWithValue("@Antiguedad", antiguedadEnAnios);
                        conn.Open();
                        object result = cmd.ExecuteScalar();
                        if (result != null && result != DBNull.Value)
                        {
                            dias = Convert.ToInt32(result);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener días de vacaciones: " + ex.Message);
            }
            return dias;
        }

        private (decimal totalPer, decimal totalDed) ObtenerConceptosProgramados(int idEmpleado, int mes, int anio, decimal sueldoBruto)
        {
            decimal totalPer = 0;
            decimal totalDed = 0;

            try
            {
                using (SqlConnection conn = new SqlConnection(GetConnectionString()))
                {
                    // MODIFICADO: Llama al Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("sp_ObtenerDetalleConceptosProgramados", conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure; // <- Importante
                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        cmd.Parameters.AddWithValue("@Mes", mes);
                        cmd.Parameters.AddWithValue("@Anio", anio);

                        conn.Open();
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tipo = reader["Tipo"].ToString();
                                decimal montoFijo = reader["MontoFijo"] != DBNull.Value ? Convert.ToDecimal(reader["MontoFijo"]) : 0;
                                decimal porcentaje = reader["Porcentaje"] != DBNull.Value ? Convert.ToDecimal(reader["Porcentaje"]) : 0;

                                decimal montoCalculado = montoFijo + (sueldoBruto * (porcentaje / 100.0m));

                                if (tipo == "P")
                                {
                                    totalPer += montoCalculado;
                                }
                                else if (tipo == "D")
                                {
                                    totalDed += montoCalculado;
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al obtener conceptos programados: " + ex.Message);
            }

            return (totalPer, totalDed);
        }

    }
}
