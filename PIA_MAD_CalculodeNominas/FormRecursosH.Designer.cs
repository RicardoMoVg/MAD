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
            this.pnlSide = new System.Windows.Forms.Panel();
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlBody = new System.Windows.Forms.Panel();
            this.tabControlEmpleado = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblIDEmpleado = new System.Windows.Forms.Label();
            this.txtIDEmpleado = new System.Windows.Forms.TextBox();
            this.lblNombreCompleto = new System.Windows.Forms.Label();
            this.txtNombreCompleto = new System.Windows.Forms.TextBox();
            this.lblFechaNac = new System.Windows.Forms.Label();
            this.dtpFechaNacimiento = new System.Windows.Forms.DateTimePicker();
            this.lblCURP = new System.Windows.Forms.Label();
            this.txtCURP = new System.Windows.Forms.TextBox();
            this.lblNSS = new System.Windows.Forms.Label();
            this.txtNSS = new System.Windows.Forms.TextBox();
            this.lblRFC = new System.Windows.Forms.Label();
            this.txtRFC = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblDepto = new System.Windows.Forms.Label();
            this.cmbDepartamento = new System.Windows.Forms.ComboBox();
            this.lblPuesto = new System.Windows.Forms.Label();
            this.cmbPuesto = new System.Windows.Forms.ComboBox();
            this.lblRegPatronal = new System.Windows.Forms.Label();
            this.lblCorreo = new System.Windows.Forms.Label();
            this.txtCorreo = new System.Windows.Forms.TextBox();
            this.lblTelefono = new System.Windows.Forms.Label();
            this.txtTelefono = new System.Windows.Forms.TextBox();
            this.txtRegistroPatronal = new System.Windows.Forms.TextBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lblCalle = new System.Windows.Forms.Label();
            this.txtCalle = new System.Windows.Forms.TextBox();
            this.lblNumExt = new System.Windows.Forms.Label();
            this.txtNumExt = new System.Windows.Forms.TextBox();
            this.lblNumInt = new System.Windows.Forms.Label();
            this.txtNumInt = new System.Windows.Forms.TextBox();
            this.lblColonia = new System.Windows.Forms.Label();
            this.txtColonia = new System.Windows.Forms.TextBox();
            this.lblMunicipio = new System.Windows.Forms.Label();
            this.txtMunicipio = new System.Windows.Forms.TextBox();
            this.lblEstado = new System.Windows.Forms.Label();
            this.txtEstado = new System.Windows.Forms.TextBox();
            this.lblCP = new System.Windows.Forms.Label();
            this.txtCP = new System.Windows.Forms.TextBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.lblBanco = new System.Windows.Forms.Label();
            this.txtBanco = new System.Windows.Forms.TextBox();
            this.lblNumCuenta = new System.Windows.Forms.Label();
            this.txtNumCuenta = new System.Windows.Forms.TextBox();
            this.lblSalarioD = new System.Windows.Forms.Label();
            this.numSalarioDiario = new System.Windows.Forms.NumericUpDown();
            this.lblSalarioMensual = new System.Windows.Forms.Label();
            this.txtSalarioMensual = new System.Windows.Forms.TextBox();
            this.btnCalcularSalarioD = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvEmpleados = new System.Windows.Forms.DataGridView();
            this.txtBuscar = new System.Windows.Forms.TextBox();
            this.btnBuscar = new System.Windows.Forms.Button();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.lblTitulo = new System.Windows.Forms.Label();
            this.pnlFooter = new System.Windows.Forms.Panel();
            this.btnDarDeBaja = new System.Windows.Forms.Button();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.pnlMain.SuspendLayout();
            this.pnlBody.SuspendLayout();
            this.tabControlEmpleado.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalarioDiario)).BeginInit();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).BeginInit();
            this.pnlHeader.SuspendLayout();
            this.pnlFooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSide
            // 
            this.pnlSide.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(80)))), ((int)(((byte)(150)))));
            this.pnlSide.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSide.Location = new System.Drawing.Point(0, 0);
            this.pnlSide.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlSide.Name = "pnlSide";
            this.pnlSide.Size = new System.Drawing.Size(267, 922);
            this.pnlSide.TabIndex = 0;
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pnlBody);
            this.pnlMain.Controls.Add(this.pnlGrid);
            this.pnlMain.Controls.Add(this.pnlHeader);
            this.pnlMain.Controls.Add(this.pnlFooter);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(267, 0);
            this.pnlMain.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(1045, 922);
            this.pnlMain.TabIndex = 1;
            // 
            // pnlBody
            // 
            this.pnlBody.AutoScroll = true;
            this.pnlBody.BackColor = System.Drawing.Color.White;
            this.pnlBody.Controls.Add(this.tabControlEmpleado);
            this.pnlBody.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlBody.Location = new System.Drawing.Point(0, 340);
            this.pnlBody.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlBody.Name = "pnlBody";
            this.pnlBody.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.pnlBody.Size = new System.Drawing.Size(1045, 508);
            this.pnlBody.TabIndex = 2;
            // 
            // tabControlEmpleado
            // 
            this.tabControlEmpleado.Controls.Add(this.tabPage1);
            this.tabControlEmpleado.Controls.Add(this.tabPage2);
            this.tabControlEmpleado.Controls.Add(this.tabPage3);
            this.tabControlEmpleado.Controls.Add(this.tabPage4);
            this.tabControlEmpleado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlEmpleado.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControlEmpleado.Location = new System.Drawing.Point(13, 12);
            this.tabControlEmpleado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabControlEmpleado.Name = "tabControlEmpleado";
            this.tabControlEmpleado.SelectedIndex = 0;
            this.tabControlEmpleado.Size = new System.Drawing.Size(1019, 484);
            this.tabControlEmpleado.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.tableLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 30);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.tabPage1.Size = new System.Drawing.Size(1011, 450);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Datos Personales";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.lblIDEmpleado, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtIDEmpleado, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.lblNombreCompleto, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtNombreCompleto, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.lblFechaNac, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.dtpFechaNacimiento, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.lblCURP, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.txtCURP, 1, 3);
            this.tableLayoutPanel1.Controls.Add(this.lblNSS, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.txtNSS, 1, 4);
            this.tableLayoutPanel1.Controls.Add(this.lblRFC, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.txtRFC, 1, 5);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(13, 12);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(985, 426);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblIDEmpleado
            // 
            this.lblIDEmpleado.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblIDEmpleado.AutoSize = true;
            this.lblIDEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblIDEmpleado.Location = new System.Drawing.Point(4, 8);
            this.lblIDEmpleado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIDEmpleado.Name = "lblIDEmpleado";
            this.lblIDEmpleado.Size = new System.Drawing.Size(99, 20);
            this.lblIDEmpleado.TabIndex = 0;
            this.lblIDEmpleado.Text = "ID Empleado:";
            // 
            // txtIDEmpleado
            // 
            this.txtIDEmpleado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtIDEmpleado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtIDEmpleado.Location = new System.Drawing.Point(164, 4);
            this.txtIDEmpleado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtIDEmpleado.Name = "txtIDEmpleado";
            this.txtIDEmpleado.ReadOnly = true;
            this.txtIDEmpleado.Size = new System.Drawing.Size(817, 27);
            this.txtIDEmpleado.TabIndex = 1;
            // 
            // lblNombreCompleto
            // 
            this.lblNombreCompleto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNombreCompleto.AutoSize = true;
            this.lblNombreCompleto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNombreCompleto.Location = new System.Drawing.Point(4, 45);
            this.lblNombreCompleto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNombreCompleto.Name = "lblNombreCompleto";
            this.lblNombreCompleto.Size = new System.Drawing.Size(137, 20);
            this.lblNombreCompleto.TabIndex = 2;
            this.lblNombreCompleto.Text = "Nombre Completo:";
            // 
            // txtNombreCompleto
            // 
            this.txtNombreCompleto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNombreCompleto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNombreCompleto.Location = new System.Drawing.Point(164, 41);
            this.txtNombreCompleto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNombreCompleto.Name = "txtNombreCompleto";
            this.txtNombreCompleto.Size = new System.Drawing.Size(817, 27);
            this.txtNombreCompleto.TabIndex = 3;
            // 
            // lblFechaNac
            // 
            this.lblFechaNac.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFechaNac.AutoSize = true;
            this.lblFechaNac.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFechaNac.Location = new System.Drawing.Point(4, 82);
            this.lblFechaNac.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblFechaNac.Name = "lblFechaNac";
            this.lblFechaNac.Size = new System.Drawing.Size(118, 20);
            this.lblFechaNac.TabIndex = 4;
            this.lblFechaNac.Text = "Fec. Nacimiento:";
            // 
            // dtpFechaNacimiento
            // 
            this.dtpFechaNacimiento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtpFechaNacimiento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dtpFechaNacimiento.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpFechaNacimiento.Location = new System.Drawing.Point(164, 78);
            this.dtpFechaNacimiento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtpFechaNacimiento.Name = "dtpFechaNacimiento";
            this.dtpFechaNacimiento.Size = new System.Drawing.Size(817, 27);
            this.dtpFechaNacimiento.TabIndex = 5;
            // 
            // lblCURP
            // 
            this.lblCURP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCURP.AutoSize = true;
            this.lblCURP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCURP.Location = new System.Drawing.Point(4, 119);
            this.lblCURP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCURP.Name = "lblCURP";
            this.lblCURP.Size = new System.Drawing.Size(48, 20);
            this.lblCURP.TabIndex = 6;
            this.lblCURP.Text = "CURP:";
            // 
            // txtCURP
            // 
            this.txtCURP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCURP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCURP.Location = new System.Drawing.Point(164, 115);
            this.txtCURP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCURP.MaxLength = 18;
            this.txtCURP.Name = "txtCURP";
            this.txtCURP.Size = new System.Drawing.Size(817, 27);
            this.txtCURP.TabIndex = 7;
            // 
            // lblNSS
            // 
            this.lblNSS.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNSS.AutoSize = true;
            this.lblNSS.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNSS.Location = new System.Drawing.Point(4, 156);
            this.lblNSS.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNSS.Name = "lblNSS";
            this.lblNSS.Size = new System.Drawing.Size(39, 20);
            this.lblNSS.TabIndex = 8;
            this.lblNSS.Text = "NSS:";
            // 
            // txtNSS
            // 
            this.txtNSS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNSS.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNSS.Location = new System.Drawing.Point(164, 152);
            this.txtNSS.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNSS.MaxLength = 11;
            this.txtNSS.Name = "txtNSS";
            this.txtNSS.Size = new System.Drawing.Size(817, 27);
            this.txtNSS.TabIndex = 9;
            // 
            // lblRFC
            // 
            this.lblRFC.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRFC.AutoSize = true;
            this.lblRFC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRFC.Location = new System.Drawing.Point(4, 193);
            this.lblRFC.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRFC.Name = "lblRFC";
            this.lblRFC.Size = new System.Drawing.Size(37, 20);
            this.lblRFC.TabIndex = 10;
            this.lblRFC.Text = "RFC:";
            // 
            // txtRFC
            // 
            this.txtRFC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRFC.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRFC.Location = new System.Drawing.Point(164, 189);
            this.txtRFC.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRFC.MaxLength = 13;
            this.txtRFC.Name = "txtRFC";
            this.txtRFC.Size = new System.Drawing.Size(817, 27);
            this.txtRFC.TabIndex = 11;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.tableLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 30);
            this.tabPage2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.tabPage2.Size = new System.Drawing.Size(1011, 450);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Laboral y Contacto";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.lblDepto, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.cmbDepartamento, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblPuesto, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.cmbPuesto, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.lblRegPatronal, 0, 2);
            this.tableLayoutPanel2.Controls.Add(this.lblCorreo, 0, 3);
            this.tableLayoutPanel2.Controls.Add(this.txtCorreo, 1, 3);
            this.tableLayoutPanel2.Controls.Add(this.lblTelefono, 0, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtTelefono, 1, 4);
            this.tableLayoutPanel2.Controls.Add(this.txtRegistroPatronal, 1, 2);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(13, 12);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 6;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(985, 426);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // lblDepto
            // 
            this.lblDepto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblDepto.AutoSize = true;
            this.lblDepto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblDepto.Location = new System.Drawing.Point(4, 8);
            this.lblDepto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDepto.Name = "lblDepto";
            this.lblDepto.Size = new System.Drawing.Size(109, 20);
            this.lblDepto.TabIndex = 0;
            this.lblDepto.Text = "Departamento:";
            // 
            // cmbDepartamento
            // 
            this.cmbDepartamento.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbDepartamento.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepartamento.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbDepartamento.FormattingEnabled = true;
            this.cmbDepartamento.Location = new System.Drawing.Point(164, 4);
            this.cmbDepartamento.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbDepartamento.Name = "cmbDepartamento";
            this.cmbDepartamento.Size = new System.Drawing.Size(817, 28);
            this.cmbDepartamento.TabIndex = 1;
            // 
            // lblPuesto
            // 
            this.lblPuesto.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPuesto.AutoSize = true;
            this.lblPuesto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblPuesto.Location = new System.Drawing.Point(4, 45);
            this.lblPuesto.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPuesto.Name = "lblPuesto";
            this.lblPuesto.Size = new System.Drawing.Size(56, 20);
            this.lblPuesto.TabIndex = 2;
            this.lblPuesto.Text = "Puesto:";
            // 
            // cmbPuesto
            // 
            this.cmbPuesto.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cmbPuesto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbPuesto.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbPuesto.FormattingEnabled = true;
            this.cmbPuesto.Location = new System.Drawing.Point(164, 41);
            this.cmbPuesto.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cmbPuesto.Name = "cmbPuesto";
            this.cmbPuesto.Size = new System.Drawing.Size(817, 28);
            this.cmbPuesto.TabIndex = 3;
            // 
            // lblRegPatronal
            // 
            this.lblRegPatronal.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblRegPatronal.AutoSize = true;
            this.lblRegPatronal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblRegPatronal.Location = new System.Drawing.Point(4, 82);
            this.lblRegPatronal.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblRegPatronal.Name = "lblRegPatronal";
            this.lblRegPatronal.Size = new System.Drawing.Size(125, 20);
            this.lblRegPatronal.TabIndex = 4;
            this.lblRegPatronal.Text = "Registro Patronal:";
            // 
            // lblCorreo
            // 
            this.lblCorreo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCorreo.AutoSize = true;
            this.lblCorreo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCorreo.Location = new System.Drawing.Point(4, 119);
            this.lblCorreo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCorreo.Name = "lblCorreo";
            this.lblCorreo.Size = new System.Drawing.Size(57, 20);
            this.lblCorreo.TabIndex = 6;
            this.lblCorreo.Text = "Correo:";
            // 
            // txtCorreo
            // 
            this.txtCorreo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCorreo.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCorreo.Location = new System.Drawing.Point(164, 115);
            this.txtCorreo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCorreo.Name = "txtCorreo";
            this.txtCorreo.Size = new System.Drawing.Size(817, 27);
            this.txtCorreo.TabIndex = 7;
            // 
            // lblTelefono
            // 
            this.lblTelefono.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTelefono.AutoSize = true;
            this.lblTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblTelefono.Location = new System.Drawing.Point(4, 156);
            this.lblTelefono.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTelefono.Name = "lblTelefono";
            this.lblTelefono.Size = new System.Drawing.Size(70, 20);
            this.lblTelefono.TabIndex = 8;
            this.lblTelefono.Text = "Teléfono:";
            // 
            // txtTelefono
            // 
            this.txtTelefono.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTelefono.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtTelefono.Location = new System.Drawing.Point(164, 152);
            this.txtTelefono.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtTelefono.MaxLength = 20;
            this.txtTelefono.Name = "txtTelefono";
            this.txtTelefono.Size = new System.Drawing.Size(817, 27);
            this.txtTelefono.TabIndex = 9;
            // 
            // txtRegistroPatronal
            // 
            this.txtRegistroPatronal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRegistroPatronal.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtRegistroPatronal.Location = new System.Drawing.Point(164, 78);
            this.txtRegistroPatronal.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtRegistroPatronal.MaxLength = 11;
            this.txtRegistroPatronal.Name = "txtRegistroPatronal";
            this.txtRegistroPatronal.Size = new System.Drawing.Size(817, 27);
            this.txtRegistroPatronal.TabIndex = 5;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.tableLayoutPanel3);
            this.tabPage3.Location = new System.Drawing.Point(4, 30);
            this.tabPage3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.tabPage3.Size = new System.Drawing.Size(1011, 450);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Dirección";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Controls.Add(this.lblCalle, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.txtCalle, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblNumExt, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.txtNumExt, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblNumInt, 0, 2);
            this.tableLayoutPanel3.Controls.Add(this.txtNumInt, 1, 2);
            this.tableLayoutPanel3.Controls.Add(this.lblColonia, 0, 3);
            this.tableLayoutPanel3.Controls.Add(this.txtColonia, 1, 3);
            this.tableLayoutPanel3.Controls.Add(this.lblMunicipio, 0, 4);
            this.tableLayoutPanel3.Controls.Add(this.txtMunicipio, 1, 4);
            this.tableLayoutPanel3.Controls.Add(this.lblEstado, 0, 5);
            this.tableLayoutPanel3.Controls.Add(this.txtEstado, 1, 5);
            this.tableLayoutPanel3.Controls.Add(this.lblCP, 0, 6);
            this.tableLayoutPanel3.Controls.Add(this.txtCP, 1, 6);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(13, 12);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 8;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(985, 426);
            this.tableLayoutPanel3.TabIndex = 0;
            // 
            // lblCalle
            // 
            this.lblCalle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCalle.AutoSize = true;
            this.lblCalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCalle.Location = new System.Drawing.Point(4, 8);
            this.lblCalle.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCalle.Name = "lblCalle";
            this.lblCalle.Size = new System.Drawing.Size(45, 20);
            this.lblCalle.TabIndex = 0;
            this.lblCalle.Text = "Calle:";
            // 
            // txtCalle
            // 
            this.txtCalle.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCalle.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCalle.Location = new System.Drawing.Point(164, 4);
            this.txtCalle.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCalle.Name = "txtCalle";
            this.txtCalle.Size = new System.Drawing.Size(817, 27);
            this.txtCalle.TabIndex = 1;
            // 
            // lblNumExt
            // 
            this.lblNumExt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNumExt.AutoSize = true;
            this.lblNumExt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNumExt.Location = new System.Drawing.Point(4, 45);
            this.lblNumExt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumExt.Name = "lblNumExt";
            this.lblNumExt.Size = new System.Drawing.Size(71, 20);
            this.lblNumExt.TabIndex = 2;
            this.lblNumExt.Text = "Num. Ext:";
            // 
            // txtNumExt
            // 
            this.txtNumExt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNumExt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNumExt.Location = new System.Drawing.Point(164, 41);
            this.txtNumExt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumExt.Name = "txtNumExt";
            this.txtNumExt.Size = new System.Drawing.Size(817, 27);
            this.txtNumExt.TabIndex = 3;
            // 
            // lblNumInt
            // 
            this.lblNumInt.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNumInt.AutoSize = true;
            this.lblNumInt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNumInt.Location = new System.Drawing.Point(4, 82);
            this.lblNumInt.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumInt.Name = "lblNumInt";
            this.lblNumInt.Size = new System.Drawing.Size(68, 20);
            this.lblNumInt.TabIndex = 4;
            this.lblNumInt.Text = "Num. Int:";
            // 
            // txtNumInt
            // 
            this.txtNumInt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNumInt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNumInt.Location = new System.Drawing.Point(164, 78);
            this.txtNumInt.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumInt.Name = "txtNumInt";
            this.txtNumInt.Size = new System.Drawing.Size(817, 27);
            this.txtNumInt.TabIndex = 5;
            // 
            // lblColonia
            // 
            this.lblColonia.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblColonia.AutoSize = true;
            this.lblColonia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblColonia.Location = new System.Drawing.Point(4, 119);
            this.lblColonia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblColonia.Name = "lblColonia";
            this.lblColonia.Size = new System.Drawing.Size(63, 20);
            this.lblColonia.TabIndex = 6;
            this.lblColonia.Text = "Colonia:";
            // 
            // txtColonia
            // 
            this.txtColonia.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtColonia.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtColonia.Location = new System.Drawing.Point(164, 115);
            this.txtColonia.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtColonia.Name = "txtColonia";
            this.txtColonia.Size = new System.Drawing.Size(817, 27);
            this.txtColonia.TabIndex = 7;
            // 
            // lblMunicipio
            // 
            this.lblMunicipio.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblMunicipio.AutoSize = true;
            this.lblMunicipio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblMunicipio.Location = new System.Drawing.Point(4, 156);
            this.lblMunicipio.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblMunicipio.Name = "lblMunicipio";
            this.lblMunicipio.Size = new System.Drawing.Size(78, 20);
            this.lblMunicipio.TabIndex = 8;
            this.lblMunicipio.Text = "Municipio:";
            // 
            // txtMunicipio
            // 
            this.txtMunicipio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtMunicipio.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtMunicipio.Location = new System.Drawing.Point(164, 152);
            this.txtMunicipio.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtMunicipio.Name = "txtMunicipio";
            this.txtMunicipio.Size = new System.Drawing.Size(817, 27);
            this.txtMunicipio.TabIndex = 9;
            // 
            // lblEstado
            // 
            this.lblEstado.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblEstado.AutoSize = true;
            this.lblEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblEstado.Location = new System.Drawing.Point(4, 193);
            this.lblEstado.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEstado.Name = "lblEstado";
            this.lblEstado.Size = new System.Drawing.Size(57, 20);
            this.lblEstado.TabIndex = 10;
            this.lblEstado.Text = "Estado:";
            // 
            // txtEstado
            // 
            this.txtEstado.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtEstado.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtEstado.Location = new System.Drawing.Point(164, 189);
            this.txtEstado.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtEstado.Name = "txtEstado";
            this.txtEstado.Size = new System.Drawing.Size(817, 27);
            this.txtEstado.TabIndex = 11;
            // 
            // lblCP
            // 
            this.lblCP.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblCP.AutoSize = true;
            this.lblCP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblCP.Location = new System.Drawing.Point(4, 230);
            this.lblCP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCP.Name = "lblCP";
            this.lblCP.Size = new System.Drawing.Size(104, 20);
            this.lblCP.TabIndex = 12;
            this.lblCP.Text = "Código Postal:";
            // 
            // txtCP
            // 
            this.txtCP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtCP.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtCP.Location = new System.Drawing.Point(164, 226);
            this.txtCP.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCP.MaxLength = 5;
            this.txtCP.Name = "txtCP";
            this.txtCP.Size = new System.Drawing.Size(817, 27);
            this.txtCP.TabIndex = 13;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.tableLayoutPanel4);
            this.tabPage4.Location = new System.Drawing.Point(4, 30);
            this.tabPage4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.tabPage4.Size = new System.Drawing.Size(1011, 450);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Bancario y Salario";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.ColumnCount = 3;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 160F));
            this.tableLayoutPanel4.Controls.Add(this.lblBanco, 0, 0);
            this.tableLayoutPanel4.Controls.Add(this.txtBanco, 1, 0);
            this.tableLayoutPanel4.Controls.Add(this.lblNumCuenta, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.txtNumCuenta, 1, 1);
            this.tableLayoutPanel4.Controls.Add(this.lblSalarioD, 0, 2);
            this.tableLayoutPanel4.Controls.Add(this.numSalarioDiario, 1, 2);
            this.tableLayoutPanel4.Controls.Add(this.lblSalarioMensual, 0, 3);
            this.tableLayoutPanel4.Controls.Add(this.txtSalarioMensual, 1, 3);
            this.tableLayoutPanel4.Controls.Add(this.btnCalcularSalarioD, 2, 3);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(13, 12);
            this.tableLayoutPanel4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 5;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 37F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel4.Size = new System.Drawing.Size(985, 426);
            this.tableLayoutPanel4.TabIndex = 0;
            // 
            // lblBanco
            // 
            this.lblBanco.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblBanco.AutoSize = true;
            this.lblBanco.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblBanco.Location = new System.Drawing.Point(4, 8);
            this.lblBanco.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBanco.Name = "lblBanco";
            this.lblBanco.Size = new System.Drawing.Size(53, 20);
            this.lblBanco.TabIndex = 0;
            this.lblBanco.Text = "Banco:";
            // 
            // txtBanco
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.txtBanco, 2);
            this.txtBanco.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBanco.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtBanco.Location = new System.Drawing.Point(164, 4);
            this.txtBanco.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBanco.Name = "txtBanco";
            this.txtBanco.Size = new System.Drawing.Size(817, 27);
            this.txtBanco.TabIndex = 1;
            // 
            // lblNumCuenta
            // 
            this.lblNumCuenta.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblNumCuenta.AutoSize = true;
            this.lblNumCuenta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblNumCuenta.Location = new System.Drawing.Point(4, 45);
            this.lblNumCuenta.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNumCuenta.Name = "lblNumCuenta";
            this.lblNumCuenta.Size = new System.Drawing.Size(118, 20);
            this.lblNumCuenta.TabIndex = 2;
            this.lblNumCuenta.Text = "Num. de Cuenta:";
            // 
            // txtNumCuenta
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.txtNumCuenta, 2);
            this.txtNumCuenta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtNumCuenta.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtNumCuenta.Location = new System.Drawing.Point(164, 41);
            this.txtNumCuenta.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtNumCuenta.Name = "txtNumCuenta";
            this.txtNumCuenta.Size = new System.Drawing.Size(817, 27);
            this.txtNumCuenta.TabIndex = 3;
            // 
            // lblSalarioD
            // 
            this.lblSalarioD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSalarioD.AutoSize = true;
            this.lblSalarioD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSalarioD.Location = new System.Drawing.Point(4, 82);
            this.lblSalarioD.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalarioD.Name = "lblSalarioD";
            this.lblSalarioD.Size = new System.Drawing.Size(103, 20);
            this.lblSalarioD.TabIndex = 4;
            this.lblSalarioD.Text = "Salario Diario:";
            // 
            // numSalarioDiario
            // 
            this.tableLayoutPanel4.SetColumnSpan(this.numSalarioDiario, 2);
            this.numSalarioDiario.DecimalPlaces = 2;
            this.numSalarioDiario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.numSalarioDiario.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.numSalarioDiario.Location = new System.Drawing.Point(164, 78);
            this.numSalarioDiario.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.numSalarioDiario.Maximum = new decimal(new int[] {
            999999,
            0,
            0,
            0});
            this.numSalarioDiario.Name = "numSalarioDiario";
            this.numSalarioDiario.Size = new System.Drawing.Size(817, 27);
            this.numSalarioDiario.TabIndex = 5;
            // 
            // lblSalarioMensual
            // 
            this.lblSalarioMensual.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblSalarioMensual.AutoSize = true;
            this.lblSalarioMensual.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.lblSalarioMensual.Location = new System.Drawing.Point(4, 119);
            this.lblSalarioMensual.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSalarioMensual.Name = "lblSalarioMensual";
            this.lblSalarioMensual.Size = new System.Drawing.Size(123, 20);
            this.lblSalarioMensual.TabIndex = 6;
            this.lblSalarioMensual.Text = "Salario Mensual:";
            // 
            // txtSalarioMensual
            // 
            this.txtSalarioMensual.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSalarioMensual.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSalarioMensual.Location = new System.Drawing.Point(164, 115);
            this.txtSalarioMensual.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtSalarioMensual.Name = "txtSalarioMensual";
            this.txtSalarioMensual.Size = new System.Drawing.Size(657, 27);
            this.txtSalarioMensual.TabIndex = 7;
            // 
            // btnCalcularSalarioD
            // 
            this.btnCalcularSalarioD.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnCalcularSalarioD.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnCalcularSalarioD.FlatAppearance.BorderSize = 0;
            this.btnCalcularSalarioD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcularSalarioD.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnCalcularSalarioD.Location = new System.Drawing.Point(829, 115);
            this.btnCalcularSalarioD.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnCalcularSalarioD.Name = "btnCalcularSalarioD";
            this.btnCalcularSalarioD.Size = new System.Drawing.Size(152, 28);
            this.btnCalcularSalarioD.TabIndex = 8;
            this.btnCalcularSalarioD.Text = "Calcular Diario";
            this.btnCalcularSalarioD.UseVisualStyleBackColor = false;
            this.btnCalcularSalarioD.Click += new System.EventHandler(this.btnCalcularSalarioD_Click);
            // 
            // pnlGrid
            // 
            this.pnlGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlGrid.Controls.Add(this.dgvEmpleados);
            this.pnlGrid.Controls.Add(this.txtBuscar);
            this.pnlGrid.Controls.Add(this.btnBuscar);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlGrid.Location = new System.Drawing.Point(0, 74);
            this.pnlGrid.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlGrid.Name = "pnlGrid";
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.pnlGrid.Size = new System.Drawing.Size(1045, 266);
            this.pnlGrid.TabIndex = 1;
            // 
            // dgvEmpleados
            // 
            this.dgvEmpleados.AllowUserToAddRows = false;
            this.dgvEmpleados.AllowUserToDeleteRows = false;
            this.dgvEmpleados.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvEmpleados.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvEmpleados.BackgroundColor = System.Drawing.Color.White;
            this.dgvEmpleados.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvEmpleados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmpleados.Location = new System.Drawing.Point(13, 52);
            this.dgvEmpleados.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dgvEmpleados.MultiSelect = false;
            this.dgvEmpleados.Name = "dgvEmpleados";
            this.dgvEmpleados.ReadOnly = true;
            this.dgvEmpleados.RowHeadersVisible = false;
            this.dgvEmpleados.RowHeadersWidth = 51;
            this.dgvEmpleados.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmpleados.Size = new System.Drawing.Size(1019, 202);
            this.dgvEmpleados.TabIndex = 2;
            this.dgvEmpleados.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvEmpleados_CellClick);
            // 
            // txtBuscar
            // 
            this.txtBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.txtBuscar.Location = new System.Drawing.Point(13, 12);
            this.txtBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBuscar.Name = "txtBuscar";
            this.txtBuscar.Size = new System.Drawing.Size(872, 29);
            this.txtBuscar.TabIndex = 0;
            // 
            // btnBuscar
            // 
            this.btnBuscar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBuscar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnBuscar.FlatAppearance.BorderSize = 0;
            this.btnBuscar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBuscar.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnBuscar.Location = new System.Drawing.Point(895, 11);
            this.btnBuscar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnBuscar.Name = "btnBuscar";
            this.btnBuscar.Size = new System.Drawing.Size(137, 33);
            this.btnBuscar.TabIndex = 1;
            this.btnBuscar.Text = "Buscar";
            this.btnBuscar.UseVisualStyleBackColor = false;
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
            this.lblTitulo.Size = new System.Drawing.Size(399, 37);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Administración de Empleados";
            // 
            // pnlFooter
            // 
            this.pnlFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.pnlFooter.Controls.Add(this.btnDarDeBaja);
            this.pnlFooter.Controls.Add(this.btnGuardar);
            this.pnlFooter.Controls.Add(this.btnLimpiar);
            this.pnlFooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlFooter.Location = new System.Drawing.Point(0, 848);
            this.pnlFooter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pnlFooter.Name = "pnlFooter";
            this.pnlFooter.Size = new System.Drawing.Size(1045, 74);
            this.pnlFooter.TabIndex = 3;
            // 
            // btnDarDeBaja
            // 
            this.btnDarDeBaja.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDarDeBaja.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(83)))), ((int)(((byte)(79)))));
            this.btnDarDeBaja.FlatAppearance.BorderSize = 0;
            this.btnDarDeBaja.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDarDeBaja.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnDarDeBaja.ForeColor = System.Drawing.Color.White;
            this.btnDarDeBaja.Location = new System.Drawing.Point(708, 17);
            this.btnDarDeBaja.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDarDeBaja.Name = "btnDarDeBaja";
            this.btnDarDeBaja.Size = new System.Drawing.Size(147, 42);
            this.btnDarDeBaja.TabIndex = 2;
            this.btnDarDeBaja.Text = "Dar de Baja";
            this.btnDarDeBaja.UseVisualStyleBackColor = false;
            this.btnDarDeBaja.Click += new System.EventHandler(this.btnDarDeBaja_Click);
            // 
            // btnGuardar
            // 
            this.btnGuardar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGuardar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnGuardar.ForeColor = System.Drawing.Color.White;
            this.btnGuardar.Location = new System.Drawing.Point(880, 17);
            this.btnGuardar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(147, 42);
            this.btnGuardar.TabIndex = 1;
            this.btnGuardar.Text = "Guardar";
            this.btnGuardar.UseVisualStyleBackColor = false;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLimpiar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLimpiar.FlatAppearance.BorderSize = 0;
            this.btnLimpiar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpiar.Font = new System.Drawing.Font("Segoe UI", 9.75F);
            this.btnLimpiar.ForeColor = System.Drawing.Color.Black;
            this.btnLimpiar.Location = new System.Drawing.Point(536, 17);
            this.btnLimpiar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(147, 42);
            this.btnLimpiar.TabIndex = 0;
            this.btnLimpiar.Text = "Limpiar (Nuevo)";
            this.btnLimpiar.UseVisualStyleBackColor = false;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click);
            // 
            // FormRecursosH
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1312, 922);
            this.Controls.Add(this.pnlMain);
            this.Controls.Add(this.pnlSide);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(1194, 883);
            this.Name = "FormRecursosH";
            this.Text = "Administración de Recursos Humanos";
            this.Load += new System.EventHandler(this.FormRecursosH_Load);
            this.pnlMain.ResumeLayout(false);
            this.pnlBody.ResumeLayout(false);
            this.tabControlEmpleado.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSalarioDiario)).EndInit();
            this.pnlGrid.ResumeLayout(false);
            this.pnlGrid.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmpleados)).EndInit();
            this.pnlHeader.ResumeLayout(false);
            this.pnlHeader.PerformLayout();
            this.pnlFooter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSide;
        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel pnlFooter;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvEmpleados;
        private System.Windows.Forms.TextBox txtBuscar;
        private System.Windows.Forms.Button btnBuscar;
        private System.Windows.Forms.Panel pnlBody;
        private System.Windows.Forms.Button btnDarDeBaja;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnLimpiar;
        private System.Windows.Forms.TabControl tabControlEmpleado;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblIDEmpleado;
        private System.Windows.Forms.TextBox txtIDEmpleado;
        private System.Windows.Forms.Label lblNombreCompleto;
        private System.Windows.Forms.TextBox txtNombreCompleto;
        private System.Windows.Forms.Label lblFechaNac;
        private System.Windows.Forms.DateTimePicker dtpFechaNacimiento;
        private System.Windows.Forms.Label lblCURP;
        private System.Windows.Forms.TextBox txtCURP;
        private System.Windows.Forms.Label lblNSS;
        private System.Windows.Forms.TextBox txtNSS;
        private System.Windows.Forms.Label lblRFC;
        private System.Windows.Forms.TextBox txtRFC;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblDepto;
        private System.Windows.Forms.ComboBox cmbDepartamento;
        private System.Windows.Forms.Label lblPuesto;
        private System.Windows.Forms.ComboBox cmbPuesto;
        private System.Windows.Forms.Label lblRegPatronal;
        private System.Windows.Forms.Label lblCorreo;
        private System.Windows.Forms.TextBox txtCorreo;
        private System.Windows.Forms.Label lblTelefono;
        private System.Windows.Forms.TextBox txtTelefono;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblCalle;
        private System.Windows.Forms.TextBox txtCalle;
        private System.Windows.Forms.Label lblNumExt;
        private System.Windows.Forms.TextBox txtNumExt;
        private System.Windows.Forms.Label lblNumInt;
        private System.Windows.Forms.TextBox txtNumInt;
        private System.Windows.Forms.Label lblColonia;
        private System.Windows.Forms.TextBox txtColonia;
        private System.Windows.Forms.Label lblMunicipio;
        private System.Windows.Forms.TextBox txtMunicipio;
        private System.Windows.Forms.Label lblEstado;
        private System.Windows.Forms.TextBox txtEstado;
        private System.Windows.Forms.Label lblCP;
        private System.Windows.Forms.TextBox txtCP;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel4;
        private System.Windows.Forms.Label lblBanco;
        private System.Windows.Forms.TextBox txtBanco;
        private System.Windows.Forms.Label lblNumCuenta;
        private System.Windows.Forms.TextBox txtNumCuenta;
        private System.Windows.Forms.Label lblSalarioD;
        private System.Windows.Forms.NumericUpDown numSalarioDiario;
        private System.Windows.Forms.Label lblSalarioMensual;
        private System.Windows.Forms.TextBox txtSalarioMensual;
        private System.Windows.Forms.Button btnCalcularSalarioD;
        private System.Windows.Forms.TextBox txtRegistroPatronal;
    }
}