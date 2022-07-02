using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinEEGO.Business;
using WinEEGO.Models;

namespace WinEEGO.Views.Eego
{
    public partial class frmUpdateEvaluacion : Form
    {
        EvaluacionGoteros evaluacion;
        private decimal? EmisionPermisible;
        private decimal? EmisionSobrePermisible;
        public frmUpdateEvaluacion(EvaluacionGoteros obj)
        {
            InitializeComponent();
            evaluacion = obj;
        }

        private void frmUpdateEvaluacion_Load(object sender, EventArgs e)
        {
            if (evaluacion != null)
            {
                dtpFecha.Value = evaluacion.Fecha;
                txtManguera.Text = evaluacion.NombreManguera;                
                txtEmision.Text = evaluacion.Emision.ToString();
                EmisionPermisible = evaluacion.EmisionPermisible;
                EmisionSobrePermisible = evaluacion.EmisionSobrePermisible;
            }
        }

        private void btnManguera_Click(object sender, EventArgs e)
        {
            frmSelectManguera frm = new frmSelectManguera();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtManguera.Text = frm.Manguera.Nombre;                
                txtEmision.Text = String.Format("{0:N2}", frm.Manguera.Emision);
                EmisionPermisible = frm.Manguera.EmisionPermisible;
                EmisionSobrePermisible = frm.Manguera.EmisionSobrePermisible;
            }
            frm.Close();
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                evaluacion.Fecha = dtpFecha.Value;
                evaluacion.CoeficienteUniformidad = null;
                evaluacion.CoeficienteDesviacion = null;
                evaluacion.CoeficienteVariacion = null;
                if (EvaluacionGoterosBL.Instancia.Update(evaluacion))
                    this.DialogResult = DialogResult.OK;
                else
                    MessageBox.Show("Ocurrio un error al intentar guardar cambios en el registro.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private bool Validar()
        {
            if (txtManguera.Text.Equals(""))
            {
                MessageBox.Show("Debe seleccionar un tipo de manguera.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnManguera.Focus();
                return false;
            }
            else
            {
                evaluacion.NombreManguera = txtManguera.Text;                
                evaluacion.Emision = decimal.Parse(txtEmision.Text);

                if (!EmisionPermisible.HasValue || !EmisionSobrePermisible.HasValue)
                {
                    MessageBox.Show("Error en la definición de los rangos permisibles de emision del tipo de manguera.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                else
                {
                    evaluacion.EmisionPermisible = EmisionPermisible;
                    evaluacion.EmisionSobrePermisible = EmisionSobrePermisible;
                    return true;
                }
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
