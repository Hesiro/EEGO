
namespace WinAppTachito.Views.Firebase
{
    partial class FormRegistros
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistros));
            this.btnTraerDatos = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.keyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.areaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreAreaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaNumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.usuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDatos = new System.Windows.Forms.BindingSource(this.components);
            this.dgvDetalle = new System.Windows.Forms.DataGridView();
            this.keyDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPadreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valvulaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ordenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medida1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.medida2DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.comentarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsDetalle = new System.Windows.Forms.BindingSource(this.components);
            this.btnEliminar = new System.Windows.Forms.Button();
            this.btnTransferir = new System.Windows.Forms.Button();
            this.lbInfo = new System.Windows.Forms.Label();
            this.lbArea = new System.Windows.Forms.Label();
            this.lbFecha = new System.Windows.Forms.Label();
            this.btnExportar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).BeginInit();
            this.SuspendLayout();
            // 
            // btnTraerDatos
            // 
            this.btnTraerDatos.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnTraerDatos.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTraerDatos.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTraerDatos.Location = new System.Drawing.Point(12, 12);
            this.btnTraerDatos.Name = "btnTraerDatos";
            this.btnTraerDatos.Size = new System.Drawing.Size(120, 30);
            this.btnTraerDatos.TabIndex = 0;
            this.btnTraerDatos.Text = "LEER REGISTROS";
            this.btnTraerDatos.UseVisualStyleBackColor = false;
            this.btnTraerDatos.Click += new System.EventHandler(this.BtnTraerDatos_Click);
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
            this.keyDataGridViewTextBoxColumn,
            this.areaDataGridViewTextBoxColumn,
            this.nombreAreaDataGridViewTextBoxColumn,
            this.fechaDataGridViewTextBoxColumn,
            this.fechaNumDataGridViewTextBoxColumn,
            this.usuarioDataGridViewTextBoxColumn});
            this.dgvDatos.DataSource = this.bsDatos;
            this.dgvDatos.Location = new System.Drawing.Point(12, 48);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersWidth = 10;
            this.dgvDatos.Size = new System.Drawing.Size(289, 501);
            this.dgvDatos.TabIndex = 1;
            this.dgvDatos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvDatos_CellContentClick);
            this.dgvDatos.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvDatos_DataError);
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.DgvDatos_SelectionChanged);
            // 
            // keyDataGridViewTextBoxColumn
            // 
            this.keyDataGridViewTextBoxColumn.DataPropertyName = "Key";
            this.keyDataGridViewTextBoxColumn.HeaderText = "Key";
            this.keyDataGridViewTextBoxColumn.Name = "keyDataGridViewTextBoxColumn";
            this.keyDataGridViewTextBoxColumn.ReadOnly = true;
            this.keyDataGridViewTextBoxColumn.Visible = false;
            // 
            // areaDataGridViewTextBoxColumn
            // 
            this.areaDataGridViewTextBoxColumn.DataPropertyName = "Area";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.areaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.areaDataGridViewTextBoxColumn.HeaderText = "Area";
            this.areaDataGridViewTextBoxColumn.Name = "areaDataGridViewTextBoxColumn";
            this.areaDataGridViewTextBoxColumn.ReadOnly = true;
            this.areaDataGridViewTextBoxColumn.Width = 70;
            // 
            // nombreAreaDataGridViewTextBoxColumn
            // 
            this.nombreAreaDataGridViewTextBoxColumn.DataPropertyName = "NombreArea";
            this.nombreAreaDataGridViewTextBoxColumn.HeaderText = "NombreArea";
            this.nombreAreaDataGridViewTextBoxColumn.Name = "nombreAreaDataGridViewTextBoxColumn";
            this.nombreAreaDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreAreaDataGridViewTextBoxColumn.Visible = false;
            // 
            // fechaDataGridViewTextBoxColumn
            // 
            this.fechaDataGridViewTextBoxColumn.DataPropertyName = "Fecha";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Format = "d";
            dataGridViewCellStyle2.NullValue = null;
            this.fechaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle2;
            this.fechaDataGridViewTextBoxColumn.HeaderText = "Fecha";
            this.fechaDataGridViewTextBoxColumn.Name = "fechaDataGridViewTextBoxColumn";
            this.fechaDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaDataGridViewTextBoxColumn.Width = 80;
            // 
            // fechaNumDataGridViewTextBoxColumn
            // 
            this.fechaNumDataGridViewTextBoxColumn.DataPropertyName = "FechaNum";
            this.fechaNumDataGridViewTextBoxColumn.HeaderText = "FechaNum";
            this.fechaNumDataGridViewTextBoxColumn.Name = "fechaNumDataGridViewTextBoxColumn";
            this.fechaNumDataGridViewTextBoxColumn.ReadOnly = true;
            this.fechaNumDataGridViewTextBoxColumn.Visible = false;
            // 
            // usuarioDataGridViewTextBoxColumn
            // 
            this.usuarioDataGridViewTextBoxColumn.DataPropertyName = "Usuario";
            this.usuarioDataGridViewTextBoxColumn.HeaderText = "Usuario";
            this.usuarioDataGridViewTextBoxColumn.Name = "usuarioDataGridViewTextBoxColumn";
            this.usuarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bsDatos
            // 
            this.bsDatos.DataSource = typeof(WinAppTachito.Models.Firebase.KeyTachitoPadre);
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
            this.keyDataGridViewTextBoxColumn1,
            this.idPadreDataGridViewTextBoxColumn,
            this.valvulaDataGridViewTextBoxColumn,
            this.ordenDataGridViewTextBoxColumn,
            this.medida1DataGridViewTextBoxColumn,
            this.medida2DataGridViewTextBoxColumn,
            this.totalDataGridViewTextBoxColumn,
            this.comentarioDataGridViewTextBoxColumn});
            this.dgvDetalle.DataSource = this.bsDetalle;
            this.dgvDetalle.Location = new System.Drawing.Point(310, 84);
            this.dgvDetalle.Name = "dgvDetalle";
            this.dgvDetalle.ReadOnly = true;
            this.dgvDetalle.RowHeadersWidth = 10;
            this.dgvDetalle.Size = new System.Drawing.Size(562, 452);
            this.dgvDetalle.TabIndex = 2;
            // 
            // keyDataGridViewTextBoxColumn1
            // 
            this.keyDataGridViewTextBoxColumn1.DataPropertyName = "Key";
            this.keyDataGridViewTextBoxColumn1.HeaderText = "Key";
            this.keyDataGridViewTextBoxColumn1.Name = "keyDataGridViewTextBoxColumn1";
            this.keyDataGridViewTextBoxColumn1.ReadOnly = true;
            this.keyDataGridViewTextBoxColumn1.Visible = false;
            // 
            // idPadreDataGridViewTextBoxColumn
            // 
            this.idPadreDataGridViewTextBoxColumn.DataPropertyName = "IdPadre";
            this.idPadreDataGridViewTextBoxColumn.HeaderText = "IdPadre";
            this.idPadreDataGridViewTextBoxColumn.Name = "idPadreDataGridViewTextBoxColumn";
            this.idPadreDataGridViewTextBoxColumn.ReadOnly = true;
            this.idPadreDataGridViewTextBoxColumn.Visible = false;
            // 
            // valvulaDataGridViewTextBoxColumn
            // 
            this.valvulaDataGridViewTextBoxColumn.DataPropertyName = "Valvula";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.valvulaDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle3;
            this.valvulaDataGridViewTextBoxColumn.HeaderText = "Valvula";
            this.valvulaDataGridViewTextBoxColumn.Name = "valvulaDataGridViewTextBoxColumn";
            this.valvulaDataGridViewTextBoxColumn.ReadOnly = true;
            this.valvulaDataGridViewTextBoxColumn.Width = 80;
            // 
            // ordenDataGridViewTextBoxColumn
            // 
            this.ordenDataGridViewTextBoxColumn.DataPropertyName = "Orden";
            this.ordenDataGridViewTextBoxColumn.HeaderText = "Orden";
            this.ordenDataGridViewTextBoxColumn.Name = "ordenDataGridViewTextBoxColumn";
            this.ordenDataGridViewTextBoxColumn.ReadOnly = true;
            this.ordenDataGridViewTextBoxColumn.Visible = false;
            // 
            // medida1DataGridViewTextBoxColumn
            // 
            this.medida1DataGridViewTextBoxColumn.DataPropertyName = "Medida1";
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle4.Format = "N2";
            this.medida1DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle4;
            this.medida1DataGridViewTextBoxColumn.HeaderText = "1ra medición (ml)";
            this.medida1DataGridViewTextBoxColumn.Name = "medida1DataGridViewTextBoxColumn";
            this.medida1DataGridViewTextBoxColumn.ReadOnly = true;
            this.medida1DataGridViewTextBoxColumn.Width = 80;
            // 
            // medida2DataGridViewTextBoxColumn
            // 
            this.medida2DataGridViewTextBoxColumn.DataPropertyName = "Medida2";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle5.Format = "N2";
            this.medida2DataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle5;
            this.medida2DataGridViewTextBoxColumn.HeaderText = "2da medición (ml)";
            this.medida2DataGridViewTextBoxColumn.Name = "medida2DataGridViewTextBoxColumn";
            this.medida2DataGridViewTextBoxColumn.ReadOnly = true;
            this.medida2DataGridViewTextBoxColumn.Width = 80;
            // 
            // totalDataGridViewTextBoxColumn
            // 
            this.totalDataGridViewTextBoxColumn.DataPropertyName = "Total";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle6.Format = "N2";
            this.totalDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle6;
            this.totalDataGridViewTextBoxColumn.HeaderText = "Total (ml)";
            this.totalDataGridViewTextBoxColumn.Name = "totalDataGridViewTextBoxColumn";
            this.totalDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // comentarioDataGridViewTextBoxColumn
            // 
            this.comentarioDataGridViewTextBoxColumn.DataPropertyName = "Comentario";
            this.comentarioDataGridViewTextBoxColumn.HeaderText = "Comentario";
            this.comentarioDataGridViewTextBoxColumn.Name = "comentarioDataGridViewTextBoxColumn";
            this.comentarioDataGridViewTextBoxColumn.ReadOnly = true;
            this.comentarioDataGridViewTextBoxColumn.Width = 300;
            // 
            // bsDetalle
            // 
            this.bsDetalle.DataSource = typeof(WinAppTachito.Models.Firebase.KeyTachitoDetalle);
            // 
            // btnEliminar
            // 
            this.btnEliminar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnEliminar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEliminar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnEliminar.Location = new System.Drawing.Point(782, 48);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(90, 30);
            this.btnEliminar.TabIndex = 3;
            this.btnEliminar.Text = "ELIMINAR";
            this.btnEliminar.UseVisualStyleBackColor = false;
            this.btnEliminar.Click += new System.EventHandler(this.BtnEliminar_Click);
            // 
            // btnTransferir
            // 
            this.btnTransferir.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnTransferir.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTransferir.ForeColor = System.Drawing.SystemColors.Control;
            this.btnTransferir.Location = new System.Drawing.Point(686, 48);
            this.btnTransferir.Name = "btnTransferir";
            this.btnTransferir.Size = new System.Drawing.Size(90, 30);
            this.btnTransferir.TabIndex = 4;
            this.btnTransferir.Text = "TRANSFERIR";
            this.btnTransferir.UseVisualStyleBackColor = false;
            this.btnTransferir.Click += new System.EventHandler(this.BtnTransferir_Click);
            // 
            // lbInfo
            // 
            this.lbInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lbInfo.AutoSize = true;
            this.lbInfo.Location = new System.Drawing.Point(307, 539);
            this.lbInfo.Name = "lbInfo";
            this.lbInfo.Size = new System.Drawing.Size(0, 13);
            this.lbInfo.TabIndex = 5;
            // 
            // lbArea
            // 
            this.lbArea.AutoSize = true;
            this.lbArea.Location = new System.Drawing.Point(307, 48);
            this.lbArea.Name = "lbArea";
            this.lbArea.Size = new System.Drawing.Size(11, 13);
            this.lbArea.TabIndex = 6;
            this.lbArea.Text = "*";
            // 
            // lbFecha
            // 
            this.lbFecha.AutoSize = true;
            this.lbFecha.Location = new System.Drawing.Point(307, 65);
            this.lbFecha.Name = "lbFecha";
            this.lbFecha.Size = new System.Drawing.Size(11, 13);
            this.lbFecha.TabIndex = 7;
            this.lbFecha.Text = "*";
            // 
            // btnExportar
            // 
            this.btnExportar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnExportar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnExportar.Location = new System.Drawing.Point(590, 48);
            this.btnExportar.Name = "btnExportar";
            this.btnExportar.Size = new System.Drawing.Size(90, 30);
            this.btnExportar.TabIndex = 19;
            this.btnExportar.Text = "A EXCEL";
            this.btnExportar.UseVisualStyleBackColor = false;
            this.btnExportar.Click += new System.EventHandler(this.btnExportar_Click);
            // 
            // FormRegistros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(884, 561);
            this.Controls.Add(this.btnExportar);
            this.Controls.Add(this.lbFecha);
            this.Controls.Add(this.lbArea);
            this.Controls.Add(this.lbInfo);
            this.Controls.Add(this.btnTransferir);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.dgvDetalle);
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnTraerDatos);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormRegistros";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Registros Tachitos Firebase v1.1";
            this.Load += new System.EventHandler(this.FormRegistros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDetalle)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDetalle)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnTraerDatos;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.BindingSource bsDatos;
        private System.Windows.Forms.DataGridView dgvDetalle;
        private System.Windows.Forms.BindingSource bsDetalle;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.Button btnTransferir;
        private System.Windows.Forms.Label lbInfo;
        private System.Windows.Forms.Label lbArea;
        private System.Windows.Forms.Label lbFecha;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPadreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valvulaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ordenDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn medida1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn medida2DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn comentarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn keyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn areaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreAreaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn usuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnExportar;
    }
}