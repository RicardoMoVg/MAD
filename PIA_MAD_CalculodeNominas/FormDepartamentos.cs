using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Windows.Forms;


namespace PIA_MAD_CalculodeNominas
{
    public partial class FormDepartamentos : Form
    {
        
        private enum EstadoFormulario
        {
            Navegando,
            Agregando,
            Editando
        }

        private EstadoFormulario estadoActual;

        private NominasDAL dal = new NominasDAL();

        private bool formularioCargado = false;

        public FormDepartamentos()
        {
            InitializeComponent();
        }

        private void FormDepartamentos_Load(object sender, EventArgs e)
        {

            CargarJefes();
            CargarDepartamentos();
            ConfigurarEstado(EstadoFormulario.Navegando);
            formularioCargado = true;
            dgvDepartamentos_SelectionChanged(null, null);
        }

        #region Lógica de Carga de Datos (Simulada)

        private void CargarDepartamentos()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_Departamento_GetAll", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvDepartamentos.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar departamentos: " + ex.Message);
            }
        }

        private void CargarJefes()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    // Asegúrate que tu SP se llame así
                    SqlCommand cmd = new SqlCommand("sp_Empleados_GetCombo", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    cmbJefeDepto.DataSource = dt;
                    cmbJefeDepto.DisplayMember = "nombreCompleto";
                    cmbJefeDepto.ValueMember = "idEmpleado";
                    cmbJefeDepto.SelectedIndex = -1;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar jefes: " + ex.Message);
            }
        }

        #endregion

        #region Gestión de Estado y Controles

        /// <summary>
        /// Controla la habilitación de campos y botones según el estado.
        /// </summary>
        private void ConfigurarEstado(EstadoFormulario nuevoEstado)
        {
            estadoActual = nuevoEstado;

            switch (estadoActual)
            {
                case EstadoFormulario.Navegando:
                    // Paneles de campos
                    HabilitarControles(false);
                    // Botones
                    btnNuevo.Enabled = true;
                    btnModificar.Enabled = true; // Habilitado, pero depende de selección
                    btnEliminar.Enabled = true; // Habilitado, pero depende de selección
                    btnGuardar.Enabled = false;
                    btnCancelar.Enabled = false;
                    break;

                case EstadoFormulario.Agregando:
                    // Paneles de campos
                    LimpiarCampos();
                    HabilitarControles(true);
                    // Botones
                    btnNuevo.Enabled = false;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnGuardar.Enabled = true;
                    btnCancelar.Enabled = true;
                    txtClaveDepto.Focus();
                    break;

                case EstadoFormulario.Editando:
                    // Paneles de campos
                    HabilitarControles(true);
                    txtClaveDepto.Focus(); // O el campo que prefieras
                    // Botones
                    btnNuevo.Enabled = false;
                    btnModificar.Enabled = false;
                    btnEliminar.Enabled = false;
                    btnGuardar.Enabled = true;
                    btnCancelar.Enabled = true;
                    break;
            }
        }

        /// <summary>
        /// Habilita o deshabilita los campos de captura.
        /// </summary>
        private void HabilitarControles(bool habilitar)
        {
            txtClaveDepto.Enabled = habilitar;
            txtNombre.Enabled = habilitar;
            txtDescripcion.Enabled = habilitar;
            // Recomiendo cambiar txtPresupuesto por un NumericUpDown
            numPresupuesto.Enabled = habilitar;
            
            cmbJefeDepto.Enabled = habilitar;

            // El ID nunca se edita manualmente
            txtId.Enabled = false;
        }

        /// <summary>
        /// Limpia todos los campos de captura.
        /// </summary>
        private void LimpiarCampos()
        {
            txtId.Clear();
            txtClaveDepto.Clear();
            txtNombre.Clear();
            txtDescripcion.Clear();
            numPresupuesto.Value = 0;
            cmbJefeDepto.SelectedIndex = -1; // Deselecciona cualquier elemento
        }

        #endregion

        #region Eventos de Botones (ABCC)

        // *** ¡NUEVO BOTÓN! ***
        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ConfigurarEstado(EstadoFormulario.Agregando);
        }

        // *** Este era tu btnEditar_Click ***
        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvDepartamentos.SelectedRows.Count > 0)
            {
                ConfigurarEstado(EstadoFormulario.Editando);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para modificar.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // *** ¡NUEVO BOTÓN! ***
        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ConfigurarEstado(EstadoFormulario.Navegando);
            // Vuelve a cargar los datos del grid por si acaso
            dgvDepartamentos_SelectionChanged(null, null);
        }

        // *** Este era tu btnAgregar_Click, ahora es btnGuardar_Click ***
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtClaveDepto.Text) || string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("Los campos Clave y Nombre son obligatorios.");
                return;
            }

            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = cnn;
                    cmd.CommandType = CommandType.StoredProcedure;

                    if (estadoActual == EstadoFormulario.Agregando)
                        cmd.CommandText = "sp_Departamento_Insert";
                    else
                    {
                        cmd.CommandText = "sp_Departamento_Update";
                        cmd.Parameters.AddWithValue("@idDepartamento", Convert.ToInt32(txtId.Text));
                    }

                    cmd.Parameters.AddWithValue("@claveDepto", txtClaveDepto.Text);
                    cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                    cmd.Parameters.AddWithValue("@idJefeDepartamento", cmbJefeDepto.SelectedValue ?? DBNull.Value); // Manejo de NULL
                    cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);

                    // --- ¡¡OJO!! Ver la advertencia de abajo ---
                    cmd.Parameters.AddWithValue("@presupuesto", numPresupuesto.Value);

                    cnn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("¡Registro guardado con éxito!");
                    CargarDepartamentos();
                    ConfigurarEstado(EstadoFormulario.Navegando);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al guardar: " + ex.Message);
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDepartamentos.SelectedRows.Count == 0) return;

            string nombreDepto = dgvDepartamentos.SelectedRows[0].Cells["Nombre"].Value.ToString();
            int idDepto = Convert.ToInt32(dgvDepartamentos.SelectedRows[0].Cells["ID"].Value);

            DialogResult result = MessageBox.Show($"¿Eliminar el departamento '{nombreDepto}'?", "Confirmar", MessageBoxButtons.YesNo);
            if (result != DialogResult.Yes) return;

            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand("sp_Departamento_Delete", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idDepartamento", idDepto);
                    cnn.Open();
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("¡Departamento eliminado!");
                    CargarDepartamentos();
                    LimpiarCampos();
                    ConfigurarEstado(EstadoFormulario.Navegando);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            // Aquí irá la lógica para tu ReportViewer o librería de PDF
            MessageBox.Show("¡Vista de Impresión lista! Código de impresión de lista de departamentos listo.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

        #region Eventos del DataGridView

        // *** ¡NUEVA FUNCIÓN CRÍTICA! ***
        private void dgvDepartamentos_SelectionChanged(object sender, EventArgs e)
        {
            // Solo actuar si estamos navegando y hay una fila seleccionada
            if (estadoActual == EstadoFormulario.Navegando && dgvDepartamentos.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvDepartamentos.SelectedRows[0];

                // Carga los datos de la fila a los controles
                txtId.Text = filaSeleccionada.Cells["ID"].Value.ToString();
                txtClaveDepto.Text = filaSeleccionada.Cells["Clave"].Value.ToString();
                txtNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                txtDescripcion.Text = filaSeleccionada.Cells["Descripcion"].Value.ToString();
                

                // Manejo cuidadoso del ComboBox
                var idJefe = filaSeleccionada.Cells["JefeDeptoID"].Value;
                if (idJefe != DBNull.Value)
                {
                    cmbJefeDepto.SelectedValue = idJefe;
                }
                else
                {
                    cmbJefeDepto.SelectedIndex = -1;
                }
            }
        }

        #endregion
    }
}