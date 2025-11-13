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
            this.capturaDePercepcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.agregarPercepcionesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemReportes = new System.Windows.Forms.ToolStripMenuItem();
            this.panelContenedor = new System.Windows.Forms.Panel();
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
            this.panelMenu.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelMenu.Name = "panelMenu";
            this.panelMenu.Size = new System.Drawing.Size(1200, 49);
            this.panelMenu.TabIndex = 0;
            // 
            // menuStripPrincipal
            // 
            this.menuStripPrincipal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(62)))), ((int)(((byte)(80)))));
            this.menuStripPrincipal.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStripPrincipal.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStripPrincipal.ForeColor = System.Drawing.Color.White;
            this.menuStripPrincipal.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStripPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemUsuario,
            this.menuItemCatalogos,
            this.menuItemRecursosHumanos,
            this.menuItemNomina,
            this.menuItemReportes});
            this.menuStripPrincipal.Location = new System.Drawing.Point(0, 12);
            this.menuStripPrincipal.Name = "menuStripPrincipal";
            this.menuStripPrincipal.Padding = new System.Windows.Forms.Padding(5, 2, 0, 2);
            this.menuStripPrincipal.Size = new System.Drawing.Size(702, 28);
            this.menuStripPrincipal.TabIndex = 0;
            this.menuStripPrincipal.Text = "menuStrip1";
            // 
            // menuItemUsuario
            // 
            this.menuItemUsuario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cerrarSesiónToolStripMenuItem});
            this.menuItemUsuario.ForeColor = System.Drawing.Color.White;
            this.menuItemUsuario.Name = "menuItemUsuario";
            this.menuItemUsuario.Size = new System.Drawing.Size(71, 24);
            this.menuItemUsuario.Text = "DATOS";
            this.menuItemUsuario.Click += new System.EventHandler(this.menuItemUsuario_Click);
            // 
            // cerrarSesiónToolStripMenuItem
            // 
            this.cerrarSesiónToolStripMenuItem.Name = "cerrarSesiónToolStripMenuItem";
            this.cerrarSesiónToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.cerrarSesiónToolStripMenuItem.Text = "EMPRESA";
            this.cerrarSesiónToolStripMenuItem.Click += new System.EventHandler(this.cerrarSesionToolStripMenuItem_Click);
            // 
            // menuItemCatalogos
            // 
            this.menuItemCatalogos.ForeColor = System.Drawing.Color.White;
            this.menuItemCatalogos.Name = "menuItemCatalogos";
            this.menuItemCatalogos.Size = new System.Drawing.Size(110, 24);
            this.menuItemCatalogos.Text = "CATALOGOS";
            this.menuItemCatalogos.Click += new System.EventHandler(this.menuItemCatalogos_Click);
            // 
            // menuItemRecursosHumanos
            // 
            this.menuItemRecursosHumanos.ForeColor = System.Drawing.Color.White;
            this.menuItemRecursosHumanos.Name = "menuItemRecursosHumanos";
            this.menuItemRecursosHumanos.Size = new System.Drawing.Size(180, 24);
            this.menuItemRecursosHumanos.Text = "RECURSOS HUMANOS";
            this.menuItemRecursosHumanos.Click += new System.EventHandler(this.menuItemRecursosHumanos_Click);
            // 
            // menuItemNomina
            // 
            this.menuItemNomina.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.capturaDePercepcionesToolStripMenuItem,
            this.agregarPercepcionesToolStripMenuItem});
            this.menuItemNomina.ForeColor = System.Drawing.Color.White;
            this.menuItemNomina.Name = "menuItemNomina";
            this.menuItemNomina.Size = new System.Drawing.Size(88, 24);
            this.menuItemNomina.Text = "NOMINA";
            this.menuItemNomina.Click += new System.EventHandler(this.menuItemNomina_Click);
            // 
            // capturaDePercepcionesToolStripMenuItem
            // 
            this.capturaDePercepcionesToolStripMenuItem.Name = "capturaDePercepcionesToolStripMenuItem";
            this.capturaDePercepcionesToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.capturaDePercepcionesToolStripMenuItem.Text = "CAPTURA DE PERCEPCIONES";
            this.capturaDePercepcionesToolStripMenuItem.Click += new System.EventHandler(this.capturaDePercepcionesToolStripMenuItem_Click);
            // 
            // agregarPercepcionesToolStripMenuItem
            // 
            this.agregarPercepcionesToolStripMenuItem.Name = "agregarPercepcionesToolStripMenuItem";
            this.agregarPercepcionesToolStripMenuItem.Size = new System.Drawing.Size(295, 26);
            this.agregarPercepcionesToolStripMenuItem.Text = "AGREGAR CONCEPTOS";
            this.agregarPercepcionesToolStripMenuItem.Click += new System.EventHandler(this.agregarPercepcionesToolStripMenuItem_Click);
            // 
            // menuItemReportes
            // 
            this.menuItemReportes.ForeColor = System.Drawing.Color.White;
            this.menuItemReportes.Name = "menuItemReportes";
            this.menuItemReportes.Size = new System.Drawing.Size(96, 24);
            this.menuItemReportes.Text = "REPORTES";
            this.menuItemReportes.Click += new System.EventHandler(this.menuItemReportes_Click);
            // 
            // panelContenedor
            // 
            this.panelContenedor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelContenedor.Location = new System.Drawing.Point(0, 49);
            this.panelContenedor.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelContenedor.Name = "panelContenedor";
            this.panelContenedor.Size = new System.Drawing.Size(1200, 689);
            this.panelContenedor.TabIndex = 1;
            this.panelContenedor.Paint += new System.Windows.Forms.PaintEventHandler(this.panelContenedor_Paint);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1200, 738);
            this.Controls.Add(this.panelContenedor);
            this.Controls.Add(this.panelMenu);
            this.MainMenuStrip = this.menuStripPrincipal;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
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
        private System.Windows.Forms.ToolStripMenuItem cerrarSesiónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem capturaDePercepcionesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem agregarPercepcionesToolStripMenuItem;
    }
}