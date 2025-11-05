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
    public partial class FormDepartamentos : Form
    {
        // Enum para un manejo de estado claro y profesional
        private enum EstadoFormulario
        {
            Navegando,
            Agregando,
            Editando
        }

        private EstadoFormulario estadoActual;

        public FormDepartamentos()
        {
            InitializeComponent();
        }

        private void FormDepartamentos_Load(object sender, EventArgs e)
        {
            // 1. Cargar el DataGridView (simulado por ahora)
            CargarDepartamentos();

            // 2. Cargar el ComboBox de Jefes (simulado)
            CargarJefes();

            // 3. Establecer el estado inicial del formulario
            ConfigurarEstado(EstadoFormulario.Navegando);
        }

        #region Lógica de Carga de Datos (Simulada)

        private void CargarDepartamentos()
        {
            // --- ¡AQUÍ VA TU LÓGICA DE SQL SERVER! ---
            // Llama a tu Stored Procedure: sp_Departamentos_GetAll
            // Por ahora, usamos datos de ejemplo:
            DataTable dt = new DataTable();
            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("Clave", typeof(string));
            dt.Columns.Add("Nombre", typeof(string));
            dt.Columns.Add("JefeDeptoID", typeof(int)); // El ID del empleado
            dt.Columns.Add("Descripcion", typeof(string));
            dt.Columns.Add("Presupuesto", typeof(decimal));

            dt.Rows.Add(1, "RH-01", "Recursos Humanos", 1, "Gestión de personal", 50000);
            dt.Rows.Add(2, "TI-01", "Tecnologías de Inf.", 2, "Sistemas y soporte", 120000);
            dt.Rows.Add(3, "FIN-01", "Finanzas", 1, "Contabilidad y Tesorería", 80000);

            dgvDepartamentos.DataSource = dt;
        }

        private void CargarJefes()
        {
            // --- ¡AQUÍ VA TU LÓGICA DE SQL SERVER! ---
            // Llama a: sp_Empleados_GetCombo
            // Por ahora, usamos datos de ejemplo:
            DataTable dtJefes = new DataTable();
            dtJefes.Columns.Add("EmpleadoID", typeof(int));
            dtJefes.Columns.Add("NombreCompleto", typeof(string));

            dtJefes.Rows.Add(1, "Ana López");
            dtJefes.Rows.Add(2, "Carlos Sánchez");

            cmbJefeDepto.DataSource = dtJefes;
            cmbJefeDepto.DisplayMember = "NombreCompleto"; // Lo que ve el usuario
            cmbJefeDepto.ValueMember = "EmpleadoID";       // Lo que guardamos en la BD
            cmbJefeDepto.SelectedIndex = -1;
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
            txtPresupuesto.Enabled = habilitar;
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
            txtPresupuesto.Clear();
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
            // Lógica de validación de datos
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtClaveDepto.Text))
            {
                MessageBox.Show("Los campos de Clave y Nombre son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // --- ¡AQUÍ VA TU LÓGICA DE SQL SERVER! ---
            if (estadoActual == EstadoFormulario.Agregando)
            {
                // Llama a tu Stored Procedure: sp_Departamentos_Insert
                // (pasando txtClaveDepto.Text, txtNombre.Text, cmbJefeDepto.SelectedValue, etc.)
                MessageBox.Show("¡Registro AGREGADO con éxito! (Simulación)", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // (estadoActual == EstadoFormulario.Editando)
            {
                // Llama a tu Stored Procedure: sp_Departamentos_Update
                // (pasando txtId.Text, txtClaveDepto.Text, txtNombre.Text, cmbJefeDepto.SelectedValue, etc.)
                MessageBox.Show("¡Registro MODIFICADO con éxito! (Simulación)", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Simular que la operación fue exitosa
            CargarDepartamentos(); // Recarga el grid
            ConfigurarEstado(EstadoFormulario.Navegando);
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (dgvDepartamentos.SelectedRows.Count > 0)
            {
                string nombreDepto = dgvDepartamentos.SelectedRows[0].Cells["Nombre"].Value.ToString();
                string idDepto = dgvDepartamentos.SelectedRows[0].Cells["ID"].Value.ToString();

                DialogResult dialogResult = MessageBox.Show($"¿Está seguro de que desea eliminar el departamento: {nombreDepto}?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dialogResult == DialogResult.Yes)
                {
                    // --- ¡AQUÍ VA TU LÓGICA DE SQL SERVER! ---
                    // Llama a tu Stored Procedure: sp_Departamentos_Delete (pasando idDepto)
                    MessageBox.Show("¡Registro ELIMINADO con éxito! (Simulación)", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    CargarDepartamentos(); // Recarga el grid
                    LimpiarCampos();
                    ConfigurarEstado(EstadoFormulario.Navegando);
                }
            }
            else
            {
                MessageBox.Show("Por favor, seleccione una fila para eliminar.", "Selección", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                txtPresupuesto.Text = filaSeleccionada.Cells["Presupuesto"].Value.ToString();

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