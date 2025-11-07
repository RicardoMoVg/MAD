namespace PIA_MAD_CalculodeNominas
{
    partial class FormRecursosH
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
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.tabControlEmpleado = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.lblRFC = new System.Windows.Forms.Label();
            this.txtNSS = new System.Windows.Forms.TextBox();
            this.lblNSS = new System.Windows.Forms.Label();
            this.txtCURP = new System.Windows.Forms.TextBox();
            this.lblCURP = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.txtApellidoM = new System.Windows.Forms.TextBox();
            this.lblApellidoM = new System.Windows.Forms.Label();
            this.txtApellidoP = new System.Windows.Forms.TextBox();
            this.lblApellidoP = new System.Windows.Forms.Label();
            this.txtNombre = new System.Windows.Forms.TextBox();
            this.lblNombre = new System.Windows.Forms.Label();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.numSalarioDI = new System.Windows.Forms.NumericUpDown();
            this.numSalarioDiario = new System.Windows.Forms.NumericUpDown();
            this.lblSalarioDI = new System.Windows.Forms.Label();
            this.lblSalarioD = new System.Windows.Forms.Label();
            this.cmbPuesto = new System.Windows.Forms.ComboBox();
            this.lblPuesto = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.lblDepto = new System.Windows.Forms.Label();
            this.txtIDEmpleado = new System.Windows.Forms.TextBox();
            this.lblIDEmpleado = new System.Windows.Forms.Label();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.txtTelCelular = new System.Windows.Forms.TextBox();
            this.lblTelCel = new System.Windows.Forms.Label();
            this.txtTelCasa = new System.Windows.Forms.TextBox();
            this.lblTelCasa = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtCP = new System.Windows.Forms.TextBox();
            this.lblCP = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.lblColonia = new System.Windows.Forms.Label();
            this.txtNumInt = new System.Windows.Forms.TextBox();
            this.lblNumInt = new System.Windows.Forms.Label();
            this.txtNumExt = new System.Windows.Forms.TextBox();
            this.lblNumExt = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.lblCalle = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.btnResetPassword = new System.Windows.Forms.Button();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.lblPassword = new System.Windows.Forms.Label();
            this.txtNumCuenta = new System.Windows.Forms.TextBox();
            this.lblNumCuenta = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.lblBanco = new System.Windows.Forms.Label();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnDarDeBaja = new System.Windows.Forms.Button();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.tabControlEmpleado.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalarioDI)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSalarioDiario)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.AllowUserToAddRows = false;
            this.dgvEmpleados.AllowUserToDeleteRows = false;
            this.dgvEmpleados.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Location = new System.Drawing.Point(12, 41);
            this.dgvEmpleados.MultiSelect = false;
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.ReadOnly = true;
            this.dgvEmpleados.RowTemplate.Height = 25;
            this.dgvEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpleados.Size = new System.Drawing.Size(860, 190);
            this.dgvEmpleados.TabIndex = 0;
            this.dgvEmpleados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpleados_CellClick);
            // 
            // tabControlEmpleado
            // 
            this.tabControlEmpleado.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlEmpleado.Controls.Add(this.tabPage1);
            this.tabControlEmpleado.Controls.Add(this.tabPage2);
            this.tabControlEmpleado.Controls.Add(this.tabPage3);
            this.tabControlEmpleado.Controls.Add(this.tabPage4);
            this.tabControlEmpleado.Location = new System.Drawing.Point(12, 237);
            this.tabControlEmpleado.Name = "tabControlEmpleado";
            this.tabControlEmpleado.SelectedIndex = 0;
            this.tabControlEmpleado.Size = new System.Drawing.Size(860, 323);
            this.tabControlEmpleado.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtRFC);
            this.tabPage1.Controls.Add(this.lblRFC);
            this.tabPage1.Controls.Add(this.txtNSS);
            this.tabPage1.Controls.Add(this.lblNSS);
            this.tabPage1.Controls.Add(this.txtCURP);
            this.tabPage1.Controls.Add(this.lblCURP);
            this.tabPage1.Controls.Add(this.dtpFechaNacimiento);
            this.tabPage1.Controls.Add(this.lblFechaNac);
            this.tabPage1.Controls.Add(this.txtApellidoM);
            this.tabPage1.Controls.Add(this.lblApellidoM);
            this.tabPage1.Controls.Add(this.txtApellidoP);
            this.tabPage1.Controls.Add(this.lblApellidoP);
            this.tabPage1.Controls.Add(this.txtNombre);
            this.tabPage1.Controls.Add(this.lblNombre);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(852, 295);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos Personales";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtRFC
            // 
            this.txtRFC.Location = new System.Drawing.Point(140, 183);
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(200, 23);
            this.txtRFC.TabIndex = 13;
            // 
            // lblRFC
            // 
            this.lblRFC.AutoSize = true;
            this.lblRFC.Location = new System.Drawing.Point(20, 186);
            this.lblRFC.Name = "lblRFC";
            this.lblRFC.Size = new System.Drawing.Size(31, 15);
            this.lblRFC.TabIndex = 12;
            this.lblRFC.Text = "RFC:";
            // 
            // txtNSS
            // 
            this.txtNSS.Location = new System.Drawing.Point(140, 154);
            this.txtNSS.Name = "txtNSS";
            this.txtNSS.Size = new System.Drawing.Size(200, 23);
            this.txtNSS.TabIndex = 11;
            // 
            // lblNSS
            // 
            this.lblNSS.AutoSize = true;
            this.lblNSS.Location = new System.Drawing.Point(20, 157);
            this.lblNSS.Name = "lblNSS";
            this.lblNSS.Size = new System.Drawing.Size(32, 15);
            this.lblNSS.TabIndex = 10;
            this.lblNSS.Text = "NSS:";
            // 
            // txtCURP
            // 
            this.txtCURP.Location = new System.Drawing.Point(140, 125);
            this.txtCURP.Name = "txtCURP";
            this.txtCURP.Size = new System.Drawing.Size(200, 23);
            this.txtCURP.TabIndex = 9;
            // 
            // lblCURP
            // 
            this.lblCURP.AutoSize = true;
            this.lblCURP.Location = new System.Drawing.Point(20, 128);
            this.lblCURP.Name = "lblCURP";
            this.lblCURP.Size = new System.Drawing.Size(40, 15);
            this.lblCURP.TabIndex = 8;
            this.lblCURP.Text = "CURP:";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(140, 96);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(200, 23);
            this.dtpFechaNacimiento.TabIndex = 7;
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Location = new System.Drawing.Point(20, 102);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(114, 15);
            this.lblFechaNac.TabIndex = 6;
            this.lblFechaNac.Text = "Fecha de Nacimento:";
            // 
            // txtApellidoM
            // 
            this.txtApellidoM.Location = new System.Drawing.Point(140, 67);
            this.txtApellidoM.Name = "txtApellidoM";
            this.txtApellidoM.Size = new System.Drawing.Size(200, 23);
            this.txtApellidoM.TabIndex = 5;
            // 
            // lblApellidoM
            // 
            this.lblApellidoM.AutoSize = true;
            this.lblApellidoM.Location = new System.Drawing.Point(20, 70);
            this.lblApellidoM.Name = "lblApellidoM";
            this.lblApellidoM.Size = new System.Drawing.Size(102, 15);
            this.lblApellidoM.TabIndex = 4;
            this.lblApellidoM.Text = "Apellido Materno:";
            // 
            // txtApellidoP
            // 
            this.txtApellidoP.Location = new System.Drawing.Point(140, 38);
            this.txtApellidoP.Name = "txtApellidoP";
            this.txtApellidoP.Size = new System.Drawing.Size(200, 23);
            this.txtApellidoP.TabIndex = 3;
            // 
            // lblApellidoP
            // 
            this.lblApellidoP.AutoSize = true;
            this.lblApellidoP.Location = new System.Drawing.Point(20, 41);
            this.lblApellidoP.Name = "lblApellidoP";
            this.lblApellidoP.Size = new System.Drawing.Size(98, 15);
            this.lblApellidoP.TabIndex = 2;
            this.lblApellidoP.Text = "Apellido Paterno:";
            // 
            // txtNombre
            // 
            this.txtNombre.Location = new System.Drawing.Point(140, 9);
            this.txtNombre.Name = "txtNombre";
            this.txtNombre.Size = new System.Drawing.Size(200, 23);
            this.txtNombre.TabIndex = 1;
            // 
            // lblNombre
            // 
            this.lblNombre.AutoSize = true;
            this.lblNombre.Location = new System.Drawing.Point(20, 12);
            this.lblNombre.Name = "lblNombre";
            this.lblNombre.Size = new System.Drawing.Size(54, 15);
            this.lblNombre.TabIndex = 0;
            this.lblNombre.Text = "Nombre:";
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.numSalarioDI);
            this.tabPage2.Controls.Add(this.numSalarioDiario);
            this.tabPage2.Controls.Add(this.lblSalarioDI);
            this.tabPage2.Controls.Add(this.lblSalarioD);
            this.tabPage2.Controls.Add(this.cmbPuesto);
            this.tabPage2.Controls.Add(this.lblPuesto);
            this.tabPage2.Controls.Add(this.cmbDepartamento);
            this.tabPage2.Controls.Add(this.lblDepto);
            this.tabPage2.Controls.Add(this.txtIDEmpleado);
            this.tabPage2.Controls.Add(this.lblIDEmpleado);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(852, 295);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Datos Laborales";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // numSalarioDI
            // 
            this.numSalarioDI.DecimalPlaces = 2;
            this.numSalarioDI.Location = new System.Drawing.Point(153, 125);
            this.numSalarioDI.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numSalarioDI.Name = "numSalarioDI";
            this.numSalarioDI.Size = new System.Drawing.Size(120, 23);
            this.numSalarioDI.TabIndex = 9;
            // 
            // numSalarioDiario
            // 
            this.numSalarioDiario.DecimalPlaces = 2;
            this.numSalarioDiario.Location = new System.Drawing.Point(153, 96);
            this.numSalarioDiario.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numSalarioDiario.Name = "numSalarioDiario";
            this.numSalarioDiario.Size = new System.Drawing.Size(120, 23);
            this.numSalarioDiario.TabIndex = 7;
            // 
            // lblSalarioDI
            // 
            this.lblSalarioDI.AutoSize = true;
            this.lblSalarioDI.Location = new System.Drawing.Point(20, 128);
            this.lblSalarioDI.Name = "lblSalarioDI";
            this.lblSalarioDI.Size = new System.Drawing.Size(127, 15);
            this.lblSalarioDI.TabIndex = 8;
            this.lblSalarioDI.Text = "Salario Diario Integrado:";
            // 
            // lblSalarioD
            // 
            this.lblSalarioD.AutoSize = true;
            this.lblSalarioD.Location = new System.Drawing.Point(20, 98);
            this.lblSalarioD.Name = "lblSalarioD";
            this.lblSalarioD.Size = new System.Drawing.Size(80, 15);
            this.lblSalarioD.TabIndex = 6;
            this.lblSalarioD.Text = "Salario Diario:";
            // 
            // cmbPuesto
            // 
            this.cmbPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuesto.FormattingEnabled = true;
            this.cmbPuesto.Location = new System.Drawing.Point(153, 67);
            this.cmbPuesto.Name = "cmbPuesto";
            this.cmbPuesto.Size = new System.Drawing.Size(220, 23);
            this.cmbPuesto.TabIndex = 5;
            // 
            // lblPuesto
            // 
            this.lblPuesto.AutoSize = true;
            this.lblPuesto.Location = new System.Drawing.Point(20, 70);
            this.lblPuesto.Name = "lblPuesto";
            this.lblPuesto.Size = new System.Drawing.Size(46, 15);
            this.lblPuesto.TabIndex = 4;
            this.lblPuesto.Text = "Puesto:";
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(153, 38);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(220, 23);
            this.cmbDepartamento.TabIndex = 3;
            // 
            // lblDepto
            // 
            this.lblDepto.AutoSize = true;
            this.lblDepto.Location = new System.Drawing.Point(20, 41);
            this.lblDepto.Name = "lblDepto";
            this.lblDepto.Size = new System.Drawing.Size(86, 15);
            this.lblDepto.TabIndex = 2;
            this.lblDepto.Text = "Departamento:";
            // 
            // txtIDEmpleado
            // 
            this.txtIDEmpleado.Location = new System.Drawing.Point(153, 9);
            this.txtIDEmpleado.Name = "txtIDEmpleado";
            this.txtIDEmpleado.ReadOnly = true;
            this.txtIDEmpleado.Size = new System.Drawing.Size(100, 23);
            this.txtIDEmpleado.TabIndex = 1;
            // 
            // lblIDEmpleado
            // 
            this.lblIDEmpleado.AutoSize = true;
            this.lblIDEmpleado.Location = new System.Drawing.Point(20, 12);
            this.lblIDEmpleado.Name = "lblIDEmpleado";
            this.lblIDEmpleado.Size = new System.Drawing.Size(127, 15);
            this.lblIDEmpleado.TabIndex = 0;
            this.lblIDEmpleado.Text = "Número de Empleado:";
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.txtTelCelular);
            this.tabPage3.Controls.Add(this.lblTelCel);
            this.tabPage3.Controls.Add(this.txtTelCasa);
            this.tabPage3.Controls.Add(this.lblTelCasa);
            this.tabPage3.Controls.Add(this.txtEmail);
            this.tabPage3.Controls.Add(this.lblEmail);
            this.tabPage3.Controls.Add(this.txtCP);
            this.tabPage3.Controls.Add(this.lblCP);
            this.tabPage3.Controls.Add(this.txtEstado);
            this.tabPage3.Controls.Add(this.lblEstado);
            this.tabPage3.Controls.Add(this.txtMunicipio);
            this.tabPage3.Controls.Add(this.lblMunicipio);
            this.tabPage3.Controls.Add(this.txtColonia);
            this.tabPage3.Controls.Add(this.lblColonia);
            this.tabPage3.Controls.Add(this.txtNumInt);
            this.tabPage3.Controls.Add(this.lblNumInt);
            this.tabPage3.Controls.Add(this.txtNumExt);
            this.tabPage3.Controls.Add(this.lblNumExt);
            this.tabPage3.Controls.Add(this.txtCalle);
            this.tabPage3.Controls.Add(this.lblCalle);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(852, 295);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Dirección y Contacto";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // txtTelCelular
            // 
            this.txtTelCelular.Location = new System.Drawing.Point(509, 67);
            this.txtTelCelular.Name = "txtTelCelular";
            this.txtTelCelular.Size = new System.Drawing.Size(130, 23);
            this.txtTelCelular.TabIndex = 19;
            // 
            // lblTelCel
            // 
            this.lblTelCel.AutoSize = true;
            this.lblTelCel.Location = new System.Drawing.Point(404, 70);
            this.lblTelCel.Name = "lblTelCel";
            this.lblTelCel.Size = new System.Drawing.Size(94, 15);
            this.lblTelCel.TabIndex = 18;
            this.lblTelCel.Text = "Teléfono Celular:";
            // 
            // txtTelCasa
            // 
            this.txtTelCasa.Location = new System.Drawing.Point(509, 38);
            this.txtTelCasa.Name = "txtTelCasa";
            this.txtTelCasa.Size = new System.Drawing.Size(130, 23);
            this.txtTelCasa.TabIndex = 17;
            // 
            // lblTelCasa
            // 
            this.lblTelCasa.AutoSize = true;
            this.lblTelCasa.Location = new System.Drawing.Point(404, 41);
            this.lblTelCasa.Name = "lblTelCasa";
            this.lblTelCasa.Size = new System.Drawing.Size(84, 15);
            this.lblTelCasa.TabIndex = 16;
            this.lblTelCasa.Text = "Teléfono Casa:";
            // 
            // txtEmail
            // 
            this.txtEmail.Location = new System.Drawing.Point(509, 9);
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(220, 23);
            this.txtEmail.TabIndex = 15;
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(404, 12);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(39, 15);
            this.lblEmail.TabIndex = 14;
            this.lblEmail.Text = "Email:";
            // 
            // txtCP
            // 
            this.txtCP.Location = new System.Drawing.Point(109, 183);
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(80, 23);
            this.txtCP.TabIndex = 13;
            // 
            // lblCP
            // 
            this.lblCP.AutoSize = true;
            this.lblCP.Location = new System.Drawing.Point(20, 186);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(84, 15);
            this.lblCP.TabIndex = 12;
            this.lblCP.Text = "Código Postal:";
            // 
            // txtEstado
            // 
            this.txtEstado.Location = new System.Drawing.Point(109, 154);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(180, 23);
            this.txtEstado.TabIndex = 11;
            // 
            // lblEstado
            // 
            this.lblEstado.AutoSize = true;
            this.lblEstado.Location = new System.Drawing.Point(20, 157);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(45, 15);
            this.lblEstado.TabIndex = 10;
            this.lblEstado.Text = "Estado:";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.Location = new System.Drawing.Point(109, 125);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(180, 23);
            this.txtMunicipio.TabIndex = 9;
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Location = new System.Drawing.Point(20, 128);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(64, 15);
            this.lblMunicipio.TabIndex = 8;
            this.lblMunicipio.Text = "Municipio:";
            // 
            // txtColonia
            // 
            this.txtColonia.Location = new System.Drawing.Point(109, 96);
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(180, 23);
            this.txtColonia.TabIndex = 7;
            // 
            // lblColonia
            // 
            this.lblColonia.AutoSize = true;
            this.lblColonia.Location = new System.Drawing.Point(20, 99);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(51, 15);
            this.lblColonia.TabIndex = 6;
            this.lblColonia.Text = "Colonia:";
            // 
            // txtNumInt
            // 
            this.txtNumInt.Location = new System.Drawing.Point(109, 67);
            this.txtNumInt.Name = "txtNumInt";
            this.txtNumInt.Size = new System.Drawing.Size(80, 23);
            this.txtNumInt.TabIndex = 5;
            // 
            // lblNumInt
            // 
            this.lblNumInt.AutoSize = true;
            this.lblNumInt.Location = new System.Drawing.Point(20, 70);
            this.lblNumInt.Name = "lblNumInt";
            this.lblNumInt.Size = new System.Drawing.Size(55, 15);
            this.lblNumInt.TabIndex = 4;
            this.lblNumInt.Text = "Num. Int:";
            // 
            // txtNumExt
            // 
            this.txtNumExt.Location = new System.Drawing.Point(109, 38);
            this.txtNumExt.Name = "txtNumExt";
            this.txtNumExt.Size = new System.Drawing.Size(80, 23);
            this.txtNumExt.TabIndex = 3;
            // 
            // lblNumExt
            // 
            this.lblNumExt.AutoSize = true;
            this.lblNumExt.Location = new System.Drawing.Point(20, 41);
            this.lblNumExt.Name = "lblNumExt";
            this.lblNumExt.Size = new System.Drawing.Size(58, 15);
            this.lblNumExt.TabIndex = 2;
            this.lblNumExt.Text = "Num. Ext:";
            // 
            // txtCalle
            // 
            this.txtCalle.Location = new System.Drawing.Point(109, 9);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(250, 23);
            this.txtCalle.TabIndex = 1;
            // 
            // lblCalle
            // 
            this.lblCalle.AutoSize = true;
            this.lblCalle.Location = new System.Drawing.Point(20, 12);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(36, 15);
            this.lblCalle.TabIndex = 0;
            this.lblCalle.Text = "Calle:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.btnResetPassword);
            this.tabPage4.Controls.Add(this.txtPassword);
            this.tabPage4.Controls.Add(this.lblPassword);
            this.tabPage4.Controls.Add(this.txtNumCuenta);
            this.tabPage4.Controls.Add(this.lblNumCuenta);
            this.tabPage4.Controls.Add(this.txtBanco);
            this.tabPage4.Controls.Add(this.lblBanco);
            this.tabPage4.Location = new System.Drawing.Point(4, 24);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(852, 295);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Datos Bancarios y Acceso";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // btnResetPassword
            // 
            this.btnResetPassword.Location = new System.Drawing.Point(341, 67);
            this.btnResetPassword.Name = "btnResetPassword";
            this.btnResetPassword.Size = new System.Drawing.Size(120, 23);
            this.btnResetPassword.TabIndex = 6;
            this.btnResetPassword.Text = "Resetear Password";
            this.btnResetPassword.UseVisualStyleBackColor = true;
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(135, 67);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(200, 23);
            this.txtPassword.TabIndex = 5;
            // 
            // lblPassword
            // 
            this.lblPassword.AutoSize = true;
            this.lblPassword.Location = new System.Drawing.Point(20, 70);
            this.lblPassword.Name = "lblPassword";
            this.lblPassword.Size = new System.Drawing.Size(70, 15);
            this.lblPassword.TabIndex = 4;
            this.lblPassword.Text = "Contraseña:";
            // 
            // txtNumCuenta
            // 
            this.txtNumCuenta.Location = new System.Drawing.Point(135, 38);
            this.txtNumCuenta.Name = "txtNumCuenta";
            this.txtNumCuenta.Size = new System.Drawing.Size(200, 23);
            this.txtNumCuenta.TabIndex = 3;
            // 
            // lblNumCuenta
            // 
            this.lblNumCuenta.AutoSize = true;
            this.lblNumCuenta.Location = new System.Drawing.Point(20, 41);
            this.lblNumCuenta.Name = "lblNumCuenta";
            this.lblNumCuenta.Size = new System.Drawing.Size(110, 15);
            this.lblNumCuenta.TabIndex = 2;
            this.lblNumCuenta.Text = "Número de Cuenta:";
            // 
            // txtBanco
            // 
            this.txtBanco.Location = new System.Drawing.Point(135, 9);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(200, 23);
            this.txtBanco.TabIndex = 1;
            // 
            // lblBanco
            // 
            this.lblBanco.AutoSize = true;
            this.lblBanco.Location = new System.Drawing.Point(20, 12);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(43, 15);
            this.lblBanco.TabIndex = 0;
            this.lblBanco.Text = "Banco:";
            // 
            // btnNuevo
            // 
            this.btnNuevo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnNuevo.Location = new System.Drawing.Point(550, 566);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(75, 23);
            this.btnNuevo.TabIndex = 2;
            this.btnNuevo.Text = "Nuevo";
            this.btnNuevo.UseVisualStyleBackColor = true;
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.Location = new System.Drawing.Point(631, 566);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(75, 23);
            this.btnGuardar.TabIndex = 3;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnDarDeBaja
            // 
            this.btnDarDeBaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDarDeBaja.Location = new System.Drawing.Point(712, 566);
            this.btnDarDeBaja.Name = "btnDarDeBaja";
            this.btnDarDeBaja.Size = new System.Drawing.Size(75, 23);
            this.btnDarDeBaja.TabIndex = 4;
            this.btnDarDeBaja.Text = "Dar de Baja";
            this.btnDarDeBaja.UseVisualStyleBackColor = true;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.Location = new System.Drawing.Point(797, 12);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(75, 23);
            this.btnBuscar.TabIndex = 6;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = true;
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Location = new System.Drawing.Point(12, 12);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(779, 23);
            this.txtBuscar.TabIndex = 5;
            // 
            // FormRecursosH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 601);
            this.Controls.Add(this.txtBuscar);
            this.Controls.Add(this.btnBuscar);
            this.Controls.Add(this.btnDarDeBaja);
            this.Controls.Add(this.btnGuardar);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.tabControlEmpleado);
            this.Controls.Add(this.dgvEmpleados);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(900, 640);
            this.Name = "FormRecursosH";
            this.Text = "Administración de Recursos Humanos";
            this.Load += new System.EventHandler(this.FormRecursosH_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.tabControlEmpleado.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalarioDI)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSalarioDiario)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.tabPage3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.TabControl tabControlEmpleado;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnDarDeBaja;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.Label lblRFC;
        private System.Windows.Forms.TextBox txtNSS;
        private System.Windows.Forms.Label lblNSS;
        private System.Windows.Forms.TextBox txtCURP;
        private System.Windows.Forms.Label lblCURP;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.TextBox txtApellidoM;
        private System.Windows.Forms.Label lblApellidoM;
        private System.Windows.Forms.TextBox txtApellidoP;
        private System.Windows.Forms.Label lblApellidoP;
        private System.Windows.Forms.TextBox txtNombre;
        private System.Windows.Forms.Label lblNombre;
        private System.Windows.Forms.NumericUpDown numSalarioDI;
        private System.Windows.Forms.NumericUpDown numSalarioDiario;
        private System.Windows.Forms.Label lblSalarioDI;
        private System.Windows.Forms.Label lblSalarioD;
        private System.Windows.Forms.ComboBox cmbPuesto;
        private System.Windows.Forms.Label lblPuesto;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Label lblDepto;
        private System.Windows.Forms.TextBox txtIDEmpleado;
        private System.Windows.Forms.Label lblIDEmpleado;
        private System.Windows.Forms.TextBox txtTelCelular;
        private System.Windows.Forms.Label lblTelCel;
        private System.Windows.Forms.TextBox txtTelCasa;
        private System.Windows.Forms.Label lblTelCasa;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.TextBox txtCP;
        private System.Windows.Forms.Label lblCP;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.TextBox txtColonia;
        private System.Windows.Forms.Label lblColonia;
        private System.Windows.Forms.TextBox txtNumInt;
        private System.Windows.Forms.Label lblNumInt;
        private System.Windows.Forms.TextBox txtNumExt;
        private System.Windows.Forms.Label lblNumExt;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.Button btnResetPassword;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Label lblPassword;
        private System.Windows.Forms.TextBox txtNumCuenta;
        private System.Windows.Forms.Label lblNumCuenta;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label lblBanco;
    }
}