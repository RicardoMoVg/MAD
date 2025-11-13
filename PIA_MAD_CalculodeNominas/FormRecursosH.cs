using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;

namespace PIA_MAD_CalculodeNominas
{
    public partial class FormRecursosH : Form
    {
        private NominasDAL dal = new NominasDAL();

        public FormRecursosH()
        {
            InitializeComponent();
        }

        private void FormRecursosH_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
            CargarComboBoxes();
            AplicarSeguridad();
            LimpiarFormulario(); // Empezamos en blanco
        }

        /// <summary>
        /// Oculta botones si el usuario no es Administrador.
        /// </summary>
        private void AplicarSeguridad()
        {
            // Asumimos que "Admin" es el rol de Recursos Humanos
            if (SesionUsuario.Rol != "Admin")
            {
                btnGuardar.Enabled = false;
                btnDarDeBaja.Enabled = false;

                // Opcional: hacer todos los campos ReadOnly
                foreach (Control ctrl in this.Controls)
                {
                    if (ctrl is TextBox) ((TextBox)ctrl).ReadOnly = true;
                    if (ctrl is ComboBox) ((ComboBox)ctrl).Enabled = false;
                    if (ctrl is DateTimePicker) ((DateTimePicker)ctrl).Enabled = false;
                    if (ctrl is NumericUpDown) ((NumericUpDown)ctrl).ReadOnly = true;
                }
            }
        }

