using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient; // ¡Importante!

namespace PIA_MAD_CalculodeNominas
{
    public partial class FormPuestos : Form
    {
        // Enum para un manejo de estado claro y profesional
        private enum EstadoFormulario
        {
            Navegando,
            Agregando,
            Editando
        }

        private EstadoFormulario estadoActual;
        private NominasDAL dal = new NominasDAL(); // Objeto de acceso a datos

        public FormPuestos()
        {
            InitializeComponent();
        }

        private void FormPuestos_Load(object sender, EventArgs e)
        {
            // 1. Cargar el DataGridView
            CargarPuestos();

            // 2. Establecer el estado inicial del formulario
            ConfigurarEstado(EstadoFormulario.Navegando);
        }

        #region Lógica de Carga de Datos

        private void CargarPuestos()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    // Llama al Stored Procedure que creamos
                    SqlCommand cmd = new SqlCommand("sp_Puesto_GetAll", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    dgvPuestos.DataSource = dt; // Asegúrate que tu DataGridView se llame dgvPuestos
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar puestos: " + ex.Message);
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

            bool habilitarCampos = (nuevoEstado == EstadoFormulario.Agregando || nuevoEstado == EstadoFormulario.Editando);

            // Habilitar/Deshabilitar campos
            HabilitarControles(habilitarCampos);

            // Habilitar/Deshabilitar botones
            btnNuevo.Enabled = (nuevoEstado == EstadoFormulario.Navegando);
            btnModificar.Enabled = (nuevoEstado == EstadoFormulario.Navegando);
            btnEliminar.Enabled = (nuevoEstado == EstadoFormulario.Navegando);
            btnGuardar.Enabled = habilitarCampos;
            btnCancelar.Enabled = habilitarCampos;

            if (nuevoEstado == EstadoFormulario.Agregando)
            {
                LimpiarCampos();
                txtNombre.Focus();
            }
        }

        /// <summary>
        /// Habilita o deshabilita los campos de captura.
        /// </summary>
        private void HabilitarControles(bool habilitar)
        {
            txtNombre.Enabled = habilitar;
            //txtDescripcion.Enabled = habilitar;

            // El ID nunca se edita manualmente
            txtId.Enabled = false;
        }

        /// <summary>
        /// Limpia todos los campos de captura.
        /// </summary>
        private void LimpiarCampos()
        {
            txtId.Clear();
            txtNombre.Clear();
            //txtDescripcion.Clear();
        }

        #endregion

        #region Eventos de Botones (ABCC)

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ConfigurarEstado(EstadoFormulario.Agregando);
        }

        private void btnModificar_Click(object sender, EventArgs e)
        {
            if (dgvPuestos.SelectedRows.Count > 0)
            {
                ConfigurarEstado(EstadoFormulario.Editando);
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para modificar.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            LimpiarCampos();
            ConfigurarEstado(EstadoFormulario.Navegando);
            dgvPuestos_SelectionChanged(null, null); // Recarga los datos de la fila seleccionada (o limpia si no hay nada)
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Lógica de validación de datos
            if (string.IsNullOrWhiteSpace(txtNombre.Text))
            {
                MessageBox.Show("El campo Nombre es obligatorio.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                    {
                        // Llama al SP de Insertar
                        cmd.CommandText = "sp_Puesto_Insert";
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        //cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                    }
                    else // (estadoActual == EstadoFormulario.Editando)
                    {
                        // Llama al SP de Modificar
                        cmd.CommandText = "sp_Puesto_Update";
                        cmd.Parameters.AddWithValue("@idPuesto", Convert.ToInt32(txtId.Text)); // ¡Importante!
                        cmd.Parameters.AddWithValue("@nombre", txtNombre.Text);
                        //cmd.Parameters.AddWithValue("@descripcion", txtDescripcion.Text);
                    }

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("¡Registro guardado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarPuestos(); // Recarga el grid
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
            if (dgvPuestos.SelectedRows.Count > 0)
            {
                string nombrePuesto = dgvPuestos.SelectedRows[0].Cells["Nombre"].Value.ToString();
                int idPuesto = Convert.ToInt32(dgvPuestos.SelectedRows[0].Cells["ID"].Value);

                DialogResult dialogResult = MessageBox.Show($"¿Está seguro de que desea eliminar el puesto: {nombrePuesto}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection cnn = dal.GetConnection())
                        {
                            // Llama al SP de Eliminar
                            SqlCommand cmd = new SqlCommand("sp_Puesto_Delete", cnn);
                            cmd.CommandType = CommandType.StoredProcedure;
                            cmd.Parameters.AddWithValue("@idPuesto", idPuesto);

                            cnn.Open();
                            cmd.ExecuteNonQuery();
                            MessageBox.Show("¡Puesto eliminado con éxito!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            CargarPuestos(); // Recarga el grid
                            LimpiarCampos();
                            ConfigurarEstado(EstadoFormulario.Navegando);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error al eliminar: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Función de impresión lista para implementar.");
        }

        #endregion

        #region Eventos del DataGridView

        private void dgvPuestos_SelectionChanged(object sender, EventArgs e)
        {
            // Solo actuar si estamos navegando y hay una fila seleccionada
            if (estadoActual == EstadoFormulario.Navegando && dgvPuestos.SelectedRows.Count > 0)
            {
                DataGridViewRow filaSeleccionada = dgvPuestos.SelectedRows[0];

                // Carga los datos de la fila a los controles
                txtId.Text = filaSeleccionada.Cells["ID"].Value.ToString();
                txtNombre.Text = filaSeleccionada.Cells["Nombre"].Value.ToString();
                //txtDescripcion.Text = filaSeleccionada.Cells["Descripcion"].Value.ToString();
            }
        }

        #endregion
    }
}