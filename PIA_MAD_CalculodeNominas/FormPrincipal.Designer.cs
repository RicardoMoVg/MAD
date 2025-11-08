namespace PIA_MAD_CalculodeNominas
{
    partial class FormPrincipal
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
            this.panelMenu = new System.Windows.Forms.Panel();
            this.menuStripPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuItemUsuario = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesiónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemCatalogos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemRecursosHumanos = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemNomina = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemConsultas = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContenedor = new System.Windows.Forms.Panel();
            this.puestosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.puestosToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.panelMenu.SuspendLayout();
            this.menuStripPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelMenu
            // 
            this.panelMenu.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.panelMenu.Controls.Add(this.menuStripPrincipal);
            this.panelMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelMenu.Location = new System.Drawing.Point(0, 0);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(900, 40);
            this.panelMenu.TabIndex = 0;
            // 
            // menuStripPrincipal
            // 
            this.menuStripPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.menuStripPrincipal.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripPrincipal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripPrincipal.ForeColor = System.Drawing.Color.White;
            this.menuStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUsuario,
            this.menuItemCatalogos,
            this.menuItemRecursosHumanos,
            this.menuItemNomina,
            this.menuItemReportes,
            this.menuItemConsultas});
            this.menuStripPrincipal.Location = new System.Drawing.Point(0, 10);
            this.menuStripPrincipal.Name = "menuStripPrincipal";
            this.menuStripPrincipal.Size = new System.Drawing.Size(665, 24);
            this.menuStripPrincipal.TabIndex = 0;
            this.menuStripPrincipal.Text = "menuStrip1";
            // 
            // menuItemUsuario
            // 
            this.menuItemUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesiónToolStripMenuItem});
            this.menuItemUsuario.ForeColor = System.Drawing.Color.White;
            this.menuItemUsuario.Name = "menuItemUsuario";
            this.menuItemUsuario.Size = new System.Drawing.Size(73, 20);
            this.menuItemUsuario.Text = "USUARIO";
            this.menuItemUsuario.Click += new System.EventHandler(this.menuItemUsuario_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.cerrarSesiónToolStripMenuItem.Text = "Cerrar Sesión";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // menuItemCatalogos
            // 
            this.menuItemCatalogos.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.puestosToolStripMenuItem,
            this.puestosToolStripMenuItem1});
            this.menuItemCatalogos.ForeColor = System.Drawing.Color.White;
            this.menuItemCatalogos.Name = "menuItemCatalogos";
            this.menuItemCatalogos.Size = new System.Drawing.Size(87, 20);
            this.menuItemCatalogos.Text = "CATALOGOS";
            this.menuItemCatalogos.Click += new System.EventHandler(this.menuItemCatalogos_Click);
            // 
            // menuItemRecursosHumanos
            // 
            this.menuItemRecursosHumanos.ForeColor = System.Drawing.Color.White;
            this.menuItemRecursosHumanos.Name = "menuItemRecursosHumanos";
            this.menuItemRecursosHumanos.Size = new System.Drawing.Size(145, 20);
            this.menuItemRecursosHumanos.Text = "RECURSOS HUMANOS";
            this.menuItemRecursosHumanos.Click += new System.EventHandler(this.menuItemRecursosHumanos_Click);
            // 
            // menuItemNomina
            // 
            this.menuItemNomina.ForeColor = System.Drawing.Color.White;
            this.menuItemNomina.Name = "menuItemNomina";
            this.menuItemNomina.Size = new System.Drawing.Size(69, 20);
            this.menuItemNomina.Text = "NOMINA";
            this.menuItemNomina.Click += new System.EventHandler(this.menuItemNomina_Click);
            // 
            // menuItemReportes
            // 
            this.menuItemReportes.ForeColor = System.Drawing.Color.White;
            this.menuItemReportes.Name = "menuItemReportes";
            this.menuItemReportes.Size = new System.Drawing.Size(77, 20);
            this.menuItemReportes.Text = "REPORTES";
            this.menuItemReportes.Click += new System.EventHandler(this.menuItemReportes_Click);
            // 
            // menuItemConsultas
            // 
            this.menuItemConsultas.ForeColor = System.Drawing.Color.White;
            this.menuItemConsultas.Name = "menuItemConsultas";
            this.menuItemConsultas.Size = new System.Drawing.Size(86, 20);
            this.menuItemConsultas.Text = "CONSULTAS";
            this.menuItemConsultas.Click += new System.EventHandler(this.menuItemConsultas_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 40);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(900, 560);
            this.panelContenedor.TabIndex = 1;
            // 
            // puestosToolStripMenuItem
            // 
            this.puestosToolStripMenuItem.Name = "puestosToolStripMenuItem";
            this.puestosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.puestosToolStripMenuItem.Text = "Departamentos";
            this.puestosToolStripMenuItem.Click += new System.EventHandler(this.puestosToolStripMenuItem_Click);
            // 
            // puestosToolStripMenuItem1
            // 
            this.puestosToolStripMenuItem1.Name = "puestosToolStripMenuItem1";
            this.puestosToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.puestosToolStripMenuItem1.Text = "Puestos";
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(900, 600);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelMenu);
            this.MainMenuStrip = this.menuStripPrincipal;
            this.Name = "FormPrincipal";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sistema de Gestión de Nómina";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.panelMenu.ResumeLayout(false);
            this.panelMenu.PerformLayout();
            this.menuStripPrincipal.ResumeLayout(false);
            this.menuStripPrincipal.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelMenu;
        private System.Windows.Forms.Panel panelContenedor;
        private System.Windows.Forms.MenuStrip menuStripPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuItemUsuario;
        private System.Windows.Forms.ToolStripMenuItem menuItemCatalogos;
        private System.Windows.Forms.ToolStripMenuItem menuItemRecursosHumanos;
        private System.Windows.Forms.ToolStripMenuItem menuItemNomina;
        private System.Windows.Forms.ToolStripMenuItem menuItemReportes;
        private System.Windows.Forms.ToolStripMenuItem menuItemConsultas;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puestosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem puestosToolStripMenuItem1;
    }
}