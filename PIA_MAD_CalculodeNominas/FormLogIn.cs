using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PIA_MAD_CalculodeNominas
{
    public partial class FormLogIn : Form
    {
        public FormLogIn()
        {
            InitializeComponent();
        }

        // ----------------------------------------------------------------------
        // MÉTODO CRUCIAL: Manejo del clic en el botón Aceptar
        // ----------------------------------------------------------------------
        private void btnAceptar_Click(object sender, EventArgs e)
        {
           
            string usuario = txtUsuario.Text.Trim();
            string contrasena = txtPassword.Text; // No aplicar Trim a contraseñas

            // **Validación básica de campos vacíos**
            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contrasena))
            {
                MessageBox.Show("Por favor, ingrese su usuario y contraseña.", "Campos Vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtUsuario.Focus(); 
                return;
            }

            // 2. Instanciar la Capa de Acceso a Datos (DAL)
            NominasDAL dal = new NominasDAL();

            // 3. Autenticación contra la Base de Datos
            if (dal.ValidarUsuario(usuario, contrasena))
            {
                // Login exitoso:
                MessageBox.Show("Credenciales correctas. Acceso concedido.", "Bienvenido", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Oculta el formulario de login.
                this.Hide();

                // Crea y muestra el FormPrincipal.
                FormPrincipal formPrincipal = new FormPrincipal();
                formPrincipal.Show();
            }
            else
            {
                // Login fallido:
                MessageBox.Show("Usuario o contraseña incorrectos. Intente de nuevo.", "Error de Autenticación", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                txtPassword.Clear(); // Limpiar solo la contraseña
                txtUsuario.Focus();
            }
        }

        // ----------------------------------------------------------------------
        // MÉTODO RECOMENDADO: Prueba de conexión al cargar el formulario
        // ----------------------------------------------------------------------
        private void FrmLogin_Load(object sender, EventArgs e)
        {
            // Opcional: Probar la conexión al cargar. Si falla, avisamos antes de que intente iniciar sesión.
            NominasDAL dal = new NominasDAL();
            if (!dal.TestConnection())
            {
                MessageBox.Show("Advertencia: No se pudo conectar con la base de datos. El sistema no funcionará correctamente.", "Fallo de Conexión", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        // ... (el resto de tus métodos vacíos)

        private void label1_Click(object sender, EventArgs e)
        {
            // ...
        }

        private void lblTituloApp_Click(object sender, EventArgs e)
        {
            // ...
        }

        // ... (Añade el método del botón Cancelar si deseas cerrar la app)
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}