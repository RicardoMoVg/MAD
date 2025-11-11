namespace PIA_MAD_CalculodeNominas
{
    partial class FormReportes
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
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnExportarPDF = new System.Windows.Forms.Button();
            this.btnExportarCSV = new System.Windows.Forms.Button();
            this.btnReporteNomina = new System.Windows.Forms.Button();
            this.btnReporteHeadcounter = new System.Windows.Forms.Button();
            this.btnReporteGeneral = new System.Windows.Forms.Button();
            this.lblTituloApp = new System.Windows.Forms.Label();
            this.pnlContenido = new System.Windows.Forms.Panel();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.pnlFiltros = new System.Windows.Forms.Panel();
            this.gbFiltroNominaDepto = new System.Windows.Forms.GroupBox();
            this.btnGenerar_Depto = new System.Windows.Forms.Button();
            this.cmbAnio_Depto = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.gbFiltroHeadcounter = new System.Windows.Forms.GroupBox();
            this.btnGenerar_HC = new System.Windows.Forms.Button();
            this.cmbAnio_HC = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmbMes_HC = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbDepto_HC = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.gbFiltroGeneral = new System.Windows.Forms.GroupBox();
            this.btnGenerar_Gen = new System.Windows.Forms.Button();
            this.cmbAnio_Gen = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbMes_Gen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTituloReporte = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            this.pnlContenido.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.pnlFiltros.SuspendLayout();
            this.gbFiltroNominaDepto.SuspendLayout();
            this.gbFiltroHeadcounter.SuspendLayout();
            this.gbFiltroGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMenu
            // 
            this.pnlMenu.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlMenu.Controls.Add(this.btnExportarPDF);
            this.pnlMenu.Controls.Add(this.btnExportarCSV);
            this.pnlMenu.Controls.Add(this.btnReporteNomina);
            this.pnlMenu.Controls.Add(this.btnReporteHeadcounter);
            this.pnlMenu.Controls.Add(this.btnReporteGeneral);
            this.pnlMenu.Controls.Add(this.lblTituloApp);
            this.pnlMenu.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlMenu.Location = new System.Drawing.Point(0, 0);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(200, 600);
            this.pnlMenu.TabIndex = 0;
            // 
            // btnExportarPDF
            // 
            this.btnExportarPDF.Enabled = false;
            this.btnExportarPDF.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarPDF.Location = new System.Drawing.Point(12, 556);
            this.btnExportarPDF.Name = "btnExportarPDF";
            this.btnExportarPDF.Size = new System.Drawing.Size(176, 32);
            this.btnExportarPDF.TabIndex = 5;
            this.btnExportarPDF.Text = "Exportar a PDF";
            this.btnExportarPDF.UseVisualStyleBackColor = true;
            this.btnExportarPDF.Click += new System.EventHandler(this.btnExportarPDF_Click);
            // 
            // btnExportarCSV
            // 
            this.btnExportarCSV.Enabled = false;
            this.btnExportarCSV.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportarCSV.Location = new System.Drawing.Point(12, 518);
            this.btnExportarCSV.Name = "btnExportarCSV";
            this.btnExportarCSV.Size = new System.Drawing.Size(176, 32);
            this.btnExportarCSV.TabIndex = 4;
            this.btnExportarCSV.Text = "Exportar a CSV";
            this.btnExportarCSV.UseVisualStyleBackColor = true;
            this.btnExportarCSV.Click += new System.EventHandler(this.btnExportarCSV_Click);
            // 
            // btnReporteNomina
            // 
            this.btnReporteNomina.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteNomina.Location = new System.Drawing.Point(12, 142);
            this.btnReporteNomina.Name = "btnReporteNomina";
            this.btnReporteNomina.Size = new System.Drawing.Size(176, 32);
            this.btnReporteNomina.TabIndex = 3;
            this.btnReporteNomina.Text = "Nómina por Departamento";
            this.btnReporteNomina.UseVisualStyleBackColor = true;
            this.btnReporteNomina.Click += new System.EventHandler(this.btnReporteNomina_Click);
            // 
            // btnReporteHeadcounter
            // 
            this.btnReporteHeadcounter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteHeadcounter.Location = new System.Drawing.Point(12, 104);
            this.btnReporteHeadcounter.Name = "btnReporteHeadcounter";
            this.btnReporteHeadcounter.Size = new System.Drawing.Size(176, 32);
            this.btnReporteHeadcounter.TabIndex = 2;
            this.btnReporteHeadcounter.Text = "Reporte Headcounter";
            this.btnReporteHeadcounter.UseVisualStyleBackColor = true;
            this.btnReporteHeadcounter.Click += new System.EventHandler(this.btnReporteHeadcounter_Click);
            // 
            // btnReporteGeneral
            // 
            this.btnReporteGeneral.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteGeneral.Location = new System.Drawing.Point(12, 66);
            this.btnReporteGeneral.Name = "btnReporteGeneral";
            this.btnReporteGeneral.Size = new System.Drawing.Size(176, 32);
            this.btnReporteGeneral.TabIndex = 1;
            this.btnReporteGeneral.Text = "Reporte General de Nómina";
            this.btnReporteGeneral.UseVisualStyleBackColor = true;
            this.btnReporteGeneral.Click += new System.EventHandler(this.btnReporteGeneral_Click);
            // 
            // lblTituloApp
            // 
            this.lblTituloApp.AutoSize = true;
            this.lblTituloApp.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloApp.Location = new System.Drawing.Point(12, 20);
            this.lblTituloApp.Name = "lblTituloApp";
            this.lblTituloApp.Size = new System.Drawing.Size(92, 25);
            this.lblTituloApp.TabIndex = 0;
            this.lblTituloApp.Text = "Reportes";
            // 
            // pnlContenido
            // 
            this.pnlContenido.BackColor = System.Drawing.Color.White;
            this.pnlContenido.Controls.Add(this.dgvReporte);
            this.pnlContenido.Controls.Add(this.pnlFiltros);
            this.pnlContenido.Controls.Add(this.lblTituloReporte);
            this.pnlContenido.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContenido.Location = new System.Drawing.Point(200, 0);
            this.pnlContenido.Name = "pnlContenido";
            this.pnlContenido.Size = new System.Drawing.Size(784, 600);
            this.pnlContenido.TabIndex = 1;
            this.pnlContenido.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlContenido_Paint);
            // 
            // dgvReporte
            // 
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(16, 180);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.Size = new System.Drawing.Size(756, 408);
            this.dgvReporte.TabIndex = 2;
            // 
            // pnlFiltros
            // 
            this.pnlFiltros.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlFiltros.Controls.Add(this.gbFiltroNominaDepto);
            this.pnlFiltros.Controls.Add(this.gbFiltroHeadcounter);
            this.pnlFiltros.Controls.Add(this.gbFiltroGeneral);
            this.pnlFiltros.Location = new System.Drawing.Point(16, 66);
            this.pnlFiltros.Name = "pnlFiltros";
            this.pnlFiltros.Size = new System.Drawing.Size(756, 108);
            this.pnlFiltros.TabIndex = 1;
            // 
            // gbFiltroNominaDepto
            // 
            this.gbFiltroNominaDepto.Controls.Add(this.btnGenerar_Depto);
            this.gbFiltroNominaDepto.Controls.Add(this.cmbAnio_Depto);
            this.gbFiltroNominaDepto.Controls.Add(this.label6);
            this.gbFiltroNominaDepto.Location = new System.Drawing.Point(3, 3);
            this.gbFiltroNominaDepto.Name = "gbFiltroNominaDepto";
            this.gbFiltroNominaDepto.Size = new System.Drawing.Size(750, 100);
            this.gbFiltroNominaDepto.TabIndex = 2;
            this.gbFiltroNominaDepto.TabStop = false;
            this.gbFiltroNominaDepto.Text = "Filtros";
            // 
            // btnGenerar_Depto
            // 
            this.btnGenerar_Depto.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar_Depto.Location = new System.Drawing.Point(165, 41);
            this.btnGenerar_Depto.Name = "btnGenerar_Depto";
            this.btnGenerar_Depto.Size = new System.Drawing.Size(121, 23);
            this.btnGenerar_Depto.TabIndex = 2;
            this.btnGenerar_Depto.Text = "Generar Reporte";
            this.btnGenerar_Depto.UseVisualStyleBackColor = true;
            this.btnGenerar_Depto.Click += new System.EventHandler(this.btnGenerar_Depto_Click);
            // 
            // cmbAnio_Depto
            // 
            this.cmbAnio_Depto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio_Depto.FormattingEnabled = true;
            this.cmbAnio_Depto.Location = new System.Drawing.Point(19, 43);
            this.cmbAnio_Depto.Name = "cmbAnio_Depto";
            this.cmbAnio_Depto.Size = new System.Drawing.Size(121, 21);
            this.cmbAnio_Depto.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(16, 27);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(29, 13);
            this.label6.TabIndex = 0;
            this.label6.Text = "Año:";
            // 
            // gbFiltroHeadcounter
            // 
            this.gbFiltroHeadcounter.Controls.Add(this.btnGenerar_HC);
            this.gbFiltroHeadcounter.Controls.Add(this.cmbAnio_HC);
            this.gbFiltroHeadcounter.Controls.Add(this.label3);
            this.gbFiltroHeadcounter.Controls.Add(this.cmbMes_HC);
            this.gbFiltroHeadcounter.Controls.Add(this.label4);
            this.gbFiltroHeadcounter.Controls.Add(this.cmbDepto_HC);
            this.gbFiltroHeadcounter.Controls.Add(this.label5);
            this.gbFiltroHeadcounter.Location = new System.Drawing.Point(3, 3);
            this.gbFiltroHeadcounter.Name = "gbFiltroHeadcounter";
            this.gbFiltroHeadcounter.Size = new System.Drawing.Size(750, 100);
            this.gbFiltroHeadcounter.TabIndex = 1;
            this.gbFiltroHeadcounter.TabStop = false;
            this.gbFiltroHeadcounter.Text = "Filtros";
            // 
            // btnGenerar_HC
            // 
            this.btnGenerar_HC.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar_HC.Location = new System.Drawing.Point(475, 41);
            this.btnGenerar_HC.Name = "btnGenerar_HC";
            this.btnGenerar_HC.Size = new System.Drawing.Size(121, 23);
            this.btnGenerar_HC.TabIndex = 6;
            this.btnGenerar_HC.Text = "Generar Reporte";
            this.btnGenerar_HC.UseVisualStyleBackColor = true;
            this.btnGenerar_HC.Click += new System.EventHandler(this.btnGenerar_HC_Click);
            // 
            // cmbAnio_HC
            // 
            this.cmbAnio_HC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio_HC.FormattingEnabled = true;
            this.cmbAnio_HC.Location = new System.Drawing.Point(328, 43);
            this.cmbAnio_HC.Name = "cmbAnio_HC";
            this.cmbAnio_HC.Size = new System.Drawing.Size(121, 21);
            this.cmbAnio_HC.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(325, 27);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Año:";
            // 
            // cmbMes_HC
            // 
            this.cmbMes_HC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes_HC.FormattingEnabled = true;
            this.cmbMes_HC.Location = new System.Drawing.Point(182, 43);
            this.cmbMes_HC.Name = "cmbMes_HC";
            this.cmbMes_HC.Size = new System.Drawing.Size(121, 21);
            this.cmbMes_HC.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(179, 27);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 13);
            this.label4.TabIndex = 2;
            this.label4.Text = "Mes:";
            // 
            // cmbDepto_HC
            // 
            this.cmbDepto_HC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDepto_HC.FormattingEnabled = true;
            this.cmbDepto_HC.Location = new System.Drawing.Point(19, 43);
            this.cmbDepto_HC.Name = "cmbDepto_HC";
            this.cmbDepto_HC.Size = new System.Drawing.Size(138, 21);
            this.cmbDepto_HC.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(16, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 0;
            this.label5.Text = "Departamento:";
            // 
            // gbFiltroGeneral
            // 
            this.gbFiltroGeneral.Controls.Add(this.btnGenerar_Gen);
            this.gbFiltroGeneral.Controls.Add(this.cmbAnio_Gen);
            this.gbFiltroGeneral.Controls.Add(this.label2);
            this.gbFiltroGeneral.Controls.Add(this.cmbMes_Gen);
            this.gbFiltroGeneral.Controls.Add(this.label1);
            this.gbFiltroGeneral.Location = new System.Drawing.Point(3, 3);
            this.gbFiltroGeneral.Name = "gbFiltroGeneral";
            this.gbFiltroGeneral.Size = new System.Drawing.Size(750, 100);
            this.gbFiltroGeneral.TabIndex = 0;
            this.gbFiltroGeneral.TabStop = false;
            this.gbFiltroGeneral.Text = "Filtros";
            // 
            // btnGenerar_Gen
            // 
            this.btnGenerar_Gen.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGenerar_Gen.Location = new System.Drawing.Point(328, 41);
            this.btnGenerar_Gen.Name = "btnGenerar_Gen";
            this.btnGenerar_Gen.Size = new System.Drawing.Size(121, 23);
            this.btnGenerar_Gen.TabIndex = 4;
            this.btnGenerar_Gen.Text = "Generar Reporte";
            this.btnGenerar_Gen.UseVisualStyleBackColor = true;
            this.btnGenerar_Gen.Click += new System.EventHandler(this.btnGenerar_Gen_Click);
            // 
            // cmbAnio_Gen
            // 
            this.cmbAnio_Gen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio_Gen.FormattingEnabled = true;
            this.cmbAnio_Gen.Location = new System.Drawing.Point(182, 43);
            this.cmbAnio_Gen.Name = "cmbAnio_Gen";
            this.cmbAnio_Gen.Size = new System.Drawing.Size(121, 21);
            this.cmbAnio_Gen.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(179, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Año:";
            // 
            // cmbMes_Gen
            // 
            this.cmbMes_Gen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes_Gen.FormattingEnabled = true;
            this.cmbMes_Gen.Location = new System.Drawing.Point(19, 43);
            this.cmbMes_Gen.Name = "cmbMes_Gen";
            this.cmbMes_Gen.Size = new System.Drawing.Size(138, 21);
            this.cmbMes_Gen.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mes:";
            // 
            // lblTituloReporte
            // 
            this.lblTituloReporte.AutoSize = true;
            this.lblTituloReporte.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloReporte.Location = new System.Drawing.Point(11, 20);
            this.lblTituloReporte.Name = "lblTituloReporte";
            this.lblTituloReporte.Size = new System.Drawing.Size(275, 25);
            this.lblTituloReporte.TabIndex = 0;
            this.lblTituloReporte.Text = "Seleccione un tipo de reporte";
            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(984, 600);
            this.Controls.Add(this.pnlContenido);
            this.Controls.Add(this.pnlMenu);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormReportes";
            this.Text = "FormReportes";
            this.Load += new System.EventHandler(this.FormReportes_Load);
            this.pnlMenu.ResumeLayout(false);
            this.pnlMenu.PerformLayout();
            this.pnlContenido.ResumeLayout(false);
            this.pnlContenido.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.pnlFiltros.ResumeLayout(false);
            this.gbFiltroNominaDepto.ResumeLayout(false);
            this.gbFiltroNominaDepto.PerformLayout();
            this.gbFiltroHeadcounter.ResumeLayout(false);
            this.gbFiltroHeadcounter.PerformLayout();
            this.gbFiltroGeneral.ResumeLayout(false);
            this.gbFiltroGeneral.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMenu;
        private System.Windows.Forms.Panel pnlContenido;
        private System.Windows.Forms.Button btnReporteNomina;
        private System.Windows.Forms.Button btnReporteHeadcounter;
        private System.Windows.Forms.Button btnReporteGeneral;
        private System.Windows.Forms.Label lblTituloApp;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Panel pnlFiltros;
        private System.Windows.Forms.Label lblTituloReporte;
        private System.Windows.Forms.GroupBox gbFiltroGeneral;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbMes_Gen;
        private System.Windows.Forms.ComboBox cmbAnio_Gen;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnGenerar_Gen;
        private System.Windows.Forms.GroupBox gbFiltroHeadcounter;
        private System.Windows.Forms.Button btnGenerar_HC;
        private System.Windows.Forms.ComboBox cmbAnio_HC;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cmbMes_HC;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbDepto_HC;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox gbFiltroNominaDepto;
        private System.Windows.Forms.Button btnGenerar_Depto;
        private System.Windows.Forms.ComboBox cmbAnio_Depto;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnExportarPDF;
        private System.Windows.Forms.Button btnExportarCSV;
    }
}