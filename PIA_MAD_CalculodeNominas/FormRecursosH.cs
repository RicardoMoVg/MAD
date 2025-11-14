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
using System.Text.RegularExpressions;
using System.Globalization; // Para el formato

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
            //AplicarSeguridad(); // <-- Comentado para que puedas probar
            LimpiarFormulario();
        }

        private void AplicarSeguridad()
        {
            // --- ¡CORREGIDO! Usa 'SesionActual' ---
            bool esAdmin = (SesionUsuario.Rol == "Admin");

            btnGuardar.Enabled = esAdmin;
            btnDarDeBaja.Enabled = esAdmin;

            HabilitarControlesRecursivo(this, esAdmin);
        }

        private void HabilitarControlesRecursivo(Control contenedor, bool habilitar)
        {
            foreach (Control ctrl in contenedor.Controls)
            {
                if (ctrl is TextBox txt)
                {
                    if (txt.Name != "txtIDEmpleado" && txt.Name != "txtBuscar" && txt.Name != "txtSalarioIntegrado")
                    {
                        txt.ReadOnly = !habilitar;
                    }
                }
                else if (ctrl is ComboBox cmb)
                {
                    cmb.Enabled = habilitar;
                }
                else if (ctrl is DateTimePicker dtp)
                {
                    dtp.Enabled = habilitar;
                }
                else if (ctrl is NumericUpDown num)
                {
                    num.ReadOnly = !habilitar;
                }
                else if (ctrl is Button btn && (btn.Name.Contains("Calcular") || btn.Name.Contains("Limpiar")))
                {
                    btn.Enabled = habilitar;
                }
                if (ctrl.HasChildren)
                {
                    HabilitarControlesRecursivo(ctrl, habilitar);
                }
            }
            txtIDEmpleado.ReadOnly = true;
            txtSalarioIntegrado.ReadOnly = true; // El SDI siempre es de solo lectura
        }

        private void CargarEmpleados()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
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

        private void CargarComboBoxes()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    SqlDataAdapter daDepto = new SqlDataAdapter("sp_Departamento_GetActivos", cnn);
                    daDepto.SelectCommand.CommandType = CommandType.StoredProcedure;
                    DataTable dtDepto = new DataTable();
                    daDepto.Fill(dtDepto);
                    cmbDepartamento.DataSource = dtDepto;
                    cmbDepartamento.ValueMember = "idDepartamento";
                    cmbDepartamento.DisplayMember = "nombre";

                    SqlDataAdapter daPuesto = new SqlDataAdapter("sp_Puesto_GetActivos", cnn);
                    daPuesto.SelectCommand.CommandType = CommandType.StoredProcedure;
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

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // --- VALIDACIONES ---
            if (string.IsNullOrWhiteSpace(txtNombreCompleto.Text) || numSalarioDiario.Value <= 0 ||
                string.IsNullOrWhiteSpace(txtCURP.Text) || string.IsNullOrWhiteSpace(txtRFC.Text) ||
                string.IsNullOrWhiteSpace(txtNSS.Text))
            {
                MessageBox.Show("Los campos: Nombre, Salario Diario, CURP, RFC y NSS son obligatorios.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(txtCURP.Text, @"^[A-Za-z0-9]{18}$"))
            {
                MessageBox.Show("El formato del CURP es incorrecto.\nDebe contener 18 caracteres (letras y números).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(txtRFC.Text, @"^[A-Za-z0-9]{13}$"))
            {
                MessageBox.Show("El formato del RFC es incorrecto.\nDebe contener 13 caracteres (letras y números).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(txtNSS.Text, @"^\d{11}$"))
            {
                MessageBox.Show("El NSS es incorrecto.\nDebe contener 11 dígitos numéricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrEmpty(txtTelefono.Text) && !Regex.IsMatch(txtTelefono.Text, @"^\d{10}$"))
            {
                MessageBox.Show("El Teléfono es incorrecto.\nDebe contener 10 dígitos numéricos (ej. 8112345678).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrEmpty(txtCorreo.Text) && !Regex.IsMatch(txtCorreo.Text, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
            {
                MessageBox.Show("El formato del Correo es incorrecto (ej. usuario@dominio.com).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrEmpty(txtRegistroPatronal.Text) && !Regex.IsMatch(txtRegistroPatronal.Text, @"^[A-Za-z]\d{10}$"))
            {
                MessageBox.Show("El Registro Patronal es incorrecto.\nDebe ser 1 letra seguida de 10 números (ej. A1234567890).", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!string.IsNullOrEmpty(txtNumCuenta.Text) && !Regex.IsMatch(txtNumCuenta.Text, @"^\d{12}$"))
            {
                MessageBox.Show("El Número de Cuenta (Tarjeta) es incorrecto.\nDebe contener 12 dígitos numéricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            // --- FIN DE VALIDACIONES ---

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

        private void GuardarNuevoEmpleado()
        {
            using (SqlConnection cnn = dal.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_InsertarEmpleado", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@nombreCompleto", txtNombreCompleto.Text);
                    cmd.Parameters.AddWithValue("@fechaNac", dtpFechaNacimiento.Value);
                    cmd.Parameters.AddWithValue("@fechaCreacion", dtpFechaInicio.Value);
                    cmd.Parameters.AddWithValue("@CURP", txtCURP.Text);
                    cmd.Parameters.AddWithValue("@NSS", txtNSS.Text);
                    cmd.Parameters.AddWithValue("@RFC", txtRFC.Text);
                    cmd.Parameters.AddWithValue("@banco", txtBanco.Text);
                    cmd.Parameters.AddWithValue("@numCuenta", txtNumCuenta.Text);
                    cmd.Parameters.AddWithValue("@idPrepa", 1);
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

        private void ActualizarEmpleadoExistente()
        {
            using (SqlConnection cnn = dal.GetConnection())
            {
                using (SqlCommand cmd = new SqlCommand("sp_ActualizarEmpleado", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@IDEmpleado", Convert.ToInt32(txtIDEmpleado.Text));
                    cmd.Parameters.AddWithValue("@nombreCompleto", txtNombreCompleto.Text);
                    cmd.Parameters.AddWithValue("@fechaNac", dtpFechaNacimiento.Value);
                    cmd.Parameters.AddWithValue("@fechaCreacion", dtpFechaInicio.Value);
                    cmd.Parameters.AddWithValue("@CURP", txtCURP.Text);
                    cmd.Parameters.AddWithValue("@NSS", txtNSS.Text);
                    cmd.Parameters.AddWithValue("@RFC", txtRFC.Text);
                    cmd.Parameters.AddWithValue("@banco", txtBanco.Text);
                    cmd.Parameters.AddWithValue("@numCuenta", txtNumCuenta.Text);
                    cmd.Parameters.AddWithValue("@idPrepa", 1);
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

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            try
            {
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
                            txtIDEmpleado.Text = reader["idEmpleado"].ToString();
                            txtNombreCompleto.Text = reader["nombreCompleto"].ToString();
                            dtpFechaNacimiento.Value = Convert.ToDateTime(reader["fechaNac"]);

                            object fechaInicio = reader["fechaCreacion"];
                            if (fechaInicio != DBNull.Value)
                                dtpFechaInicio.Value = Convert.ToDateTime(fechaInicio);
                            else
                                dtpFechaInicio.Value = DateTime.Now;

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

                            decimal salarioDiario = Convert.ToDecimal(reader["SalarioDiario"]);
                            numSalarioDiario.Value = salarioDiario;

                            CalcularSDI(salarioDiario);

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

        private void LimpiarFormulario()
        {
            txtIDEmpleado.Text = "";
            txtNombreCompleto.Text = "";
            dtpFechaNacimiento.Value = DateTime.Now;
            dtpFechaInicio.Value = DateTime.Now;
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
            txtSalarioMensual.Text = "";
            txtSalarioIntegrado.Text = ""; // ¡Limpiamos el SDI!
            cmbDepartamento.SelectedIndex = -1;
            cmbPuesto.SelectedIndex = -1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            LimpiarFormulario();
        }

        private void btnCalcularSalarioD_Click(object sender, EventArgs e)
        {
            try
            {
                decimal salarioMensual = decimal.Parse(txtSalarioMensual.Text);
                decimal salarioDiario = salarioMensual / 30m;
                numSalarioDiario.Value = decimal.Round(salarioDiario, 2);

                CalcularSDI(numSalarioDiario.Value);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Por favor, ingrese un monto mensual válido. " + ex.Message, "Error de Cálculo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void numSalarioDiario_ValueChanged(object sender, EventArgs e)
        {
            CalcularSDI(numSalarioDiario.Value);
        }

        /// <summary>
        /// --- ¡¡MÉTODO CORREGIDO (V9.1)!! ---
        /// Calcula el SDI basado en la regla del profe (SDI = SD).
        /// </summary>
        private void CalcularSDI(decimal salarioDiario)
        {
            if (salarioDiario <= 0)
            {
                txtSalarioIntegrado.Text = "0.00";
                return;
            }

            // Regla del Profe: Si no hay aguinaldo ni vacaciones, SDI = SD
            decimal sdi = salarioDiario;

            // Mostramos con 2 decimales, ya que son iguales
            txtSalarioIntegrado.Text = sdi.ToString("N2", CultureInfo.InvariantCulture);
        }
    }
}