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
            // Al cargar el formulario, llenamos la tabla y los combos
            CargarEmpleados();
            CargarComboBoxes();
        }

        /// <summary>
        /// Carga el DataGridView con la lista de empleados activos.
        /// </summary>
        private void CargarEmpleados()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    // Usamos un SP para obtener los empleados (como en el código de Priscila)
                    using (SqlCommand cmd = new SqlCommand("sp_ConsultarEmpleados", cnn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);
                        dgvEmpleados.DataSource = dt;

                        // Aquí puedes añadir personalización de columnas si lo deseas
                        // ej: dgvEmpleados.Columns["idEmpleado"].HeaderText = "ID";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Carga los catálogos de Departamentos, Puestos y Preparatorias.
        /// </summary>
        private void CargarComboBoxes()
        {
            try
            {
                using (SqlConnection cnn = dal.GetConnection())
                {
                    // Esta consulta está BIEN porque 'Departamento' SÍ tiene la columna 'activo'
                    SqlDataAdapter daDepto = new SqlDataAdapter("SELECT idDepartamento, nombre FROM Departamento WHERE activo = 1", cnn);
                    DataTable dtDepto = new DataTable();
                    daDepto.Fill(dtDepto);
                    cmbDepartamento.DataSource = dtDepto;
                    cmbDepartamento.ValueMember = "idDepartamento";
                    cmbDepartamento.DisplayMember = "nombre";

                    // --- ¡CORRECCIÓN AQUÍ! ---
                    // Quitamos "WHERE activo = 1" porque la tabla 'Puesto' no tiene esa columna
                    SqlDataAdapter daPuesto = new SqlDataAdapter("SELECT idPuesto, nombre FROM Puesto", cnn);
                    DataTable dtPuesto = new DataTable();
                    daPuesto.Fill(dtPuesto);
                    cmbPuesto.DataSource = dtPuesto;
                    cmbPuesto.ValueMember = "idPuesto";
                    cmbPuesto.DisplayMember = "nombre";

                    // --- ¡CORRECCIÓN AQUÍ! ---
                    // Quitamos "WHERE activo = 1" porque la tabla 'Preparatoria' no tiene esa columna
                    SqlDataAdapter daPrepa = new SqlDataAdapter("SELECT idPrepa, nombre FROM Preparatoria", cnn);
                    DataTable dtPrepa = new DataTable();
                    daPrepa.Fill(dtPrepa);

                    // Asumiendo que tienes un cmbPrepa (descomenta si lo necesitas)
                    // cmbPrepa.DataSource = dtPrepa;
                    // cmbPrepa.ValueMember = "idPrepa";
                    // cmbPrepa.DisplayMember = "nombre";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar catálogos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Evento principal del botón Guardar.
        /// Decide si se debe insertar un nuevo empleado o actualizar uno existente.
        /// </summary>
        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Opcional: Añadir validación de campos aquí...
            // if (string.IsNullOrEmpty(txtNombre.Text) || ... ) {
            //     MessageBox.Show("Faltan campos por llenar");
            //     return;
            // }

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

                CargarEmpleados(); // Recargamos la tabla para ver los cambios
                // LimpiarFormulario(); // Es buena idea tener un método que limpie los txt
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
        /// Lógica para INSERTAR un nuevo empleado usando una transacción.
        /// </summary>
        private void GuardarNuevoEmpleado()
        {
            using (SqlConnection cnn = dal.GetConnection())
            {
                cnn.Open();
                // 1. Iniciar la Transacción
                SqlTransaction tran = cnn.BeginTransaction();

                try
                {
                    // --- 2. EJECUTAR TU SP DE EMPLEADO/HISTORIAL ---
                    // Tu SP ya es atómico (inserta empleado e historial)
                    SqlCommand cmdEmpleado = new SqlCommand("sp_InsertarEmpleado_CORREGIDO", cnn, tran);
                    cmdEmpleado.CommandType = CommandType.StoredProcedure;

                    // Añadir TODOS los parámetros que tu SP espera
                    // ¡OJO! Tu SP espera @nombre (completo), lo concatenamos
                    string nombreCompleto = $"{txtNombre.Text} {txtApellidoP.Text} {txtApellidoM.Text}";
                    cmdEmpleado.Parameters.AddWithValue("@nombre", nombreCompleto);
                    cmdEmpleado.Parameters.AddWithValue("@fechaNac", dtpFechaNacimiento.Value);
                    cmdEmpleado.Parameters.AddWithValue("@CURP", txtCURP.Text);
                    cmdEmpleado.Parameters.AddWithValue("@NSS", txtNSS.Text);
                    cmdEmpleado.Parameters.AddWithValue("@RFC", txtRFC.Text);
                    cmdEmpleado.Parameters.AddWithValue("@banco", txtBanco.Text);
                    cmdEmpleado.Parameters.AddWithValue("@numCuenta", txtNumCuenta.Text);
                    cmdEmpleado.Parameters.AddWithValue("@idPrepa", DBNull.Value);
                    cmdEmpleado.Parameters.AddWithValue("@correo", txtEmail.Text);
                    cmdEmpleado.Parameters.AddWithValue("@calle", txtCalle.Text);
                    cmdEmpleado.Parameters.AddWithValue("@numExt", txtNumExt.Text);
                    cmdEmpleado.Parameters.AddWithValue("@numInt", txtNumInt.Text);
                    cmdEmpleado.Parameters.AddWithValue("@colonia", txtColonia.Text);
                    cmdEmpleado.Parameters.AddWithValue("@municipio", txtMunicipio.Text);
                    cmdEmpleado.Parameters.AddWithValue("@estado", txtEstado.Text);
                    cmdEmpleado.Parameters.AddWithValue("@codigoPostal", txtCP.Text);
                    cmdEmpleado.Parameters.AddWithValue("@idDepartamento", cmbDepartamento.SelectedValue);
                    cmdEmpleado.Parameters.AddWithValue("@idPuesto", cmbPuesto.SelectedValue);
                    cmdEmpleado.Parameters.AddWithValue("@salarioDiario", numSalarioDiario.Value);

                    // 3. Ejecutamos el SP y capturamos el ID que devuelve (gracias al "SELECT @NuevoEmpleadoID")
                    int nuevoID = Convert.ToInt32(cmdEmpleado.ExecuteScalar());

                    // --- 4. EJECUTAR SP DE TELÉFONO CASA ---
                    SqlCommand cmdTelCasa = new SqlCommand("sp_InsertarTelefonoEmpleado", cnn, tran);
                    cmdTelCasa.CommandType = CommandType.StoredProcedure;
                    cmdTelCasa.Parameters.AddWithValue("@idEmpleado", nuevoID); // Usamos el ID devuelto
                    cmdTelCasa.Parameters.AddWithValue("@telefono", txtTelCasa.Text);
                    cmdTelCasa.Parameters.AddWithValue("@tipoTelefono", "Casa");
                    cmdTelCasa.ExecuteNonQuery();

                    // --- 5. EJECUTAR SP DE TELÉFONO CELULAR ---
                    SqlCommand cmdTelCel = new SqlCommand("sp_InsertarTelefonoEmpleado", cnn, tran);
                    cmdTelCel.CommandType = CommandType.StoredProcedure;
                    cmdTelCel.Parameters.AddWithValue("@idEmpleado", nuevoID); // Usamos el ID devuelto
                    cmdTelCel.Parameters.AddWithValue("@telefono", txtTelCelular.Text);
                    cmdTelCel.Parameters.AddWithValue("@tipoTelefono", "Celular");
                    cmdTelCel.ExecuteNonQuery();

                    // --- 6. SI TODO SALIÓ BIEN, CONFIRMAR ---
                    tran.Commit();
                }
                catch (Exception)
                {
                    // 7. SI ALGO FALLÓ, REVERTIR TODO
                    tran.Rollback();
                    throw; // Re-lanza la excepción para que el btnGuardar_Click la atrape
                }
            }
        }

        /// <summary>
        /// Lógica para ACTUALIZAR un empleado existente usando una transacción.
        /// </summary>
        private void ActualizarEmpleadoExistente()
        {
            using (SqlConnection cnn = dal.GetConnection())
            {
                cnn.Open();
                SqlTransaction tran = cnn.BeginTransaction(); // 1. Iniciar Transacción

                try
                {
                    int idEmpleado = Convert.ToInt32(txtIDEmpleado.Text);

                    // --- 2. EJECUTAR SP DE ACTUALIZAR EMPLEADO ---
                    SqlCommand cmdEmpleado = new SqlCommand("sp_ActualizarEmpleado", cnn, tran);
                    cmdEmpleado.CommandType = CommandType.StoredProcedure;

                    // Añadir TODOS los parámetros para actualizar
                    cmdEmpleado.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                    string nombreCompleto = $"{txtNombre.Text} {txtApellidoP.Text} {txtApellidoM.Text}";
                    cmdEmpleado.Parameters.AddWithValue("@nombre", nombreCompleto);
                    // ... (añadir TODOS los demás parámetros igual que en el INSERT) ...

                    cmdEmpleado.ExecuteNonQuery();

                    // --- 3. EJECUTAR SP DE ACTUALIZAR TELÉFONO CASA ---
                    SqlCommand cmdTelCasa = new SqlCommand("sp_ActualizarTelefonoEmpleado", cnn, tran);
                    cmdTelCasa.CommandType = CommandType.StoredProcedure;
                    cmdTelCasa.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                    cmdTelCasa.Parameters.AddWithValue("@telefono", txtTelCasa.Text);
                    cmdTelCasa.Parameters.AddWithValue("@tipoTelefono", "Casa");
                    cmdTelCasa.ExecuteNonQuery();

                    // --- 4. EJECUTAR SP DE ACTUALIZAR TELÉFONO CELULAR ---
                    SqlCommand cmdTelCel = new SqlCommand("sp_ActualizarTelefonoEmpleado", cnn, tran);
                    cmdTelCel.CommandType = CommandType.StoredProcedure;
                    cmdTelCel.Parameters.AddWithValue("@idEmpleado", idEmpleado);
                    cmdTelCel.Parameters.AddWithValue("@telefono", txtTelCelular.Text);
                    cmdTelCel.Parameters.AddWithValue("@tipoTelefono", "Celular");
                    cmdTelCel.ExecuteNonQuery();

                    // --- 5. SI TODO SALIÓ BIEN, CONFIRMAR ---
                    tran.Commit();
                }
                catch (Exception)
                {
                    // 6. SI ALGO FALLÓ, REVERTIR TODO
                    tran.Rollback();
                    throw; // Re-lanza la excepción
                }
            }
        }

        /// <summary>
        /// Al hacer clic en una celda, carga la info de ese empleado en los campos del form.
        /// </summary>
        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Nos aseguramos de que no sea el renglón de Encabezado
            if (e.RowIndex < 0) return;

            try
            {
                int idEmpleado = Convert.ToInt32(dgvEmpleados.Rows[e.RowIndex].Cells["idEmpleado"].Value);

                using (SqlConnection cnn = dal.GetConnection())
                {
                    // Usamos el SP que acabamos de crear
                    SqlCommand cmd = new SqlCommand("sp_ConsultarEmpleadoPorID", cnn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idEmpleado", idEmpleado);

                    cnn.Open();
                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        txtIDEmpleado.Text = reader["idEmpleado"].ToString();

                        txtNombre.Text = reader["nombreCompleto"].ToString();
                        txtApellidoP.Text = ""; // Dejamos estos vacíos
                        txtApellidoM.Text = ""; // Dejamos estos vacíos

                        dtpFechaNacimiento.Value = Convert.ToDateTime(reader["fechaNac"]);
                        txtCURP.Text = reader["CURP"].ToString();
                        txtNSS.Text = reader["NSS"].ToString();
                        txtRFC.Text = reader["RFC"].ToString();
                        txtBanco.Text = reader["banco"].ToString();
                        txtNumCuenta.Text = reader["numCuenta"].ToString();
                        txtEmail.Text = reader["correo"].ToString();
                        txtCalle.Text = reader["calle"].ToString();
                        txtNumExt.Text = reader["numExt"].ToString();
                        txtNumInt.Text = reader["numInt"].ToString();
                        txtColonia.Text = reader["colonia"].ToString();
                        txtMunicipio.Text = reader["municipio"].ToString();
                        txtEstado.Text = reader["estado"].ToString();
                        txtCP.Text = reader["codigoPostal"].ToString();

                        cmbDepartamento.SelectedValue = Convert.ToInt32(reader["idDepartamento"]);
                        cmbPuesto.SelectedValue = Convert.ToInt32(reader["idPuesto"]);
                        numSalarioDiario.Value = Convert.ToDecimal(reader["salarioDiario"]);

                        txtTelCasa.Text = reader["telefonoCasa"].ToString();
                        txtTelCelular.Text = reader["telefonoCelular"].ToString();

                    }
                    reader.Close();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}