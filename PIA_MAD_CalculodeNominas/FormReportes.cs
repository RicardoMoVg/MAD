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
    public partial class FormReportes : Form
    {
        public FormReportes()
        {
            InitializeComponent();
        }

        private void btnReporteGeneral_Click(object sender, EventArgs e)
        {
            lblTituloReporte.Text = "Reporte General de Nómina";
            LimpiarFiltros();

            // Lógica de filtros: Año y Mes
            // Aquí puedes agregar un ComboBox para el Año y otro para el Mes

            MessageBox.Show("¡Vista lista! Aquí se mostrará el reporte general de nómina.");
        }

        private void btnReporteHeadcounter_Click(object sender, EventArgs e)
        {
            lblTituloReporte.Text = "Reporte Headcounter";
            LimpiarFiltros();

            // Lógica de filtros: Departamento y Año-Mes
            // Aquí puedes agregar un ComboBox para el Departamento y otros para Año y Mes

            MessageBox.Show("¡Vista lista! Aquí se mostrará el reporte Headcounter.");
        }

        private void btnReporteNomina_Click(object sender, EventArgs e)
        {
            lblTituloReporte.Text = "Reporte de Nómina";
            LimpiarFiltros();

            // Lógica de filtros: Año
            // Aquí puedes agregar un ComboBox para el Año

            MessageBox.Show("¡Vista lista! Aquí se mostrará el reporte de nómina.");
        }

        private void LimpiarFiltros()
        {
            // Limpia los controles del panel de filtros para el nuevo reporte
            panelFiltros.Controls.Clear();
            // Restablece el DataGridView
            dgvReporte.DataSource = null;
            dgvReporte.Columns.Clear();
        }
    }
}