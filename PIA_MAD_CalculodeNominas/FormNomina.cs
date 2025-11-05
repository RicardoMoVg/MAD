using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA_MAD_CalculodeNominas
{
    public partial class FormNomina : Form
    {
        public FormNomina()
        {
            InitializeComponent();
            LlenarCombos();
            ConfigurarDataGridView();
        }

        private void LlenarCombos()
        {
            // Llenar ComboBox de Meses
            string[] meses = {
                "Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio",
                "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"
            };
            cmbMes.Items.AddRange(meses);
            cmbMes.SelectedIndex = DateTime.Now.Month - 1; // Selecciona el mes actual

            // Llenar ComboBox de Años
            int anioActual = DateTime.Now.Year;
            for (int i = anioActual - 5; i <= anioActual + 5; i++)
            {
                cmbAnio.Items.Add(i);
            }
            cmbAnio.SelectedItem = anioActual; // Selecciona el año actual
        }

        private void ConfigurarDataGridView()
        {
            // Simular las columnas del reporte de nómina
            dgvNomina.Columns.Add("NumeroEmpleado", "No. Empleado");
            dgvNomina.Columns.Add("NombreCompleto", "Nombre del Empleado");
            dgvNomina.Columns.Add("FechaPago", "Fecha de Pago");
            dgvNomina.Columns.Add("SalarioBruto", "Sueldo Bruto");
            dgvNomina.Columns.Add("IMSS", "Deducción IMSS");
            dgvNomina.Columns.Add("ISR", "Deducción ISR");
            dgvNomina.Columns.Add("PercepcionesEspeciales", "Percepciones Especiales");
            dgvNomina.Columns.Add("DeduccionesEspeciales", "Deducciones Especiales");
            dgvNomina.Columns.Add("SalarioNeto", "Sueldo Neto a Pagar");
            dgvNomina.Columns.Add("Banco", "Banco");
            dgvNomina.Columns.Add("CuentaBancaria", "Cuenta Bancaria");
        }

        private void btnCalcularNomina_Click(object sender, EventArgs e)
        {
            // Aquí se implementará la lógica para calcular la nómina
            // Por ahora, solo simulará que se ha realizado el cálculo
            MessageBox.Show($"Nómina para {cmbMes.SelectedItem} de {cmbAnio.SelectedItem} calculada. Se ha llenado la tabla con datos de ejemplo.");
            SimularDatosEnDataGridView();
        }

        private void SimularDatosEnDataGridView()
        {
            dgvNomina.Rows.Clear(); // Limpia los datos anteriores

            // Datos de ejemplo
            dgvNomina.Rows.Add("101", "Juan Pérez", "30/09/2025", "9,000.00", "377.75", "1,050.00", "500.00", "150.00", "7,922.25", "Banco MX", "123456789");
            dgvNomina.Rows.Add("102", "María López", "30/09/2025", "12,000.00", "503.67", "1,500.00", "0.00", "0.00", "9,996.33", "Bancomer", "987654321");
            // Agrega más datos de prueba si lo deseas
        }

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
                    // Encabezados
                    for (int i = 0; i < dgvNomina.Columns.Count; i++)
                    {
                        sb.Append(dgvNomina.Columns[i].HeaderText + (i == dgvNomina.Columns.Count - 1 ? "" : ","));
                    }
                    sb.AppendLine();

                    // Datos
                    foreach (DataGridViewRow row in dgvNomina.Rows)
                    {
                        for (int i = 0; i < dgvNomina.Columns.Count; i++)
                        {
                            sb.Append(row.Cells[i].Value.ToString().Replace(",", "") + (i == dgvNomina.Columns.Count - 1 ? "" : ","));
                        }
                        sb.AppendLine();
                    }

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
                // Aquí se abriría un nuevo formulario para mostrar el recibo de nómina detallado
                MessageBox.Show("¡Vista lista! Se simulará la generación del recibo de nómina en una nueva ventana para el empleado seleccionado.");
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un empleado de la lista para ver su recibo.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