        /// <summary>
        /// Carga el DataGridView con empleados activos usando el nuevo SP.
        /// </summary>
        private void CargarEmpleados()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    // ¡NUEVO SP!
                    using (SqlCommand cmd = new SqlCommand("sp_ConsultarEmpleadosActivos", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvEmpleados.DataSource = dt;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga los catálogos (Puestos y Departamentos)
        /// </summary>
        private void CargarComboBoxes()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    // Cargamos Departamentos (asumiendo que tienen 'activo')
                    SqlDataAdapter daDepto = new SqlDataAdapter("SELECT idDepartamento, nombre FROM Departamento WHERE activo = 1", cnn);
                    DataTable dtDepto = new DataTable();
                    daDepto.Fill(dtDepto);
                    cmbDepartamento.DataSource = dtDepto;
                    cmbDepartamento.ValueMember = "idDepartamento";
                    cmbDepartamento.DisplayMember = "nombre";

                    // Cargamos Puestos (asumiendo que tienen 'activo')
                    SqlDataAdapter daPuesto = new SqlDataAdapter("SELECT idPuesto, nombre FROM Puesto WHERE activo = 1", cnn);
                    DataTable dtPuesto = new DataTable();
                    daPuesto.Fill(dtPuesto);
                    cmbPuesto.DataSource = dtPuesto;
                    cmbPuesto.ValueMember = "idPuesto";
                    cmbPuesto.DisplayMember = "nombre";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar catálogos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento principal del botón Guardar.
        /// Decide si insertar o actualizar.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // --- ¡VALIDACIÓN! (Ejemplo) ---
            if (string.IsNullOrEmpty(txtNombreCompleto.Text) || string.IsNullOrEmpty(txtCURP.Text) || numSalarioDiario.Value <= 0)
            {
                MessageBox.Show("Los campos Nombre, CURP y Salario Diario son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                if (string.IsNullOrEmpty(txtIDEmpleado.Text))
                {
                    GuardarNuevoEmpleado();
                    MessageBox.Show("¡Empleado guardado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    ActualizarEmpleadoExistente();
                    MessageBox.Show("¡Empleado actualizado exitosamente!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

                CargarEmpleados();
                LimpiarFormulario();
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Error de SQL: " + ex.Message, "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message, "Error de Aplicación", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ¡NUEVA LÓGICA SIMPLIFICADA!
        /// Llama al SP para INSERTAR un nuevo empleado.
        /// </summary>
        private void GuardarNuevoEmpleado()
        {
            using (SqlConnection cnn = dal.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarEmpleado", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Mapeo de parámetros
                    cmd.Parameters.AddWithValue("@nombreCompleto", txtNombreCompleto.Text);
                    cmd.Parameters.AddWithValue("@fechaNac", dtpFechaNacimiento.Value);
                    cmd.Parameters.AddWithValue("@CURP", txtCURP.Text);
                    cmd.Parameters.AddWithValue("@NSS", txtNSS.Text);
                    cmd.Parameters.AddWithValue("@RFC", txtRFC.Text);
                    cmd.Parameters.AddWithValue("@banco", txtBanco.Text);
                    cmd.Parameters.AddWithValue("@numCuenta", txtNumCuenta.Text);
                    cmd.Parameters.AddWithValue("@idPrepa", 1); // Asumimos 1 (Honkai Star Rail)
                    cmd.Parameters.AddWithValue("@calle", txtCalle.Text);
                    cmd.Parameters.AddWithValue("@numExt", txtNumExt.Text);
                    cmd.Parameters.AddWithValue("@numInt", (object)txtNumInt.Text ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@colonia", txtColonia.Text);
                    cmd.Parameters.AddWithValue("@municipio", txtMunicipio.Text);
                    cmd.Parameters.AddWithValue("@estado", txtEstado.Text);
                    cmd.Parameters.AddWithValue("@codigoPostal", txtCP.Text);
                    cmd.Parameters.AddWithValue("@SalarioDiario", numSalarioDiario.Value);
                    cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@RegistroPatronal", txtRegistroPatronal.Text);
                    cmd.Parameters.AddWithValue("@idPuesto", cmbPuesto.SelectedValue);
                    cmd.Parameters.AddWithValue("@idDepartamento", cmbDepartamento.SelectedValue);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// ¡NUEVA LÓGICA SIMPLIFICADA!
        /// Llama al SP para ACTUALIZAR un empleado.
        /// </summary>
        private void ActualizarEmpleadoExistente()
        {
            using (SqlConnection cnn = dal.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarEmpleado", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Mapeo de parámetros
                    cmd.Parameters.AddWithValue("@IDEmpleado", Convert.ToInt32(txtIDEmpleado.Text));
                    cmd.Parameters.AddWithValue("@nombreCompleto", txtNombreCompleto.Text);
                    cmd.Parameters.AddWithValue("@fechaNac", dtpFechaNacimiento.Value);
                    cmd.Parameters.AddWithValue("@CURP", txtCURP.Text);
                    cmd.Parameters.AddWithValue("@NSS", txtNSS.Text);
                    cmd.Parameters.AddWithValue("@RFC", txtRFC.Text);
                    cmd.Parameters.AddWithValue("@banco", txtBanco.Text);
                    cmd.Parameters.AddWithValue("@numCuenta", txtNumCuenta.Text);
                    cmd.Parameters.AddWithValue("@idPrepa", 1); // Asumimos 1
                    cmd.Parameters.AddWithValue("@calle", txtCalle.Text);
                    cmd.Parameters.AddWithValue("@numExt", txtNumExt.Text);
                    cmd.Parameters.AddWithValue("@numInt", (object)txtNumInt.Text ?? DBNull.Value);
                    cmd.Parameters.AddWithValue("@colonia", txtColonia.Text);
                    cmd.Parameters.AddWithValue("@municipio", txtMunicipio.Text);
                    cmd.Parameters.AddWithValue("@estado", txtEstado.Text);
                    cmd.Parameters.AddWithValue("@codigoPostal", txtCP.Text);
                    cmd.Parameters.AddWithValue("@SalarioDiario", numSalarioDiario.Value);
                    cmd.Parameters.AddWithValue("@Correo", txtCorreo.Text);
                    cmd.Parameters.AddWithValue("@Telefono", txtTelefono.Text);
                    cmd.Parameters.AddWithValue("@RegistroPatronal", txtRegistroPatronal.Text);
                    cmd.Parameters.AddWithValue("@idPuesto", cmbPuesto.SelectedValue);
                    cmd.Parameters.AddWithValue("@idDepartamento", cmbDepartamento.SelectedValue);

                    cnn.Open();
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// ¡NUEVO EVENTO!
        /// Llama al SP para la BAJA LÓGICA.
        /// </summary>
        private void btnDarDeBaja_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtIDEmpleado.Text))
            {
                MessageBox.Show("Por favor, seleccione un empleado de la lista para darlo de baja.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show("¿Está seguro de que desea dar de baja a este empleado? Esta acción no se puede deshacer.", "Confirmar Baja", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.No)
            {
                return;
            }

            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_BajaEmpleado", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@IDEmpleado", Convert.ToInt32(txtIDEmpleado.Text));
                        cnn.Open();
                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Empleado dado de baja exitosamente.", "Baja Completada", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CargarEmpleados();
                LimpiarFormulario();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al dar de baja al empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// ¡NUEVA LÓGICA SIMPLIFICADA!
        /// Al hacer clic en una celda, carga la info del empleado.
        /// </summary>
        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return; // No es el encabezado

            try
            {
                // Obtenemos el ID de la fila seleccionada
                int idEmpleado = Convert.ToInt32(dgvEmpleados.Rows[e.RowIndex].Cells["idEmpleado"].Value);

                using (SqlConnection cnn = dal.GetConnection())
                {
                    using (SqlCommand cmd = new SqlCommand("sp_ConsultarEmpleadoPorID", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                        cnn.Open();
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            // Llenamos el formulario
                            txtIDEmpleado.Text = reader["idEmpleado"].ToString();
                            txtNombreCompleto.Text = reader["nombreCompleto"].ToString();
                            dtpFechaNacimiento.Value = Convert.ToDateTime(reader["fechaNac"]);
                            txtCURP.Text = reader["CURP"].ToString();
                            txtNSS.Text = reader["NSS"].ToString();
                            txtRFC.Text = reader["RFC"].ToString();
                            txtBanco.Text = reader["banco"].ToString();
                            txtNumCuenta.Text = reader["numCuenta"].ToString();
                            txtCorreo.Text = reader["Correo"].ToString();
                            txtTelefono.Text = reader["Telefono"].ToString();
                            txtRegistroPatronal.Text = reader["RegistroPatronal"].ToString();
                            txtCalle.Text = reader["calle"].ToString();
                            txtNumExt.Text = reader["numExt"].ToString();
                            txtNumInt.Text = reader["numInt"].ToString();
                            txtColonia.Text = reader["colonia"].ToString();
                            txtMunicipio.Text = reader["municipio"].ToString();
                            txtEstado.Text = reader["estado"].ToString();
                            txtCP.Text = reader["codigoPostal"].ToString();
                            numSalarioDiario.Value = Convert.ToDecimal(reader["SalarioDiario"]);
                            cmbDepartamento.SelectedValue = Convert.ToInt32(reader["idDepartamento"]);
                            cmbPuesto.SelectedValue = Convert.ToInt32(reader["idPuesto"]);
                        }
                        reader.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Limpia todos los campos del formulario.
        /// </summary>
        private void LimpiarFormulario()
        {
            txtIDEmpleado.Text = "";
            txtNombreCompleto.Text = "";
            dtpFechaNacimiento.Value = DateTime.Now;
            txtCURP.Text = "";
            txtNSS.Text = "";
            txtRFC.Text = "";
            txtBanco.Text = "";
            txtNumCuenta.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtRegistroPatronal.Text = "";
            txtCalle.Text = "";
            txtNumExt.Text = "";
            txtNumInt.Text = "";
            txtColonia.Text = "";
            txtMunicipio.Text = "";
            txtEstado.Text = "";
            txtCP.Text = "";
            numSalarioDiario.Value = 0;
            cmbDepartamento.SelectedIndex = -1;
            cmbPuesto.SelectedIndex = -1;
        }

        // Evento para el botón de limpiar
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        // Evento para la "reversa" del salario
        private void btnCalcularSalarioD_Click(object sender, EventArgs e)
        {
            try
            {
                decimal salarioMensual = decimal.Parse(txtSalarioMensual.Text);
                decimal salarioDiario = salarioMensual / 30m; // Usar 'm' para decimal
                numSalarioDiario.Value = decimal.Round(salarioDiario, 2);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor, ingrese un monto mensual válido. " + ex.Message, "Error de Cálculo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}