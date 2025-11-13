namespace PIA_MAD_CalculodeNominas
{
    partial class FormCatalogos
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
            this.pnlSide = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.gbPuestos = new System.Windows.Forms.GroupBox();
            this.dgvPuestos = new System.Windows.Forms.DataGridView();
            this.pnlPuestosFields = new System.Windows.Forms.Panel();
            this.btnPuestoBaja = new System.Windows.Forms.Button();
            this.btnPuestoGuardar = new System.Windows.Forms.Button();
            this.btnPuestoLimpiar = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPuestoDescripcion = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPuestoNombre = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPuestoCodigo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPuestoID = new System.Windows.Forms.TextBox();
            this.gbDepartamentos = new System.Windows.Forms.GroupBox();
            this.dgvDepartamentos = new System.Windows.Forms.DataGridView();
            this.pnlDeptoFields = new System.Windows.Forms.Panel();
            this.btnDeptoBaja = new System.Windows.Forms.Button();
            this.btnDeptoGuardar = new System.Windows.Forms.Button();
            this.btnDeptoLimpiar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDeptoNombre = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDeptoCodigo = new System.Windows.Forms.TextBox();
            this.lblDeptoID = new System.Windows.Forms.Label();
            this.txtDeptoID = new System.Windows.Forms.TextBox();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.gbPuestos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuestos)).BeginInit();
            this.pnlPuestosFields.SuspendLayout();
            this.gbDepartamentos.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).BeginInit();
            this.pnlDeptoFields.SuspendLayout();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(200, 661);
            this.pnlSide.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlBody);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(200, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(784, 661);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.gbPuestos);
            this.pnlBody.Controls.Add(this.gbDepartamentos);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 60);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(10);
            this.pnlBody.Size = new System.Drawing.Size(784, 483);
            this.pnlBody.TabIndex = 1;
            // 
            // gbPuestos
            // 
            this.gbPuestos.Controls.Add(this.dgvPuestos);
            this.gbPuestos.Controls.Add(this.pnlPuestosFields);
            this.gbPuestos.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbPuestos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbPuestos.Location = new System.Drawing.Point(10, 231);
            this.gbPuestos.Name = "gbPuestos";
            this.gbPuestos.Padding = new System.Windows.Forms.Padding(10);
            this.gbPuestos.Size = new System.Drawing.Size(747, 330);
            this.gbPuestos.TabIndex = 1;
            this.gbPuestos.TabStop = false;
            this.gbPuestos.Text = "Puestos";
            // 
            // dgvPuestos
            // 
            this.dgvPuestos.AllowUserToAddRows = false;
            this.dgvPuestos.AllowUserToDeleteRows = false;
            this.dgvPuestos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvPuestos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvPuestos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvPuestos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPuestos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPuestos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvPuestos.Location = new System.Drawing.Point(754, 28);
            this.dgvPuestos.MultiSelect = false;
            this.dgvPuestos.Name = "dgvPuestos";
            this.dgvPuestos.ReadOnly = true;
            this.dgvPuestos.RowHeadersVisible = false;
            this.dgvPuestos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPuestos.Size = new System.Drawing.Size(0, 292);
            this.dgvPuestos.TabIndex = 3;
            this.dgvPuestos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvPuestos_CellClick);
            // 
            // pnlPuestosFields
            // 
            this.pnlPuestosFields.Controls.Add(this.btnPuestoBaja);
            this.pnlPuestosFields.Controls.Add(this.btnPuestoGuardar);
            this.pnlPuestosFields.Controls.Add(this.btnPuestoLimpiar);
            this.pnlPuestosFields.Controls.Add(this.label6);
            this.pnlPuestosFields.Controls.Add(this.txtPuestoDescripcion);
            this.pnlPuestosFields.Controls.Add(this.label3);
            this.pnlPuestosFields.Controls.Add(this.txtPuestoNombre);
            this.pnlPuestosFields.Controls.Add(this.label4);
            this.pnlPuestosFields.Controls.Add(this.txtPuestoCodigo);
            this.pnlPuestosFields.Controls.Add(this.label5);
            this.pnlPuestosFields.Controls.Add(this.txtPuestoID);
            this.pnlPuestosFields.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlPuestosFields.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlPuestosFields.Location = new System.Drawing.Point(10, 28);
            this.pnlPuestosFields.Name = "pnlPuestosFields";
            this.pnlPuestosFields.Size = new System.Drawing.Size(744, 292);
            this.pnlPuestosFields.TabIndex = 2;
            // 
            // btnPuestoBaja
            // 
            this.btnPuestoBaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.btnPuestoBaja.FlatAppearance.BorderSize = 0;
            this.btnPuestoBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPuestoBaja.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPuestoBaja.ForeColor = System.Drawing.Color.White;
            this.btnPuestoBaja.Location = new System.Drawing.Point(649, 135);
            this.btnPuestoBaja.Name = "btnPuestoBaja";
            this.btnPuestoBaja.Size = new System.Drawing.Size(75, 30);
            this.btnPuestoBaja.TabIndex = 10;
            this.btnPuestoBaja.Text = "Eliminar";
            this.btnPuestoBaja.UseVisualStyleBackColor = false;
            this.btnPuestoBaja.Click += new System.EventHandler(this.btnPuestoBaja_Click);
            // 
            // btnPuestoGuardar
            // 
            this.btnPuestoGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnPuestoGuardar.FlatAppearance.BorderSize = 0;
            this.btnPuestoGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPuestoGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPuestoGuardar.ForeColor = System.Drawing.Color.White;
            this.btnPuestoGuardar.Location = new System.Drawing.Point(649, 94);
            this.btnPuestoGuardar.Name = "btnPuestoGuardar";
            this.btnPuestoGuardar.Size = new System.Drawing.Size(75, 30);
            this.btnPuestoGuardar.TabIndex = 9;
            this.btnPuestoGuardar.Text = "Guardar";
            this.btnPuestoGuardar.UseVisualStyleBackColor = false;
            this.btnPuestoGuardar.Click += new System.EventHandler(this.btnPuestoGuardar_Click);
            // 
            // btnPuestoLimpiar
            // 
            this.btnPuestoLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnPuestoLimpiar.FlatAppearance.BorderSize = 0;
            this.btnPuestoLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPuestoLimpiar.Location = new System.Drawing.Point(649, 50);
            this.btnPuestoLimpiar.Name = "btnPuestoLimpiar";
            this.btnPuestoLimpiar.Size = new System.Drawing.Size(75, 30);
            this.btnPuestoLimpiar.TabIndex = 8;
            this.btnPuestoLimpiar.Text = "Nuevo";
            this.btnPuestoLimpiar.UseVisualStyleBackColor = false;
            this.btnPuestoLimpiar.Click += new System.EventHandler(this.btnPuestoLimpiar_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 117);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 15);
            this.label6.TabIndex = 6;
            this.label6.Text = "Descripción:";
            // 
            // txtPuestoDescripcion
            // 
            this.txtPuestoDescripcion.Location = new System.Drawing.Point(4, 135);
            this.txtPuestoDescripcion.Multiline = true;
            this.txtPuestoDescripcion.Name = "txtPuestoDescripcion";
            this.txtPuestoDescripcion.Size = new System.Drawing.Size(237, 53);
            this.txtPuestoDescripcion.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 73);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 15);
            this.label3.TabIndex = 4;
            this.label3.Text = "Nombre:";
            // 
            // txtPuestoNombre
            // 
            this.txtPuestoNombre.Location = new System.Drawing.Point(4, 91);
            this.txtPuestoNombre.Name = "txtPuestoNombre";
            this.txtPuestoNombre.Size = new System.Drawing.Size(237, 23);
            this.txtPuestoNombre.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(90, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 15);
            this.label4.TabIndex = 2;
            this.label4.Text = "Código:";
            // 
            // txtPuestoCodigo
            // 
            this.txtPuestoCodigo.Location = new System.Drawing.Point(90, 47);
            this.txtPuestoCodigo.Name = "txtPuestoCodigo";
            this.txtPuestoCodigo.Size = new System.Drawing.Size(151, 23);
            this.txtPuestoCodigo.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 15);
            this.label5.TabIndex = 0;
            this.label5.Text = "ID:";
            // 
            // txtPuestoID
            // 
            this.txtPuestoID.Location = new System.Drawing.Point(4, 47);
            this.txtPuestoID.Name = "txtPuestoID";
            this.txtPuestoID.ReadOnly = true;
            this.txtPuestoID.Size = new System.Drawing.Size(70, 23);
            this.txtPuestoID.TabIndex = 1;
            // 
            // gbDepartamentos
            // 
            this.gbDepartamentos.Controls.Add(this.dgvDepartamentos);
            this.gbDepartamentos.Controls.Add(this.pnlDeptoFields);
            this.gbDepartamentos.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbDepartamentos.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbDepartamentos.Location = new System.Drawing.Point(10, 10);
            this.gbDepartamentos.Name = "gbDepartamentos";
            this.gbDepartamentos.Padding = new System.Windows.Forms.Padding(10);
            this.gbDepartamentos.Size = new System.Drawing.Size(747, 221);
            this.gbDepartamentos.TabIndex = 0;
            this.gbDepartamentos.TabStop = false;
            this.gbDepartamentos.Text = "Departamentos";
            // 
            // dgvDepartamentos
            // 
            this.dgvDepartamentos.AllowUserToAddRows = false;
            this.dgvDepartamentos.AllowUserToDeleteRows = false;
            this.dgvDepartamentos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDepartamentos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvDepartamentos.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDepartamentos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartamentos.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepartamentos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dgvDepartamentos.Location = new System.Drawing.Point(751, 28);
            this.dgvDepartamentos.MultiSelect = false;
            this.dgvDepartamentos.Name = "dgvDepartamentos";
            this.dgvDepartamentos.ReadOnly = true;
            this.dgvDepartamentos.RowHeadersVisible = false;
            this.dgvDepartamentos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartamentos.Size = new System.Drawing.Size(0, 183);
            this.dgvDepartamentos.TabIndex = 1;
            this.dgvDepartamentos.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDepartamentos_CellClick);
            // 
            // pnlDeptoFields
            // 
            this.pnlDeptoFields.Controls.Add(this.btnDeptoBaja);
            this.pnlDeptoFields.Controls.Add(this.btnDeptoGuardar);
            this.pnlDeptoFields.Controls.Add(this.btnDeptoLimpiar);
            this.pnlDeptoFields.Controls.Add(this.label2);
            this.pnlDeptoFields.Controls.Add(this.txtDeptoNombre);
            this.pnlDeptoFields.Controls.Add(this.label1);
            this.pnlDeptoFields.Controls.Add(this.txtDeptoCodigo);
            this.pnlDeptoFields.Controls.Add(this.lblDeptoID);
            this.pnlDeptoFields.Controls.Add(this.txtDeptoID);
            this.pnlDeptoFields.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlDeptoFields.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pnlDeptoFields.Location = new System.Drawing.Point(10, 28);
            this.pnlDeptoFields.Name = "pnlDeptoFields";
            this.pnlDeptoFields.Size = new System.Drawing.Size(741, 183);
            this.pnlDeptoFields.TabIndex = 0;
            // 
            // btnDeptoBaja
            // 
            this.btnDeptoBaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.btnDeptoBaja.FlatAppearance.BorderSize = 0;
            this.btnDeptoBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeptoBaja.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeptoBaja.ForeColor = System.Drawing.Color.White;
            this.btnDeptoBaja.Location = new System.Drawing.Point(649, 118);
            this.btnDeptoBaja.Name = "btnDeptoBaja";
            this.btnDeptoBaja.Size = new System.Drawing.Size(75, 30);
            this.btnDeptoBaja.TabIndex = 8;
            this.btnDeptoBaja.Text = "Eliminar";
            this.btnDeptoBaja.UseVisualStyleBackColor = false;
            this.btnDeptoBaja.Click += new System.EventHandler(this.btnDeptoBaja_Click);
            // 
            // btnDeptoGuardar
            // 
            this.btnDeptoGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnDeptoGuardar.FlatAppearance.BorderSize = 0;
            this.btnDeptoGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeptoGuardar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDeptoGuardar.ForeColor = System.Drawing.Color.White;
            this.btnDeptoGuardar.Location = new System.Drawing.Point(649, 73);
            this.btnDeptoGuardar.Name = "btnDeptoGuardar";
            this.btnDeptoGuardar.Size = new System.Drawing.Size(75, 30);
            this.btnDeptoGuardar.TabIndex = 7;
            this.btnDeptoGuardar.Text = "Guardar";
            this.btnDeptoGuardar.UseVisualStyleBackColor = false;
            this.btnDeptoGuardar.Click += new System.EventHandler(this.btnDeptoGuardar_Click);
            // 
            // btnDeptoLimpiar
            // 
            this.btnDeptoLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnDeptoLimpiar.FlatAppearance.BorderSize = 0;
            this.btnDeptoLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeptoLimpiar.Location = new System.Drawing.Point(649, 26);
            this.btnDeptoLimpiar.Name = "btnDeptoLimpiar";
            this.btnDeptoLimpiar.Size = new System.Drawing.Size(75, 30);
            this.btnDeptoLimpiar.TabIndex = 6;
            this.btnDeptoLimpiar.Text = "Nuevo";
            this.btnDeptoLimpiar.UseVisualStyleBackColor = false;
            this.btnDeptoLimpiar.Click += new System.EventHandler(this.btnDeptoLimpiar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 73);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Nombre:";
            // 
            // txtDeptoNombre
            // 
            this.txtDeptoNombre.Location = new System.Drawing.Point(4, 91);
            this.txtDeptoNombre.Name = "txtDeptoNombre";
            this.txtDeptoNombre.Size = new System.Drawing.Size(237, 23);
            this.txtDeptoNombre.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(90, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "Código:";
            // 
            // txtDeptoCodigo
            // 
            this.txtDeptoCodigo.Location = new System.Drawing.Point(90, 47);
            this.txtDeptoCodigo.Name = "txtDeptoCodigo";
            this.txtDeptoCodigo.Size = new System.Drawing.Size(151, 23);
            this.txtDeptoCodigo.TabIndex = 3;
            // 
            // lblDeptoID
            // 
            this.lblDeptoID.AutoSize = true;
            this.lblDeptoID.Location = new System.Drawing.Point(4, 29);
            this.lblDeptoID.Name = "lblDeptoID";
            this.lblDeptoID.Size = new System.Drawing.Size(21, 15);
            this.lblDeptoID.TabIndex = 0;
            this.lblDeptoID.Text = "ID:";
            // 
            // txtDeptoID
            // 
            this.txtDeptoID.Location = new System.Drawing.Point(4, 47);
            this.txtDeptoID.Name = "txtDeptoID";
            this.txtDeptoID.ReadOnly = true;
            this.txtDeptoID.Size = new System.Drawing.Size(70, 23);
            this.txtDeptoID.TabIndex = 1;
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(784, 60);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(12, 15);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(306, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Catálogos (Deptos. y Puestos)";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 543);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(784, 118);
            this.pnlFooter.TabIndex = 2;
            // 
            // FormCatalogos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSide);
            this.MinimumSize = new System.Drawing.Size(800, 700);
            this.Name = "FormCatalogos";
            this.Text = "Catálogos";
            this.Load += new System.EventHandler(this.FormCatalogos_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.gbPuestos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPuestos)).EndInit();
            this.pnlPuestosFields.ResumeLayout(false);
            this.pnlPuestosFields.PerformLayout();
            this.gbDepartamentos.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartamentos)).EndInit();
            this.pnlDeptoFields.ResumeLayout(false);
            this.pnlDeptoFields.PerformLayout();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.TabControl tabCatalogos;
        private System.Windows.Forms.TabPage tabDepartamentos;
        private System.Windows.Forms.TabPage tabPuestos;
        private System.Windows.Forms.DataGridView dgvDepartamentos;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDeptoNombre;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDeptoCodigo;
        private System.Windows.Forms.Label lblDeptoID;
        private System.Windows.Forms.TextBox txtDeptoID;
        private System.Windows.Forms.DataGridView dgvPuestos;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPuestoDescripcion;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPuestoNombre;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPuestoCodigo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPuestoID;
        private System.Windows.Forms.GroupBox gbDepartamentos;
        private System.Windows.Forms.Panel pnlDeptoFields;
        private System.Windows.Forms.Button btnDeptoBaja;
        private System.Windows.Forms.Button btnDeptoGuardar;
        private System.Windows.Forms.Button btnDeptoLimpiar;
        private System.Windows.Forms.GroupBox gbPuestos;
        private System.Windows.Forms.Panel pnlPuestosFields;
        private System.Windows.Forms.Button btnPuestoBaja;
        private System.Windows.Forms.Button btnPuestoGuardar;
        private System.Windows.Forms.Button btnPuestoLimpiar;
        // --- Controles de la versión con Tabs, ahora eliminados ---
        // private System.Windows.Forms.Button btnDarDeBaja;
        // private System.Windows.Forms.Button btnGuardar;
        // private System.Windows.Forms.Button btnLimpiar;
    }
}