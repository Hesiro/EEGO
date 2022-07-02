
namespace WinEEGO.Views
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
            this.msPrincipal = new System.Windows.Forms.MenuStrip();
            this.evaluacionTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.nuevoTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.abrirTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.mantenimientoTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.usuariosTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.cultivosTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.areasTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.emisoresTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.reporteTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.porAnioTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.porAreaTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.porValvulaTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.lotesSinEvaluaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.usuarioTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.iniciarSesionTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.cambiarClaveTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.cerrarSesionTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.ventanaTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.cascadaTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.verticalTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.horizontalTSMI = new System.Windows.Forms.ToolStripMenuItem();
            this.tsPrincipal = new System.Windows.Forms.ToolStrip();
            this.btnNuevo = new System.Windows.Forms.ToolStripButton();
            this.btnAbrir = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPorAnio = new System.Windows.Forms.ToolStripButton();
            this.btnPorArea = new System.Windows.Forms.ToolStripButton();
            this.btnPorValvula = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnIniciarSesion = new System.Windows.Forms.ToolStripButton();
            this.btnCerrarSesion = new System.Windows.Forms.ToolStripButton();
            this.ssPrincipal = new System.Windows.Forms.StatusStrip();
            this.msStatusBar = new System.Windows.Forms.ToolStripStatusLabel();
            this.bwk = new System.ComponentModel.BackgroundWorker();
            this.cuCvCdToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msPrincipal.SuspendLayout();
            this.tsPrincipal.SuspendLayout();
            this.ssPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // msPrincipal
            // 
            this.msPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.evaluacionTSMI,
            this.mantenimientoTSMI,
            this.reporteTSMI,
            this.usuarioTSMI,
            this.ventanaTSMI});
            this.msPrincipal.Location = new System.Drawing.Point(0, 0);
            this.msPrincipal.Name = "msPrincipal";
            this.msPrincipal.Size = new System.Drawing.Size(800, 24);
            this.msPrincipal.TabIndex = 1;
            this.msPrincipal.Text = "Menu Principal";
            // 
            // evaluacionTSMI
            // 
            this.evaluacionTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.nuevoTSMI,
            this.abrirTSMI});
            this.evaluacionTSMI.Name = "evaluacionTSMI";
            this.evaluacionTSMI.Size = new System.Drawing.Size(76, 20);
            this.evaluacionTSMI.Text = "&Evaluación";
            // 
            // nuevoTSMI
            // 
            this.nuevoTSMI.Image = global::WinEEGO.Properties.Resources.baseline_add_black_24dp;
            this.nuevoTSMI.Name = "nuevoTSMI";
            this.nuevoTSMI.Size = new System.Drawing.Size(109, 22);
            this.nuevoTSMI.Text = "&Nuevo";
            this.nuevoTSMI.Click += new System.EventHandler(this.nuevoTSMI_Click);
            // 
            // abrirTSMI
            // 
            this.abrirTSMI.Image = global::WinEEGO.Properties.Resources.baseline_folder_open_black_24dp;
            this.abrirTSMI.Name = "abrirTSMI";
            this.abrirTSMI.Size = new System.Drawing.Size(109, 22);
            this.abrirTSMI.Text = "&Abrir";
            this.abrirTSMI.Click += new System.EventHandler(this.abrirTSMI_Click);
            // 
            // mantenimientoTSMI
            // 
            this.mantenimientoTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuariosTSMI,
            this.cultivosTSMI,
            this.areasTSMI,
            this.emisoresTSMI});
            this.mantenimientoTSMI.Name = "mantenimientoTSMI";
            this.mantenimientoTSMI.Size = new System.Drawing.Size(101, 20);
            this.mantenimientoTSMI.Text = "&Mantenimiento";
            // 
            // usuariosTSMI
            // 
            this.usuariosTSMI.Name = "usuariosTSMI";
            this.usuariosTSMI.Size = new System.Drawing.Size(114, 22);
            this.usuariosTSMI.Text = "Usuario";
            this.usuariosTSMI.Click += new System.EventHandler(this.usuariosTSMI_Click);
            // 
            // cultivosTSMI
            // 
            this.cultivosTSMI.Name = "cultivosTSMI";
            this.cultivosTSMI.Size = new System.Drawing.Size(114, 22);
            this.cultivosTSMI.Text = "Cultivo";
            this.cultivosTSMI.Click += new System.EventHandler(this.cultivosTSMI_Click);
            // 
            // areasTSMI
            // 
            this.areasTSMI.Name = "areasTSMI";
            this.areasTSMI.Size = new System.Drawing.Size(114, 22);
            this.areasTSMI.Text = "Filtrado";
            this.areasTSMI.Click += new System.EventHandler(this.areasTSMI_Click);
            // 
            // emisoresTSMI
            // 
            this.emisoresTSMI.Name = "emisoresTSMI";
            this.emisoresTSMI.Size = new System.Drawing.Size(114, 22);
            this.emisoresTSMI.Text = "Emisor";
            this.emisoresTSMI.Click += new System.EventHandler(this.emisoresTSMI_Click);
            // 
            // reporteTSMI
            // 
            this.reporteTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.porAnioTSMI,
            this.toolStripMenuItem1,
            this.porAreaTSMI,
            this.porValvulaTSMI,
            this.toolStripMenuItem2,
            this.lotesSinEvaluaciónToolStripMenuItem,
            this.cuCvCdToolStripMenuItem});
            this.reporteTSMI.Name = "reporteTSMI";
            this.reporteTSMI.Size = new System.Drawing.Size(60, 20);
            this.reporteTSMI.Text = "&Reporte";
            // 
            // porAnioTSMI
            // 
            this.porAnioTSMI.Image = global::WinEEGO.Properties.Resources.baseline_outlined_flag_black_24dp;
            this.porAnioTSMI.Name = "porAnioTSMI";
            this.porAnioTSMI.Size = new System.Drawing.Size(180, 22);
            this.porAnioTSMI.Text = "Por año";
            this.porAnioTSMI.Click += new System.EventHandler(this.porAnioTSMI_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // porAreaTSMI
            // 
            this.porAreaTSMI.Image = global::WinEEGO.Properties.Resources.baseline_stacked_line_chart_black_24dp;
            this.porAreaTSMI.Name = "porAreaTSMI";
            this.porAreaTSMI.Size = new System.Drawing.Size(180, 22);
            this.porAreaTSMI.Text = "Por filtrado";
            this.porAreaTSMI.Click += new System.EventHandler(this.porAreaTSMI_Click);
            // 
            // porValvulaTSMI
            // 
            this.porValvulaTSMI.Image = global::WinEEGO.Properties.Resources.baseline_show_chart_black_24dp;
            this.porValvulaTSMI.Name = "porValvulaTSMI";
            this.porValvulaTSMI.Size = new System.Drawing.Size(180, 22);
            this.porValvulaTSMI.Text = "Por lote";
            this.porValvulaTSMI.Click += new System.EventHandler(this.porValvulaTSMI_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(177, 6);
            // 
            // lotesSinEvaluaciónToolStripMenuItem
            // 
            this.lotesSinEvaluaciónToolStripMenuItem.Name = "lotesSinEvaluaciónToolStripMenuItem";
            this.lotesSinEvaluaciónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.lotesSinEvaluaciónToolStripMenuItem.Text = "Lotes sin evaluación";
            this.lotesSinEvaluaciónToolStripMenuItem.Click += new System.EventHandler(this.lotesSinEvaluaciónToolStripMenuItem_Click);
            // 
            // usuarioTSMI
            // 
            this.usuarioTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iniciarSesionTSMI,
            this.cambiarClaveTSMI,
            this.cerrarSesionTSMI});
            this.usuarioTSMI.Name = "usuarioTSMI";
            this.usuarioTSMI.Size = new System.Drawing.Size(59, 20);
            this.usuarioTSMI.Text = "&Usuario";
            // 
            // iniciarSesionTSMI
            // 
            this.iniciarSesionTSMI.Image = global::WinEEGO.Properties.Resources.baseline_login_black_24dp;
            this.iniciarSesionTSMI.Name = "iniciarSesionTSMI";
            this.iniciarSesionTSMI.Size = new System.Drawing.Size(149, 22);
            this.iniciarSesionTSMI.Text = "Iniciar sesión";
            this.iniciarSesionTSMI.Click += new System.EventHandler(this.iniciarSesionTSMI_Click);
            // 
            // cambiarClaveTSMI
            // 
            this.cambiarClaveTSMI.Image = global::WinEEGO.Properties.Resources.baseline_lock_black_24dp;
            this.cambiarClaveTSMI.Name = "cambiarClaveTSMI";
            this.cambiarClaveTSMI.Size = new System.Drawing.Size(149, 22);
            this.cambiarClaveTSMI.Text = "Cambiar clave";
            this.cambiarClaveTSMI.Click += new System.EventHandler(this.cambiarClaveTSMI_Click);
            // 
            // cerrarSesionTSMI
            // 
            this.cerrarSesionTSMI.Image = global::WinEEGO.Properties.Resources.baseline_logout_black_24dp;
            this.cerrarSesionTSMI.Name = "cerrarSesionTSMI";
            this.cerrarSesionTSMI.Size = new System.Drawing.Size(149, 22);
            this.cerrarSesionTSMI.Text = "Cerrar sesión";
            this.cerrarSesionTSMI.Click += new System.EventHandler(this.cerrarSesionTSMI_Click);
            // 
            // ventanaTSMI
            // 
            this.ventanaTSMI.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cascadaTSMI,
            this.verticalTSMI,
            this.horizontalTSMI});
            this.ventanaTSMI.Name = "ventanaTSMI";
            this.ventanaTSMI.Size = new System.Drawing.Size(61, 20);
            this.ventanaTSMI.Text = "&Ventana";
            // 
            // cascadaTSMI
            // 
            this.cascadaTSMI.Name = "cascadaTSMI";
            this.cascadaTSMI.Size = new System.Drawing.Size(129, 22);
            this.cascadaTSMI.Text = "Cascada";
            this.cascadaTSMI.Click += new System.EventHandler(this.cascadaTSMI_Click);
            // 
            // verticalTSMI
            // 
            this.verticalTSMI.Name = "verticalTSMI";
            this.verticalTSMI.Size = new System.Drawing.Size(129, 22);
            this.verticalTSMI.Text = "Vertical";
            this.verticalTSMI.Click += new System.EventHandler(this.verticalTSMI_Click);
            // 
            // horizontalTSMI
            // 
            this.horizontalTSMI.Name = "horizontalTSMI";
            this.horizontalTSMI.Size = new System.Drawing.Size(129, 22);
            this.horizontalTSMI.Text = "Horizontal";
            this.horizontalTSMI.Click += new System.EventHandler(this.horizontalTSMI_Click);
            // 
            // tsPrincipal
            // 
            this.tsPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnNuevo,
            this.btnAbrir,
            this.toolStripSeparator1,
            this.btnPorAnio,
            this.btnPorArea,
            this.btnPorValvula,
            this.toolStripSeparator2,
            this.btnIniciarSesion,
            this.btnCerrarSesion});
            this.tsPrincipal.Location = new System.Drawing.Point(0, 24);
            this.tsPrincipal.Name = "tsPrincipal";
            this.tsPrincipal.Size = new System.Drawing.Size(800, 25);
            this.tsPrincipal.TabIndex = 2;
            this.tsPrincipal.Text = "Barra de herramientas";
            // 
            // btnNuevo
            // 
            this.btnNuevo.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnNuevo.Image = global::WinEEGO.Properties.Resources.baseline_add_black_24dp;
            this.btnNuevo.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(23, 22);
            this.btnNuevo.Text = "Nueva evaluación";
            this.btnNuevo.Click += new System.EventHandler(this.btnNuevo_Click);
            // 
            // btnAbrir
            // 
            this.btnAbrir.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnAbrir.Image = global::WinEEGO.Properties.Resources.baseline_folder_open_black_24dp;
            this.btnAbrir.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAbrir.Name = "btnAbrir";
            this.btnAbrir.Size = new System.Drawing.Size(23, 22);
            this.btnAbrir.Text = "Abrir evaluación";
            this.btnAbrir.Click += new System.EventHandler(this.btnAbrir_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnPorAnio
            // 
            this.btnPorAnio.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPorAnio.Image = global::WinEEGO.Properties.Resources.baseline_outlined_flag_black_24dp;
            this.btnPorAnio.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPorAnio.Name = "btnPorAnio";
            this.btnPorAnio.Size = new System.Drawing.Size(23, 22);
            this.btnPorAnio.Text = "Reporte por año";
            this.btnPorAnio.Click += new System.EventHandler(this.btnPorAnio_Click);
            // 
            // btnPorArea
            // 
            this.btnPorArea.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPorArea.Image = global::WinEEGO.Properties.Resources.baseline_stacked_line_chart_black_24dp;
            this.btnPorArea.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPorArea.Name = "btnPorArea";
            this.btnPorArea.Size = new System.Drawing.Size(23, 22);
            this.btnPorArea.Text = "Reporte por area";
            this.btnPorArea.Click += new System.EventHandler(this.btnPorArea_Click);
            // 
            // btnPorValvula
            // 
            this.btnPorValvula.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnPorValvula.Image = global::WinEEGO.Properties.Resources.baseline_show_chart_black_24dp;
            this.btnPorValvula.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPorValvula.Name = "btnPorValvula";
            this.btnPorValvula.Size = new System.Drawing.Size(23, 22);
            this.btnPorValvula.Text = "Reporte por válvula";
            this.btnPorValvula.Click += new System.EventHandler(this.btnPorValvula_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnIniciarSesion
            // 
            this.btnIniciarSesion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnIniciarSesion.Image = global::WinEEGO.Properties.Resources.baseline_login_black_24dp;
            this.btnIniciarSesion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnIniciarSesion.Name = "btnIniciarSesion";
            this.btnIniciarSesion.Size = new System.Drawing.Size(23, 22);
            this.btnIniciarSesion.Text = "Iniciar sesión";
            this.btnIniciarSesion.Click += new System.EventHandler(this.btnIniciarSesion_Click);
            // 
            // btnCerrarSesion
            // 
            this.btnCerrarSesion.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.btnCerrarSesion.Image = global::WinEEGO.Properties.Resources.baseline_logout_black_24dp;
            this.btnCerrarSesion.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCerrarSesion.Name = "btnCerrarSesion";
            this.btnCerrarSesion.Size = new System.Drawing.Size(23, 22);
            this.btnCerrarSesion.Text = "Cerrar sesión";
            this.btnCerrarSesion.Click += new System.EventHandler(this.btnCerrarSesion_Click);
            // 
            // ssPrincipal
            // 
            this.ssPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.msStatusBar});
            this.ssPrincipal.Location = new System.Drawing.Point(0, 428);
            this.ssPrincipal.Name = "ssPrincipal";
            this.ssPrincipal.Size = new System.Drawing.Size(800, 22);
            this.ssPrincipal.TabIndex = 3;
            this.ssPrincipal.Text = "Barra de estado";
            this.ssPrincipal.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.ssPrincipal_MouseDoubleClick);
            // 
            // msStatusBar
            // 
            this.msStatusBar.Name = "msStatusBar";
            this.msStatusBar.Size = new System.Drawing.Size(12, 17);
            this.msStatusBar.Text = "*";
            // 
            // bwk
            // 
            this.bwk.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwk_DoWork);
            this.bwk.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwk_RunWorkerCompleted);
            // 
            // cuCvCdToolStripMenuItem
            // 
            this.cuCvCdToolStripMenuItem.Name = "cuCvCdToolStripMenuItem";
            this.cuCvCdToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.cuCvCdToolStripMenuItem.Text = "Cu Cv Cd";
            this.cuCvCdToolStripMenuItem.Click += new System.EventHandler(this.cuCvCdToolStripMenuItem_Click);
            // 
            // FormPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ssPrincipal);
            this.Controls.Add(this.tsPrincipal);
            this.Controls.Add(this.msPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.msPrincipal;
            this.Name = "FormPrincipal";
            this.Text = "EEGO - Evaluación de Emisión de Goteros";
            this.Load += new System.EventHandler(this.FormPrincipal_Load);
            this.Shown += new System.EventHandler(this.FormPrincipal_Shown);
            this.msPrincipal.ResumeLayout(false);
            this.msPrincipal.PerformLayout();
            this.tsPrincipal.ResumeLayout(false);
            this.tsPrincipal.PerformLayout();
            this.ssPrincipal.ResumeLayout(false);
            this.ssPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip msPrincipal;
        private System.Windows.Forms.ToolStripMenuItem evaluacionTSMI;
        private System.Windows.Forms.ToolStripMenuItem nuevoTSMI;
        private System.Windows.Forms.ToolStripMenuItem abrirTSMI;
        private System.Windows.Forms.ToolStripMenuItem mantenimientoTSMI;
        private System.Windows.Forms.ToolStripMenuItem reporteTSMI;
        private System.Windows.Forms.ToolStripMenuItem usuarioTSMI;
        private System.Windows.Forms.ToolStripMenuItem ventanaTSMI;
        private System.Windows.Forms.ToolStripMenuItem cascadaTSMI;
        private System.Windows.Forms.ToolStripMenuItem verticalTSMI;
        private System.Windows.Forms.ToolStripMenuItem horizontalTSMI;
        private System.Windows.Forms.ToolStrip tsPrincipal;
        private System.Windows.Forms.StatusStrip ssPrincipal;
        private System.Windows.Forms.ToolStripStatusLabel msStatusBar;
        private System.Windows.Forms.ToolStripButton btnNuevo;
        private System.Windows.Forms.ToolStripButton btnAbrir;
        private System.Windows.Forms.ToolStripButton btnIniciarSesion;
        private System.Windows.Forms.ToolStripButton btnCerrarSesion;
        private System.ComponentModel.BackgroundWorker bwk;
        private System.Windows.Forms.ToolStripMenuItem iniciarSesionTSMI;
        private System.Windows.Forms.ToolStripMenuItem cambiarClaveTSMI;
        private System.Windows.Forms.ToolStripMenuItem cerrarSesionTSMI;
        private System.Windows.Forms.ToolStripMenuItem usuariosTSMI;
        private System.Windows.Forms.ToolStripMenuItem areasTSMI;
        private System.Windows.Forms.ToolStripMenuItem emisoresTSMI;
        private System.Windows.Forms.ToolStripMenuItem cultivosTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem porAnioTSMI;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem porAreaTSMI;
        private System.Windows.Forms.ToolStripMenuItem porValvulaTSMI;
        private System.Windows.Forms.ToolStripButton btnPorAnio;
        private System.Windows.Forms.ToolStripButton btnPorArea;
        private System.Windows.Forms.ToolStripButton btnPorValvula;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem lotesSinEvaluaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cuCvCdToolStripMenuItem;
    }
}