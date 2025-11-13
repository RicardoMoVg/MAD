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

            ConfigurarMenuPorRol();
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

        

        private void menuItemUsuario_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormUsuarios());
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
           
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormHSR());
        }

        private void puestosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormPuestos());
        }

        private void capturaDePercepcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            AbrirFormularioEnPanel(new FormCapturaDedPer(this));
        }

        private void agregarPercepcionesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Hacemos lo mismo aquí
            AbrirFormularioEnPanel(new FormAgregarPercepciones(this));
        }

        private void capturasEspecialesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AbrirFormularioEnPanel(new FormCapturaEspeciales());
        }

        private void panelContenedor_Paint(object sender, PaintEventArgs e)
        {

        }

        /// <summary>
        /// Configura la visibilidad de los menús basados en el rol del usuario
        /// guardado en la clase SesionUsuario.
        /// </summary>
        private void ConfigurarMenuPorRol()
        {
            // Asumimos que los nombres de tus menús son los de la imagen/código:
            // menuItemRecursosHumanos, menuItemNomina, menuItemReportes

            // Ocultar todo lo sensible por defecto
            menuItemRecursosHumanos.Visible = false;
            menuItemNomina.Visible = false;
            menuItemReportes.Visible = false;

            // (Ajusta los nombres de los roles a como los tengas en tu BD)
            // Ej: "Administrador", "Nómina", "RecursosHumanos", "Consulta"

            string rol = SesionUsuario.Rol;

            switch (rol)
            {
                case "Administrador":
                    // El Admin ve todo
                    menuItemRecursosHumanos.Visible = true;
                    menuItemNomina.Visible = true;
                    menuItemReportes.Visible = true;
                    break;

                case "Nómina":
                    // El de Nómina solo ve "NOMINA"
                    menuItemNomina.Visible = true;
                    break;

                case "RecursosHumanos":
                    // El de RRHH ve "RECURSOS HUMANOS" y "REPORTES"
                    menuItemRecursosHumanos.Visible = true;
                    menuItemReportes.Visible = true;
                    break;

                case "Consulta":
                    // El de "Consulta" (o cualquier otro rol) no ve nada de esto.
                    // No hacemos nada, ya están ocultos.
                    break;

                default:
                    // "Usuario normal" o rol no reconocido
                    // No se muestra nada sensible.
                    break;
            }

            // Los menús "USUARIO", "CATALOGOS" y "CONSULTAS"
            // se quedan visibles para todos (ya que no los ocultamos).
        }
    }
}