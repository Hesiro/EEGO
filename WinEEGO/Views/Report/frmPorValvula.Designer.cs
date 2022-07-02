
namespace WinEEGO.Views.Report
{
    partial class frmPorValvula
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.txtAnio = new System.Windows.Forms.NumericUpDown();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.cbValvula = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.dgDatos = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hectareaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cultivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coeficienteUniformidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coeficienteVariacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coeficienteDesviacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroMuestrasDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numeroPresionesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreMangueraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emisionPermisibleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emisionSobrePermisibleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caudalMedioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.caudalMedio25DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.desviacionSDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goterosDebajoPermisibleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goterosPermisibleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.goterosSobrePermisibleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaAfectadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaRegularDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaBuenoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroAfectadoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroRegularDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroBuenoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCreacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCierreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalGoterosDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaEvaluadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeAreaAfectadaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeAreaRegularDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.porcentajeAreaBuenaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsEvaluacionGoteros = new System.Windows.Forms.BindingSource(this.components);
            this.chart01 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)(this.txtAnio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEvaluacionGoteros)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart01)).BeginInit();
            this.SuspendLayout();
            // 
            // txtAnio
            // 
            this.txtAnio.Location = new System.Drawing.Point(47, 12);
            this.txtAnio.Maximum = new decimal(new int[] {
            2200,
            0,
            0,
            0});
            this.txtAnio.Minimum = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            this.txtAnio.Name = "txtAnio";
            this.txtAnio.Size = new System.Drawing.Size(120, 20);
            this.txtAnio.TabIndex = 4;
            this.txtAnio.Value = new decimal(new int[] {
            2000,
            0,
            0,
            0});
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Año:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(203, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Filtrado:";
            // 
            // cbArea
            // 
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Location = new System.Drawing.Point(253, 12);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(121, 21);
            this.cbArea.TabIndex = 7;
            this.cbArea.SelectedIndexChanged += new System.EventHandler(this.cbArea_SelectedIndexChanged);
            // 
            // cbValvula
            // 
            this.cbValvula.FormattingEnabled = true;
            this.cbValvula.Location = new System.Drawing.Point(460, 12);
            this.cbValvula.Name = "cbValvula";
            this.cbValvula.Size = new System.Drawing.Size(121, 21);
            this.cbValvula.TabIndex = 10;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(423, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(31, 13);
            this.label3.TabIndex = 11;
            this.label3.Text = "Lote:";
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(619, 12);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(75, 23);
            this.btnMostrar.TabIndex = 12;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // dgDatos
            // 
            this.dgDatos.AllowUserToAddRows = false;
            this.dgDatos.AllowUserToDeleteRows = false;
            this.dgDatos.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dgDatos.AutoGenerateColumns = false;
            this.dgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.areaDataGridViewTextBoxColumn,
            this.hectareaDataGridViewTextBoxColumn,
            this.cultivoDataGridViewTextBoxColumn,
            this.coeficienteUniformidadDataGridViewTextBoxColumn,
            this.coeficienteVariacionDataGridViewTextBoxColumn,
            this.coeficienteDesviacionDataGridViewTextBoxColumn,
            this.numeroMuestrasDataGridViewTextBoxColumn,
            this.numeroPresionesDataGridViewTextBoxColumn,
            this.usuarioDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.nombreMangueraDataGridViewTextBoxColumn,
            this.emisionDataGridViewTextBoxColumn,
            this.emisionPermisibleDataGridViewTextBoxColumn,
            this.emisionSobrePermisibleDataGridViewTextBoxColumn,
            this.caudalMedioDataGridViewTextBoxColumn,
            this.caudalMedio25DataGridViewTextBoxColumn,
            this.desviacionSDataGridViewTextBoxColumn,
            this.goterosDebajoPermisibleDataGridViewTextBoxColumn,
            this.goterosPermisibleDataGridViewTextBoxColumn,
            this.goterosSobrePermisibleDataGridViewTextBoxColumn,
            this.areaAfectadaDataGridViewTextBoxColumn,
            this.areaRegularDataGridViewTextBoxColumn,
            this.areaBuenoDataGridViewTextBoxColumn,
            this.nroAfectadoDataGridViewTextBoxColumn,
            this.nroRegularDataGridViewTextBoxColumn,
            this.nroBuenoDataGridViewTextBoxColumn,
            this.fechaCreacionDataGridViewTextBoxColumn,
            this.fechaCierreDataGridViewTextBoxColumn,
            this.totalGoterosDataGridViewTextBoxColumn,
            this.areaEvaluadaDataGridViewTextBoxColumn,
            this.porcentajeAreaAfectadaDataGridViewTextBoxColumn,
            this.porcentajeAreaRegularDataGridViewTextBoxColumn,
            this.porcentajeAreaBuenaDataGridViewTextBoxColumn});
            this.dgDatos.DataSource = this.bsEvaluacionGoteros;
            this.dgDatos.Location = new System.Drawing.Point(12, 80);
            this.dgDatos.Name = "dgDatos";
            this.dgDatos.ReadOnly = true;
            this.dgDatos.RowHeadersWidth = 20;
            this.dgDatos.Size = new System.Drawing.Size(386, 358);
            this.dgDatos.TabIndex = 14;
            this.dgDatos.SelectionChanged += new System.EventHandler(this.dgDatos_SelectionChanged);
            this.dgDatos.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.dgDatos_MouseDoubleClick);
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.Format = "d";
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha de evaluación";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 80;
            // 
            // areaDataGridViewTextBoxColumn
            // 
            this.areaDataGridViewTextBoxColumn.DataPropertyName = "Area";
            this.areaDataGridViewTextBoxColumn.HeaderText = "Area";
            this.areaDataGridViewTextBoxColumn.Name = "areaDataGridViewTextBoxColumn";
            this.areaDataGridViewTextBoxColumn.ReadOnly = true;
            this.areaDataGridViewTextBoxColumn.Visible = false;
            // 
            // hectareaDataGridViewTextBoxColumn
            // 
            this.hectareaDataGridViewTextBoxColumn.DataPropertyName = "Hectarea";
            this.hectareaDataGridViewTextBoxColumn.HeaderText = "Hectarea";
            this.hectareaDataGridViewTextBoxColumn.Name = "hectareaDataGridViewTextBoxColumn";
            this.hectareaDataGridViewTextBoxColumn.ReadOnly = true;
            this.hectareaDataGridViewTextBoxColumn.Visible = false;
            // 
            // cultivoDataGridViewTextBoxColumn
            // 
            this.cultivoDataGridViewTextBoxColumn.DataPropertyName = "Cultivo";
            this.cultivoDataGridViewTextBoxColumn.HeaderText = "Cultivo";
            this.cultivoDataGridViewTextBoxColumn.Name = "cultivoDataGridViewTextBoxColumn";
            this.cultivoDataGridViewTextBoxColumn.ReadOnly = true;
            this.cultivoDataGridViewTextBoxColumn.Visible = false;
            // 
            // coeficienteUniformidadDataGridViewTextBoxColumn
            // 
            this.coeficienteUniformidadDataGridViewTextBoxColumn.DataPropertyName = "CoeficienteUniformidad";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle2.Format = "N2";
            this.coeficienteUniformidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.coeficienteUniformidadDataGridViewTextBoxColumn.HeaderText = "Coeficiente uniformidad %";
            this.coeficienteUniformidadDataGridViewTextBoxColumn.Name = "coeficienteUniformidadDataGridViewTextBoxColumn";
            this.coeficienteUniformidadDataGridViewTextBoxColumn.ReadOnly = true;
            this.coeficienteUniformidadDataGridViewTextBoxColumn.Width = 80;
            // 
            // coeficienteVariacionDataGridViewTextBoxColumn
            // 
            this.coeficienteVariacionDataGridViewTextBoxColumn.DataPropertyName = "CoeficienteVariacion";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.coeficienteVariacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.coeficienteVariacionDataGridViewTextBoxColumn.HeaderText = "Coeficiente variación %";
            this.coeficienteVariacionDataGridViewTextBoxColumn.Name = "coeficienteVariacionDataGridViewTextBoxColumn";
            this.coeficienteVariacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.coeficienteVariacionDataGridViewTextBoxColumn.Width = 80;
            // 
            // coeficienteDesviacionDataGridViewTextBoxColumn
            // 
            this.coeficienteDesviacionDataGridViewTextBoxColumn.DataPropertyName = "CoeficienteDesviacion";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.coeficienteDesviacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.coeficienteDesviacionDataGridViewTextBoxColumn.HeaderText = "Coeficiente desviación %";
            this.coeficienteDesviacionDataGridViewTextBoxColumn.Name = "coeficienteDesviacionDataGridViewTextBoxColumn";
            this.coeficienteDesviacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.coeficienteDesviacionDataGridViewTextBoxColumn.Width = 80;
            // 
            // numeroMuestrasDataGridViewTextBoxColumn
            // 
            this.numeroMuestrasDataGridViewTextBoxColumn.DataPropertyName = "NumeroMuestras";
            this.numeroMuestrasDataGridViewTextBoxColumn.HeaderText = "NumeroMuestras";
            this.numeroMuestrasDataGridViewTextBoxColumn.Name = "numeroMuestrasDataGridViewTextBoxColumn";
            this.numeroMuestrasDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeroMuestrasDataGridViewTextBoxColumn.Visible = false;
            // 
            // numeroPresionesDataGridViewTextBoxColumn
            // 
            this.numeroPresionesDataGridViewTextBoxColumn.DataPropertyName = "NumeroPresiones";
            this.numeroPresionesDataGridViewTextBoxColumn.HeaderText = "NumeroPresiones";
            this.numeroPresionesDataGridViewTextBoxColumn.Name = "numeroPresionesDataGridViewTextBoxColumn";
            this.numeroPresionesDataGridViewTextBoxColumn.ReadOnly = true;
            this.numeroPresionesDataGridViewTextBoxColumn.Visible = false;
            // 
            // usuarioDataGridViewTextBoxColumn
            // 
            this.usuarioDataGridViewTextBoxColumn.DataPropertyName = "Usuario";
            this.usuarioDataGridViewTextBoxColumn.HeaderText = "Usuario";
            this.usuarioDataGridViewTextBoxColumn.Name = "usuarioDataGridViewTextBoxColumn";
            this.usuarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioDataGridViewTextBoxColumn.Visible = false;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Status";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Visible = false;
            // 
            // nombreMangueraDataGridViewTextBoxColumn
            // 
            this.nombreMangueraDataGridViewTextBoxColumn.DataPropertyName = "NombreManguera";
            this.nombreMangueraDataGridViewTextBoxColumn.HeaderText = "NombreManguera";
            this.nombreMangueraDataGridViewTextBoxColumn.Name = "nombreMangueraDataGridViewTextBoxColumn";
            this.nombreMangueraDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreMangueraDataGridViewTextBoxColumn.Visible = false;
            // 
            // emisionDataGridViewTextBoxColumn
            // 
            this.emisionDataGridViewTextBoxColumn.DataPropertyName = "Emision";
            this.emisionDataGridViewTextBoxColumn.HeaderText = "Emision";
            this.emisionDataGridViewTextBoxColumn.Name = "emisionDataGridViewTextBoxColumn";
            this.emisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.emisionDataGridViewTextBoxColumn.Visible = false;
            // 
            // emisionPermisibleDataGridViewTextBoxColumn
            // 
            this.emisionPermisibleDataGridViewTextBoxColumn.DataPropertyName = "EmisionPermisible";
            this.emisionPermisibleDataGridViewTextBoxColumn.HeaderText = "EmisionPermisible";
            this.emisionPermisibleDataGridViewTextBoxColumn.Name = "emisionPermisibleDataGridViewTextBoxColumn";
            this.emisionPermisibleDataGridViewTextBoxColumn.ReadOnly = true;
            this.emisionPermisibleDataGridViewTextBoxColumn.Visible = false;
            // 
            // emisionSobrePermisibleDataGridViewTextBoxColumn
            // 
            this.emisionSobrePermisibleDataGridViewTextBoxColumn.DataPropertyName = "EmisionSobrePermisible";
            this.emisionSobrePermisibleDataGridViewTextBoxColumn.HeaderText = "EmisionSobrePermisible";
            this.emisionSobrePermisibleDataGridViewTextBoxColumn.Name = "emisionSobrePermisibleDataGridViewTextBoxColumn";
            this.emisionSobrePermisibleDataGridViewTextBoxColumn.ReadOnly = true;
            this.emisionSobrePermisibleDataGridViewTextBoxColumn.Visible = false;
            // 
            // caudalMedioDataGridViewTextBoxColumn
            // 
            this.caudalMedioDataGridViewTextBoxColumn.DataPropertyName = "CaudalMedio";
            this.caudalMedioDataGridViewTextBoxColumn.HeaderText = "CaudalMedio";
            this.caudalMedioDataGridViewTextBoxColumn.Name = "caudalMedioDataGridViewTextBoxColumn";
            this.caudalMedioDataGridViewTextBoxColumn.ReadOnly = true;
            this.caudalMedioDataGridViewTextBoxColumn.Visible = false;
            // 
            // caudalMedio25DataGridViewTextBoxColumn
            // 
            this.caudalMedio25DataGridViewTextBoxColumn.DataPropertyName = "CaudalMedio25";
            this.caudalMedio25DataGridViewTextBoxColumn.HeaderText = "CaudalMedio25";
            this.caudalMedio25DataGridViewTextBoxColumn.Name = "caudalMedio25DataGridViewTextBoxColumn";
            this.caudalMedio25DataGridViewTextBoxColumn.ReadOnly = true;
            this.caudalMedio25DataGridViewTextBoxColumn.Visible = false;
            // 
            // desviacionSDataGridViewTextBoxColumn
            // 
            this.desviacionSDataGridViewTextBoxColumn.DataPropertyName = "DesviacionS";
            this.desviacionSDataGridViewTextBoxColumn.HeaderText = "DesviacionS";
            this.desviacionSDataGridViewTextBoxColumn.Name = "desviacionSDataGridViewTextBoxColumn";
            this.desviacionSDataGridViewTextBoxColumn.ReadOnly = true;
            this.desviacionSDataGridViewTextBoxColumn.Visible = false;
            // 
            // goterosDebajoPermisibleDataGridViewTextBoxColumn
            // 
            this.goterosDebajoPermisibleDataGridViewTextBoxColumn.DataPropertyName = "GoterosDebajoPermisible";
            this.goterosDebajoPermisibleDataGridViewTextBoxColumn.HeaderText = "GoterosDebajoPermisible";
            this.goterosDebajoPermisibleDataGridViewTextBoxColumn.Name = "goterosDebajoPermisibleDataGridViewTextBoxColumn";
            this.goterosDebajoPermisibleDataGridViewTextBoxColumn.ReadOnly = true;
            this.goterosDebajoPermisibleDataGridViewTextBoxColumn.Visible = false;
            // 
            // goterosPermisibleDataGridViewTextBoxColumn
            // 
            this.goterosPermisibleDataGridViewTextBoxColumn.DataPropertyName = "GoterosPermisible";
            this.goterosPermisibleDataGridViewTextBoxColumn.HeaderText = "GoterosPermisible";
            this.goterosPermisibleDataGridViewTextBoxColumn.Name = "goterosPermisibleDataGridViewTextBoxColumn";
            this.goterosPermisibleDataGridViewTextBoxColumn.ReadOnly = true;
            this.goterosPermisibleDataGridViewTextBoxColumn.Visible = false;
            // 
            // goterosSobrePermisibleDataGridViewTextBoxColumn
            // 
            this.goterosSobrePermisibleDataGridViewTextBoxColumn.DataPropertyName = "GoterosSobrePermisible";
            this.goterosSobrePermisibleDataGridViewTextBoxColumn.HeaderText = "GoterosSobrePermisible";
            this.goterosSobrePermisibleDataGridViewTextBoxColumn.Name = "goterosSobrePermisibleDataGridViewTextBoxColumn";
            this.goterosSobrePermisibleDataGridViewTextBoxColumn.ReadOnly = true;
            this.goterosSobrePermisibleDataGridViewTextBoxColumn.Visible = false;
            // 
            // areaAfectadaDataGridViewTextBoxColumn
            // 
            this.areaAfectadaDataGridViewTextBoxColumn.DataPropertyName = "AreaAfectada";
            this.areaAfectadaDataGridViewTextBoxColumn.HeaderText = "AreaAfectada";
            this.areaAfectadaDataGridViewTextBoxColumn.Name = "areaAfectadaDataGridViewTextBoxColumn";
            this.areaAfectadaDataGridViewTextBoxColumn.ReadOnly = true;
            this.areaAfectadaDataGridViewTextBoxColumn.Visible = false;
            // 
            // areaRegularDataGridViewTextBoxColumn
            // 
            this.areaRegularDataGridViewTextBoxColumn.DataPropertyName = "AreaRegular";
            this.areaRegularDataGridViewTextBoxColumn.HeaderText = "AreaRegular";
            this.areaRegularDataGridViewTextBoxColumn.Name = "areaRegularDataGridViewTextBoxColumn";
            this.areaRegularDataGridViewTextBoxColumn.ReadOnly = true;
            this.areaRegularDataGridViewTextBoxColumn.Visible = false;
            // 
            // areaBuenoDataGridViewTextBoxColumn
            // 
            this.areaBuenoDataGridViewTextBoxColumn.DataPropertyName = "AreaBueno";
            this.areaBuenoDataGridViewTextBoxColumn.HeaderText = "AreaBueno";
            this.areaBuenoDataGridViewTextBoxColumn.Name = "areaBuenoDataGridViewTextBoxColumn";
            this.areaBuenoDataGridViewTextBoxColumn.ReadOnly = true;
            this.areaBuenoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nroAfectadoDataGridViewTextBoxColumn
            // 
            this.nroAfectadoDataGridViewTextBoxColumn.DataPropertyName = "NroAfectado";
            this.nroAfectadoDataGridViewTextBoxColumn.HeaderText = "NroAfectado";
            this.nroAfectadoDataGridViewTextBoxColumn.Name = "nroAfectadoDataGridViewTextBoxColumn";
            this.nroAfectadoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nroAfectadoDataGridViewTextBoxColumn.Visible = false;
            // 
            // nroRegularDataGridViewTextBoxColumn
            // 
            this.nroRegularDataGridViewTextBoxColumn.DataPropertyName = "NroRegular";
            this.nroRegularDataGridViewTextBoxColumn.HeaderText = "NroRegular";
            this.nroRegularDataGridViewTextBoxColumn.Name = "nroRegularDataGridViewTextBoxColumn";
            this.nroRegularDataGridViewTextBoxColumn.ReadOnly = true;
            this.nroRegularDataGridViewTextBoxColumn.Visible = false;
            // 
            // nroBuenoDataGridViewTextBoxColumn
            // 
            this.nroBuenoDataGridViewTextBoxColumn.DataPropertyName = "NroBueno";
            this.nroBuenoDataGridViewTextBoxColumn.HeaderText = "NroBueno";
            this.nroBuenoDataGridViewTextBoxColumn.Name = "nroBuenoDataGridViewTextBoxColumn";
            this.nroBuenoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nroBuenoDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaCreacionDataGridViewTextBoxColumn
            // 
            this.fechaCreacionDataGridViewTextBoxColumn.DataPropertyName = "FechaCreacion";
            this.fechaCreacionDataGridViewTextBoxColumn.HeaderText = "FechaCreacion";
            this.fechaCreacionDataGridViewTextBoxColumn.Name = "fechaCreacionDataGridViewTextBoxColumn";
            this.fechaCreacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaCreacionDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaCierreDataGridViewTextBoxColumn
            // 
            this.fechaCierreDataGridViewTextBoxColumn.DataPropertyName = "FechaCierre";
            this.fechaCierreDataGridViewTextBoxColumn.HeaderText = "FechaCierre";
            this.fechaCierreDataGridViewTextBoxColumn.Name = "fechaCierreDataGridViewTextBoxColumn";
            this.fechaCierreDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaCierreDataGridViewTextBoxColumn.Visible = false;
            // 
            // totalGoterosDataGridViewTextBoxColumn
            // 
            this.totalGoterosDataGridViewTextBoxColumn.DataPropertyName = "TotalGoteros";
            this.totalGoterosDataGridViewTextBoxColumn.HeaderText = "TotalGoteros";
            this.totalGoterosDataGridViewTextBoxColumn.Name = "totalGoterosDataGridViewTextBoxColumn";
            this.totalGoterosDataGridViewTextBoxColumn.ReadOnly = true;
            this.totalGoterosDataGridViewTextBoxColumn.Visible = false;
            // 
            // areaEvaluadaDataGridViewTextBoxColumn
            // 
            this.areaEvaluadaDataGridViewTextBoxColumn.DataPropertyName = "AreaEvaluada";
            this.areaEvaluadaDataGridViewTextBoxColumn.HeaderText = "AreaEvaluada";
            this.areaEvaluadaDataGridViewTextBoxColumn.Name = "areaEvaluadaDataGridViewTextBoxColumn";
            this.areaEvaluadaDataGridViewTextBoxColumn.ReadOnly = true;
            this.areaEvaluadaDataGridViewTextBoxColumn.Visible = false;
            // 
            // porcentajeAreaAfectadaDataGridViewTextBoxColumn
            // 
            this.porcentajeAreaAfectadaDataGridViewTextBoxColumn.DataPropertyName = "PorcentajeAreaAfectada";
            this.porcentajeAreaAfectadaDataGridViewTextBoxColumn.HeaderText = "PorcentajeAreaAfectada";
            this.porcentajeAreaAfectadaDataGridViewTextBoxColumn.Name = "porcentajeAreaAfectadaDataGridViewTextBoxColumn";
            this.porcentajeAreaAfectadaDataGridViewTextBoxColumn.ReadOnly = true;
            this.porcentajeAreaAfectadaDataGridViewTextBoxColumn.Visible = false;
            // 
            // porcentajeAreaRegularDataGridViewTextBoxColumn
            // 
            this.porcentajeAreaRegularDataGridViewTextBoxColumn.DataPropertyName = "PorcentajeAreaRegular";
            this.porcentajeAreaRegularDataGridViewTextBoxColumn.HeaderText = "PorcentajeAreaRegular";
            this.porcentajeAreaRegularDataGridViewTextBoxColumn.Name = "porcentajeAreaRegularDataGridViewTextBoxColumn";
            this.porcentajeAreaRegularDataGridViewTextBoxColumn.ReadOnly = true;
            this.porcentajeAreaRegularDataGridViewTextBoxColumn.Visible = false;
            // 
            // porcentajeAreaBuenaDataGridViewTextBoxColumn
            // 
            this.porcentajeAreaBuenaDataGridViewTextBoxColumn.DataPropertyName = "PorcentajeAreaBuena";
            this.porcentajeAreaBuenaDataGridViewTextBoxColumn.HeaderText = "PorcentajeAreaBuena";
            this.porcentajeAreaBuenaDataGridViewTextBoxColumn.Name = "porcentajeAreaBuenaDataGridViewTextBoxColumn";
            this.porcentajeAreaBuenaDataGridViewTextBoxColumn.ReadOnly = true;
            this.porcentajeAreaBuenaDataGridViewTextBoxColumn.Visible = false;
            // 
            // bsEvaluacionGoteros
            // 
            this.bsEvaluacionGoteros.DataSource = typeof(WinEEGO.Models.EvaluacionGoteros);
            // 
            // chart01
            // 
            this.chart01.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chart01.BackColor = System.Drawing.SystemColors.Control;
            chartArea1.Name = "ChartArea1";
            this.chart01.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart01.Legends.Add(legend1);
            this.chart01.Location = new System.Drawing.Point(415, 80);
            this.chart01.Name = "chart01";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chart01.Series.Add(series1);
            this.chart01.Size = new System.Drawing.Size(373, 358);
            this.chart01.TabIndex = 15;
            this.chart01.Text = "chart1";
            this.chart01.GetToolTipText += new System.EventHandler<System.Windows.Forms.DataVisualization.Charting.ToolTipEventArgs>(this.chart01_GetToolTipText);
            // 
            // frmPorValvula
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.chart01);
            this.Controls.Add(this.dgDatos);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cbValvula);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.cbArea);
            this.Controls.Add(this.txtAnio);
            this.Controls.Add(this.label1);
            this.Name = "frmPorValvula";
            this.Text = "Reporte por lote";
            this.Load += new System.EventHandler(this.frmPorValvula_Load);
            this.Shown += new System.EventHandler(this.frmPorValvula_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.txtAnio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsEvaluacionGoteros)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart01)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NumericUpDown txtAnio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.ComboBox cbValvula;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.DataGridView dgDatos;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart01;
        private System.Windows.Forms.BindingSource bsEvaluacionGoteros;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hectareaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cultivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coeficienteUniformidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coeficienteVariacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coeficienteDesviacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroMuestrasDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numeroPresionesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreMangueraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emisionPermisibleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emisionSobrePermisibleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn caudalMedioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn caudalMedio25DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn desviacionSDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goterosDebajoPermisibleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goterosPermisibleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn goterosSobrePermisibleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaAfectadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaRegularDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaBuenoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroAfectadoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroRegularDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroBuenoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCierreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalGoterosDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaEvaluadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeAreaAfectadaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeAreaRegularDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn porcentajeAreaBuenaDataGridViewTextBoxColumn;
    }
}