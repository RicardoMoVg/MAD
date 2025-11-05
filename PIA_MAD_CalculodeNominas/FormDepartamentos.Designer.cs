namespace PIA_MAD_CalculodeNominas
{
    partial class FormDepartamentos
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.lblTitulo = new System.Windows.Forms.Label();
            this.panelControles = new System.Windows.Forms.Panel();
            this.btnCancelar = new System.Windows.Forms.Button(); // NUEVO
            this.btnNuevo = new System.Windows.Forms.Button(); // NUEVO
            this.cmbJefeDepto = new System.Windows.Forms.ComboBox();
            this.lblJefeDepto = new System.Windows.Forms.Label();
            this.txtPresupuesto = new System.Windows.Forms.TextBox();
            this.lblPresupuesto = new System.Windows.Forms.Label();
            this.txtDescripcion = new System.Windows.Forms.TextBox();
            this.lblDescripcion = new System.Windows.Forms.Label();
            this.txtClaveDepto = new System.Windows.Forms.TextBox();
            this.lblClaveDepto = new System.Windows.Forms.Label();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnModificar = new System.Windows.Forms.Button(); // Renombrado (era btnEditar)
            this.btnGuardar = new System.Windows.Forms.Button(); // Renombrado (era btnAgregar)
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.dgvDepartamentos = new System.Windows.Forms.DataGridView();
            this.panelControles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(15, 16);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(306, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Catálogo de Departamentos";
            // 
            // panelControles
            // 
            this.panelControles.BackColor = System.Drawing.Color.Gainsboro;
            this.panelControles.Controls.Add(this.btnCancelar);
            this.panelControles.Controls.Add(this.btnNuevo);
            this.panelControles.Controls.Add(this.cmbJefeDepto);
            this.panelControles.Controls.Add(this.lblJefeDepto);
            this.panelControles.Controls.Add(this.txtPresupuesto);
            this.panelControles.Controls.Add(this.lblPresupuesto);
            this.panelControles.Controls.Add(this.txtDescripcion);
            this.panelControles.Controls.Add(this.lblDescripcion);
            this.panelControles.Controls.Add(this.txtClaveDepto);
            this.panelControles.Controls.Add(this.lblClaveDepto);
            this.panelControles.Controls.Add(this.btnImprimir);
            this.panelControles.Controls.Add(this.btnEliminar);
            this.panelControles.Controls.Add(this.btnModificar);
            this.panelControles.Controls.Add(this.btnGuardar);
            this.panelControles.Controls.Add(this.txtNombre);
            this.panelControles.Controls.Add(this.lblNombre);
            this.panelControles.Controls.Add(this.txtId);
            this.panelControles.Controls.Add(this.lblId);
            this.panelControles.Location = new System.Drawing.Point(15, 57);
            this.panelControles.Margin = new System.Windows.Forms.Padding(2);
            this.panelControles.Name = "panelControles";
            this.panelControles.Size = new System.Drawing.Size(210, 480); // Aumenté el tamaño
            this.panelControles.TabIndex = 1;
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.Gray; // NUEVO
            this.btnCancelar.FlatAppearance.BorderSize = 0;
            this.btnCancelar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.Color.White;
            this.btnCancelar.Location = new System.Drawing.Point(110, 390); // NUEVO
            this.btnCancelar.Margin = new System.Windows.Forms.Padding(2);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(86, 32);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click); // NUEVO EVENTO
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226))))); // NUEVO
            this.btnNuevo.FlatAppearance.BorderSize = 0;
            this.btnNuevo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.Color.White;
            this.btnNuevo.Location = new System.Drawing.Point(15, 317); // NUEVO
            this.btnNuevo.Margin = new System.Windows.Forms.Padding(2);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(180, 32);
            this.btnNuevo.TabIndex = 16;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click); // NUEVO EVENTO
            // 
            // cmbJefeDepto
            // 
            this.cmbJefeDepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbJefeDepto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbJefeDepto.FormattingEnabled = true;
            this.cmbJefeDepto.Location = new System.Drawing.Point(15, 175);
            this.cmbJefeDepto.Margin = new System.Windows.Forms.Padding(2);
            this.cmbJefeDepto.Name = "cmbJefeDepto";
            this.cmbJefeDepto.Size = new System.Drawing.Size(181, 27);
            this.cmbJefeDepto.TabIndex = 15;
            // 
            // lblJefeDepto
            // 
            this.lblJefeDepto.AutoSize = true;
            this.lblJefeDepto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblJefeDepto.Location = new System.Drawing.Point(12, 156);
            this.lblJefeDepto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblJefeDepto.Name = "lblJefeDepto";
            this.lblJefeDepto.Size = new System.Drawing.Size(125, 15);
            this.lblJefeDepto.TabIndex = 14;
            this.lblJefeDepto.Text = "Jefe de Departamento:";
            // 
            // txtPresupuesto
            // 
            this.txtPresupuesto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPresupuesto.Location = new System.Drawing.Point(15, 280);
            this.txtPresupuesto.Margin = new System.Windows.Forms.Padding(2);
            this.txtPresupuesto.Name = "txtPresupuesto";
            this.txtPresupuesto.Size = new System.Drawing.Size(181, 26);
            this.txtPresupuesto.TabIndex = 13;
            // 
            // lblPresupuesto
            // 
            this.lblPresupuesto.AutoSize = true;
            this.lblPresupuesto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPresupuesto.Location = new System.Drawing.Point(12, 262);
            this.lblPresupuesto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblPresupuesto.Name = "lblPresupuesto";
            this.lblPresupuesto.Size = new System.Drawing.Size(75, 15);
            this.lblPresupuesto.TabIndex = 12;
            this.lblPresupuesto.Text = "Presupuesto:";
            // 
            // txtDescripcion
            // 
            this.txtDescripcion.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDescripcion.Location = new System.Drawing.Point(15, 228);
            this.txtDescripcion.Margin = new System.Windows.Forms.Padding(2);
            this.txtDescripcion.Multiline = true;
            this.txtDescripcion.Name = "txtDescripcion";
            this.txtDescripcion.Size = new System.Drawing.Size(181, 32);
            this.txtDescripcion.TabIndex = 11;
            // 
            // lblDescripcion
            // 
            this.lblDescripcion.AutoSize = true;
            this.lblDescripcion.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDescripcion.Location = new System.Drawing.Point(12, 209);
            this.lblDescripcion.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblDescripcion.Name = "lblDescripcion";
            this.lblDescripcion.Size = new System.Drawing.Size(72, 15);
            this.lblDescripcion.TabIndex = 10;
            this.lblDescripcion.Text = "Descripción:";
            // 
            // txtClaveDepto
            // 
            this.txtClaveDepto.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtClaveDepto.Location = new System.Drawing.Point(15, 77);
            this.txtClaveDepto.Margin = new System.Windows.Forms.Padding(2);
            this.txtClaveDepto.Name = "txtClaveDepto";
            this.txtClaveDepto.Size = new System.Drawing.Size(181, 26);
            this.txtClaveDepto.TabIndex = 9;
            // 
            // lblClaveDepto
            // 
            this.lblClaveDepto.AutoSize = true;
            this.lblClaveDepto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblClaveDepto.Location = new System.Drawing.Point(12, 58);
            this.lblClaveDepto.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblClaveDepto.Name = "lblClaveDepto";
            this.lblClaveDepto.Size = new System.Drawing.Size(136, 15);
            this.lblClaveDepto.TabIndex = 8;
            this.lblClaveDepto.Text = "Clave del departamento:";
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.Gainsboro;
            this.btnImprimir.FlatAppearance.BorderSize = 0;
            this.btnImprimir.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.Color.Black;
            this.btnImprimir.Location = new System.Drawing.Point(15, 434); // Movido
            this.btnImprimir.Margin = new System.Windows.Forms.Padding(2);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(180, 32);
            this.btnImprimir.TabIndex = 7;
            this.btnImprimir.Text = "Imprimir Lista";
            this.btnImprimir.UseVisualStyleBackColor = false;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(74)))), ((int)(((byte)(74)))));
            this.btnEliminar.FlatAppearance.BorderSize = 0;
            this.btnEliminar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.Color.White;
            this.btnEliminar.Location = new System.Drawing.Point(15, 353); // Movido
            this.btnEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(86, 32); // Ajustado
            this.btnEliminar.TabIndex = 6;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // btnModificar
            // 
            this.btnModificar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(165)))), ((int)(((byte)(74)))));
            this.btnModificar.FlatAppearance.BorderSize = 0;
            this.btnModificar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnModificar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnModificar.ForeColor = System.Drawing.Color.White;
            this.btnModificar.Location = new System.Drawing.Point(110, 353); // Movido
            this.btnModificar.Margin = new System.Windows.Forms.Padding(2);
            this.btnModificar.Name = "btnModificar";
            this.btnModificar.Size = new System.Drawing.Size(86, 32); // Ajustado
            this.btnModificar.TabIndex = 5;
            this.btnModificar.Text = "Modificar"; // Renombrado
            this.btnModificar.UseVisualStyleBackColor = false;
            this.btnModificar.Click += new System.EventHandler(this.btnModificar_Click); // Evento cambiado
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(139)))), ((int)(((byte)(202))))); // Color cambiado
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(15, 390); // Movido
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(86, 32); // Ajustado
            this.btnGuardar.TabIndex = 4;
            this.btnGuardar.Text = "Guardar"; // Renombrado
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click); // Evento cambiado
            // 
            // txtNombre
            // 
            this.txtNombre.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombre.Location = new System.Drawing.Point(15, 126);
            this.txtNombre.Margin = new System.Windows.Forms.Padding(2);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(181, 26);
            this.txtNombre.TabIndex = 3;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombre.Location = new System.Drawing.Point(12, 107);
            this.lblNombre.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(152, 15);
            this.lblNombre.TabIndex = 2;
            this.lblNombre.Text = "Nombre del Departamento:";
            // 
            // txtId
            // 
            this.txtId.Enabled = false;
            this.txtId.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtId.Location = new System.Drawing.Point(15, 32);
            this.txtId.Margin = new System.Windows.Forms.Padding(2);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(181, 26);
            this.txtId.TabIndex = 1;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblId.Location = new System.Drawing.Point(12, 14);
            this.lblId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 15);
            this.lblId.TabIndex = 0;
            this.lblId.Text = "ID:";
            // 
            // dgvDepartamentos
            // 
            this.dgvDepartamentos.AllowUserToAddRows = false;
            this.dgvDepartamentos.AllowUserToDeleteRows = false;
            this.dgvDepartamentos.AllowUserToResizeRows = false;
            this.dgvDepartamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartamentos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDepartamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartamentos.Location = new System.Drawing.Point(240, 57);
            this.dgvDepartamentos.Margin = new System.Windows.Forms.Padding(2);
            this.dgvDepartamentos.MultiSelect = false; // Importante
            this.dgvDepartamentos.Name = "dgvDepartamentos";
            this.dgvDepartamentos.ReadOnly = true;
            this.dgvDepartamentos.RowHeadersWidth = 51;
            this.dgvDepartamentos.RowTemplate.Height = 24;
            this.dgvDepartamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect; // Importante
            this.dgvDepartamentos.Size = new System.Drawing.Size(525, 480); // Ajustado
            this.dgvDepartamentos.TabIndex = 2;
            this.dgvDepartamentos.SelectionChanged += new System.EventHandler(this.dgvDepartamentos_SelectionChanged); // NUEVO EVENTO
            // 
            // FormDepartamentos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(780, 550); // Ajustado
            this.Controls.Add(this.dgvDepartamentos);
            this.Controls.Add(this.panelControles);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormDepartamentos";
            this.Text = "FormDepartamentos";
            this.Load += new System.EventHandler(this.FormDepartamentos_Load);
            this.panelControles.ResumeLayout(false);
            this.panelControles.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelControles;
        private System.Windows.Forms.DataGridView dgvDepartamentos;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnGuardar; // Renombrado
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtClaveDepto;
        private System.Windows.Forms.Label lblClaveDepto;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox txtDescripcion;
        private System.Windows.Forms.Label lblDescripcion;
        private System.Windows.Forms.TextBox txtPresupuesto;
        private System.Windows.Forms.Label lblPresupuesto;
        private System.Windows.Forms.ComboBox cmbJefeDepto;
        private System.Windows.Forms.Label lblJefeDepto;
        private System.Windows.Forms.Button btnModificar; // Renombrado
        private System.Windows.Forms.Button btnCancelar; // NUEVO
        private System.Windows.Forms.Button btnNuevo; // NUEVO
    }
}