
namespace WinAppTachito.Views
{
    partial class FormPrincipal
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrincipal));
            this.TsPrincipal = new System.Windows.Forms.ToolStrip();
            this.SsPrincipal = new System.Windows.Forms.StatusStrip();
            this.MsStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.MsPrincipal = new System.Windows.Forms.MenuStrip();
            this.EvaluacionTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.TachitosTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.SalirTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.AppTachitoTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.UsuariosTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.RegistrosTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.registros2TSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.SharepointTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.acumuladoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resumenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SsPrincipal.SuspendLayout();
            this.MsPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // TsPrincipal
            // 
            this.TsPrincipal.Location = new System.Drawing.Point(0, 24);
            this.TsPrincipal.Name = "TsPrincipal";
            this.TsPrincipal.Size = new System.Drawing.Size(800, 25);
            this.TsPrincipal.TabIndex = 2;
            this.TsPrincipal.Text = "toolStrip1";
            // 
            // SsPrincipal
            // 
            this.SsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MsStatusBar});
            this.SsPrincipal.Location = new System.Drawing.Point(0, 428);
            this.SsPrincipal.Name = "SsPrincipal";
            this.SsPrincipal.Size = new System.Drawing.Size(800, 22);
            this.SsPrincipal.TabIndex = 3;
            this.SsPrincipal.Text = "statusStrip1";
            this.SsPrincipal.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.SsPrincipal_MouseDoubleClick);
            // 
            // MsStatusBar
            // 
            this.MsStatusBar.Name = "MsStatusBar";
            this.MsStatusBar.Size = new System.Drawing.Size(12, 17);
            this.MsStatusBar.Text = "*";
            // 
            // MsPrincipal
            // 
            this.MsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EvaluacionTSMI,
            this.AppTachitoTSMI,
            this.reporteTSMI});
            this.MsPrincipal.Location = new System.Drawing.Point(0, 0);
            this.MsPrincipal.Name = "MsPrincipal";
            this.MsPrincipal.Size = new System.Drawing.Size(800, 24);
            this.MsPrincipal.TabIndex = 4;
            this.MsPrincipal.Text = "menuStrip1";
            // 
            // EvaluacionTSMI
            // 
            this.EvaluacionTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.TachitosTSMI,
            this.toolStripMenuItem1,
            this.SalirTSMI});
            this.EvaluacionTSMI.Name = "EvaluacionTSMI";
            this.EvaluacionTSMI.Size = new System.Drawing.Size(76, 20);
            this.EvaluacionTSMI.Text = "&Evaluación";
            // 
            // TachitosTSMI
            // 
            this.TachitosTSMI.Name = "TachitosTSMI";
            this.TachitosTSMI.Size = new System.Drawing.Size(117, 22);
            this.TachitosTSMI.Text = "Tachitos";
            this.TachitosTSMI.Click += new System.EventHandler(this.TachitosTSMI_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(114, 6);
            // 
            // SalirTSMI
            // 
            this.SalirTSMI.Name = "SalirTSMI";
            this.SalirTSMI.Size = new System.Drawing.Size(117, 22);
            this.SalirTSMI.Text = "Salir";
            this.SalirTSMI.Click += new System.EventHandler(this.SalirTSMI_Click);
            // 
            // AppTachitoTSMI
            // 
            this.AppTachitoTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.UsuariosTSMI,
            this.RegistrosTSMI,
            this.registros2TSMI,
            this.toolStripMenuItem2,
            this.SharepointTSMI});
            this.AppTachitoTSMI.Name = "AppTachitoTSMI";
            this.AppTachitoTSMI.Size = new System.Drawing.Size(82, 20);
            this.AppTachitoTSMI.Text = "&App Tachito";
            // 
            // UsuariosTSMI
            // 
            this.UsuariosTSMI.Name = "UsuariosTSMI";
            this.UsuariosTSMI.Size = new System.Drawing.Size(180, 22);
            this.UsuariosTSMI.Text = "Usuarios";
            this.UsuariosTSMI.Click += new System.EventHandler(this.UsuariosTSMI_Click);
            // 
            // RegistrosTSMI
            // 
            this.RegistrosTSMI.Name = "RegistrosTSMI";
            this.RegistrosTSMI.Size = new System.Drawing.Size(180, 22);
            this.RegistrosTSMI.Text = "Registros v1.1";
            this.RegistrosTSMI.Click += new System.EventHandler(this.RegistrosTSMI_Click);
            // 
            // registros2TSMI
            // 
            this.registros2TSMI.Name = "registros2TSMI";
            this.registros2TSMI.Size = new System.Drawing.Size(180, 22);
            this.registros2TSMI.Text = "Registros v1.2";
            this.registros2TSMI.Click += new System.EventHandler(this.registrosV13ToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // SharepointTSMI
            // 
            this.SharepointTSMI.Name = "SharepointTSMI";
            this.SharepointTSMI.Size = new System.Drawing.Size(180, 22);
            this.SharepointTSMI.Text = "Sharepoint";
            this.SharepointTSMI.Click += new System.EventHandler(this.SharepointTSMI_Click);
            // 
            // reporteTSMI
            // 
            this.reporteTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.acumuladoToolStripMenuItem,
            this.resumenToolStripMenuItem});
            this.reporteTSMI.Name = "reporteTSMI";
            this.reporteTSMI.Size = new System.Drawing.Size(60, 20);
            this.reporteTSMI.Text = "Reporte";
            // 
            // acumuladoToolStripMenuItem
            // 
            this.acumuladoToolStripMenuItem.Name = "acumuladoToolStripMenuItem";
            this.acumuladoToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.acumuladoToolStripMenuItem.Text = "Acumulado";
            this.acumuladoToolStripMenuItem.Click += new System.EventHandler(this.acumuladoToolStripMenuItem_Click);
            // 
            // resumenToolStripMenuItem
            // 
            this.resumenToolStripMenuItem.Name = "resumenToolStripMenuItem";
            this.resumenToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.resumenToolStripMenuItem.Text = "Resumen";
            this.resumenToolStripMenuItem.Click += new System.EventHandler(this.resumenToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.SsPrincipal);
            this.Controls.Add(this.TsPrincipal);
            this.Controls.Add(this.MsPrincipal);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.MsPrincipal;
            this.Name = "FormPrincipal";
            this.Text = "App Tachito";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.Shown += new System.EventHandler(this.FormPrincipal_Shown);
            this.SsPrincipal.ResumeLayout(false);
            this.SsPrincipal.PerformLayout();
            this.MsPrincipal.ResumeLayout(false);
            this.MsPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip TsPrincipal;
        private System.Windows.Forms.StatusStrip SsPrincipal;
        private System.Windows.Forms.MenuStrip MsPrincipal;
        private System.Windows.Forms.ToolStripStatusLabel MsStatusBar;
        private System.Windows.Forms.ToolStripMenuItem EvaluacionTSMI;
        private System.Windows.Forms.ToolStripMenuItem TachitosTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem SalirTSMI;
        private System.Windows.Forms.ToolStripMenuItem AppTachitoTSMI;
        private System.Windows.Forms.ToolStripMenuItem UsuariosTSMI;
        private System.Windows.Forms.ToolStripMenuItem RegistrosTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem SharepointTSMI;
        private System.Windows.Forms.ToolStripMenuItem reporteTSMI;
        private System.Windows.Forms.ToolStripMenuItem acumuladoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resumenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem registros2TSMI;
    }
}