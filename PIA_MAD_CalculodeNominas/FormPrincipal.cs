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
    public partial class FormPrincipal : Form
    {
        public FormPrincipal()
        {
            InitializeComponent();
        }

        private void FormPrincipal_Load(object sender, EventArgs e)
        {
            // Opcional: Abrir un formulario por defecto
        }

        /// <summary>
        /// Método genérico para abrir un formulario dentro del panel contenedor.
        /// </summary>
        /// <param name="formHijo">La instancia del formulario a abrir.</param>
        private void AbrirFormularioEnPanel(object formHijo)
        {
            if (this.panelContenedor.Controls.Count > 0)
                this.panelContenedor.Controls.RemoveAt(0);

            Form fh = formHijo as Form;
            fh.TopLevel = false;
            fh.Dock = DockStyle.Fill;
            this.panelContenedor.Controls.Add(fh);
            this.panelContenedor.Tag = fh;
            fh.Show();
        }

        // --- Eventos Click de cada ToolStripMenuItem del menú principal ---

        private void menuItemUsuario_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¡Vista de Usuario! Aquí se gestionarán los perfiles.", "Información");
        }

        private void menuItemCatalogos_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormDepartamentos());
        }

        private void menuItemRecursosHumanos_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormRecursosH());
        }

        private void menuItemNomina_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormNomina());
        }

        private void menuItemReportes_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormReportes());
        }

        private void menuItemConsultas_Click(object sender, EventArgs e)
        {
            MessageBox.Show("¡Vista de Consultas! Aquí se realizarán búsquedas avanzadas.", "Información");
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}