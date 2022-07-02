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

namespace WinEEGO.Views.Report
{
    public partial class frmCuCvCd : Form
    {
        private List<EvaluacionGoteros> listEvaluacion = new List<EvaluacionGoteros>();
        public frmCuCvCd()
        {
            InitializeComponent();
        }

        private void frmCuCvCd_Load(object sender, EventArgs e)
        {
            CargarCultivo();
            dgDatos.Enabled = false;
        }
        private void CargarCultivo()
        {
            List<Cultivo> listaCultivo;
            listaCultivo = CultivoBL.Instancia.List();
            cbCultivo.DataSource = listaCultivo;
            cbCultivo.DisplayMember = "NombreCultivo";
            cbCultivo.ValueMember = "NombreCultivo";
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (cbCultivo.SelectedIndex >= 0)
            {
                if (btnMostrar.Text.Equals("Mostrar"))
                {
                    btnMostrar.Text = "Cambiar";
                    dtpDesde.Enabled = false;
                    dtpHasta.Enabled = false;
                    nupCU.Enabled = false;
                    nupCV.Enabled = false;
                    nupCD.Enabled = false;
                    cbCultivo.Enabled = false;
                    dgDatos.Enabled = true;
                    btnMostrar.Enabled = false;
                    ActualizarDatos();
                    btnMostrar.Enabled = true;
                }
                else
                {
                    btnMostrar.Text = "Mostrar";
                    dtpDesde.Enabled = true;
                    dtpHasta.Enabled = true;
                    nupCU.Enabled = true;
                    nupCV.Enabled = true;
                    nupCD.Enabled = true;
                    cbCultivo.Enabled = true;
                    bsDetalleEvaluacion.DataSource = null;
                    dgDatos.Enabled = false;
                }
            }
        }

        private void ActualizarDatos()
        {
            listEvaluacion = EvaluacionGoterosBL.Instancia.ListParaActuar(dtpDesde.Value, dtpHasta.Value, cbCultivo.Text, (Int16)nupCU.Value, (Int16)nupCV.Value, (Int16)nupCD.Value);
            bsDetalleEvaluacion.DataSource = listEvaluacion;
            PintarGrid2();
        }

        private void PintarGrid2()
        {
            if (dgDatos.RowCount > 0)
            {
                try
                {
                    Single cuLimiteSuperior = 90;
                    Single cuLimiteInferior = 70;
                    Single LimiteInferior = 7;
                    Single LimiteSuperior = 10;
                    Single tCurrent;

                    for (int i = 0; i < dgDatos.RowCount; i++)
                    {
                        //Pintado de Coeficiente de Uniformidad
                        if (dgDatos.Rows[i].Cells[6].Value != null)
                        {
                            if (Single.TryParse(dgDatos.Rows[i].Cells[6].Value.ToString(), out tCurrent))
                            {
                                if (tCurrent > cuLimiteSuperior)
                                {
                                    dgDatos.Rows[i].Cells[6].Style.ForeColor = Color.White;
                                    dgDatos.Rows[i].Cells[6].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent > cuLimiteInferior)
                                    {
                                        dgDatos.Rows[i].Cells[6].Style.ForeColor = Color.Black;
                                        dgDatos.Rows[i].Cells[6].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDatos.Rows[i].Cells[6].Style.ForeColor = Color.White;
                                        dgDatos.Rows[i].Cells[6].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }

                        //Pintado de Coeficiente de Variacion
                        if (dgDatos.Rows[i].Cells[7].Value != null)
                        {
                            if (Single.TryParse(dgDatos.Rows[i].Cells[7].Value.ToString(), out tCurrent))
                            {
                                tCurrent = Math.Abs(tCurrent);
                                if (tCurrent < LimiteInferior)
                                {
                                    dgDatos.Rows[i].Cells[7].Style.ForeColor = Color.White;
                                    dgDatos.Rows[i].Cells[7].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent < LimiteSuperior)
                                    {
                                        dgDatos.Rows[i].Cells[7].Style.ForeColor = Color.Black;
                                        dgDatos.Rows[i].Cells[7].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDatos.Rows[i].Cells[7].Style.ForeColor = Color.White;
                                        dgDatos.Rows[i].Cells[7].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }

                        //Pintado de Coeficiente de Desviacion
                        if (dgDatos.Rows[i].Cells[8].Value != null)
                        {
                            if (Single.TryParse(dgDatos.Rows[i].Cells[8].Value.ToString(), out tCurrent))
                            {
                                tCurrent = Math.Abs(tCurrent);
                                if (tCurrent < LimiteInferior)
                                {
                                    dgDatos.Rows[i].Cells[8].Style.ForeColor = Color.White;
                                    dgDatos.Rows[i].Cells[8].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent < LimiteSuperior)
                                    {
                                        dgDatos.Rows[i].Cells[8].Style.ForeColor = Color.Black;
                                        dgDatos.Rows[i].Cells[8].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDatos.Rows[i].Cells[8].Style.ForeColor = Color.White;
                                        dgDatos.Rows[i].Cells[8].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }

                        //Pintado de Coeficiente de Uniformidad * Desviacion
                        //if (dgDatos.Rows[i].Cells[9].Value != null)
                        //{
                        //    if (Single.TryParse(dgDatos.Rows[i].Cells[9].Value.ToString(), out tCurrent))
                        //    {
                        //        if (tCurrent > cuLimiteSuperior)
                        //        {
                        //            dgDatos.Rows[i].Cells[9].Style.ForeColor = Color.White;
                        //            dgDatos.Rows[i].Cells[9].Style.BackColor = Color.Green;
                        //        }
                        //        else
                        //        {
                        //            if (tCurrent > cuLimiteInferior)
                        //            {
                        //                dgDatos.Rows[i].Cells[9].Style.ForeColor = Color.Black;
                        //                dgDatos.Rows[i].Cells[9].Style.BackColor = Color.Yellow;
                        //            }
                        //            else
                        //            {
                        //                dgDatos.Rows[i].Cells[9].Style.ForeColor = Color.White;
                        //                dgDatos.Rows[i].Cells[9].Style.BackColor = Color.Red;
                        //            }
                        //        }
                        //    }
                        //}


                    }
                }
                catch
                {
                }
            }
        }

    }
}
