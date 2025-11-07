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

        private void CargarEmpleados()
        {
            // Lógica para llenar el dgvEmpleados
            // Query: SELECT ID_Empleado, Nombre, ApellidoPaterno, RFC FROM Empleados WHERE Estatus = 1
            // ...
            // dgvEmpleados.DataSource = dataTable;
            Console.WriteLine("Cargando empleados en el DataGridView...");
        }

        private void CargarComboBoxes()
        {
            // Lógica para llenar cmbDepartamento y cmbPuesto
            // Query: SELECT ID_Departamento, NombreDepartamento FROM Departamentos
            // ...
            // cmbDepartamento.DataSource = dataTableDeptos;
            // cmbDepartamento.ValueMember = "ID_Departamento";
            // cmbDepartamento.DisplayMember = "NombreDepartamento";
            Console.WriteLine("Cargando catálogos (Departamentos, Puestos)...");
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            // Aquí va la lógica de INSERT o UPDATE
            // ¡¡¡USA SIEMPRE PARÁMETROS PARA EVITAR SQL INJECTION!!!

            try
            {
                // 2. Usar la instancia 'dal' para llamar a 'GetConnection()'
                using (SqlConnection cnn = dal.GetConnection())
                {
                    string query = "";

                    // Si el txtIDEmpleado está vacío, es un INSERT
                    if (string.IsNullOrEmpty(txtIDEmpleado.Text))
                    {
                        query = @"INSERT INTO Empleados (Nombre, ApellidoPaterno, ..., RFC) 
                          VALUES (@Nombre, @ApellidoPaterno, ..., @RFC)";
                        // Falta implementar el hash de la contraseña aquí
                    }
                    else // Si tiene ID, es un UPDATE
                    {
                        query = @"UPDATE Empleados SET Nombre = @Nombre, ApellidoPaterno = @ApellidoPaterno, 
                          ..., RFC = @RFC WHERE ID_Empleado = @ID_Empleado";
                    }

                    using (SqlCommand cmd = new SqlCommand(query, cnn))
                    {
                        // Añadir parámetros
                        cmd.Parameters.AddWithValue("@Nombre", txtNombre.Text);
                        cmd.Parameters.AddWithValue("@ApellidoPaterno", txtApellidoP.Text);
                        cmd.Parameters.AddWithValue("@RFC", txtRFC.Text);
                        // ... añadir TODOS los demás parámetros ...

                        if (!string.IsNullOrEmpty(txtIDEmpleado.Text))
                        {
                            cmd.Parameters.AddWithValue("@ID_Empleado", Convert.ToInt32(txtIDEmpleado.Text));
                        }

                        // 3. ¡IMPORTANTE! Abrir la conexión manualmente
                        cnn.Open();

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("¡Empleado guardado exitosamente!");

                        // Recargamos la tabla para ver los cambios
                        CargarEmpleados();
                    }
                }
            }
            catch (SqlException ex) // Esto ya no dará error gracias al 'using'
            {
                MessageBox.Show("Error al guardar en la BD: " + ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error inesperado: " + ex.Message);
            }
        }

        private void dgvEmpleados_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Lógica para cuando el usuario hace clic en una fila del DataGridView
            // 1. Obtener el ID_Empleado de la fila seleccionada
            //    int idSeleccionado = Convert.ToInt32(dgvEmpleados.CurrentRow.Cells["ID_Empleado"].Value);

            // 2. Hacer un SELECT * FROM Empleados WHERE ID_Empleado = idSeleccionado

            // 3. Llenar todos los TextBoxes, ComboBoxes, etc., con los datos del empleado
            //    txtIDEmpleado.Text = ...
            //    txtNombre.Text = ...
            //    cmbDepartamento.SelectedValue = ...
        }
    }
}