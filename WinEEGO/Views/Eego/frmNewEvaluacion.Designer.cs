
namespace WinEEGO.Views.Eego
{
    partial class frmNewEvaluacion
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
            this.dtpFecha = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMuestras = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPresiones = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.btnArea = new System.Windows.Forms.Button();
            this.btnManguera = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txtArea = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHectarea = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtCultivo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtEmision = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtManguera = new System.Windows.Forms.TextBox();
            this.btnAceptar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.txtMuestras)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPresiones)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpFecha
            // 
            this.dtpFecha.CustomFormat = "dd/MM/yyyy hh:mm tt";
            this.dtpFecha.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFecha.Location = new System.Drawing.Point(52, 19);
            this.dtpFecha.Name = "dtpFecha";
            this.dtpFecha.Size = new System.Drawing.Size(175, 20);
            this.dtpFecha.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Fecha:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(254, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Cantidad de muestras:";
            // 
            // txtMuestras
            // 
            this.txtMuestras.Location = new System.Drawing.Point(372, 19);
            this.txtMuestras.Maximum = new decimal(new int[] {
            36,
            0,
            0,
            0});
            this.txtMuestras.Name = "txtMuestras";
            this.txtMuestras.Size = new System.Drawing.Size(80, 20);
            this.txtMuestras.TabIndex = 3;
            this.txtMuestras.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(485, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(115, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "Cantidad de presiones:";
            // 
            // txtPresiones
            // 
            this.txtPresiones.Location = new System.Drawing.Point(606, 19);
            this.txtPresiones.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.txtPresiones.Name = "txtPresiones";
            this.txtPresiones.Size = new System.Drawing.Size(80, 20);
            this.txtPresiones.TabIndex = 5;
            this.txtPresiones.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(288, 64);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "l/h";
            // 
            // btnArea
            // 
            this.btnArea.Location = new System.Drawing.Point(52, 17);
            this.btnArea.Name = "btnArea";
            this.btnArea.Size = new System.Drawing.Size(50, 23);
            this.btnArea.TabIndex = 0;
            this.btnArea.Text = "...";
            this.btnArea.UseVisualStyleBackColor = true;
            this.btnArea.Click += new System.EventHandler(this.btnArea_Click);
            // 
            // btnManguera
            // 
            this.btnManguera.Location = new System.Drawing.Point(52, 58);
            this.btnManguera.Name = "btnManguera";
            this.btnManguera.Size = new System.Drawing.Size(50, 23);
            this.btnManguera.TabIndex = 7;
            this.btnManguera.Text = "...";
            this.btnManguera.UseVisualStyleBackColor = true;
            this.btnManguera.Click += new System.EventHandler(this.btnManguera_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(144, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(32, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Filtro:";
            // 
            // txtArea
            // 
            this.txtArea.BackColor = System.Drawing.SystemColors.Window;
            this.txtArea.Location = new System.Drawing.Point(182, 19);
            this.txtArea.Name = "txtArea";
            this.txtArea.ReadOnly = true;
            this.txtArea.Size = new System.Drawing.Size(100, 20);
            this.txtArea.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(312, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(54, 13);
            this.label7.TabIndex = 3;
            this.label7.Text = "Hectarea:";
            // 
            // txtHectarea
            // 
            this.txtHectarea.BackColor = System.Drawing.SystemColors.Window;
            this.txtHectarea.Location = new System.Drawing.Point(372, 19);
            this.txtHectarea.Name = "txtHectarea";
            this.txtHectarea.ReadOnly = true;
            this.txtHectarea.Size = new System.Drawing.Size(70, 20);
            this.txtHectarea.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(485, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(42, 13);
            this.label8.TabIndex = 5;
            this.label8.Text = "Cultivo:";
            // 
            // txtCultivo
            // 
            this.txtCultivo.BackColor = System.Drawing.SystemColors.Window;
            this.txtCultivo.Location = new System.Drawing.Point(533, 19);
            this.txtCultivo.Name = "txtCultivo";
            this.txtCultivo.ReadOnly = true;
            this.txtCultivo.Size = new System.Drawing.Size(120, 20);
            this.txtCultivo.TabIndex = 6;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(130, 63);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(46, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Emisión:";
            // 
            // txtEmision
            // 
            this.txtEmision.BackColor = System.Drawing.SystemColors.Window;
            this.txtEmision.Location = new System.Drawing.Point(182, 60);
            this.txtEmision.Name = "txtEmision";
            this.txtEmision.ReadOnly = true;
            this.txtEmision.Size = new System.Drawing.Size(100, 20);
            this.txtEmision.TabIndex = 9;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(370, 60);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(47, 13);
            this.label10.TabIndex = 11;
            this.label10.Text = "Nombre:";
            // 
            // txtManguera
            // 
            this.txtManguera.BackColor = System.Drawing.SystemColors.Window;
            this.txtManguera.Location = new System.Drawing.Point(423, 57);
            this.txtManguera.Name = "txtManguera";
            this.txtManguera.ReadOnly = true;
            this.txtManguera.Size = new System.Drawing.Size(230, 20);
            this.txtManguera.TabIndex = 12;
            // 
            // btnAceptar
            // 
            this.btnAceptar.Location = new System.Drawing.Point(560, 219);
            this.btnAceptar.Name = "btnAceptar";
            this.btnAceptar.Size = new System.Drawing.Size(75, 23);
            this.btnAceptar.TabIndex = 2;
            this.btnAceptar.Text = "Aceptar";
            this.btnAceptar.UseVisualStyleBackColor = true;
            this.btnAceptar.Click += new System.EventHandler(this.btnAceptar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelar.Location = new System.Drawing.Point(641, 219);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 23);
            this.btnCancelar.TabIndex = 3;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpFecha);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtMuestras);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtPresiones);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(704, 56);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Evaluación:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnArea);
            this.groupBox2.Controls.Add(this.btnManguera);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.txtArea);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.txtManguera);
            this.groupBox2.Controls.Add(this.txtHectarea);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.txtEmision);
            this.groupBox2.Controls.Add(this.txtCultivo);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Location = new System.Drawing.Point(12, 100);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(704, 95);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filtro evaluado:";
            // 
            // frmNewEvaluacion
            // 
            this.AcceptButton = this.btnAceptar;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancelar;
            this.ClientSize = new System.Drawing.Size(730, 263);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnAceptar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmNewEvaluacion";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Evaluación";
            this.Load += new System.EventHandler(this.frmNewEvaluacion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.txtMuestras)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPresiones)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dtpFecha;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown txtMuestras;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown txtPresiones;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnArea;
        private System.Windows.Forms.Button btnManguera;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtArea;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHectarea;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtCultivo;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtEmision;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtManguera;
        private System.Windows.Forms.Button btnAceptar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}