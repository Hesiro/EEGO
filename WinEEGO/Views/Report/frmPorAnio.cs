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
    public partial class frmPorAnio : Form
    {
        private ReportePorAnioBL ReporteAnio;
        private EvaluacionGoteros currentEvaluacionDet;
        public frmPorAnio()
        {
            InitializeComponent();
        }

        private void frmPorAnio_Load(object sender, EventArgs e)
        {
            txtCampania.Value = DateTime.Today.Year;
            CargarCultivo();
            CleanGrafico01();
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
                    btnMostrar.ImageIndex = 1;
                    btnMostrar.Visible = false;
                    txtCampania.Enabled = false;
                    cbCultivo.Enabled = false;
                    dgDatos.Enabled = true;
                    dgDetalles.Enabled = true;
                    CleanGrafico01();
                    ReporteAnio = new ReportePorAnioBL(int.Parse(txtCampania.Text), cbCultivo.Text);
                    bsAnio.DataSource = ReporteAnio.ListaReporte();
                    //cbResp.DataSource = ReporteCampania.ListaResponsables();
                    //cbResp.SelectedIndex = 0;
                    //cbResp_SelectedIndexChanged(new Object(), EventArgs.Empty);
                    //if (cbResp.Items.Count == 1)
                    //    cbResp.Visible = false;
                    //else
                    //    cbResp.Visible = true;
                    PintarGrid();
                    btnMostrar.Visible = true;
                }
                else
                {
                    btnMostrar.Text = "Mostrar";
                    btnMostrar.ImageIndex = 0;
                    btnMostrar.Visible = false;
                    txtCampania.Enabled = true;
                    cbCultivo.Enabled = true;
                    dgDatos.Enabled = false;
                    dgDetalles.Enabled = false;
                    bsAnio.DataSource = null;
                    //lbResp.Visible = false;
                    //cbResp.Visible = false;
                    ReporteAnio = null;
                    CleanGrafico01();
                    btnMostrar.Visible = true;
                }
            }
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
                        if (dgDatos.Rows[i].Cells[2].Value != null)
                        {
                            if (Single.TryParse(dgDatos.Rows[i].Cells[2].Value.ToString(), out tCurrent))
                            {
                                if (tCurrent > cuLimiteSuperior)
                                {
                                    dgDatos.Rows[i].Cells[2].Style.ForeColor = Color.White;
                                    dgDatos.Rows[i].Cells[2].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent > cuLimiteInferior)
                                    {
                                        dgDatos.Rows[i].Cells[2].Style.ForeColor = Color.Black;
                                        dgDatos.Rows[i].Cells[2].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDatos.Rows[i].Cells[2].Style.ForeColor = Color.White;
                                        dgDatos.Rows[i].Cells[2].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }

                        if (dgDatos.Rows[i].Cells[3].Value != null)
                        {
                            if (Single.TryParse(dgDatos.Rows[i].Cells[3].Value.ToString(), out tCurrent))
                            {
                                tCurrent = Math.Abs(tCurrent);

                                if (tCurrent < LimiteInferior)
                                {
                                    dgDatos.Rows[i].Cells[3].Style.ForeColor = Color.White;
                                    dgDatos.Rows[i].Cells[3].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent < LimiteSuperior)
                                    {
                                        dgDatos.Rows[i].Cells[3].Style.ForeColor = Color.Black;
                                        dgDatos.Rows[i].Cells[3].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDatos.Rows[i].Cells[3].Style.ForeColor = Color.White;
                                        dgDatos.Rows[i].Cells[3].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }

                        if (dgDatos.Rows[i].Cells[4].Value != null)
                        {
                            if (Single.TryParse(dgDatos.Rows[i].Cells[4].Value.ToString(), out tCurrent))
                            {
                                tCurrent = Math.Abs(tCurrent);

                                if (tCurrent < LimiteInferior)
                                {
                                    dgDatos.Rows[i].Cells[4].Style.ForeColor = Color.White;
                                    dgDatos.Rows[i].Cells[4].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent < LimiteSuperior)
                                    {
                                        dgDatos.Rows[i].Cells[4].Style.ForeColor = Color.Black;
                                        dgDatos.Rows[i].Cells[4].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDatos.Rows[i].Cells[4].Style.ForeColor = Color.White;
                                        dgDatos.Rows[i].Cells[4].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.FailRegister("frmRepCampania - " + ex.Message);
                }
            }
        }

        private void dgDatos_SelectionChanged(object sender, EventArgs e)
        {
            EvaluacionGoterosAnio oi = new EvaluacionGoterosAnio();
            oi = (EvaluacionGoterosAnio)bsAnio.Current;
            if (oi != null)
            {
                bsDetalleAnio.DataSource = oi.Evaluaciones;
                PintarGridPadre();
                Grafico01();
            }
            else
            {
                bsDetalleAnio.DataSource = null;
                CleanGrafico01();
            }
        }
        private void PintarGridPadre()
        {
            if (dgDetalles.RowCount > 0)
            {
                try
                {
                    Single cuLimiteSuperior = 90;
                    Single cuLimiteInferior = 70;
                    Single LimiteInferior = 7;
                    Single LimiteSuperior = 10;
                    Single tCurrent;

                    for (int i = 0; i < dgDetalles.RowCount; i++)
                    {
                        if (dgDetalles.Rows[i].Cells[3].Value != null)
                        {
                            if (Single.TryParse(dgDetalles.Rows[i].Cells[3].Value.ToString(), out tCurrent))
                            {
                                if (tCurrent > cuLimiteSuperior)
                                {
                                    dgDetalles.Rows[i].Cells[3].Style.ForeColor = Color.White;
                                    dgDetalles.Rows[i].Cells[3].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent > cuLimiteInferior)
                                    {
                                        dgDetalles.Rows[i].Cells[3].Style.ForeColor = Color.Black;
                                        dgDetalles.Rows[i].Cells[3].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDetalles.Rows[i].Cells[3].Style.ForeColor = Color.White;
                                        dgDetalles.Rows[i].Cells[3].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }

                        if (dgDetalles.Rows[i].Cells[4].Value != null)
                        {
                            if (Single.TryParse(dgDetalles.Rows[i].Cells[4].Value.ToString(), out tCurrent))
                            {
                                tCurrent = Math.Abs(tCurrent);

                                if (tCurrent < LimiteInferior)
                                {
                                    dgDetalles.Rows[i].Cells[4].Style.ForeColor = Color.White;
                                    dgDetalles.Rows[i].Cells[4].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent < LimiteSuperior)
                                    {
                                        dgDetalles.Rows[i].Cells[4].Style.ForeColor = Color.Black;
                                        dgDetalles.Rows[i].Cells[4].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDetalles.Rows[i].Cells[4].Style.ForeColor = Color.White;
                                        dgDetalles.Rows[i].Cells[4].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }

                        if (dgDetalles.Rows[i].Cells[5].Value != null)
                        {
                            if (Single.TryParse(dgDetalles.Rows[i].Cells[5].Value.ToString(), out tCurrent))
                            {
                                tCurrent = Math.Abs(tCurrent);

                                if (tCurrent < LimiteInferior)
                                {
                                    dgDetalles.Rows[i].Cells[5].Style.ForeColor = Color.White;
                                    dgDetalles.Rows[i].Cells[5].Style.BackColor = Color.Green;
                                }
                                else
                                {
                                    if (tCurrent < LimiteSuperior)
                                    {
                                        dgDetalles.Rows[i].Cells[5].Style.ForeColor = Color.Black;
                                        dgDetalles.Rows[i].Cells[5].Style.BackColor = Color.Yellow;
                                    }
                                    else
                                    {
                                        dgDetalles.Rows[i].Cells[5].Style.ForeColor = Color.White;
                                        dgDetalles.Rows[i].Cells[5].Style.BackColor = Color.Red;
                                    }
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Log.FailRegister("frmRepCampania - " + ex.Message);
                }
            }
        }

        private void dgDetalles_SelectionChanged(object sender, EventArgs e)
        {
            currentEvaluacionDet = (EvaluacionGoteros)bsDetalleAnio.Current;
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
            chart01.ChartAreas["Grafico"].AxisY.Maximum = 100;
            chart01.ChartAreas["Grafico"].AxisY.Minimum = 0;
            chart01.ChartAreas["Grafico"].AxisY.LabelStyle.Format = "#0 '%'";

            chart01.Series["Cu"].Points.DataBindXY(bsAnio.List, "RepNombreMes", bsAnio.List, "CoeficienteUniformidad");

            Int32 i = 0;
            foreach (var item in (List<EvaluacionGoterosAnio>)bsAnio.List)
            {
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

        private void frmPorAnio_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
        }

        private void dgDetalles_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (currentEvaluacionDet != null)
            {
                frmDetalleEvaluacion frm = new frmDetalleEvaluacion(0, currentEvaluacionDet);
                frm.MdiParent = this.MdiParent;
                frm.Show();
            }
        }
    }
}
