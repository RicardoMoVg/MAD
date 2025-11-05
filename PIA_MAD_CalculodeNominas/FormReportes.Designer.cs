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
            this.panelMenuReportes = new System.Windows.Forms.Panel();
            this.btnReporteNomina = new System.Windows.Forms.Button();
            this.btnReporteHeadcounter = new System.Windows.Forms.Button();
            this.btnReporteGeneral = new System.Windows.Forms.Button();
            this.lblTituloPanel = new System.Windows.Forms.Label();
            this.panelContenidoReporte = new System.Windows.Forms.Panel();
            this.lblFiltros = new System.Windows.Forms.Label();
            this.panelFiltros = new System.Windows.Forms.Panel();
            this.dgvReporte = new System.Windows.Forms.DataGridView();
            this.lblTituloReporte = new System.Windows.Forms.Label();
            this.panelMenuReportes.SuspendLayout();
            this.panelContenidoReporte.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMenuReportes
            // 
            this.panelMenuReportes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelMenuReportes.Controls.Add(this.btnReporteNomina);
            this.panelMenuReportes.Controls.Add(this.btnReporteHeadcounter);
            this.panelMenuReportes.Controls.Add(this.btnReporteGeneral);
            this.panelMenuReportes.Controls.Add(this.lblTituloPanel);
            this.panelMenuReportes.Dock = System.Windows.Forms.DockStyle.Left;
            this.panelMenuReportes.Location = new System.Drawing.Point(0, 0);
            this.panelMenuReportes.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelMenuReportes.Name = "panelMenuReportes";
            this.panelMenuReportes.Size = new System.Drawing.Size(188, 569);
            this.panelMenuReportes.TabIndex = 0;
            // 
            // btnReporteNomina
            // 
            this.btnReporteNomina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnReporteNomina.FlatAppearance.BorderSize = 0;
            this.btnReporteNomina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteNomina.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteNomina.ForeColor = System.Drawing.Color.White;
            this.btnReporteNomina.Location = new System.Drawing.Point(0, 162);
            this.btnReporteNomina.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReporteNomina.Name = "btnReporteNomina";
            this.btnReporteNomina.Size = new System.Drawing.Size(188, 41);
            this.btnReporteNomina.TabIndex = 3;
            this.btnReporteNomina.Text = "Reporte de Nómina";
            this.btnReporteNomina.UseVisualStyleBackColor = false;
            // 
            // btnReporteHeadcounter
            // 
            this.btnReporteHeadcounter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnReporteHeadcounter.FlatAppearance.BorderSize = 0;
            this.btnReporteHeadcounter.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteHeadcounter.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteHeadcounter.ForeColor = System.Drawing.Color.White;
            this.btnReporteHeadcounter.Location = new System.Drawing.Point(0, 114);
            this.btnReporteHeadcounter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReporteHeadcounter.Name = "btnReporteHeadcounter";
            this.btnReporteHeadcounter.Size = new System.Drawing.Size(188, 41);
            this.btnReporteHeadcounter.TabIndex = 2;
            this.btnReporteHeadcounter.Text = "Reporte Headcounter";
            this.btnReporteHeadcounter.UseVisualStyleBackColor = false;
            // 
            // btnReporteGeneral
            // 
            this.btnReporteGeneral.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnReporteGeneral.FlatAppearance.BorderSize = 0;
            this.btnReporteGeneral.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnReporteGeneral.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReporteGeneral.ForeColor = System.Drawing.Color.White;
            this.btnReporteGeneral.Location = new System.Drawing.Point(0, 65);
            this.btnReporteGeneral.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btnReporteGeneral.Name = "btnReporteGeneral";
            this.btnReporteGeneral.Size = new System.Drawing.Size(188, 41);
            this.btnReporteGeneral.TabIndex = 1;
            this.btnReporteGeneral.Text = "Reporte General de Nómina";
            this.btnReporteGeneral.UseVisualStyleBackColor = false;
            // 
            // lblTituloPanel
            // 
            this.lblTituloPanel.AutoSize = true;
            this.lblTituloPanel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloPanel.ForeColor = System.Drawing.Color.White;
            this.lblTituloPanel.Location = new System.Drawing.Point(9, 16);
            this.lblTituloPanel.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTituloPanel.Name = "lblTituloPanel";
            this.lblTituloPanel.Size = new System.Drawing.Size(170, 21);
            this.lblTituloPanel.TabIndex = 0;
            this.lblTituloPanel.Text = "Selección de Reporte";
            // 
            // panelContenidoReporte
            // 
            this.panelContenidoReporte.Controls.Add(this.lblFiltros);
            this.panelContenidoReporte.Controls.Add(this.panelFiltros);
            this.panelContenidoReporte.Controls.Add(this.dgvReporte);
            this.panelContenidoReporte.Controls.Add(this.lblTituloReporte);
            this.panelContenidoReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenidoReporte.Location = new System.Drawing.Point(188, 0);
            this.panelContenidoReporte.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelContenidoReporte.Name = "panelContenidoReporte";
            this.panelContenidoReporte.Size = new System.Drawing.Size(712, 569);
            this.panelContenidoReporte.TabIndex = 1;
            // 
            // lblFiltros
            // 
            this.lblFiltros.AutoSize = true;
            this.lblFiltros.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFiltros.Location = new System.Drawing.Point(15, 54);
            this.lblFiltros.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblFiltros.Name = "lblFiltros";
            this.lblFiltros.Size = new System.Drawing.Size(44, 15);
            this.lblFiltros.TabIndex = 3;
            this.lblFiltros.Text = "Filtros:";
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.Gainsboro;
            this.panelFiltros.Location = new System.Drawing.Point(15, 73);
            this.panelFiltros.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(682, 41);
            this.panelFiltros.TabIndex = 2;
            // 
            // dgvReporte
            // 
            this.dgvReporte.AllowUserToAddRows = false;
            this.dgvReporte.AllowUserToDeleteRows = false;
            this.dgvReporte.AllowUserToResizeRows = false;
            this.dgvReporte.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvReporte.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvReporte.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvReporte.Location = new System.Drawing.Point(15, 122);
            this.dgvReporte.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgvReporte.Name = "dgvReporte";
            this.dgvReporte.ReadOnly = true;
            this.dgvReporte.RowHeadersWidth = 51;
            this.dgvReporte.RowTemplate.Height = 24;
            this.dgvReporte.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvReporte.Size = new System.Drawing.Size(682, 422);
            this.dgvReporte.TabIndex = 1;
            // 
            // lblTituloReporte
            // 
            this.lblTituloReporte.AutoSize = true;
            this.lblTituloReporte.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTituloReporte.Location = new System.Drawing.Point(15, 16);
            this.lblTituloReporte.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTituloReporte.Name = "lblTituloReporte";
            this.lblTituloReporte.Size = new System.Drawing.Size(238, 30);
            this.lblTituloReporte.TabIndex = 0;
            this.lblTituloReporte.Text = "Seleccione un reporte";

            // 
            // FormReportes
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 569);
            this.Controls.Add(this.panelContenidoReporte);
            this.Controls.Add(this.panelMenuReportes);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FormReportes";
            this.Text = "FormReportes";
            this.panelMenuReportes.ResumeLayout(false);
            this.panelMenuReportes.PerformLayout();
            this.panelContenidoReporte.ResumeLayout(false);
            this.panelContenidoReporte.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvReporte)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenuReportes;
        private System.Windows.Forms.Label lblTituloPanel;
        private System.Windows.Forms.Button btnReporteNomina;
        private System.Windows.Forms.Button btnReporteHeadcounter;
        private System.Windows.Forms.Button btnReporteGeneral;
        private System.Windows.Forms.Panel panelContenidoReporte;
        private System.Windows.Forms.Label lblTituloReporte;
        private System.Windows.Forms.DataGridView dgvReporte;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.Label lblFiltros;
    }
}