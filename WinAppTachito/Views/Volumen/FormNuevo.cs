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
    public partial class FormNuevo : Form
    {
        private decimal? hectarea, distancia;
        DateTime oFecha;
        public FormNuevo(DateTime fecha)
        {
            InitializeComponent();
            oFecha = fecha;
        }

        private void BtnArea_Click(object sender, EventArgs e)
        {
            FormSelectArea frm = new FormSelectArea();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtArea.Text = frm.Area.Codigo;
                hectarea = frm.Area.Hectarea;    //txtHectarea.Text = String.Format("{0:N2}", frm.Area.Hectarea);
                txtCultivo.Text = frm.Area.Cultivo;
            }
            frm.Close();
        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
        private async void BtnAceptar_Click(object sender, EventArgs e)
        {            
            if(Validar())
            {                
                btnArea.Enabled = false;
                btnEmisor.Enabled = false;
                btnAceptar.Enabled = false;
                btnCancelar.Enabled = false;

                EvaluacionVolumen evaluacion = new EvaluacionVolumen
                {
                    Usuario = Log.UsuarioSistema,
                    Fecha = oFecha,
                    Lote = txtArea.Text,
                    Cultivo = txtCultivo.Text,
                    Hectarea = hectarea,
                    NombreManguera = txtManguera.Text,
                    Distancia = distancia,
                    Emision = decimal.Parse(txtEmision.Text),
                    TipoEvaluacion = "Del gotero testigo",
                    Status = "En creacion"
                };
                await Task.Run(() => {
                    evaluacion.Id = EvaluacionVolumenBL.Instancia.Insert(evaluacion);
                });
                
                if (evaluacion.Id > 0)
                {
                    await Task.Run(() => {
                        EvaluacionVolumenBL.Instancia.InsertDetail(evaluacion);
                    });                                        
                    DialogResult = DialogResult.OK;
                }
                else
                {
                    MessageBox.Show("Ocurrio un error al intentar guardar nuevo registro.", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);                    
                    btnArea.Enabled = true;
                    btnEmisor.Enabled = true;
                    btnAceptar.Enabled = true;
                    btnCancelar.Enabled = true;
                }
            }
        }
        private void BtnEmisor_Click(object sender, EventArgs e)
        {
            FormSelectEmisor frm = new FormSelectEmisor();
            if (frm.ShowDialog() == DialogResult.OK)
            {
                txtManguera.Text = frm.Manguera.Nombre;
                distancia = frm.Manguera.Distancia; //txtDistancia.Text = String.Format("{0:N2}", frm.Manguera.Distancia);
                txtEmision.Text = String.Format("{0:N2}", frm.Manguera.Emision);
                //EmisionPermisible = frm.Manguera.EmisionPermisible;
                //EmisionSobrePermisible = frm.Manguera.EmisionSobrePermisible;
            }
            frm.Close();
        }

        private void FormNuevo_Load(object sender, EventArgs e)
        {
            lbFecha.Text = oFecha.ToShortDateString();
        }

        private bool Validar()
        {
            if(txtArea.Text.Equals(""))
            {
                MessageBox.Show("Debe seleccionar una area.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnArea.Focus();
                return false;
            }
            else
            {
                if (txtManguera.Text.Equals(""))
                {
                    MessageBox.Show("Debe seleccionar un tipo de emisor.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnEmisor.Focus();
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
