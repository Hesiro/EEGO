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
    public partial class frmNewEvaluacion : Form
    {
        EvaluacionGoteros evaluacion = new EvaluacionGoteros();
        private decimal? EmisionPermisible;
        private decimal? EmisionSobrePermisible;
        public frmNewEvaluacion()
        {
            InitializeComponent();
        }

        private void frmNewEvaluacion_Load(object sender, EventArgs e)
        {

        }
        public EvaluacionGoteros Evaluacion
        {
            get
            {
                return evaluacion;
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnAceptar_Click(object sender, EventArgs e)
        {
            if (Validar())
            {
                evaluacion.Usuario = Log.UsuarioSistema;
                evaluacion.Fecha = dtpFecha.Value;
                evaluacion.Status = "En creacion";
                evaluacion.Id = EvaluacionGoterosBL.Instancia.Insert(evaluacion);
                if (evaluacion.Id > 0)
                {
                    ///Actualizar asignado la fecha
                    //if (ckbIncluirReporte.Checked)
                    //{
                    //    Int16 Camp, Mess;
                    //    Camp = (Int16)txtCampania.Value;
                    //    if (cbMes.SelectedIndex <= 9)
                    //        Mess = (Int16)(cbMes.SelectedIndex + 3);
                    //    else
                    //        Mess = (Int16)(cbMes.SelectedIndex - 9);
                    //    evaluacion.RepCampania = Camp;
                    //    evaluacion.RepMes = Mess;
                    //    EvaluacionGoterosBL.Instancia.UpdateReport(evaluacion);
                    //}
                    ///
                    this.DialogResult = DialogResult.OK;
                }
                else
                    MessageBox.Show("Ocurrio un error al intentar guardar nuevo registro.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool Validar()
        {
            if (txtArea.Text.Equals(""))
            {
                MessageBox.Show("Debe seleccionar una area.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnArea.Focus();
                return false;
            }
            else
            {
                evaluacion.Area = txtArea.Text;
                evaluacion.Cultivo = txtCultivo.Text;
                float cA;
                if (!txtHectarea.Text.Equals("") && !float.TryParse(txtHectarea.Text, out cA))
                {
                    MessageBox.Show("Verificar hectarea.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtHectarea.Focus();
                    return false;
                }
                else
                {
                    if (!txtHectarea.Text.Equals(""))
                        evaluacion.Hectarea = decimal.Parse(txtHectarea.Text);

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
                            evaluacion.NumeroMuestras = (int)txtMuestras.Value;
                            evaluacion.NumeroPresiones = (int)txtPresiones.Value;
                            //if (ckbIncluirReporte.Checked)
                            //{
                            //    if (cbMes.SelectedIndex >= 0)
                            //    {
                            //        return true;
                            //    }
                            //    else
                            //    {
                            //        MessageBox.Show("Seleccione el nombre del mes a asignar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            //        return false;
                            //    }
                            //}
                            //else
                            //{
                            return true;
                            //}
                        }
                    }
                }
            }
        }

        private void btnArea_Click(object sender, EventArgs e)
        {
            frmSelectArea frm = new frmSelectArea();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtArea.Text = frm.Area.Codigo;
                txtHectarea.Text = String.Format("{0:N2}", frm.Area.Hectarea);
                txtCultivo.Text = frm.Area.Cultivo;
            }
            frm.Close();
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
    }
}
