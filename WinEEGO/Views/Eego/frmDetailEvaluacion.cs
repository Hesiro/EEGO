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
    public partial class frmDetailEvaluacion : Form
    {
        public event EventHandler onFormCerrado;
        private EvaluacionGoteros currentParent;
        private List<DetalleEvaluacionGoteros> listDetalleEvaluacion = new List<DetalleEvaluacionGoteros>();
        //private DetalleEvaluacionGoteros currentDetalleEvaluacion;
        private List<string> listIDs = new List<string>();
        public frmDetailEvaluacion(EvaluacionGoteros obj)
        {
            InitializeComponent();
            currentParent = obj;
        }

        private void frmDetailEvaluacion_Load(object sender, EventArgs e)
        {
            txtFecha.Text = currentParent.Fecha.ToShortDateString();
            txtArea.Text = currentParent.Area;
            txtHectarea.Text = String.Format("{0:N2}", currentParent.Hectarea);
            txtCultivo.Text = currentParent.Cultivo;            
            txtEmision.Text = String.Format("{0:N2}", currentParent.Emision) + " l/h";

            if (currentParent.NumeroMuestras > 0)
                for (int i = currentParent.NumeroMuestras; i < 36; i++)
                    dgDatos.Columns[i + 6].Visible = false;

            if (currentParent.NumeroPresiones >= 0)
                for (int i = currentParent.NumeroPresiones; i < 16; i++)
                    dgDatos.Columns[i + 43].Visible = false;

            ActualizarPadre();
            ActualizarDatos();            
        }

        private void frmDetailEvaluacion_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (onFormCerrado != null)
                onFormCerrado(this, EventArgs.Empty);
        }
        private void ActualizarDatos()
        {
            listDetalleEvaluacion = EvaluacionGoterosBL.Instancia.ListDetail(currentParent);

            bsDetalleEvaluacion.DataSource = listDetalleEvaluacion;

            if (listDetalleEvaluacion.Count == 0)
            {
                btnInsert.Enabled = true;
                btnGuardar.Enabled = false;
                btnTerminar.Enabled = false;
            }
            else
            {
                btnInsert.Enabled = false;
                btnGuardar.Enabled = true;
                btnTerminar.Enabled = true;
            }

            if (currentParent.Status.Equals("Terminado"))
            {
                btnGuardar.Enabled = false;
                btnTerminar.Enabled = false;
                dgDatos.ReadOnly = true;
            }

            PaintGrid();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (EvaluacionGoterosBL.Instancia.InsertDetail(currentParent))
                ActualizarDatos();
            else
                MessageBox.Show("Ocurrio un error al intertar guardar el registro", "Error",
                                    MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (EvaluacionGoterosBL.Instancia.UpdateDetail(DevolverListaIDs()))
            {
                listIDs.Clear();
                btnTerminar.Enabled = true;
                if (EvaluacionGoterosBL.Instancia.UpdateResult(currentParent, listDetalleEvaluacion))
                {
                    ActualizarPadre();
                    ActualizarDatos();
                }
            }
        }

        private void btnTerminar_Click(object sender, EventArgs e)
        {
            if (EvaluacionGoterosBL.Instancia.UpdateDetail(listDetalleEvaluacion))
            {
                currentParent.Status = "Terminado";
                if (EvaluacionGoterosBL.Instancia.UpdateResult(currentParent, listDetalleEvaluacion))
                {
                    ActualizarPadre();
                    ActualizarDatos();
                }
            }
        }

        private void dgDatos_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            try
            {
                MessageBox.Show("Dato ingresado incorrecto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dgDatos.Rows[dgDatos.CurrentCell.RowIndex].Cells[dgDatos.CurrentCell.ColumnIndex].Value = "";
            }
            catch (Exception ex)
            {
                Log.FailRegister("frmDatailEvaluacion - " + ex.Message);
            }
        }

        private void dgDatos_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (dgDatos.Rows.Count > 0)
            {
                ((DetalleEvaluacionGoteros)bsDetalleEvaluacion.Current).RefreshCoeficientes();
                ((DetalleEvaluacionGoteros)bsDetalleEvaluacion.Current).RefreshCUPresion();
                AgregarListaIDs(dgDatos.Rows[dgDatos.CurrentCell.RowIndex].Cells[4].Value.ToString());
                btnTerminar.Enabled = false;
                PaintGrid();
            }
        }
        private void AgregarListaIDs(string Id)
        {
            bool find = false;
            foreach (var item in listIDs)
            {
                if (item.Equals(Id))
                {
                    find = true;
                    break;
                }
            }
            if (!find)
                listIDs.Add(Id);
        }
        private List<DetalleEvaluacionGoteros> DevolverListaIDs()
        {
            List<DetalleEvaluacionGoteros> oLista = new List<DetalleEvaluacionGoteros>();
            if (listIDs.Count > 0)
            {
                Boolean incluir;
                foreach (var item in listDetalleEvaluacion)
                {
                    incluir = false;
                    foreach (var itemA in listIDs)
                    {
                        if (item.Id.ToString().Equals(itemA))
                        {
                            incluir = true;
                            break;
                        }
                    }

                    if (incluir)
                    {
                        item.RefreshCoeficientes();
                        item.RefreshCUPresion();
                        oLista.Add(item);
                    }
                }
            }
            return oLista;
        }
        private void ActualizarPadre()
        {
            EvaluacionGoteros xXx = new EvaluacionGoteros();
            xXx = EvaluacionGoterosBL.Instancia.FindByID(currentParent);

            if (xXx.CaudalMedio.HasValue)
                txtCaudalMedio.Text = String.Format("{0:N3}", xXx.CaudalMedio) + " l/h";
            else
                txtCaudalMedio.Text = "";

            if (xXx.CaudalMedio25.HasValue)
                txtCaudalMedio25.Text = String.Format("{0:N3}", xXx.CaudalMedio25) + " l/h";
            else
                txtCaudalMedio25.Text = "";

            if (xXx.DesviacionS.HasValue)
                txtDesv.Text = String.Format("{0:N3}", xXx.DesviacionS);
            else
                txtDesv.Text = "";

            if (xXx.CoeficienteUniformidad.HasValue)
            {
                txtCU.Text = String.Format("{0:N2}", xXx.CoeficienteUniformidad) + " %";
                if (xXx.CoeficienteUniformidad > 90)
                {
                    txtCU.ForeColor = Color.White;
                    txtCU.BackColor = Color.Green;
                }
                else
                {
                    if (xXx.CoeficienteUniformidad > 70)
                    {
                        txtCU.ForeColor = Color.Black;
                        txtCU.BackColor = Color.Yellow;
                    }
                    else
                    {
                        txtCU.ForeColor = Color.White;
                        txtCU.BackColor = Color.Red;
                    }
                }
            }
            else
            {
                txtCU.Text = "";
                txtCU.ForeColor = Color.Black;
                txtCU.BackColor = Color.White;
            }

            if (xXx.CoeficienteVariacion.HasValue)
            {
                txtCV.Text = String.Format("{0:N2}", xXx.CoeficienteVariacion) + " %";
                if (Math.Abs((Decimal)xXx.CoeficienteVariacion) < 7)
                {
                    txtCV.ForeColor = Color.White;
                    txtCV.BackColor = Color.Green;
                }
                else
                {
                    if (xXx.CoeficienteVariacion < 10)
                    {
                        txtCV.ForeColor = Color.Black;
                        txtCV.BackColor = Color.Yellow;
                    }
                    else
                    {
                        txtCV.ForeColor = Color.White;
                        txtCV.BackColor = Color.Red;
                    }
                }
            }
            else
            {
                txtCV.Text = "";
                txtCV.ForeColor = Color.Black;
                txtCV.BackColor = Color.White;
            }

            if (xXx.CoeficienteDesviacion.HasValue)
            {
                txtCD.Text = String.Format("{0:N2}", xXx.CoeficienteDesviacion) + " %";
                if (Math.Abs((Decimal)xXx.CoeficienteDesviacion) < 7)
                {
                    txtCD.ForeColor = Color.White;
                    txtCD.BackColor = Color.Green;
                }
                else
                {
                    if (xXx.CoeficienteDesviacion < 10)
                    {
                        txtCD.ForeColor = Color.Black;
                        txtCD.BackColor = Color.Yellow;
                    }
                    else
                    {
                        txtCD.ForeColor = Color.White;
                        txtCD.BackColor = Color.Red;
                    }
                }
            }
            else
            {
                txtCD.Text = "";
                txtCD.ForeColor = Color.Black;
                txtCD.BackColor = Color.White;
            }

            if (xXx.GoterosDebajoPermisible.HasValue)
                txtGCDP.Text = String.Format("{0:N0}", xXx.GoterosDebajoPermisible);
            else
                txtGCDP.Text = "";

            if (xXx.GoterosPermisible.HasValue)
                txtGCP.Text = String.Format("{0:N0}", xXx.GoterosPermisible);
            else
                txtGCP.Text = "";

            if (xXx.GoterosSobrePermisible.HasValue)
                txtGCSP.Text = String.Format("{0:N0}", xXx.GoterosSobrePermisible);
            else
                txtGCSP.Text = "";

            if (xXx.GoterosDebajoPermisible.HasValue && xXx.GoterosPermisible.HasValue && xXx.GoterosSobrePermisible.HasValue)
                txtTotalGoteros.Text = String.Format("{0:N0}", xXx.GoterosDebajoPermisible + xXx.GoterosPermisible + xXx.GoterosSobrePermisible);
            else
                txtTotalGoteros.Text = "";
        }

        private void frmDetailEvaluacion_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (listIDs.Count > 0)
            {
                if (MessageBox.Show("Hay datos sin guardar. ¿Desea cerrar la ventana?", "Aviso", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
        private void PaintGrid()
        {
            if (dgDatos.RowCount > 0)
            {
                try
                {
                    decimal cuLimiteSuperior = 90;
                    decimal cuLimiteInferior = 70;

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

        private void frmDetailEvaluacion_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
            PaintGrid();
        }
    }
}
