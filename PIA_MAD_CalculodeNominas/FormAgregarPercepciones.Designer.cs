namespace PIA_MAD_CalculodeNominas
{
    partial class FormAgregarPercepciones
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNombre = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblId = new System.Windows.Forms.Label();
            this.txtId = new System.Windows.Forms.TextBox();
            this.lblTipoConcepto = new System.Windows.Forms.Label();
            this.cmbTipoConcepto = new System.Windows.Forms.ComboBox();
            this.lblCuotaPorcentaje = new System.Windows.Forms.Label();
            this.cmbCuotaPorcentaje = new System.Windows.Forms.ComboBox();
            this.lblFijo = new System.Windows.Forms.Label();
            this.cmbFijo = new System.Windows.Forms.ComboBox();
            this.txtValor = new System.Windows.Forms.TextBox();
            this.lblFechaCreacion = new System.Windows.Forms.Label();
            this.dtpFechaCreacion = new System.Windows.Forms.DateTimePicker();
            this.btnIngresar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgvConceptos = new System.Windows.Forms.DataGridView();
            this.gbDatosConcepto = new System.Windows.Forms.GroupBox();
            this.lblValor = new System.Windows.Forms.Label();
            this.gbAcciones = new System.Windows.Forms.GroupBox();
            this.lblGridTitle = new System.Windows.Forms.Label();
            this.btnConsultar = new System.Windows.Forms.Button(); // <-- DECLARACIÓN
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).BeginInit();
            this.gbDatosConcepto.SuspendLayout();
            this.gbAcciones.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(15, 30);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(47, 13);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(18, 46);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(320, 20);
            this.txtNombre.TabIndex = 1;
            // 
            // lblId
            // 
            this.lblId.AutoSize = true;
            this.lblId.Location = new System.Drawing.Point(355, 30);
            this.lblId.Name = "lblId";
            this.lblId.Size = new System.Drawing.Size(21, 13);
            this.lblId.TabIndex = 2;
            this.lblId.Text = "ID:";
            // 
            // txtId
            // 
            this.txtId.Location = new System.Drawing.Point(358, 46);
            this.txtId.Name = "txtId";
            this.txtId.ReadOnly = true;
            this.txtId.Size = new System.Drawing.Size(100, 20);
            this.txtId.TabIndex = 3;
            // 
            // lblTipoConcepto
            // 
            this.lblTipoConcepto.AutoSize = true;
            this.lblTipoConcepto.Location = new System.Drawing.Point(15, 80);
            this.lblTipoConcepto.Name = "lblTipoConcepto";
            this.lblTipoConcepto.Size = new System.Drawing.Size(94, 13);
            this.lblTipoConcepto.TabIndex = 4;
            this.lblTipoConcepto.Text = "Tipo de concepto:";
            // 
            // cmbTipoConcepto
            // 
            this.cmbTipoConcepto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTipoConcepto.FormattingEnabled = true;
            this.cmbTipoConcepto.Location = new System.Drawing.Point(18, 96);
            this.cmbTipoConcepto.Name = "cmbTipoConcepto";
            this.cmbTipoConcepto.Size = new System.Drawing.Size(160, 21);
            this.cmbTipoConcepto.TabIndex = 5;
            // 
            // lblCuotaPorcentaje
            // 
            this.lblCuotaPorcentaje.AutoSize = true;
            this.lblCuotaPorcentaje.Location = new System.Drawing.Point(15, 131);
            this.lblCuotaPorcentaje.Name = "lblCuotaPorcentaje";
            this.lblCuotaPorcentaje.Size = new System.Drawing.Size(73, 13);
            this.lblCuotaPorcentaje.TabIndex = 6;
            this.lblCuotaPorcentaje.Text = "Tipo de Valor:";
            // 
            // cmbCuotaPorcentaje
            // 
            this.cmbCuotaPorcentaje.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCuotaPorcentaje.FormattingEnabled = true;
            this.cmbCuotaPorcentaje.Location = new System.Drawing.Point(18, 147);
            this.cmbCuotaPorcentaje.Name = "cmbCuotaPorcentaje";
            this.cmbCuotaPorcentaje.Size = new System.Drawing.Size(160, 21);
            this.cmbCuotaPorcentaje.TabIndex = 7;
            this.cmbCuotaPorcentaje.SelectedIndexChanged += new System.EventHandler(this.cmbCuotaPorcentaje_SelectedIndexChanged);
            // 
            // lblFijo
            // 
            this.lblFijo.AutoSize = true;
            this.lblFijo.Location = new System.Drawing.Point(195, 80);
            this.lblFijo.Name = "lblFijo";
            this.lblFijo.Size = new System.Drawing.Size(49, 13);
            this.lblFijo.TabIndex = 8;
            this.lblFijo.Text = "Fijo o no:";
            // 
            // cmbFijo
            // 
            this.cmbFijo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFijo.FormattingEnabled = true;
            this.cmbFijo.Location = new System.Drawing.Point(198, 96);
            this.cmbFijo.Name = "cmbFijo";
            this.cmbFijo.Size = new System.Drawing.Size(140, 21);
            this.cmbFijo.TabIndex = 9;
            // 
            // txtValor
            // 
            this.txtValor.Location = new System.Drawing.Point(198, 148);
            this.txtValor.Name = "txtValor";
            this.txtValor.Size = new System.Drawing.Size(140, 20);
            this.txtValor.TabIndex = 10;
            // 
            // lblFechaCreacion
            // 
            this.lblFechaCreacion.AutoSize = true;
            this.lblFechaCreacion.Location = new System.Drawing.Point(355, 131);
            this.lblFechaCreacion.Name = "lblFechaCreacion";
            this.lblFechaCreacion.Size = new System.Drawing.Size(85, 13);
            this.lblFechaCreacion.TabIndex = 11;
            this.lblFechaCreacion.Text = "Fecha Creacion:";
            // 
            // dtpFechaCreacion
            // 
            this.dtpFechaCreacion.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaCreacion.Location = new System.Drawing.Point(358, 148);
            this.dtpFechaCreacion.Name = "dtpFechaCreacion";
            this.dtpFechaCreacion.Size = new System.Drawing.Size(100, 20);
            this.dtpFechaCreacion.TabIndex = 12;
            // 
            // btnIngresar
            // 
            this.btnIngresar.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIngresar.Location = new System.Drawing.Point(19, 25);
            this.btnIngresar.Name = "btnIngresar";
            this.btnIngresar.Size = new System.Drawing.Size(110, 30);
            this.btnIngresar.TabIndex = 13;
            this.btnIngresar.Text = "Ingresar Nuevo";
            this.btnIngresar.UseVisualStyleBackColor = true;
            this.btnIngresar.Click += new System.EventHandler(this.btnIngresar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(19, 65);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(110, 30);
            this.btnLimpiar.TabIndex = 14;
            this.btnLimpiar.Text = "Limpiar / Cancelar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(19, 105);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(110, 30);
            this.btnEliminar.TabIndex = 15;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgvConceptos
            // 
            this.dgvConceptos.AllowUserToAddRows = false;
            this.dgvConceptos.AllowUserToDeleteRows = false;
            this.dgvConceptos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvConceptos.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvConceptos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvConceptos.Location = new System.Drawing.Point(12, 237);
            this.dgvConceptos.MultiSelect = false;
            this.dgvConceptos.Name = "dgvConceptos";
            this.dgvConceptos.ReadOnly = true;
            this.dgvConceptos.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvConceptos.Size = new System.Drawing.Size(760, 212);
            this.dgvConceptos.TabIndex = 17;
            this.dgvConceptos.SelectionChanged += new System.EventHandler(this.dgvConceptos_SelectionChanged);
            // 
            // gbDatosConcepto
            // 
            this.gbDatosConcepto.Controls.Add(this.lblValor);
            this.gbDatosConcepto.Controls.Add(this.lblNombre);
            this.gbDatosConcepto.Controls.Add(this.txtNombre);
            this.gbDatosConcepto.Controls.Add(this.lblId);
            this.gbDatosConcepto.Controls.Add(this.txtId);
            this.gbDatosConcepto.Controls.Add(this.lblTipoConcepto);
            this.gbDatosConcepto.Controls.Add(this.cmbTipoConcepto);
            this.gbDatosConcepto.Controls.Add(this.dtpFechaCreacion);
            this.gbDatosConcepto.Controls.Add(this.lblFijo);
            this.gbDatosConcepto.Controls.Add(this.lblFechaCreacion);
            this.gbDatosConcepto.Controls.Add(this.cmbFijo);
            this.gbDatosConcepto.Controls.Add(this.txtValor);
            this.gbDatosConcepto.Controls.Add(this.lblCuotaPorcentaje);
            this.gbDatosConcepto.Controls.Add(this.cmbCuotaPorcentaje);
            this.gbDatosConcepto.Location = new System.Drawing.Point(12, 12);
            this.gbDatosConcepto.Name = "gbDatosConcepto";
            this.gbDatosConcepto.Size = new System.Drawing.Size(600, 190);
            this.gbDatosConcepto.TabIndex = 18;
            this.gbDatosConcepto.TabStop = false;
            this.gbDatosConcepto.Text = "Datos del Concepto";
            // 
            // lblValor
            // 
            this.lblValor.AutoSize = true;
            this.lblValor.Location = new System.Drawing.Point(195, 131);
            this.lblValor.Name = "lblValor";
            this.lblValor.Size = new System.Drawing.Size(34, 13);
            this.lblValor.TabIndex = 13;
            this.lblValor.Text = "Valor:";
            // 
            // gbAcciones
            // 
            this.gbAcciones.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.gbAcciones.Controls.Add(this.btnConsultar); // <-- AÑADIDO AL GRUPO
            this.gbAcciones.Controls.Add(this.btnIngresar);
            this.gbAcciones.Controls.Add(this.btnLimpiar);
            this.gbAcciones.Controls.Add(this.btnEliminar);
            this.gbAcciones.Location = new System.Drawing.Point(623, 12);
            this.gbAcciones.Name = "gbAcciones";
            this.gbAcciones.Size = new System.Drawing.Size(149, 190);
            this.gbAcciones.TabIndex = 19;
            this.gbAcciones.TabStop = false;
            this.gbAcciones.Text = "Acciones";
            // 
            // lblGridTitle
            // 
            this.lblGridTitle.AutoSize = true;
            this.lblGridTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblGridTitle.Location = new System.Drawing.Point(12, 221);
            this.lblGridTitle.Name = "lblGridTitle";
            this.lblGridTitle.Size = new System.Drawing.Size(130, 13);
            this.lblGridTitle.TabIndex = 20;
            this.lblGridTitle.Text = "Conceptos Existentes";
            // 
            // btnConsultar
            // 
            this.btnConsultar.Location = new System.Drawing.Point(19, 145);
            this.btnConsultar.Name = "btnConsultar";
            this.btnConsultar.Size = new System.Drawing.Size(110, 30);
            this.btnConsultar.TabIndex = 16;
            this.btnConsultar.Text = "Consultar";
            this.btnConsultar.UseVisualStyleBackColor = true;
            this.btnConsultar.Click += new System.EventHandler(this.btnConsultar_Click); // <-- EVENTO
            // 
            // FormAgregarPercepciones
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.lblGridTitle);
            this.Controls.Add(this.gbAcciones);
            this.Controls.Add(this.gbDatosConcepto);
            this.Controls.Add(this.dgvConceptos);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "FormAgregarPercepciones";
            this.Text = "Catálogo de Percepciones y Deducciones";
            this.Load += new System.EventHandler(this.FormAgregarPercepciones_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvConceptos)).EndInit();
            this.gbDatosConcepto.ResumeLayout(false);
            this.gbDatosConcepto.PerformLayout();
            this.gbAcciones.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblId;
        private System.Windows.Forms.TextBox txtId;
        private System.Windows.Forms.Label lblTipoConcepto;
        private System.Windows.Forms.ComboBox cmbTipoConcepto;
        private System.Windows.Forms.Label lblCuotaPorcentaje;
        private System.Windows.Forms.ComboBox cmbCuotaPorcentaje;
        private System.Windows.Forms.Label lblFijo;
        private System.Windows.Forms.ComboBox cmbFijo;
        private System.Windows.Forms.TextBox txtValor;
        private System.Windows.Forms.Label lblFechaCreacion;
        private System.Windows.Forms.DateTimePicker dtpFechaCreacion;
        private System.Windows.Forms.Button btnIngresar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgvConceptos;
        private System.Windows.Forms.GroupBox gbDatosConcepto;
        private System.Windows.Forms.Label lblValor;
        private System.Windows.Forms.GroupBox gbAcciones;
        private System.Windows.Forms.Label lblGridTitle;
        private System.Windows.Forms.Button btnConsultar; // <-- DECLARACIÓN
    }
}