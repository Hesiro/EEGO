namespace WinEEGO.Views.Report
{
    partial class frmCuCvCd
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
            this.cbCultivo = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpHasta = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDesde = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.nupCD = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.nupCV = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.nupCU = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.dgDatos = new System.Windows.Forms.DataGridView();
            this.bsDetalleEvaluacion = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hectareaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cultivoDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coeficienteUniformidadDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coeficienteVariacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.coeficienteDesviacionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.nupCD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCU)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalleEvaluacion)).BeginInit();
            this.SuspendLayout();
            // 
            // cbCultivo
            // 
            this.cbCultivo.FormattingEnabled = true;
            this.cbCultivo.Location = new System.Drawing.Point(422, 11);
            this.cbCultivo.Name = "cbCultivo";
            this.cbCultivo.Size = new System.Drawing.Size(121, 21);
            this.cbCultivo.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(374, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Cultivo:";
            // 
            // dtpHasta
            // 
            this.dtpHasta.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpHasta.Location = new System.Drawing.Point(238, 12);
            this.dtpHasta.Name = "dtpHasta";
            this.dtpHasta.Size = new System.Drawing.Size(90, 20);
            this.dtpHasta.TabIndex = 13;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(194, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 13);
            this.label2.TabIndex = 12;
            this.label2.Text = "Hasta:";
            // 
            // dtpDesde
            // 
            this.dtpDesde.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDesde.Location = new System.Drawing.Point(68, 12);
            this.dtpDesde.Name = "dtpDesde";
            this.dtpDesde.Size = new System.Drawing.Size(90, 20);
            this.dtpDesde.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Desde:";
            // 
            // nupCD
            // 
            this.nupCD.Location = new System.Drawing.Point(422, 53);
            this.nupCD.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nupCD.Name = "nupCD";
            this.nupCD.Size = new System.Drawing.Size(80, 20);
            this.nupCD.TabIndex = 27;
            this.nupCD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nupCD.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(372, 55);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 13);
            this.label5.TabIndex = 26;
            this.label5.Text = "| CD | > ";
            // 
            // nupCV
            // 
            this.nupCV.Location = new System.Drawing.Point(238, 55);
            this.nupCV.Minimum = new decimal(new int[] {
            7,
            0,
            0,
            0});
            this.nupCV.Name = "nupCV";
            this.nupCV.Size = new System.Drawing.Size(80, 20);
            this.nupCV.TabIndex = 25;
            this.nupCV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nupCV.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(199, 55);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(33, 13);
            this.label4.TabIndex = 24;
            this.label4.Text = "CV > ";
            // 
            // nupCU
            // 
            this.nupCU.Increment = new decimal(new int[] {
            5,
            0,
            0,
            0});
            this.nupCU.Location = new System.Drawing.Point(68, 53);
            this.nupCU.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.nupCU.Minimum = new decimal(new int[] {
            70,
            0,
            0,
            0});
            this.nupCU.Name = "nupCU";
            this.nupCU.Size = new System.Drawing.Size(80, 20);
            this.nupCU.TabIndex = 23;
            this.nupCU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nupCU.Value = new decimal(new int[] {
            70,
            0,
            0,
            0});
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(28, 55);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "CU < ";
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(607, 52);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(75, 23);
            this.btnMostrar.TabIndex = 28;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click);
            // 
            // dgDatos
            // 
            this.dgDatos.AllowUserToAddRows = false;
            this.dgDatos.AllowUserToDeleteRows = false;
            this.dgDatos.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgDatos.AutoGenerateColumns = false;
            this.dgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.areaDataGridViewTextBoxColumn,
            this.hectareaDataGridViewTextBoxColumn,
            this.cultivoDataGridViewTextBoxColumn,
            this.usuarioDataGridViewTextBoxColumn,
            this.coeficienteUniformidadDataGridViewTextBoxColumn,
            this.coeficienteVariacionDataGridViewTextBoxColumn,
            this.coeficienteDesviacionDataGridViewTextBoxColumn});
            this.dgDatos.DataSource = this.bsDetalleEvaluacion;
            this.dgDatos.Location = new System.Drawing.Point(12, 98);
            this.dgDatos.Name = "dgDatos";
            this.dgDatos.ReadOnly = true;
            this.dgDatos.RowHeadersWidth = 20;
            this.dgDatos.Size = new System.Drawing.Size(776, 340);
            this.dgDatos.TabIndex = 29;
            // 
            // bsDetalleEvaluacion
            // 
            this.bsDetalleEvaluacion.DataSource = typeof(WinEEGO.Models.EvaluacionGoteros);
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
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // areaDataGridViewTextBoxColumn
            // 
            this.areaDataGridViewTextBoxColumn.DataPropertyName = "Area";
            this.areaDataGridViewTextBoxColumn.HeaderText = "Filtro";
            this.areaDataGridViewTextBoxColumn.Name = "areaDataGridViewTextBoxColumn";
            this.areaDataGridViewTextBoxColumn.ReadOnly = true;
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
            this.cultivoDataGridViewTextBoxColumn.HeaderText = "Lote";
            this.cultivoDataGridViewTextBoxColumn.Name = "cultivoDataGridViewTextBoxColumn";
            this.cultivoDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // usuarioDataGridViewTextBoxColumn
            // 
            this.usuarioDataGridViewTextBoxColumn.DataPropertyName = "Usuario";
            this.usuarioDataGridViewTextBoxColumn.HeaderText = "Usuario";
            this.usuarioDataGridViewTextBoxColumn.Name = "usuarioDataGridViewTextBoxColumn";
            this.usuarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.usuarioDataGridViewTextBoxColumn.Visible = false;
            // 
            // coeficienteUniformidadDataGridViewTextBoxColumn
            // 
            this.coeficienteUniformidadDataGridViewTextBoxColumn.DataPropertyName = "CoeficienteUniformidad";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "n2";
            this.coeficienteUniformidadDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.coeficienteUniformidadDataGridViewTextBoxColumn.HeaderText = "CU%";
            this.coeficienteUniformidadDataGridViewTextBoxColumn.Name = "coeficienteUniformidadDataGridViewTextBoxColumn";
            this.coeficienteUniformidadDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // coeficienteVariacionDataGridViewTextBoxColumn
            // 
            this.coeficienteVariacionDataGridViewTextBoxColumn.DataPropertyName = "CoeficienteVariacion";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.Format = "n2";
            this.coeficienteVariacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.coeficienteVariacionDataGridViewTextBoxColumn.HeaderText = "CV%";
            this.coeficienteVariacionDataGridViewTextBoxColumn.Name = "coeficienteVariacionDataGridViewTextBoxColumn";
            this.coeficienteVariacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // coeficienteDesviacionDataGridViewTextBoxColumn
            // 
            this.coeficienteDesviacionDataGridViewTextBoxColumn.DataPropertyName = "CoeficienteDesviacion";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle4.Format = "n2";
            this.coeficienteDesviacionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.coeficienteDesviacionDataGridViewTextBoxColumn.HeaderText = "CD%";
            this.coeficienteDesviacionDataGridViewTextBoxColumn.Name = "coeficienteDesviacionDataGridViewTextBoxColumn";
            this.coeficienteDesviacionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // frmCuCvCd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgDatos);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.nupCD);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.nupCV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.nupCU);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.cbCultivo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpHasta);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtpDesde);
            this.Controls.Add(this.label1);
            this.Name = "frmCuCvCd";
            this.Text = "Cu Cv Cd";
            this.Load += new System.EventHandler(this.frmCuCvCd_Load);
            ((System.ComponentModel.ISupportInitialize)(this.nupCD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nupCU)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalleEvaluacion)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cbCultivo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpHasta;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDesde;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nupCD;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown nupCV;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown nupCU;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.DataGridView dgDatos;
        private System.Windows.Forms.BindingSource bsDetalleEvaluacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn hectareaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn cultivoDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coeficienteUniformidadDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coeficienteVariacionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn coeficienteDesviacionDataGridViewTextBoxColumn;
    }
}