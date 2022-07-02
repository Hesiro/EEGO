using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using WinEEGO.Business;
using WinEEGO.Models;

namespace WinEEGO.Views.Report
{
    public partial class frmPorValvula : Form
    {
        List<EvaluacionGoteros> listEvaluacion = new List<EvaluacionGoteros>();
        List<EvaluacionGoteros> listEvaluacionFiltrado = new List<EvaluacionGoteros>();
        EvaluacionGoteros currentEvaluacion = new EvaluacionGoteros();
        public frmPorValvula()
        {
            InitializeComponent();
        }

        private void frmPorValvula_Load(object sender, EventArgs e)
        {
            txtAnio.Value = DateTime.Today.Year;
            LoadArea();
            CleanGrafico01();
        }
        private void LoadArea()
        {
            cbArea.DisplayMember = "Codigo";
            cbArea.ValueMember = "Codigo";
            cbArea.DataSource = AreaGeneralBL.Instancia.List();
            if (cbArea.Items.Count > 0)
            {
                LoadValvula();
            }
        }
        private void LoadValvula()
        {
            cbValvula.Text = "";
            if (cbArea.SelectedIndex >= 0 && !cbArea.Text.Equals(""))
            {
                cbValvula.DisplayMember = "Nombre";
                cbValvula.ValueMember = "Nombre";
                cbValvula.DataSource = ValvulaCampoBL.Instancia.List(new AreaGeneral() { Codigo = cbArea.Text });
            }
            else
            {
                cbValvula.DataSource = null;
            }
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (cbValvula.SelectedIndex >= 0)
            {
                if (btnMostrar.Text.Equals("Mostrar"))
                {
                    btnMostrar.Text = "Cambiar";
                    btnMostrar.ImageIndex = 1;
                    //btnDetalles.Visible = true;
                    txtAnio.Enabled = false;
                    cbArea.Enabled = false;
                    cbValvula.Enabled = false;
                    dgDatos.Enabled = true;
                    ActualizarDatos();
                }
                else
                {
                    btnMostrar.Text = "Mostrar";
                    btnMostrar.ImageIndex = 0;
                    txtAnio.Enabled = true;
                    //btnDetalles.Visible = false;
                    cbArea.Enabled = true;
                    cbValvula.Enabled = true;
                    dgDatos.Enabled = false;
                    bsEvaluacionGoteros.DataSource = null;
                    currentEvaluacion = null;
                    CleanGrafico01();
                    //lbResp.Visible = false;
                    //cbResp.Visible = false;
                }
            }
        }
        private void ActualizarDatos()
        {
            listEvaluacion = EvaluacionGoterosBL.Instancia.List((int)txtAnio.Value, cbArea.SelectedValue.ToString(), cbValvula.SelectedValue.ToString());

            //var res = (from a in listEvaluacion
            //           select a.Usuario.PerteneceA.NombreDepartamento).Distinct();

            //if (res != null)
            //{
            //    if (res.Count() > 1)
            //    {
            //        lbResp.Visible = true;
            //        cbResp.Visible = true;

            //        cbResp.Items.Clear();
            //        cbResp.Items.Add("Todos");

            //        foreach (var item in res)
            //        {
            //            cbResp.Items.Add(item.ToString());
            //        }

            //        cbResp.SelectedIndex = 0;
            //        Filtrar();
            //    }
            //    else
            //    {
            //        lbResp.Visible = false;
            //        cbResp.Visible = false;
                    listEvaluacionFiltrado = listEvaluacion;
            //    }
            //}

            bsEvaluacionGoteros.DataSource = listEvaluacionFiltrado;

            CargarDato();
            PintarGrid();
            Grafico01();
        }
        private void CargarDato()
        {
            if (dgDatos.RowCount > 0)
                currentEvaluacion = (EvaluacionGoteros)bsEvaluacionGoteros.Current;
        }
        private void PintarGrid()
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
                        if (dgDatos.Rows[i].Cells[5].Value != null)
                        {
                            if (Single.TryParse(dgDatos.Rows[i].Cells[5].Value.ToString(), out tCurrent))
                            {
                                if (tCurrent > cuLimiteSuperior)
                                {
                                    dgDatos.Rows[i].Cells[5].Style.ForeColor = Color.White;
                                    dgDatos.Rows[i].Cells[5].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent > cuLimiteInferior)
                                    {
                                        dgDatos.Rows[i].Cells[5].Style.ForeColor = Color.Black;
                                        dgDatos.Rows[i].Cells[5].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDatos.Rows[i].Cells[5].Style.ForeColor = Color.White;
                                        dgDatos.Rows[i].Cells[5].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }

                        //Pintado de Coeficiente de Variacion
                        if (dgDatos.Rows[i].Cells[6].Value != null)
                        {
                            if (Single.TryParse(dgDatos.Rows[i].Cells[6].Value.ToString(), out tCurrent))
                            {
                                tCurrent = Math.Abs(tCurrent);
                                if (tCurrent < LimiteInferior)
                                {
                                    dgDatos.Rows[i].Cells[6].Style.ForeColor = Color.White;
                                    dgDatos.Rows[i].Cells[6].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent < LimiteSuperior)
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

                        //Pintado de Coeficiente de Desviacion
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

                        //Pintado de Coeficiente de Uniformidad * Desviacion
                        if (dgDatos.Rows[i].Cells[12].Value != null)
                        {
                            if (Single.TryParse(dgDatos.Rows[i].Cells[12].Value.ToString(), out tCurrent))
                            {
                                if (tCurrent > cuLimiteSuperior)
                                {
                                    dgDatos.Rows[i].Cells[12].Style.ForeColor = Color.White;
                                    dgDatos.Rows[i].Cells[12].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent > cuLimiteInferior)
                                    {
                                        dgDatos.Rows[i].Cells[12].Style.ForeColor = Color.Black;
                                        dgDatos.Rows[i].Cells[12].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDatos.Rows[i].Cells[12].Style.ForeColor = Color.White;
                                        dgDatos.Rows[i].Cells[12].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }

                    }

                }
                catch (Exception ex)
                {
                    Log.FailRegister(ex.Message);
                }
            }
        }

        private void dgDatos_SelectionChanged(object sender, EventArgs e)
        {
            CargarDato();
        }
        private void CleanGrafico01()
        {
            chart01.Series.Clear();
            chart01.ChartAreas.Clear();
            chart01.Legends.Clear();
            chart01.Titles.Clear();
        }
        private void Grafico01()
        {
            CleanGrafico01();

            chart01.ChartAreas.Add("Grafico");

            chart01.Series.Add("Cu");            

            foreach (Series serie in chart01.Series)
            {
                serie.ChartType = SeriesChartType.Line;
                serie.Font = new Font("Arial", 8, FontStyle.Regular);
                serie.MarkerStyle = MarkerStyle.Circle;
                serie.MarkerBorderColor = Color.Black;
                serie.BorderWidth = 2;
                serie.MarkerSize = 6;
            }

            chart01.Legends.Add("Grafico");
            chart01.Legends["Grafico"].BorderColor = Color.Black;
            chart01.Legends["Grafico"].ShadowOffset = 1;
            chart01.Legends["Grafico"].Docking = Docking.Top;
            //chart01.Legends["Grafico"].InsideChartArea = "Grafico";

            chart01.ChartAreas["Grafico"].BackColor = Color.Transparent;
            chart01.ChartAreas["Grafico"].AxisX.MajorGrid.Enabled = true;
            chart01.ChartAreas["Grafico"].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart01.ChartAreas["Grafico"].AxisX.MajorGrid.LineWidth = 1;
            chart01.ChartAreas["Grafico"].AxisX.LabelStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            chart01.ChartAreas["Grafico"].AxisX.LabelStyle.IsStaggered = false;
            chart01.ChartAreas["Grafico"].AxisX.IsMarginVisible = true;
            chart01.ChartAreas["Grafico"].AxisX.LabelStyle.Format = "MMM";

            chart01.ChartAreas["Grafico"].AxisY.MajorGrid.Enabled = true;
            chart01.ChartAreas["Grafico"].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart01.ChartAreas["Grafico"].AxisY.MajorGrid.LineWidth = 1;
            chart01.ChartAreas["Grafico"].AxisY.LabelStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            chart01.ChartAreas["Grafico"].AxisY.LabelStyle.Format = "#0 '%'";
            chart01.ChartAreas["Grafico"].AxisY.Maximum = 100;
            chart01.ChartAreas["Grafico"].AxisY.Minimum = 0;

            chart01.Series["Cu"].Points.DataBindXY(listEvaluacionFiltrado, "Fecha", listEvaluacionFiltrado, "CoeficienteUniformidad");            

            Int32 i = 0;
            foreach (var item in listEvaluacionFiltrado)
            {
                //Puntos de CU
                if (item.CoeficienteUniformidad.HasValue)
                {
                    if (item.CoeficienteUniformidad > 90)
                    {
                        chart01.Series["Cu"].Points[i].MarkerColor = Color.Green;
                        chart01.Series["Cu"].Points[i].MarkerSize = 8;
                    }
                    else
                    {
                        if (item.CoeficienteUniformidad > 70)
                        {
                            chart01.Series["Cu"].Points[i].MarkerColor = Color.Yellow;
                            chart01.Series["Cu"].Points[i].MarkerSize = 8;
                        }
                        else
                        {
                            chart01.Series["Cu"].Points[i].MarkerColor = Color.Red;
                            chart01.Series["Cu"].Points[i].MarkerSize = 10;
                        }
                    }
                }
                
                i++;
            }

            StripLine stripLineGreen = new StripLine();
            stripLineGreen.BackColor = Color.FromArgb(33, Color.Green);
            stripLineGreen.IntervalOffset = 90;
            stripLineGreen.StripWidth = 10;

            StripLine stripLineYellow = new StripLine();
            stripLineYellow.BackColor = Color.FromArgb(33, Color.Yellow);
            stripLineYellow.IntervalOffset = 70;
            stripLineYellow.StripWidth = 20;

            StripLine stripLineRed = new StripLine();
            stripLineRed.BackColor = Color.FromArgb(33, Color.Red);
            stripLineRed.IntervalOffset = 0;
            stripLineRed.StripWidth = 70;

            chart01.ChartAreas["Grafico"].AxisY.StripLines.Add(stripLineGreen);
            chart01.ChartAreas["Grafico"].AxisY.StripLines.Add(stripLineYellow);
            chart01.ChartAreas["Grafico"].AxisY.StripLines.Add(stripLineRed);
        }

        private void cbArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadValvula();
        }

        private void frmPorValvula_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void chart01_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:
                    e.Text = e.HitTestResult.Series.Name + ": " +
                        e.HitTestResult.Series.Points[e.HitTestResult.PointIndex].GetValueByName("Y").ToString("N1") + "%";
                    break;
            }
        }

        private void dgDatos_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (currentEvaluacion != null)
            {
                frmDetalleEvaluacion frm = new frmDetalleEvaluacion((int)txtAnio.Value, currentEvaluacion);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }
    }
}
