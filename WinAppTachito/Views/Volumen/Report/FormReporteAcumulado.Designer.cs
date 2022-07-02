namespace WinAppTachito.Views.Volumen.Report
{
    partial class FormReporteAcumulado
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReporteAcumulado));
            this.label1 = new System.Windows.Forms.Label();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.cultivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valvulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fallasAcumuladasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fallasSucesivasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlertasAcumuladas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AlertasSucesivas = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDatos = new System.Windows.Forms.BindingSource(this.components);
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.litrosProgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.litrosRealDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.variacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.incluirDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.notaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDetalle = new System.Windows.Forms.BindingSource(this.components);
            this.chart01 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.listaImg = new System.Windows.Forms.ImageList(this.components);
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.panFiltro = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.cbValvula = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbCultivo = new System.Windows.Forms.ComboBox();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart01)).BeginInit();
            this.panFiltro.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(108, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(356, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "Fallas acumuladas y fallas sucesivas desde última evaluación en los últimos 30 di" +
    "as";
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnActualizar.Location = new System.Drawing.Point(12, 12);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(90, 30);
            this.btnActualizar.TabIndex = 14;
            this.btnActualizar.Text = "MOSTRAR";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.btnActualizar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgvDatos.AutoGenerateColumns = false;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cultivoDataGridViewTextBoxColumn,
            this.loteDataGridViewTextBoxColumn,
            this.valvulaDataGridViewTextBoxColumn,
            this.fallasAcumuladasDataGridViewTextBoxColumn,
            this.fallasSucesivasDataGridViewTextBoxColumn,
            this.AlertasAcumuladas,
            this.AlertasSucesivas});
            this.dgvDatos.DataSource = this.bsDatos;
            this.dgvDatos.Location = new System.Drawing.Point(12, 48);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersWidth = 10;
            this.dgvDatos.Size = new System.Drawing.Size(452, 501);
            this.dgvDatos.TabIndex = 15;
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.dgvDatos_SelectionChanged);
            // 
            // cultivoDataGridViewTextBoxColumn
            // 
            this.cultivoDataGridViewTextBoxColumn.DataPropertyName = "Cultivo";
            this.cultivoDataGridViewTextBoxColumn.HeaderText = "Cultivo";
            this.cultivoDataGridViewTextBoxColumn.Name = "cultivoDataGridViewTextBoxColumn";
            this.cultivoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cultivoDataGridViewTextBoxColumn.Width = 70;
            // 
            // loteDataGridViewTextBoxColumn
            // 
            this.loteDataGridViewTextBoxColumn.DataPropertyName = "Lote";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.loteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.loteDataGridViewTextBoxColumn.HeaderText = "Area";
            this.loteDataGridViewTextBoxColumn.Name = "loteDataGridViewTextBoxColumn";
            this.loteDataGridViewTextBoxColumn.ReadOnly = true;
            this.loteDataGridViewTextBoxColumn.Width = 50;
            // 
            // valvulaDataGridViewTextBoxColumn
            // 
            this.valvulaDataGridViewTextBoxColumn.DataPropertyName = "Valvula";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.valvulaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.valvulaDataGridViewTextBoxColumn.HeaderText = "Valvula";
            this.valvulaDataGridViewTextBoxColumn.Name = "valvulaDataGridViewTextBoxColumn";
            this.valvulaDataGridViewTextBoxColumn.ReadOnly = true;
            this.valvulaDataGridViewTextBoxColumn.Width = 50;
            // 
            // fallasAcumuladasDataGridViewTextBoxColumn
            // 
            this.fallasAcumuladasDataGridViewTextBoxColumn.DataPropertyName = "FallasAcumuladas";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fallasAcumuladasDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.fallasAcumuladasDataGridViewTextBoxColumn.HeaderText = "Fallas Acum.";
            this.fallasAcumuladasDataGridViewTextBoxColumn.Name = "fallasAcumuladasDataGridViewTextBoxColumn";
            this.fallasAcumuladasDataGridViewTextBoxColumn.ReadOnly = true;
            this.fallasAcumuladasDataGridViewTextBoxColumn.Width = 60;
            // 
            // fallasSucesivasDataGridViewTextBoxColumn
            // 
            this.fallasSucesivasDataGridViewTextBoxColumn.DataPropertyName = "FallasSucesivas";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.fallasSucesivasDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.fallasSucesivasDataGridViewTextBoxColumn.HeaderText = "Fallas Suces.";
            this.fallasSucesivasDataGridViewTextBoxColumn.Name = "fallasSucesivasDataGridViewTextBoxColumn";
            this.fallasSucesivasDataGridViewTextBoxColumn.ReadOnly = true;
            this.fallasSucesivasDataGridViewTextBoxColumn.Width = 60;
            // 
            // AlertasAcumuladas
            // 
            this.AlertasAcumuladas.DataPropertyName = "AlertasAcumuladas";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AlertasAcumuladas.DefaultCellStyle = dataGridViewCellStyle5;
            this.AlertasAcumuladas.HeaderText = "Alertas Acum.";
            this.AlertasAcumuladas.Name = "AlertasAcumuladas";
            this.AlertasAcumuladas.ReadOnly = true;
            this.AlertasAcumuladas.Width = 60;
            // 
            // AlertasSucesivas
            // 
            this.AlertasSucesivas.DataPropertyName = "AlertasSucesivas";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.AlertasSucesivas.DefaultCellStyle = dataGridViewCellStyle6;
            this.AlertasSucesivas.HeaderText = "Alertas Suces.";
            this.AlertasSucesivas.Name = "AlertasSucesivas";
            this.AlertasSucesivas.ReadOnly = true;
            this.AlertasSucesivas.Width = 60;
            // 
            // bsDatos
            // 
            this.bsDatos.DataSource = typeof(WinAppTachito.Models.Report.EvaluacionAcumulado);
            // 
            // dgvDetalle
            // 
            this.dgvDetalle.AllowUserToAddRows = false;
            this.dgvDetalle.AllowUserToDeleteRows = false;
            this.dgvDetalle.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDetalle.AutoGenerateColumns = false;
            this.dgvDetalle.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDetalle.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDetalle.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.litrosProgDataGridViewTextBoxColumn,
            this.litrosRealDataGridViewTextBoxColumn,
            this.variacionDataGridViewTextBoxColumn,
            this.incluirDataGridViewCheckBoxColumn,
            this.notaDataGridViewTextBoxColumn});
            this.dgvDetalle.DataSource = this.bsDetalle;
            this.dgvDetalle.Location = new System.Drawing.Point(470, 341);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersWidth = 10;
            this.dgvDetalle.Size = new System.Drawing.Size(402, 208);
            this.dgvDetalle.TabIndex = 16;
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // litrosProgDataGridViewTextBoxColumn
            // 
            this.litrosProgDataGridViewTextBoxColumn.DataPropertyName = "LitrosProg";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle7.Format = "N3";
            this.litrosProgDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.litrosProgDataGridViewTextBoxColumn.HeaderText = "Litros Programados";
            this.litrosProgDataGridViewTextBoxColumn.Name = "litrosProgDataGridViewTextBoxColumn";
            this.litrosProgDataGridViewTextBoxColumn.ReadOnly = true;
            this.litrosProgDataGridViewTextBoxColumn.Width = 80;
            // 
            // litrosRealDataGridViewTextBoxColumn
            // 
            this.litrosRealDataGridViewTextBoxColumn.DataPropertyName = "LitrosReal";
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle8.Format = "N3";
            this.litrosRealDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle8;
            this.litrosRealDataGridViewTextBoxColumn.HeaderText = "Litros Reales";
            this.litrosRealDataGridViewTextBoxColumn.Name = "litrosRealDataGridViewTextBoxColumn";
            this.litrosRealDataGridViewTextBoxColumn.ReadOnly = true;
            this.litrosRealDataGridViewTextBoxColumn.Width = 80;
            // 
            // variacionDataGridViewTextBoxColumn
            // 
            this.variacionDataGridViewTextBoxColumn.DataPropertyName = "Variacion";
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle9.Format = "N2";
            this.variacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle9;
            this.variacionDataGridViewTextBoxColumn.HeaderText = "Variacion %";
            this.variacionDataGridViewTextBoxColumn.Name = "variacionDataGridViewTextBoxColumn";
            this.variacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.variacionDataGridViewTextBoxColumn.Width = 70;
            // 
            // incluirDataGridViewCheckBoxColumn
            // 
            this.incluirDataGridViewCheckBoxColumn.DataPropertyName = "Incluir";
            this.incluirDataGridViewCheckBoxColumn.HeaderText = "Incluir";
            this.incluirDataGridViewCheckBoxColumn.Name = "incluirDataGridViewCheckBoxColumn";
            this.incluirDataGridViewCheckBoxColumn.ReadOnly = true;
            this.incluirDataGridViewCheckBoxColumn.Width = 50;
            // 
            // notaDataGridViewTextBoxColumn
            // 
            this.notaDataGridViewTextBoxColumn.DataPropertyName = "Nota";
            this.notaDataGridViewTextBoxColumn.HeaderText = "Nota";
            this.notaDataGridViewTextBoxColumn.Name = "notaDataGridViewTextBoxColumn";
            this.notaDataGridViewTextBoxColumn.ReadOnly = true;
            this.notaDataGridViewTextBoxColumn.Width = 500;
            // 
            // bsDetalle
            // 
            this.bsDetalle.DataSource = typeof(WinAppTachito.Models.Report.DetalleEvaluacionCorta);
            // 
            // chart01
            // 
            this.chart01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea1.Name = "ChartArea1";
            this.chart01.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart01.Legends.Add(legend1);
            this.chart01.Location = new System.Drawing.Point(470, 48);
            this.chart01.Name = "chart01";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart01.Series.Add(series1);
            this.chart01.Size = new System.Drawing.Size(402, 287);
            this.chart01.TabIndex = 17;
            this.chart01.Text = "chart1";
            this.chart01.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chart01_GetToolTipText);
            // 
            // listaImg
            // 
            this.listaImg.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("listaImg.ImageStream")));
            this.listaImg.TransparentColor = System.Drawing.Color.Transparent;
            this.listaImg.Images.SetKeyName(0, "outline_new_label_white_24dp.png");
            this.listaImg.Images.SetKeyName(1, "outline_update_white_24dp.png");
            this.listaImg.Images.SetKeyName(2, "outline_view_list_white_24dp.png");
            this.listaImg.Images.SetKeyName(3, "outline_print_white_24dp.png");
            this.listaImg.Images.SetKeyName(4, "outline_extension_white_24dp.png");
            this.listaImg.Images.SetKeyName(5, "outline_filter_list_white_24dp.png");
            this.listaImg.Images.SetKeyName(6, "outline_edit_note_white_24dp.png");
            this.listaImg.Images.SetKeyName(7, "outline_delete_white_24dp.png");
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExportar.ImageIndex = 4;
            this.btnExportar.ImageList = this.listaImg;
            this.btnExportar.Location = new System.Drawing.Point(536, 12);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(60, 30);
            this.btnExportar.TabIndex = 23;
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // btnFiltrar
            // 
            this.btnFiltrar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnFiltrar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFiltrar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnFiltrar.ImageIndex = 5;
            this.btnFiltrar.ImageList = this.listaImg;
            this.btnFiltrar.Location = new System.Drawing.Point(470, 12);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(60, 30);
            this.btnFiltrar.TabIndex = 24;
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // panFiltro
            // 
            this.panFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panFiltro.Controls.Add(this.label2);
            this.panFiltro.Controls.Add(this.cbValvula);
            this.panFiltro.Controls.Add(this.label4);
            this.panFiltro.Controls.Add(this.label3);
            this.panFiltro.Controls.Add(this.cbCultivo);
            this.panFiltro.Controls.Add(this.cbArea);
            this.panFiltro.Location = new System.Drawing.Point(470, 48);
            this.panFiltro.Name = "panFiltro";
            this.panFiltro.Size = new System.Drawing.Size(200, 113);
            this.panFiltro.TabIndex = 25;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Valvula:";
            // 
            // cbValvula
            // 
            this.cbValvula.FormattingEnabled = true;
            this.cbValvula.Items.AddRange(new object[] {
            "Todos"});
            this.cbValvula.Location = new System.Drawing.Point(67, 66);
            this.cbValvula.Name = "cbValvula";
            this.cbValvula.Size = new System.Drawing.Size(121, 21);
            this.cbValvula.TabIndex = 27;
            this.cbValvula.SelectedIndexChanged += new System.EventHandler(this.cbValvula_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(42, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Cultivo:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 42);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Area:";
            // 
            // cbCultivo
            // 
            this.cbCultivo.FormattingEnabled = true;
            this.cbCultivo.Items.AddRange(new object[] {
            "Todos"});
            this.cbCultivo.Location = new System.Drawing.Point(67, 12);
            this.cbCultivo.Name = "cbCultivo";
            this.cbCultivo.Size = new System.Drawing.Size(121, 21);
            this.cbCultivo.TabIndex = 26;
            this.cbCultivo.SelectedIndexChanged += new System.EventHandler(this.cbCultivo_SelectedIndexChanged);
            // 
            // cbArea
            // 
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Items.AddRange(new object[] {
            "Todos"});
            this.cbArea.Location = new System.Drawing.Point(67, 39);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(121, 21);
            this.cbArea.TabIndex = 25;
            this.cbArea.SelectedIndexChanged += new System.EventHandler(this.cbArea_SelectedIndexChanged);
            // 
            // FormReporteAcumulado
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panFiltro);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.chart01);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormReporteAcumulado";
            this.Text = "Acumulado";
            this.Load += new System.EventHandler(this.FormReporteAcumulado_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart01)).EndInit();
            this.panFiltro.ResumeLayout(false);
            this.panFiltro.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource bsDatos;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.BindingSource bsDetalle;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart01;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn litrosProgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn litrosRealDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn variacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn incluirDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn notaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cultivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valvulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fallasAcumuladasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fallasSucesivasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertasAcumuladas;
        private System.Windows.Forms.DataGridViewTextBoxColumn AlertasSucesivas;
        private System.Windows.Forms.ImageList listaImg;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Panel panFiltro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbCultivo;
        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbValvula;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
    }
}