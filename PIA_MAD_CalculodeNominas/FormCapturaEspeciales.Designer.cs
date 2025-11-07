namespace PIA_MAD_CalculodeNominas
{
    partial class FormCapturaEspeciales
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
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.lblAnio = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.cmbEmpleado = new System.Windows.Forms.ComboBox();
            this.lblEmpleado = new System.Windows.Forms.Label();
            this.dgvConceptos = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.numMonto = new System.Windows.Forms.NumericUpDown();
            this.lblValor = new System.Windows.Forms.Label();
            this.rbPorcentaje = new System.Windows.Forms.RadioButton();
            this.rbMontoFijo = new System.Windows.Forms.RadioButton();
            this.cmbConcepto = new System.Windows.Forms.ComboBox();
            this.lblConcepto = new System.Windows.Forms.Label();
            this.lblSubtitulo = new System.Windows.Forms.Label();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold);
            this.lblTitulo.Location = new System.Drawing.Point(22, 18);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(534, 38);
            this.lblTitulo.TabIndex = 1;
            this.lblTitulo.Text = "Captura de Conceptos Programados";
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.Gainsboro;
            this.panelFiltros.Controls.Add(this.cmbAnio);
            this.panelFiltros.Controls.Add(this.lblAnio);
            this.panelFiltros.Controls.Add(this.cmbMes);
            this.panelFiltros.Controls.Add(this.lblMes);
            this.panelFiltros.Controls.Add(this.cmbEmpleado);
            this.panelFiltros.Controls.Add(this.lblEmpleado);
            this.panelFiltros.Location = new System.Drawing.Point(29, 71);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(941, 60);
            this.panelFiltros.TabIndex = 2;
            // 
            // cmbAnio
            // 
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(796, 15);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(121, 31);
            this.cmbAnio.TabIndex = 5;
            this.cmbAnio.SelectedIndexChanged += new System.EventHandler(this.Filtro_SelectedIndexChanged);
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAnio.Location = new System.Drawing.Point(751, 19);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(39, 20);
            this.lblAnio.TabIndex = 4;
            this.lblAnio.Text = "Año:";
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(588, 15);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(147, 31);
            this.cmbMes.TabIndex = 3;
            this.cmbMes.SelectedIndexChanged += new System.EventHandler(this.Filtro_SelectedIndexChanged);
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMes.Location = new System.Drawing.Point(543, 19);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(39, 20);
            this.lblMes.TabIndex = 2;
            this.lblMes.Text = "Mes:";
            // 
            // cmbEmpleado
            // 
            this.cmbEmpleado.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbEmpleado.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmbEmpleado.FormattingEnabled = true;
            this.cmbEmpleado.Location = new System.Drawing.Point(105, 15);
            this.cmbEmpleado.Name = "cmbEmpleado";
            this.cmbEmpleado.Size = new System.Drawing.Size(419, 31);
            this.cmbEmpleado.TabIndex = 1;
            this.cmbEmpleado.SelectedIndexChanged += new System.EventHandler(this.Filtro_SelectedIndexChanged);
            // 
            // lblEmpleado
            // 
            this.lblEmpleado.AutoSize = true;
            this.lblEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEmpleado.Location = new System.Drawing.Point(18, 19);
            this.lblEmpleado.Name = "lblEmpleado";
            this.lblEmpleado.Size = new System.Drawing.Size(81, 20);
            this.lblEmpleado.TabIndex = 0;
            this.lblEmpleado.Text = "Empleado:";
            // 
            // dgvConceptos
            // 
            this.dgvConceptos.AllowUserToAddRows = false;
            this.dgvConceptos.AllowUserToDeleteRows = false;
            this.dgvConceptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConceptos.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptos.Location = new System.Drawing.Point(401, 185);
            this.dgvConceptos.Name = "dgvConceptos";
            this.dgvConceptos.ReadOnly = true;
            this.dgvConceptos.RowHeadersWidth = 51;
            this.dgvConceptos.RowTemplate.Height = 24;
            this.dgvConceptos.Size = new System.Drawing.Size(569, 361);
            this.dgvConceptos.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnGuardar);
            this.groupBox1.Controls.Add(this.numMonto);
            this.groupBox1.Controls.Add(this.lblValor);
            this.groupBox1.Controls.Add(this.rbPorcentaje);
            this.groupBox1.Controls.Add(this.rbMontoFijo);
            this.groupBox1.Controls.Add(this.cmbConcepto);
            this.groupBox1.Controls.Add(this.lblConcepto);
            this.groupBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.groupBox1.Location = new System.Drawing.Point(29, 166);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(350, 380);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Agregar Nuevo Concepto";
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(27, 305);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(296, 47);
            this.btnGuardar.TabIndex = 6;
            this.btnGuardar.Text = "Guardar Concepto";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // numMonto
            // 
            this.numMonto.DecimalPlaces = 2;
            this.numMonto.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.numMonto.Location = new System.Drawing.Point(27, 227);
            this.numMonto.Maximum = new decimal(new int[] {
            1000000,
            0,
            0,
            0});
            this.numMonto.Name = "numMonto";
            this.numMonto.Size = new System.Drawing.Size(296, 30);
            this.numMonto.TabIndex = 5;
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblValor.Location = new System.Drawing.Point(23, 204);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(55, 20);
            this.lblValor.TabIndex = 4;
            this.lblValor.Text = "Monto:";
            // 
            // rbPorcentaje
            // 
            this.rbPorcentaje.AutoSize = true;
            this.rbPorcentaje.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbPorcentaje.Location = new System.Drawing.Point(173, 148);
            this.rbPorcentaje.Name = "rbPorcentaje";
            this.rbPorcentaje.Size = new System.Drawing.Size(150, 24);
            this.rbPorcentaje.TabIndex = 3;
            this.rbPorcentaje.Text = "Porcentaje (Sobre Bruto)";
            this.rbPorcentaje.UseVisualStyleBackColor = true;
            this.rbPorcentaje.CheckedChanged += new System.EventHandler(this.rbTipoCalculo_CheckedChanged);
            // 
            // rbMontoFijo
            // 
            this.rbMontoFijo.AutoSize = true;
            this.rbMontoFijo.Checked = true;
            this.rbMontoFijo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.rbMontoFijo.Location = new System.Drawing.Point(27, 148);
            this.rbMontoFijo.Name = "rbMontoFijo";
            this.rbMontoFijo.Size = new System.Drawing.Size(100, 24);
            this.rbMontoFijo.TabIndex = 2;
            this.rbMontoFijo.TabStop = true;
            this.rbMontoFijo.Text = "Monto Fijo";
            this.rbMontoFijo.UseVisualStyleBackColor = true;
            this.rbMontoFijo.CheckedChanged += new System.EventHandler(this.rbTipoCalculo_CheckedChanged);
            // 
            // cmbConcepto
            // 
            this.cmbConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbConcepto.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.cmbConcepto.FormattingEnabled = true;
            this.cmbConcepto.Location = new System.Drawing.Point(27, 72);
            this.cmbConcepto.Name = "cmbConcepto";
            this.cmbConcepto.Size = new System.Drawing.Size(296, 31);
            this.cmbConcepto.TabIndex = 1;
            // 
            // lblConcepto
            // 
            this.lblConcepto.AutoSize = true;
            this.lblConcepto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblConcepto.Location = new System.Drawing.Point(23, 49);
            this.lblConcepto.Name = "lblConcepto";
            this.lblConcepto.Size = new System.Drawing.Size(73, 20);
            this.lblConcepto.TabIndex = 0;
            this.lblConcepto.Text = "Concepto:";
            // 
            // lblSubtitulo
            // 
            this.lblSubtitulo.AutoSize = true;
            this.lblSubtitulo.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSubtitulo.Location = new System.Drawing.Point(397, 159);
            this.lblSubtitulo.Name = "lblSubtitulo";
            this.lblSubtitulo.Size = new System.Drawing.Size(370, 23);
            this.lblSubtitulo.TabIndex = 5;
            this.lblSubtitulo.Text = "Conceptos Programados para este Empleado:";
            // 
            // FormCapturaEspeciales
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1000, 570);
            this.Controls.Add(this.lblSubtitulo);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvConceptos);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormCapturaEspeciales";
            this.Text = "FormCapturaEspeciales";
            this.Load += new System.EventHandler(this.FormCapturaEspeciales_Load);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.ComboBox cmbEmpleado;
        private System.Windows.Forms.Label lblEmpleado;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.DataGridView dgvConceptos;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cmbConcepto;
        private System.Windows.Forms.Label lblConcepto;
        private System.Windows.Forms.NumericUpDown numMonto;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.RadioButton rbPorcentaje;
        private System.Windows.Forms.RadioButton rbMontoFijo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Label lblSubtitulo;
    }
}