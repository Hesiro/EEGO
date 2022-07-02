
namespace WinEEGO.Views.Mantto
{
    partial class frmUsuarios
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
            this.label1 = new System.Windows.Forms.Label();
            this.txtCodigo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtApeNom = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbPerteneceA = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbNivelAccesoEGO = new System.Windows.Forms.ComboBox();
            this.btnInsertar = new System.Windows.Forms.Button();
            this.btnEditar = new System.Windows.Forms.Button();
            this.btnEliminar = new System.Windows.Forms.Button();
            this.dgDatos = new System.Windows.Forms.DataGridView();
            this.nombreUsuarioDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.passwordDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accesoEGODataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.perteneceADataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.apeNomDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsUsuario = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsuario)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(92, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Usuario:";
            // 
            // txtCodigo
            // 
            this.txtCodigo.Location = new System.Drawing.Point(144, 12);
            this.txtCodigo.MaxLength = 16;
            this.txtCodigo.Name = "txtCodigo";
            this.txtCodigo.Size = new System.Drawing.Size(100, 20);
            this.txtCodigo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(35, 41);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Apellidos y nombres:";
            // 
            // txtApeNom
            // 
            this.txtApeNom.Location = new System.Drawing.Point(144, 38);
            this.txtApeNom.MaxLength = 255;
            this.txtApeNom.Name = "txtApeNom";
            this.txtApeNom.Size = new System.Drawing.Size(375, 20);
            this.txtApeNom.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(70, 67);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Pertenece a:";
            // 
            // cbPerteneceA
            // 
            this.cbPerteneceA.FormattingEnabled = true;
            this.cbPerteneceA.Location = new System.Drawing.Point(144, 64);
            this.cbPerteneceA.Name = "cbPerteneceA";
            this.cbPerteneceA.Size = new System.Drawing.Size(200, 21);
            this.cbPerteneceA.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(51, 94);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(87, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Nivel de acceso:";
            // 
            // cbNivelAccesoEGO
            // 
            this.cbNivelAccesoEGO.FormattingEnabled = true;
            this.cbNivelAccesoEGO.Location = new System.Drawing.Point(144, 91);
            this.cbNivelAccesoEGO.Name = "cbNivelAccesoEGO";
            this.cbNivelAccesoEGO.Size = new System.Drawing.Size(200, 21);
            this.cbNivelAccesoEGO.TabIndex = 7;
            // 
            // btnInsertar
            // 
            this.btnInsertar.Location = new System.Drawing.Point(12, 156);
            this.btnInsertar.Name = "btnInsertar";
            this.btnInsertar.Size = new System.Drawing.Size(75, 23);
            this.btnInsertar.TabIndex = 8;
            this.btnInsertar.Text = "Nuevo";
            this.btnInsertar.UseVisualStyleBackColor = true;
            this.btnInsertar.Click += new System.EventHandler(this.btnInsertar_Click);
            // 
            // btnEditar
            // 
            this.btnEditar.Location = new System.Drawing.Point(93, 156);
            this.btnEditar.Name = "btnEditar";
            this.btnEditar.Size = new System.Drawing.Size(75, 23);
            this.btnEditar.TabIndex = 9;
            this.btnEditar.Text = "Editar";
            this.btnEditar.UseVisualStyleBackColor = true;
            this.btnEditar.Click += new System.EventHandler(this.btnEditar_Click);
            // 
            // btnEliminar
            // 
            this.btnEliminar.Location = new System.Drawing.Point(174, 156);
            this.btnEliminar.Name = "btnEliminar";
            this.btnEliminar.Size = new System.Drawing.Size(75, 23);
            this.btnEliminar.TabIndex = 10;
            this.btnEliminar.Text = "Eliminar";
            this.btnEliminar.UseVisualStyleBackColor = true;
            this.btnEliminar.Click += new System.EventHandler(this.btnEliminar_Click);
            // 
            // dgDatos
            // 
            this.dgDatos.AllowUserToAddRows = false;
            this.dgDatos.AllowUserToDeleteRows = false;
            this.dgDatos.AutoGenerateColumns = false;
            this.dgDatos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgDatos.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombreUsuarioDataGridViewTextBoxColumn,
            this.passwordDataGridViewTextBoxColumn,
            this.accesoEGODataGridViewTextBoxColumn,
            this.perteneceADataGridViewTextBoxColumn,
            this.apeNomDataGridViewTextBoxColumn});
            this.dgDatos.DataSource = this.bsUsuario;
            this.dgDatos.Location = new System.Drawing.Point(12, 185);
            this.dgDatos.Name = "dgDatos";
            this.dgDatos.ReadOnly = true;
            this.dgDatos.RowHeadersWidth = 20;
            this.dgDatos.Size = new System.Drawing.Size(776, 253);
            this.dgDatos.TabIndex = 11;
            this.dgDatos.SelectionChanged += new System.EventHandler(this.dgDatos_SelectionChanged);
            // 
            // nombreUsuarioDataGridViewTextBoxColumn
            // 
            this.nombreUsuarioDataGridViewTextBoxColumn.DataPropertyName = "NombreUsuario";
            this.nombreUsuarioDataGridViewTextBoxColumn.HeaderText = "Usuario";
            this.nombreUsuarioDataGridViewTextBoxColumn.Name = "nombreUsuarioDataGridViewTextBoxColumn";
            this.nombreUsuarioDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // passwordDataGridViewTextBoxColumn
            // 
            this.passwordDataGridViewTextBoxColumn.DataPropertyName = "Password";
            this.passwordDataGridViewTextBoxColumn.HeaderText = "Password";
            this.passwordDataGridViewTextBoxColumn.Name = "passwordDataGridViewTextBoxColumn";
            this.passwordDataGridViewTextBoxColumn.ReadOnly = true;
            this.passwordDataGridViewTextBoxColumn.Visible = false;
            // 
            // accesoEGODataGridViewTextBoxColumn
            // 
            this.accesoEGODataGridViewTextBoxColumn.DataPropertyName = "AccesoEGO";
            this.accesoEGODataGridViewTextBoxColumn.HeaderText = "AccesoEGO";
            this.accesoEGODataGridViewTextBoxColumn.Name = "accesoEGODataGridViewTextBoxColumn";
            this.accesoEGODataGridViewTextBoxColumn.ReadOnly = true;
            this.accesoEGODataGridViewTextBoxColumn.Visible = false;
            // 
            // perteneceADataGridViewTextBoxColumn
            // 
            this.perteneceADataGridViewTextBoxColumn.DataPropertyName = "PerteneceA";
            this.perteneceADataGridViewTextBoxColumn.HeaderText = "Pertenece A";
            this.perteneceADataGridViewTextBoxColumn.Name = "perteneceADataGridViewTextBoxColumn";
            this.perteneceADataGridViewTextBoxColumn.ReadOnly = true;
            this.perteneceADataGridViewTextBoxColumn.Width = 250;
            // 
            // apeNomDataGridViewTextBoxColumn
            // 
            this.apeNomDataGridViewTextBoxColumn.DataPropertyName = "ApeNom";
            this.apeNomDataGridViewTextBoxColumn.HeaderText = "ApeNom";
            this.apeNomDataGridViewTextBoxColumn.Name = "apeNomDataGridViewTextBoxColumn";
            this.apeNomDataGridViewTextBoxColumn.ReadOnly = true;
            this.apeNomDataGridViewTextBoxColumn.Visible = false;
            // 
            // bsUsuario
            // 
            this.bsUsuario.DataSource = typeof(WinEEGO.Models.Usuario);
            // 
            // frmUsuarios
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dgDatos);
            this.Controls.Add(this.btnEliminar);
            this.Controls.Add(this.btnEditar);
            this.Controls.Add(this.btnInsertar);
            this.Controls.Add(this.cbNivelAccesoEGO);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cbPerteneceA);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtApeNom);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtCodigo);
            this.Controls.Add(this.label1);
            this.Name = "frmUsuarios";
            this.Text = "Usuarios";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.frmUsuarios_FormClosed);
            this.Load += new System.EventHandler(this.frmUsuarios_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgDatos)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsUsuario)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCodigo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtApeNom;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPerteneceA;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbNivelAccesoEGO;
        private System.Windows.Forms.Button btnInsertar;
        private System.Windows.Forms.Button btnEditar;
        private System.Windows.Forms.Button btnEliminar;
        private System.Windows.Forms.DataGridView dgDatos;
        private System.Windows.Forms.BindingSource bsUsuario;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreUsuarioDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn passwordDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accesoEGODataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn perteneceADataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn apeNomDataGridViewTextBoxColumn;
    }
}