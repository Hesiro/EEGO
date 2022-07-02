
namespace WinAppTachito.Views.Volumen
{
    partial class FormSelectEmisor
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormSelectEmisor));
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.dgvDatos = new System.Windows.Forms.DataGridView();
            this.bsDatos = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.distanciaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emisionPermisibleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.emisionSobrePermisibleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDatos)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAceptar
            // 
            this.btnAceptar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnAceptar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAceptar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnAceptar.Location = new System.Drawing.Point(336, 269);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(90, 30);
            this.btnAceptar.TabIndex = 16;
            this.btnAceptar.Text = "ACEPTAR";
            this.btnAceptar.UseVisualStyleBackColor = false;
            this.btnAceptar.Click += new System.EventHandler(this.BtnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(118)))), ((int)(((byte)(210)))));
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancelar.ForeColor = System.Drawing.SystemColors.Control;
            this.btnCancelar.Location = new System.Drawing.Point(432, 269);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(90, 30);
            this.btnCancelar.TabIndex = 17;
            this.btnCancelar.Text = "CANCELAR";
            this.btnCancelar.UseVisualStyleBackColor = false;
            this.btnCancelar.Click += new System.EventHandler(this.BtnCancelar_Click);
            // 
            // dgvDatos
            // 
            this.dgvDatos.AllowUserToAddRows = false;
            this.dgvDatos.AllowUserToDeleteRows = false;
            this.dgvDatos.AutoGenerateColumns = false;
            this.dgvDatos.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgvDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.emisionDataGridViewTextBoxColumn,
            this.nombreDataGridViewTextBoxColumn,
            this.distanciaDataGridViewTextBoxColumn,
            this.emisionPermisibleDataGridViewTextBoxColumn,
            this.emisionSobrePermisibleDataGridViewTextBoxColumn});
            this.dgvDatos.DataSource = this.bsDatos;
            this.dgvDatos.Location = new System.Drawing.Point(12, 12);
            this.dgvDatos.Name = "dgvDatos";
            this.dgvDatos.ReadOnly = true;
            this.dgvDatos.RowHeadersWidth = 20;
            this.dgvDatos.Size = new System.Drawing.Size(510, 251);
            this.dgvDatos.TabIndex = 18;
            this.dgvDatos.SelectionChanged += new System.EventHandler(this.DgvDatos_SelectionChanged);
            // 
            // bsDatos
            // 
            this.bsDatos.DataSource = typeof(WinAppTachito.Models.TipoManguera);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "Id";
            this.idDataGridViewTextBoxColumn.HeaderText = "Id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // emisionDataGridViewTextBoxColumn
            // 
            this.emisionDataGridViewTextBoxColumn.DataPropertyName = "Emision";
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle1.Format = "N2";
            this.emisionDataGridViewTextBoxColumn.DefaultCellStyle = dataGridViewCellStyle1;
            this.emisionDataGridViewTextBoxColumn.HeaderText = "Emisión (l/h)";
            this.emisionDataGridViewTextBoxColumn.Name = "emisionDataGridViewTextBoxColumn";
            this.emisionDataGridViewTextBoxColumn.ReadOnly = true;
            this.emisionDataGridViewTextBoxColumn.Width = 95;
            // 
            // nombreDataGridViewTextBoxColumn
            // 
            this.nombreDataGridViewTextBoxColumn.DataPropertyName = "Nombre";
            this.nombreDataGridViewTextBoxColumn.HeaderText = "Nombre";
            this.nombreDataGridViewTextBoxColumn.Name = "nombreDataGridViewTextBoxColumn";
            this.nombreDataGridViewTextBoxColumn.ReadOnly = true;
            this.nombreDataGridViewTextBoxColumn.Width = 300;
            // 
            // distanciaDataGridViewTextBoxColumn
            // 
            this.distanciaDataGridViewTextBoxColumn.DataPropertyName = "Distancia";
            this.distanciaDataGridViewTextBoxColumn.HeaderText = "Distancia";
            this.distanciaDataGridViewTextBoxColumn.Name = "distanciaDataGridViewTextBoxColumn";
            this.distanciaDataGridViewTextBoxColumn.ReadOnly = true;
            this.distanciaDataGridViewTextBoxColumn.Visible = false;
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
            // FormSelectEmisor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(534, 311);
            this.ControlBox = false;
            this.Controls.Add(this.dgvDatos);
            this.Controls.Add(this.btnAceptar);
            this.Controls.Add(this.btnCancelar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormSelectEmisor";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Seleccionar emisor";
            this.Load += new System.EventHandler(this.FormSelectEmisor_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsDatos)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.DataGridView dgvDatos;
        private System.Windows.Forms.BindingSource bsDatos;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emisionDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn distanciaDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emisionPermisibleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn emisionSobrePermisibleDataGridViewTextBoxColumn;
    }
}