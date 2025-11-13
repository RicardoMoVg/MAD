namespace PIA_MAD_CalculodeNominas
{
    partial class FormInicio
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
            this.pbLogo = new System.Windows.Forms.PictureBox();
            this.lblNombreEscuela = new System.Windows.Forms.Label();
            this.panelKpiEmpleados = new System.Windows.Forms.Panel();
            this.lblTotalEmpleados = new System.Windows.Forms.Label();
            this.lblTituloEmpleados = new System.Windows.Forms.Label();
            this.gbAnuncio = new System.Windows.Forms.GroupBox();
            this.lblTextoAnuncio = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).BeginInit();
            this.panelKpiEmpleados.SuspendLayout();
            this.gbAnuncio.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbLogo
            // 
            this.pbLogo.Image = global::PIA_MAD_CalculodeNominas.Properties.Resources.con_fondo;
            this.pbLogo.Location = new System.Drawing.Point(40, 30);
            this.pbLogo.Name = "pbLogo";
            this.pbLogo.Size = new System.Drawing.Size(150, 150);
            this.pbLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbLogo.TabIndex = 0;
            this.pbLogo.TabStop = false;
            // 
            // lblNombreEscuela
            // 
            this.lblNombreEscuela.AutoSize = true;
            this.lblNombreEscuela.Font = new System.Drawing.Font("Segoe UI", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNombreEscuela.Location = new System.Drawing.Point(210, 86);
            this.lblNombreEscuela.Name = "lblNombreEscuela";
            this.lblNombreEscuela.Size = new System.Drawing.Size(393, 37);
            this.lblNombreEscuela.TabIndex = 1;
            this.lblNombreEscuela.Text = "Preparatoria Honkai Star Rail";
            // 
            // panelKpiEmpleados
            // 
            this.panelKpiEmpleados.BackColor = System.Drawing.Color.Gainsboro;
            this.panelKpiEmpleados.Controls.Add(this.lblTotalEmpleados);
            this.panelKpiEmpleados.Controls.Add(this.lblTituloEmpleados);
            this.panelKpiEmpleados.Location = new System.Drawing.Point(40, 220);
            this.panelKpiEmpleados.Name = "panelKpiEmpleados";
            this.panelKpiEmpleados.Size = new System.Drawing.Size(300, 150);
            this.panelKpiEmpleados.TabIndex = 2;
            
            // 
            // gbAnuncio
            // 
            this.gbAnuncio.Controls.Add(this.lblTextoAnuncio);
            this.gbAnuncio.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbAnuncio.Location = new System.Drawing.Point(380, 220);
            this.gbAnuncio.Name = "gbAnuncio";
            this.gbAnuncio.Size = new System.Drawing.Size(480, 150);
            this.gbAnuncio.TabIndex = 3;
            this.gbAnuncio.TabStop = false;
            this.gbAnuncio.Text = "Avisos Importantes 🎄";
            this.gbAnuncio.Enter += new System.EventHandler(this.gbAnuncio_Enter);
            // 
            // lblTextoAnuncio
            // 
            this.lblTextoAnuncio.AutoSize = true;
            this.lblTextoAnuncio.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTextoAnuncio.Location = new System.Drawing.Point(15, 35);
            this.lblTextoAnuncio.MaximumSize = new System.Drawing.Size(450, 0);
            this.lblTextoAnuncio.Name = "lblTextoAnuncio";
            this.lblTextoAnuncio.Size = new System.Drawing.Size(450, 60);
            this.lblTextoAnuncio.TabIndex = 0;
            this.lblTextoAnuncio.Text = "¡No te pierdas nuestro gran Festival Navideño este 14 de Diciembre en el auditori" +
    "o principal! Habrá presentaciones, comida y muchas sorpresas. ¡Invita a tu famil" +
    "ia!";
            // 
            // FormInicio
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 560);
            this.Controls.Add(this.gbAnuncio);
            this.Controls.Add(this.panelKpiEmpleados);
            this.Controls.Add(this.lblNombreEscuela);
            this.Controls.Add(this.pbLogo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormInicio";
            this.Text = "FormInicio";
            this.Load += new System.EventHandler(this.FormInicio_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbLogo)).EndInit();
            this.panelKpiEmpleados.ResumeLayout(false);
            this.gbAnuncio.ResumeLayout(false);
            this.gbAnuncio.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbLogo;
        private System.Windows.Forms.Label lblNombreEscuela;
        private System.Windows.Forms.Panel panelKpiEmpleados;
        private System.Windows.Forms.Label lblTotalEmpleados;
        private System.Windows.Forms.Label lblTituloEmpleados;
        private System.Windows.Forms.GroupBox gbAnuncio;
        private System.Windows.Forms.Label lblTextoAnuncio;
    }
}