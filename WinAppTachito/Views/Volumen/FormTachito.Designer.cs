
namespace WinAppTachito.Views.Volumen
{
    partial class FormTachito
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormTachito));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.btnActualizar = new System.Windows.Forms.Button();
            this.btnNuevo = new System.Windows.Forms.Button();
            this.listaImg = new System.Windows.Forms.ImageList(this.components);
            this.btnDetalle = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnEstado = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.btnRecargar = new System.Windows.Forms.Button();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.btnExportar = new System.Windows.Forms.Button();
            this.btnFiltrar = new System.Windows.Forms.Button();
            this.panFiltro = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbEstado = new System.Windows.Forms.ComboBox();
            this.cbArea = new System.Windows.Forms.ComboBox();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.bsDatos = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hectareaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cultivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tipoEvaluacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreMangueraDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distanciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroDeficitDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroOptimoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nroExcesoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            this.panFiltro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(129, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mostrar Evaluaciones";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 38);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(110, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha de evaluación:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.CustomFormat = "";
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(128, 35);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(120, 20);
            this.dtpDesde.TabIndex = 3;
            // 
            // btnActualizar
            // 
            this.btnActualizar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnActualizar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnActualizar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnActualizar.Location = new System.Drawing.Point(282, 32);
            this.btnActualizar.Name = "btnActualizar";
            this.btnActualizar.Size = new System.Drawing.Size(90, 30);
            this.btnActualizar.TabIndex = 13;
            this.btnActualizar.Text = "MOSTRAR";
            this.btnActualizar.UseVisualStyleBackColor = false;
            this.btnActualizar.Click += new System.EventHandler(this.BtnActualizar_Click);
            // 
            // btnNuevo
            // 
            this.btnNuevo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnNuevo.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNuevo.ForeColor = System.Drawing.SystemColors.Control;
            this.btnNuevo.ImageIndex = 0;
            this.btnNuevo.ImageList = this.listaImg;
            this.btnNuevo.Location = new System.Drawing.Point(477, 93);
            this.btnNuevo.Name = "btnNuevo";
            this.btnNuevo.Size = new System.Drawing.Size(60, 30);
            this.btnNuevo.TabIndex = 14;
            this.toolTip.SetToolTip(this.btnNuevo, "Nuevo");
            this.btnNuevo.UseVisualStyleBackColor = false;
            this.btnNuevo.Click += new System.EventHandler(this.BtnNuevo_Click);
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
            // btnDetalle
            // 
            this.btnDetalle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnDetalle.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDetalle.ForeColor = System.Drawing.SystemColors.Control;
            this.btnDetalle.ImageIndex = 2;
            this.btnDetalle.ImageList = this.listaImg;
            this.btnDetalle.Location = new System.Drawing.Point(213, 93);
            this.btnDetalle.Name = "btnDetalle";
            this.btnDetalle.Size = new System.Drawing.Size(60, 30);
            this.btnDetalle.TabIndex = 15;
            this.toolTip.SetToolTip(this.btnDetalle, "Ver detalle");
            this.btnDetalle.UseVisualStyleBackColor = false;
            this.btnDetalle.Click += new System.EventHandler(this.BtnDetalle_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.ImageIndex = 7;
            this.btnEliminar.ImageList = this.listaImg;
            this.btnEliminar.Location = new System.Drawing.Point(609, 93);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(60, 30);
            this.btnEliminar.TabIndex = 16;
            this.toolTip.SetToolTip(this.btnEliminar, "Eliminar");
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // btnEstado
            // 
            this.btnEstado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnEstado.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEstado.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEstado.ImageIndex = 6;
            this.btnEstado.ImageList = this.listaImg;
            this.btnEstado.Location = new System.Drawing.Point(543, 93);
            this.btnEstado.Name = "btnEstado";
            this.btnEstado.Size = new System.Drawing.Size(60, 30);
            this.btnEstado.TabIndex = 17;
            this.toolTip.SetToolTip(this.btnEstado, "Editar");
            this.btnEstado.UseVisualStyleBackColor = false;
            this.btnEstado.Click += new System.EventHandler(this.BtnEstado_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDatos.AutoGenerateColumns = false;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.loteDataGridViewTextBoxColumn,
            this.hectareaDataGridViewTextBoxColumn,
            this.cultivoDataGridViewTextBoxColumn,
            this.emisionDataGridViewTextBoxColumn,
            this.tipoEvaluacionDataGridViewTextBoxColumn,
            this.nombreMangueraDataGridViewTextBoxColumn,
            this.distanciaDataGridViewTextBoxColumn,
            this.nroDeficitDataGridViewTextBoxColumn,
            this.nroOptimoDataGridViewTextBoxColumn,
            this.nroExcesoDataGridViewTextBoxColumn,
            this.statusDataGridViewTextBoxColumn,
            this.usuarioDataGridViewTextBoxColumn});
            this.dgvDatos.DataSource = this.bsDatos;
            this.dgvDatos.Location = new System.Drawing.Point(12, 129);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersWidth = 20;
            this.dgvDatos.Size = new System.Drawing.Size(860, 420);
            this.dgvDatos.TabIndex = 18;
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.DgvDatos_SelectionChanged);
            this.dgvDatos.DoubleClick += new System.EventHandler(this.DgvDatos_DoubleClick);
            // 
            // btnRecargar
            // 
            this.btnRecargar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnRecargar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRecargar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnRecargar.ImageIndex = 1;
            this.btnRecargar.ImageList = this.listaImg;
            this.btnRecargar.Location = new System.Drawing.Point(15, 93);
            this.btnRecargar.Name = "btnRecargar";
            this.btnRecargar.Size = new System.Drawing.Size(60, 30);
            this.btnRecargar.TabIndex = 19;
            this.toolTip.SetToolTip(this.btnRecargar, "Actualizar");
            this.btnRecargar.UseVisualStyleBackColor = false;
            this.btnRecargar.Click += new System.EventHandler(this.btnRecargar_Click);
            // 
            // btnImprimir
            // 
            this.btnImprimir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnImprimir.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImprimir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnImprimir.ImageIndex = 3;
            this.btnImprimir.ImageList = this.listaImg;
            this.btnImprimir.Location = new System.Drawing.Point(279, 93);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(60, 30);
            this.btnImprimir.TabIndex = 21;
            this.toolTip.SetToolTip(this.btnImprimir, "Imprimir");
            this.btnImprimir.UseVisualStyleBackColor = false;
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExportar.ImageIndex = 4;
            this.btnExportar.ImageList = this.listaImg;
            this.btnExportar.Location = new System.Drawing.Point(345, 93);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(60, 30);
            this.btnExportar.TabIndex = 22;
            this.toolTip.SetToolTip(this.btnExportar, "Exportar");
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
            this.btnFiltrar.Location = new System.Drawing.Point(81, 93);
            this.btnFiltrar.Name = "btnFiltrar";
            this.btnFiltrar.Size = new System.Drawing.Size(60, 30);
            this.btnFiltrar.TabIndex = 23;
            this.toolTip.SetToolTip(this.btnFiltrar, "Filtrar");
            this.btnFiltrar.UseVisualStyleBackColor = false;
            this.btnFiltrar.Click += new System.EventHandler(this.btnFiltrar_Click);
            // 
            // panFiltro
            // 
            this.panFiltro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panFiltro.Controls.Add(this.label4);
            this.panFiltro.Controls.Add(this.label3);
            this.panFiltro.Controls.Add(this.cbEstado);
            this.panFiltro.Controls.Add(this.cbArea);
            this.panFiltro.Location = new System.Drawing.Point(16, 133);
            this.panFiltro.Name = "panFiltro";
            this.panFiltro.Size = new System.Drawing.Size(200, 83);
            this.panFiltro.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Estado:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(32, 13);
            this.label3.TabIndex = 25;
            this.label3.Text = "Area:";
            // 
            // cbEstado
            // 
            this.cbEstado.FormattingEnabled = true;
            this.cbEstado.Items.AddRange(new object[] {
            "Todos",
            "En creacion",
            "Terminado"});
            this.cbEstado.Location = new System.Drawing.Point(67, 39);
            this.cbEstado.Name = "cbEstado";
            this.cbEstado.Size = new System.Drawing.Size(121, 21);
            this.cbEstado.TabIndex = 26;
            this.cbEstado.SelectedIndexChanged += new System.EventHandler(this.cbEstado_SelectedIndexChanged);
            // 
            // cbArea
            // 
            this.cbArea.FormattingEnabled = true;
            this.cbArea.Items.AddRange(new object[] {
            "Todos"});
            this.cbArea.Location = new System.Drawing.Point(67, 12);
            this.cbArea.Name = "cbArea";
            this.cbArea.Size = new System.Drawing.Size(121, 21);
            this.cbArea.TabIndex = 25;
            this.cbArea.SelectedIndexChanged += new System.EventHandler(this.cbArea_SelectedIndexChanged);
            // 
            // bsDatos
            // 
            this.bsDatos.DataSource = typeof(WinAppTachito.Models.EvaluacionVolumen);
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
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha de Evaluación";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 90;
            // 
            // loteDataGridViewTextBoxColumn
            // 
            this.loteDataGridViewTextBoxColumn.DataPropertyName = "Lote";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.loteDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.loteDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.loteDataGridViewTextBoxColumn.Name = "loteDataGridViewTextBoxColumn";
            this.loteDataGridViewTextBoxColumn.ReadOnly = true;
            this.loteDataGridViewTextBoxColumn.Width = 80;
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
            this.cultivoDataGridViewTextBoxColumn.Width = 70;
            // 
            // emisionDataGridViewTextBoxColumn
            // 
            this.emisionDataGridViewTextBoxColumn.DataPropertyName = "Emision";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.Format = "N2";
            this.emisionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.emisionDataGridViewTextBoxColumn.HeaderText = "Emision";
            this.emisionDataGridViewTextBoxColumn.Name = "emisionDataGridViewTextBoxColumn";
            this.emisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.emisionDataGridViewTextBoxColumn.Width = 70;
            // 
            // tipoEvaluacionDataGridViewTextBoxColumn
            // 
            this.tipoEvaluacionDataGridViewTextBoxColumn.DataPropertyName = "TipoEvaluacion";
            this.tipoEvaluacionDataGridViewTextBoxColumn.HeaderText = "Tipo de Evaluación";
            this.tipoEvaluacionDataGridViewTextBoxColumn.Name = "tipoEvaluacionDataGridViewTextBoxColumn";
            this.tipoEvaluacionDataGridViewTextBoxColumn.ReadOnly = true;
            this.tipoEvaluacionDataGridViewTextBoxColumn.Width = 130;
            // 
            // nombreMangueraDataGridViewTextBoxColumn
            // 
            this.nombreMangueraDataGridViewTextBoxColumn.DataPropertyName = "NombreManguera";
            this.nombreMangueraDataGridViewTextBoxColumn.HeaderText = "NombreManguera";
            this.nombreMangueraDataGridViewTextBoxColumn.Name = "nombreMangueraDataGridViewTextBoxColumn";
            this.nombreMangueraDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreMangueraDataGridViewTextBoxColumn.Visible = false;
            // 
            // distanciaDataGridViewTextBoxColumn
            // 
            this.distanciaDataGridViewTextBoxColumn.DataPropertyName = "Distancia";
            this.distanciaDataGridViewTextBoxColumn.HeaderText = "Distancia";
            this.distanciaDataGridViewTextBoxColumn.Name = "distanciaDataGridViewTextBoxColumn";
            this.distanciaDataGridViewTextBoxColumn.ReadOnly = true;
            this.distanciaDataGridViewTextBoxColumn.Visible = false;
            // 
            // nroDeficitDataGridViewTextBoxColumn
            // 
            this.nroDeficitDataGridViewTextBoxColumn.DataPropertyName = "NroDeficit";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N0";
            this.nroDeficitDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.nroDeficitDataGridViewTextBoxColumn.HeaderText = "Déficit";
            this.nroDeficitDataGridViewTextBoxColumn.Name = "nroDeficitDataGridViewTextBoxColumn";
            this.nroDeficitDataGridViewTextBoxColumn.ReadOnly = true;
            this.nroDeficitDataGridViewTextBoxColumn.Width = 80;
            // 
            // nroOptimoDataGridViewTextBoxColumn
            // 
            this.nroOptimoDataGridViewTextBoxColumn.DataPropertyName = "NroOptimo";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N0";
            this.nroOptimoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.nroOptimoDataGridViewTextBoxColumn.HeaderText = "Optimo";
            this.nroOptimoDataGridViewTextBoxColumn.Name = "nroOptimoDataGridViewTextBoxColumn";
            this.nroOptimoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nroOptimoDataGridViewTextBoxColumn.Width = 80;
            // 
            // nroExcesoDataGridViewTextBoxColumn
            // 
            this.nroExcesoDataGridViewTextBoxColumn.DataPropertyName = "NroExceso";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N0";
            this.nroExcesoDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.nroExcesoDataGridViewTextBoxColumn.HeaderText = "Exceso";
            this.nroExcesoDataGridViewTextBoxColumn.Name = "nroExcesoDataGridViewTextBoxColumn";
            this.nroExcesoDataGridViewTextBoxColumn.ReadOnly = true;
            this.nroExcesoDataGridViewTextBoxColumn.Width = 80;
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.statusDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle7;
            this.statusDataGridViewTextBoxColumn.HeaderText = "Estado";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioDataGridViewTextBoxColumn
            // 
            this.usuarioDataGridViewTextBoxColumn.DataPropertyName = "Usuario";
            this.usuarioDataGridViewTextBoxColumn.HeaderText = "Usuario";
            this.usuarioDataGridViewTextBoxColumn.Name = "usuarioDataGridViewTextBoxColumn";
            this.usuarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioDataGridViewTextBoxColumn.Visible = false;
            // 
            // FormTachito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.panFiltro);
            this.Controls.Add(this.btnFiltrar);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnRecargar);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnEstado);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnDetalle);
            this.Controls.Add(this.btnNuevo);
            this.Controls.Add(this.btnActualizar);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormTachito";
            this.Text = "Tachitos";
            this.Load += new System.EventHandler(this.FormTachito_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            this.panFiltro.ResumeLayout(false);
            this.panFiltro.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bsDatos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Button btnActualizar;
        private System.Windows.Forms.Button btnNuevo;
        private System.Windows.Forms.Button btnDetalle;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnEstado;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.BindingSource bsDatos;
        private System.Windows.Forms.ImageList listaImg;
        private System.Windows.Forms.Button btnRecargar;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.Button btnExportar;
        private System.Windows.Forms.Button btnFiltrar;
        private System.Windows.Forms.Panel panFiltro;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbEstado;
        private System.Windows.Forms.ComboBox cbArea;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loteDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hectareaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cultivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tipoEvaluacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreMangueraDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distanciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroDeficitDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroOptimoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nroExcesoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioDataGridViewTextBoxColumn;
    }
}