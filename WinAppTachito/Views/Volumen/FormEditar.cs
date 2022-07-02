using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinAppTachito.Business;
using WinAppTachito.Models;

namespace WinAppTachito.Views.Volumen
{
    public partial class FormEditar : Form
    {
        public event EventHandler onFormCerrado;
        private EvaluacionVolumen currentParent;
        public FormEditar(EvaluacionVolumen obj)
        {
            InitializeComponent();
            currentParent = obj;
        }

        private void FormEditar_Load(object sender, EventArgs e)
        {
            dtpFecha.Value = currentParent.Fecha;
            if (currentParent.Status.Equals("Terminado"))
            {
                rbTerminado.Checked = true;
            }
            else
            {
                rbEnCreacion.Checked = true;
                rbTerminado.Visible = false;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private async void btnAceptar_Click(object sender, EventArgs e)
        {
            dtpFecha.Enabled = false;
            rbEnCreacion.Enabled = false;
            rbTerminado.Enabled = false;
            btnAceptar.Enabled = false;
            btnCancelar.Enabled = false;
            if (rbTerminado.Visible)
            {
                if (rbTerminado.Checked)
                    currentParent.Status = "Terminado";
                else
                    currentParent.Status = "En creacion";
            }
            currentParent.Fecha = dtpFecha.Value;
            bool resul = false;
            await Task.Run(() =>
            {
                resul = EvaluacionVolumenBL.Instancia.UpdateStatus(currentParent);
            });
            if (resul)
                DialogResult = DialogResult.OK;
            else
            {
                MessageBox.Show("No se pudo actualizar el registro", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                dtpFecha.Enabled = true;
                rbEnCreacion.Enabled = true;
                rbTerminado.Enabled = true;
                btnAceptar.Enabled = true;
                btnCancelar.Enabled = true;
            }
        }
    }
}
