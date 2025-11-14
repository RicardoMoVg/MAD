namespace PIA_MAD_CalculodeNominas
{
    partial class FormIncidencias
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
            this.dgvFaltasRegistradas = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnEliminarIncidencia = new System.Windows.Forms.Button();
            this.numMonto = new System.Windows.Forms.NumericUpDown();
            this.lblMonto = new System.Windows.Forms.Label();
            this.cmbConcepto = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnRegistrarIncidencia = new System.Windows.Forms.Button();
            this.dtpFechaFalta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbPeriodo = new System.Windows.Forms.ComboBox();
            this.lblDeptoID = new System.Windows.Forms.Label();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.pnlBody.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaltasRegistradas)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(267, 738);
            this.pnlSide.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlBody);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(267, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1045, 738);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlBody
            // 
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.dgvFaltasRegistradas);
            this.pnlBody.Controls.Add(this.label3);
            this.pnlBody.Controls.Add(this.panel1);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 74);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(27, 25, 27, 25);
            this.pnlBody.Size = new System.Drawing.Size(1045, 590);
            this.pnlBody.TabIndex = 1;
            // 
            // dgvFaltasRegistradas
            // 
            this.dgvFaltasRegistradas.AllowUserToAddRows = false;
            this.dgvFaltasRegistradas.AllowUserToDeleteRows = false;
            this.dgvFaltasRegistradas.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFaltasRegistradas.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvFaltasRegistradas.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvFaltasRegistradas.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFaltasRegistradas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFaltasRegistradas.Location = new System.Drawing.Point(27, 278);
            this.dgvFaltasRegistradas.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvFaltasRegistradas.MultiSelect = false;
            this.dgvFaltasRegistradas.Name = "dgvFaltasRegistradas";
            this.dgvFaltasRegistradas.ReadOnly = true;
            this.dgvFaltasRegistradas.RowHeadersVisible = false;
            this.dgvFaltasRegistradas.RowHeadersWidth = 51;
            this.dgvFaltasRegistradas.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFaltasRegistradas.Size = new System.Drawing.Size(991, 287);
            this.dgvFaltasRegistradas.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Top;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(27, 243);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(0, 12, 0, 0);
            this.label3.Size = new System.Drawing.Size(195, 35);
            this.label3.TabIndex = 1;
            this.label3.Text = "Incidencias Registradas";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnEliminarIncidencia);
            this.panel1.Controls.Add(this.numMonto);
            this.panel1.Controls.Add(this.lblMonto);
            this.panel1.Controls.Add(this.cmbConcepto);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Controls.Add(this.btnRegistrarIncidencia);
            this.panel1.Controls.Add(this.dtpFechaFalta);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cmbEmpleado);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cmbPeriodo);
            this.panel1.Controls.Add(this.lblDeptoID);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(27, 25);
            this.panel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(991, 218);
            this.panel1.TabIndex = 0;
            // 
            // btnEliminarIncidencia
            // 
            this.btnEliminarIncidencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.btnEliminarIncidencia.FlatAppearance.BorderSize = 0;
            this.btnEliminarIncidencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEliminarIncidencia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminarIncidencia.ForeColor = System.Drawing.Color.White;
            this.btnEliminarIncidencia.Location = new System.Drawing.Point(611, 161);
            this.btnEliminarIncidencia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnEliminarIncidencia.Name = "btnEliminarIncidencia";
            this.btnEliminarIncidencia.Size = new System.Drawing.Size(187, 42);
            this.btnEliminarIncidencia.TabIndex = 11;
            this.btnEliminarIncidencia.Text = "Eliminar";
            this.btnEliminarIncidencia.UseVisualStyleBackColor = false;
            this.btnEliminarIncidencia.Click += new System.EventHandler(this.btnEliminarIncidencia_Click);
            // 
            // numMonto
            // 
            this.numMonto.DecimalPlaces = 2;
            this.numMonto.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.numMonto.Location = new System.Drawing.Point(608, 118);
            this.numMonto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numMonto.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numMonto.Name = "numMonto";
            this.numMonto.Size = new System.Drawing.Size(160, 29);
            this.numMonto.TabIndex = 5;
            // 
            // lblMonto
            // 
            this.lblMonto.AutoSize = true;
            this.lblMonto.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblMonto.Location = new System.Drawing.Point(535, 121);
            this.lblMonto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMonto.Name = "lblMonto";
            this.lblMonto.Size = new System.Drawing.Size(65, 23);
            this.lblMonto.TabIndex = 9;
            this.lblMonto.Text = "Monto:";
            // 
            // cmbConcepto
            // 
            this.cmbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcepto.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbConcepto.FormattingEnabled = true;
            this.cmbConcepto.Location = new System.Drawing.Point(164, 117);
            this.cmbConcepto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbConcepto.Name = "cmbConcepto";
            this.cmbConcepto.Size = new System.Drawing.Size(345, 29);
            this.cmbConcepto.TabIndex = 4;
            this.cmbConcepto.DropDown += new System.EventHandler(this.cmbConcepto_DropDown);
            this.cmbConcepto.SelectedIndexChanged += new System.EventHandler(this.cmbConcepto_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label7.Location = new System.Drawing.Point(19, 121);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 23);
            this.label7.TabIndex = 7;
            this.label7.Text = "Concepto:";
            // 
            // btnRegistrarIncidencia
            // 
            this.btnRegistrarIncidencia.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnRegistrarIncidencia.FlatAppearance.BorderSize = 0;
            this.btnRegistrarIncidencia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegistrarIncidencia.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegistrarIncidencia.ForeColor = System.Drawing.Color.White;
            this.btnRegistrarIncidencia.Location = new System.Drawing.Point(805, 161);
            this.btnRegistrarIncidencia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnRegistrarIncidencia.Name = "btnRegistrarIncidencia";
            this.btnRegistrarIncidencia.Size = new System.Drawing.Size(187, 42);
            this.btnRegistrarIncidencia.TabIndex = 6;
            this.btnRegistrarIncidencia.Text = "Registrar";
            this.btnRegistrarIncidencia.UseVisualStyleBackColor = false;
            this.btnRegistrarIncidencia.Click += new System.EventHandler(this.btnRegistrarIncidencia_Click);
            // 
            // dtpFechaFalta
            // 
            this.dtpFechaFalta.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.dtpFechaFalta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaFalta.Location = new System.Drawing.Point(164, 169);
            this.dtpFechaFalta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFechaFalta.Name = "dtpFechaFalta";
            this.dtpFechaFalta.Size = new System.Drawing.Size(345, 29);
            this.dtpFechaFalta.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label2.Location = new System.Drawing.Point(19, 174);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 23);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fecha:";
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpleado.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(164, 66);
            this.cmbEmpleado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(345, 29);
            this.cmbEmpleado.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.label1.Location = new System.Drawing.Point(19, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 23);
            this.label1.TabIndex = 2;
            this.label1.Text = "Empleado:";
            // 
            // cmbPeriodo
            // 
            this.cmbPeriodo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPeriodo.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.cmbPeriodo.FormattingEnabled = true;
            this.cmbPeriodo.Location = new System.Drawing.Point(164, 17);
            this.cmbPeriodo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPeriodo.Name = "cmbPeriodo";
            this.cmbPeriodo.Size = new System.Drawing.Size(345, 29);
            this.cmbPeriodo.TabIndex = 1;
            this.cmbPeriodo.SelectedIndexChanged += new System.EventHandler(this.cmbPeriodo_SelectedIndexChanged);
            // 
            // lblDeptoID
            // 
            this.lblDeptoID.AutoSize = true;
            this.lblDeptoID.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.lblDeptoID.Location = new System.Drawing.Point(19, 21);
            this.lblDeptoID.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDeptoID.Name = "lblDeptoID";
            this.lblDeptoID.Size = new System.Drawing.Size(133, 23);
            this.lblDeptoID.TabIndex = 0;
            this.lblDeptoID.Text = "Periodo Abierto:";
            // 
            // pnlHeader
            // 
            this.pnlHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(66)))), ((int)(((byte)(91)))));
            this.pnlHeader.Controls.Add(this.lblTitulo);
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1045, 74);
            this.pnlHeader.TabIndex = 0;
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 15.75F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.ForeColor = System.Drawing.Color.White;
            this.lblTitulo.Location = new System.Drawing.Point(16, 18);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(313, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Registro de Incidencias";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 664);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1045, 74);
            this.pnlFooter.TabIndex = 2;
            // 
            // FormIncidencias
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 738);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSide);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1061, 605);
            this.Name = "FormIncidencias";
            this.Text = "Incidencias";
            this.Load += new System.EventHandler(this.FormIncidencias_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.pnlBody.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFaltasRegistradas)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).EndInit();
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
        private System.Windows.Forms.DataGridView dgvFaltasRegistradas;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnRegistrarIncidencia;
        private System.Windows.Forms.DateTimePicker dtpFechaFalta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbPeriodo;
        private System.Windows.Forms.Label lblDeptoID;
        private System.Windows.Forms.ComboBox cmbConcepto;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.NumericUpDown numMonto;
        private System.Windows.Forms.Label lblMonto;
        private System.Windows.Forms.Button btnEliminarIncidencia;
    }
}