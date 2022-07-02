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

namespace WinEEGO.Views.Report{
    
    public partial class frmDetalleEvaluacion : Form
    {
        private EvaluacionGoteros currentParent;
        private List<DetalleEvaluacionGoteros> listDetalleEvaluacion = new List<DetalleEvaluacionGoteros>();
        private DetalleEvaluacionGoteros currentDetalleEvaluacion = new DetalleEvaluacionGoteros();
        private int anio;
        public frmDetalleEvaluacion(int Anio, EvaluacionGoteros obj)
        {
            InitializeComponent();
            currentParent = obj;
            anio = Anio;
        }

        private void frmDetalleEvaluacion_Load(object sender, EventArgs e)
        {
            txtFecha.Text = currentParent.Fecha.ToShortDateString();
            txtArea.Text = currentParent.Area;            
            txtEmision.Text = string.Format("{0:N2}", currentParent.Emision);

            if (currentParent.NumeroMuestras > 0)
                for (int i = currentParent.NumeroMuestras; i < 36; i++)
                    dgDatos.Columns[i + 6].Visible = false;

            if (currentParent.NumeroPresiones > 0)
                for (int i = currentParent.NumeroPresiones; i < 16; i++)
                    dgDatos.Columns[i + 43].Visible = false;

            ActualizarPadre();
            ActualizarDatos();
        }
        private void ActualizarPadre()
        {
            EvaluacionGoteros xXx = new EvaluacionGoteros();
            xXx = EvaluacionGoterosBL.Instancia.FindByID(currentParent);
            currentParent = xXx;
            int iGDP, iGSP, iGP, iTG;

            //if (xXx.CoeficienteUniformidad.HasValue)
            //    gCu.Valor = (Single)xXx.CoeficienteUniformidad;
            //else
            //    gCu.Valor = 100;

            //if (xXx.CoeficienteVariacion.HasValue)
            //{
            //    if (Math.Abs((decimal)xXx.CoeficienteVariacion) > 30)
            //    {
            //        gCv.Visible = false;
            //    }
            //    else
            //    {
            //        gCv.Valor = (Single)xXx.CoeficienteVariacion;
            //    }
            //}
            //else
            //    gCv.Valor = 0;

            //if (xXx.CoeficienteDesviacion.HasValue)
            //{
            //    if (Math.Abs((decimal)xXx.CoeficienteDesviacion) > 15)
            //    {
            //        gCd.Visible = false;
            //    }
            //    else
            //    {
            //        gCd.Valor = (Single)xXx.CoeficienteDesviacion;
            //    }
            //}
            //else
            //    gCd.Valor = 0;

            if (xXx.GoterosDebajoPermisible.HasValue)
            {
                iGDP = (int)xXx.GoterosDebajoPermisible;
                txtGCDP.Text = string.Format("{0:N0}", iGDP);
            }
            else
            {
                iGDP = 0;
                txtGCDP.Text = "";
            }

            if (xXx.GoterosPermisible.HasValue)
            {
                iGP = (int)xXx.GoterosPermisible;
                txtGCP.Text = string.Format("{0:N0}", iGP);
            }
            else
            {
                iGP = 0;
                txtGCP.Text = "";
            }

            if (xXx.GoterosSobrePermisible.HasValue)
            {
                iGSP = (int)xXx.GoterosSobrePermisible;
                txtGCSP.Text = string.Format("{0:N0}", iGSP);
            }
            else
            {
                iGSP = 0;
                txtGCSP.Text = "";
            }

            if (xXx.GoterosDebajoPermisible.HasValue && xXx.GoterosPermisible.HasValue && xXx.GoterosSobrePermisible.HasValue)
                txtTotalGoteros.Text = string.Format("{0:N0}", xXx.GoterosDebajoPermisible + xXx.GoterosPermisible + xXx.GoterosSobrePermisible);
            else
                txtTotalGoteros.Text = "";

            iTG = iGDP + iGP + iGSP;

            if (iTG > 0)
            {
                txtPorGCDP.Text = (100 * (decimal)iGDP / (decimal)iTG).ToString("N2") + " %";
                txtPorGCP.Text = (100 * (decimal)iGP / (decimal)iTG).ToString("N2") + " %";
                txtPorGCSP.Text = (100 * (decimal)iGSP / (decimal)iTG).ToString("N2") + " %";
                txtPorTotalGoteros.Text = "100 %";
            }
            else
            {
                txtPorGCDP.Text = "";
                txtPorGCP.Text = "";
                txtPorGCSP.Text = "";
                txtPorTotalGoteros.Text = "";
            }
        }
        private void ActualizarDatos()
        {
            listDetalleEvaluacion = EvaluacionGoterosBL.Instancia.ListDetail(currentParent);
            bsDetalleEvaluacion.DataSource = listDetalleEvaluacion;

            //if (listDetalleEvaluacion.Count > 0)
            //    btnShow.Enabled = true;
            //else
            //    btnShow.Enabled = false;

            PaintGrid();
        }
        private void PaintGrid()
        {
            if (dgDatos.RowCount > 0)
            {
                try
                {
                    Decimal cuLimiteSuperior = 90;
                    Decimal cuLimiteInferior = 70;

                    decimal cvLimiteSuperior = 10;
                    decimal cvLimiteInferior = 7;

                    Decimal tCurrent;
                    Boolean isToPaint;

                    for (int i = 0; i < dgDatos.RowCount; i++)
                    {
                        #region Pintado de coeficiente de uniformidad

                        int colGrid = 1;
                        if (dgDatos.Rows[i].Cells[colGrid].Value != null)
                        {
                            if (Decimal.TryParse(dgDatos.Rows[i].Cells[colGrid].Value.ToString(), out tCurrent))
                            {
                                if (tCurrent > cuLimiteSuperior)
                                {
                                    dgDatos.Rows[i].Cells[colGrid].Style.ForeColor = Color.White;
                                    dgDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent > cuLimiteInferior)
                                    {
                                        dgDatos.Rows[i].Cells[colGrid].Style.ForeColor = Color.Black;
                                        dgDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDatos.Rows[i].Cells[colGrid].Style.ForeColor = Color.White;
                                        dgDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }

                        #endregion

                        #region Pintado de coeficiente de variacion
                        colGrid = 2;
                        if (dgDatos.Rows[i].Cells[colGrid].Value != null)
                        {
                            if (Decimal.TryParse(dgDatos.Rows[i].Cells[colGrid].Value.ToString(), out tCurrent))
                            {
                                tCurrent = Math.Abs(tCurrent);
                                if (tCurrent < cvLimiteInferior)
                                {
                                    dgDatos.Rows[i].Cells[colGrid].Style.ForeColor = Color.White;
                                    dgDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent < cvLimiteSuperior)
                                    {
                                        dgDatos.Rows[i].Cells[colGrid].Style.ForeColor = Color.Black;
                                        dgDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDatos.Rows[i].Cells[colGrid].Style.ForeColor = Color.White;
                                        dgDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                        #endregion

                        #region Pintado de coeficiente de desviacion
                        colGrid = 3;
                        if (dgDatos.Rows[i].Cells[colGrid].Value != null)
                        {
                            if (Decimal.TryParse(dgDatos.Rows[i].Cells[colGrid].Value.ToString(), out tCurrent))
                            {
                                tCurrent = Math.Abs(tCurrent);
                                if (tCurrent < cvLimiteInferior)
                                {
                                    dgDatos.Rows[i].Cells[colGrid].Style.ForeColor = Color.White;
                                    dgDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent < cvLimiteSuperior)
                                    {
                                        dgDatos.Rows[i].Cells[colGrid].Style.ForeColor = Color.Black;
                                        dgDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDatos.Rows[i].Cells[colGrid].Style.ForeColor = Color.White;
                                        dgDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                        #endregion

                        #region Pintado de emisiones
                        for (int j = 0; j < currentParent.NumeroMuestras; j++)
                        {
                            dgDatos.Rows[i].Cells[j + 6].Style.ForeColor = Color.Black;
                            dgDatos.Rows[i].Cells[j + 6].Style.BackColor = Color.White;
                            isToPaint = false;

                            if (dgDatos.Rows[i].Cells[j + 6].Value != null)
                                if (Decimal.TryParse(dgDatos.Rows[i].Cells[j + 6].Value.ToString(), out tCurrent))
                                    if (tCurrent > currentParent.EmisionSobrePermisible)
                                        isToPaint = rbTop.Checked;
                                    else
                                        if (tCurrent > currentParent.EmisionPermisible)
                                        isToPaint = rbCenter.Checked;
                                    else
                                        isToPaint = rbBottom.Checked;

                            if (isToPaint)
                            {
                                dgDatos.Rows[i].Cells[j + 6].Style.ForeColor = Color.Black;
                                dgDatos.Rows[i].Cells[j + 6].Style.BackColor = Color.Aquamarine;
                            }
                        }
                        #endregion

                        #region Pintado Cu presiones

                        colGrid = 42;
                        if (dgDatos.Rows[i].Cells[colGrid].Value != null)
                        {
                            if (Decimal.TryParse(dgDatos.Rows[i].Cells[colGrid].Value.ToString(), out tCurrent))
                            {
                                if (tCurrent > cuLimiteSuperior)
                                {
                                    dgDatos.Rows[i].Cells[colGrid].Style.ForeColor = Color.White;
                                    dgDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent > cuLimiteInferior)
                                    {
                                        dgDatos.Rows[i].Cells[colGrid].Style.ForeColor = Color.Black;
                                        dgDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDatos.Rows[i].Cells[colGrid].Style.ForeColor = Color.White;
                                        dgDatos.Rows[i].Cells[colGrid].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }

                        #endregion

                        

                    }
                }
                catch (Exception ex)
                {
                    Log.FailRegister("frmDetailEvaluacion - " + ex.Message);
                }
            }
        }

        private void rbBottom_CheckedChanged(object sender, EventArgs e)
        {
            PaintGrid();
        }

        private void rbCenter_CheckedChanged(object sender, EventArgs e)
        {
            PaintGrid();
        }

        private void rbTop_CheckedChanged(object sender, EventArgs e)
        {
            PaintGrid();
        }

        private void frmDetalleEvaluacion_Shown(object sender, EventArgs e)
        {
            PaintGrid();
        }
        
    }
}
