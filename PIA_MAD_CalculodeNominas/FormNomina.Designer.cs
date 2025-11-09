namespace PIA_MAD_CalculodeNominas
{
    partial class FormNomina
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
            this.btnCalcularNomina = new System.Windows.Forms.Button();
            this.cmbAnio = new System.Windows.Forms.ComboBox();
            this.lblAnio = new System.Windows.Forms.Label();
            this.cmbMes = new System.Windows.Forms.ComboBox();
            this.lblMes = new System.Windows.Forms.Label();
            this.dgvNomina = new System.Windows.Forms.DataGridView();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnVerRecibo = new System.Windows.Forms.Button();
            this.panelFiltros.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNomina)).BeginInit();
            this.SuspendLayout();
            // 
            // lblTitulo
            // 
            this.lblTitulo.AutoSize = true;
            this.lblTitulo.Font = new System.Drawing.Font("Segoe UI", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTitulo.Location = new System.Drawing.Point(15, 16);
            this.lblTitulo.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblTitulo.Name = "lblTitulo";
            this.lblTitulo.Size = new System.Drawing.Size(207, 30);
            this.lblTitulo.TabIndex = 0;
            this.lblTitulo.Text = "Cálculo de Nómina";
            // 
            // panelFiltros
            // 
            this.panelFiltros.BackColor = System.Drawing.Color.Gainsboro;
            this.panelFiltros.Controls.Add(this.btnCalcularNomina);
            this.panelFiltros.Controls.Add(this.cmbAnio);
            this.panelFiltros.Controls.Add(this.lblAnio);
            this.panelFiltros.Controls.Add(this.cmbMes);
            this.panelFiltros.Controls.Add(this.lblMes);
            this.panelFiltros.Location = new System.Drawing.Point(15, 57);
            this.panelFiltros.Margin = new System.Windows.Forms.Padding(2);
            this.panelFiltros.Name = "panelFiltros";
            this.panelFiltros.Size = new System.Drawing.Size(720, 49);
            this.panelFiltros.TabIndex = 1;
            // 
            // btnCalcularNomina
            // 
            this.btnCalcularNomina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnCalcularNomina.FlatAppearance.BorderSize = 0;
            this.btnCalcularNomina.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCalcularNomina.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCalcularNomina.ForeColor = System.Drawing.Color.White;
            this.btnCalcularNomina.Location = new System.Drawing.Point(450, 8);
            this.btnCalcularNomina.Margin = new System.Windows.Forms.Padding(2);
            this.btnCalcularNomina.Name = "btnCalcularNomina";
            this.btnCalcularNomina.Size = new System.Drawing.Size(150, 32);
            this.btnCalcularNomina.TabIndex = 4;
            this.btnCalcularNomina.Text = "Calcular Nómina";
            this.btnCalcularNomina.UseVisualStyleBackColor = false;
            this.btnCalcularNomina.Click += new System.EventHandler(this.btnCalcularNomina_Click);
            // 
            // cmbAnio
            // 
            this.cmbAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbAnio.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbAnio.FormattingEnabled = true;
            this.cmbAnio.Location = new System.Drawing.Point(262, 12);
            this.cmbAnio.Margin = new System.Windows.Forms.Padding(2);
            this.cmbAnio.Name = "cmbAnio";
            this.cmbAnio.Size = new System.Drawing.Size(151, 27);
            this.cmbAnio.TabIndex = 3;
            // 
            // lblAnio
            // 
            this.lblAnio.AutoSize = true;
            this.lblAnio.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAnio.Location = new System.Drawing.Point(221, 15);
            this.lblAnio.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblAnio.Name = "lblAnio";
            this.lblAnio.Size = new System.Drawing.Size(32, 15);
            this.lblAnio.TabIndex = 2;
            this.lblAnio.Text = "Año:";
            // 
            // cmbMes
            // 
            this.cmbMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbMes.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbMes.FormattingEnabled = true;
            this.cmbMes.Location = new System.Drawing.Point(52, 12);
            this.cmbMes.Margin = new System.Windows.Forms.Padding(2);
            this.cmbMes.Name = "cmbMes";
            this.cmbMes.Size = new System.Drawing.Size(151, 27);
            this.cmbMes.TabIndex = 1;
            // 
            // lblMes
            // 
            this.lblMes.AutoSize = true;
            this.lblMes.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMes.Location = new System.Drawing.Point(11, 15);
            this.lblMes.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblMes.Name = "lblMes";
            this.lblMes.Size = new System.Drawing.Size(32, 15);
            this.lblMes.TabIndex = 0;
            this.lblMes.Text = "Mes:";
            // 
            // dgvNomina
            // 
            this.dgvNomina.AllowUserToAddRows = false;
            this.dgvNomina.AllowUserToDeleteRows = false;
            this.dgvNomina.AllowUserToResizeRows = false;
            this.dgvNomina.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvNomina.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgvNomina.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvNomina.Location = new System.Drawing.Point(15, 122);
            this.dgvNomina.Margin = new System.Windows.Forms.Padding(2);
            this.dgvNomina.Name = "dgvNomina";
            this.dgvNomina.ReadOnly = true;
            this.dgvNomina.RowHeadersWidth = 51;
            this.dgvNomina.RowTemplate.Height = 24;
            this.dgvNomina.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvNomina.Size = new System.Drawing.Size(720, 390);
            this.dgvNomina.TabIndex = 2;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(165)))), ((int)(((byte)(74)))));
            this.btnExportar.FlatAppearance.BorderSize = 0;
            this.btnExportar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.Color.White;
            this.btnExportar.Location = new System.Drawing.Point(585, 520);
            this.btnExportar.Margin = new System.Windows.Forms.Padding(2);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(150, 32);
            this.btnExportar.TabIndex = 3;
            this.btnExportar.Text = "Exportar a CSV";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnVerRecibo
            // 
            this.btnVerRecibo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(74)))), ((int)(((byte)(144)))), ((int)(((byte)(226)))));
            this.btnVerRecibo.FlatAppearance.BorderSize = 0;
            this.btnVerRecibo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnVerRecibo.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVerRecibo.ForeColor = System.Drawing.Color.White;
            this.btnVerRecibo.Location = new System.Drawing.Point(428, 520);
            this.btnVerRecibo.Margin = new System.Windows.Forms.Padding(2);
            this.btnVerRecibo.Name = "btnVerRecibo";
            this.btnVerRecibo.Size = new System.Drawing.Size(150, 32);
            this.btnVerRecibo.TabIndex = 4;
            this.btnVerRecibo.Text = "Ver Recibo";
            this.btnVerRecibo.UseVisualStyleBackColor = false;
            this.btnVerRecibo.Click += new System.EventHandler(this.btnVerRecibo_Click);
            // 
            // FormNomina
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 569);
            this.Controls.Add(this.btnVerRecibo);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.dgvNomina);
            this.Controls.Add(this.panelFiltros);
            this.Controls.Add(this.lblTitulo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "FormNomina";
            this.Text = "FormNomina";
            this.Load += new System.EventHandler(this.FormNomina_Load);
            this.panelFiltros.ResumeLayout(false);
            this.panelFiltros.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvNomina)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblTitulo;
        private System.Windows.Forms.Panel panelFiltros;
        private System.Windows.Forms.DataGridView dgvNomina;
        private System.Windows.Forms.Button btnCalcularNomina;
        private System.Windows.Forms.ComboBox cmbAnio;
        private System.Windows.Forms.Label lblAnio;
        private System.Windows.Forms.ComboBox cmbMes;
        private System.Windows.Forms.Label lblMes;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnVerRecibo;
    }
}