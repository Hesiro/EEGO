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
    public partial class frmPorArea : Form
    {
        List<EvaluacionGoteros> listEvaluacion = new List<EvaluacionGoteros>();
        List<EvaluacionGoteros> listEvaluacionFiltrado = new List<EvaluacionGoteros>();
        EvaluacionGoteros currentEvaluacion = new EvaluacionGoteros();

        public frmPorArea()
        {
            InitializeComponent();
        }

        private void frmPorArea_Load(object sender, EventArgs e)
        {
            txtAnio.Value = DateTime.Today.Year;
            LoadArea();
            CleanGrafico01();
            CleanGrafico02();
        }
        private void LoadArea()
        {
            cbArea.DataSource = AreaGeneralBL.Instancia.List();
            cbArea.DisplayMember = "Codigo";
            cbArea.ValueMember = "Codigo";
        }
        private void CleanGrafico01()
        {
            chart01.Series.Clear();
            chart01.Legends.Clear();
            chart01.Titles.Clear();
            chart01.ChartAreas.Clear();

            chart01.ChartAreas.Add("Grafico");
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

        private void CleanGrafico02()
        {
            chart02.Series.Clear();
            chart02.Legends.Clear();
            chart02.Titles.Clear();
            chart02.ChartAreas.Clear();

            chart02.ChartAreas.Add("Grafico");
            chart02.Legends.Add("Grafico");

            chart02.Legends["Grafico"].BorderColor = Color.Black;
            chart02.Legends["Grafico"].ShadowOffset = 1;
            chart02.Legends["Grafico"].Docking = Docking.Top;
            //chart02.Legends["Grafico"].InsideChartArea = "Grafico";

            chart02.ChartAreas["Grafico"].BackColor = Color.Transparent;
            chart02.ChartAreas["Grafico"].AxisX.MajorGrid.Enabled = true;
            chart02.ChartAreas["Grafico"].AxisX.MajorGrid.LineColor = Color.LightGray;
            chart02.ChartAreas["Grafico"].AxisX.MajorGrid.LineWidth = 1;
            chart02.ChartAreas["Grafico"].AxisX.LabelStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            chart02.ChartAreas["Grafico"].AxisX.LabelStyle.IsStaggered = false;
            chart02.ChartAreas["Grafico"].AxisX.IsMarginVisible = true;
            chart02.ChartAreas["Grafico"].AxisX.LabelStyle.Format = "MMM";

            chart02.ChartAreas["Grafico"].AxisY.MajorGrid.Enabled = true;
            chart02.ChartAreas["Grafico"].AxisY.MajorGrid.LineColor = Color.LightGray;
            chart02.ChartAreas["Grafico"].AxisY.MajorGrid.LineWidth = 1;
            chart02.ChartAreas["Grafico"].AxisY.LabelStyle.Font = new Font("Arial", 8, FontStyle.Regular);
            chart02.ChartAreas["Grafico"].AxisY.Maximum = 15;
            chart02.ChartAreas["Grafico"].AxisY.Minimum = -15;
            chart02.ChartAreas["Grafico"].AxisY.LabelStyle.Format = "#0 '%'";

            StripLine stripLineGreen = new StripLine();
            stripLineGreen.BackColor = Color.FromArgb(33, Color.Green);
            stripLineGreen.IntervalOffset = -7;
            stripLineGreen.StripWidth = 14;

            StripLine stripLineYellowI = new StripLine();
            stripLineYellowI.BackColor = Color.FromArgb(33, Color.Yellow);
            stripLineYellowI.IntervalOffset = -10;
            stripLineYellowI.StripWidth = 3;

            StripLine stripLineYellowS = new StripLine();
            stripLineYellowS.BackColor = Color.FromArgb(33, Color.Yellow);
            stripLineYellowS.IntervalOffset = 7;
            stripLineYellowS.StripWidth = 3;

            StripLine stripLineRedI = new StripLine();
            stripLineRedI.BackColor = Color.FromArgb(33, Color.Red);
            stripLineRedI.IntervalOffset = -15;
            stripLineRedI.StripWidth = 5;

            StripLine stripLineRedS = new StripLine();
            stripLineRedS.BackColor = Color.FromArgb(33, Color.Red);
            stripLineRedS.IntervalOffset = 10;
            stripLineRedS.StripWidth = 5;

            chart02.ChartAreas["Grafico"].AxisY.StripLines.Add(stripLineGreen);
            chart02.ChartAreas["Grafico"].AxisY.StripLines.Add(stripLineYellowI);
            chart02.ChartAreas["Grafico"].AxisY.StripLines.Add(stripLineYellowS);
            chart02.ChartAreas["Grafico"].AxisY.StripLines.Add(stripLineRedI);
            chart02.ChartAreas["Grafico"].AxisY.StripLines.Add(stripLineRedS);
        }

        private void btnMostrar_Click(object sender, EventArgs e)
        {
            if (cbArea.SelectedIndex >= 0)
            {
                if (btnMostrar.Text.Equals("Mostrar"))
                {
                    btnMostrar.Text = "Cambiar";
                    btnMostrar.ImageIndex = 1;
                    txtAnio.Enabled = false;
                    cbArea.Enabled = false;
                    //btnDetalles.Enabled = true;
                    dgDatos.Enabled = true;
                    ActualizarDatos();
                    //btnDetalles.Visible = true;
                }
                else
                {
                    btnMostrar.Text = "Mostrar";
                    btnMostrar.ImageIndex = 0;
                    txtAnio.Enabled = true;
                    cbArea.Enabled = true;
                    //btnDetalles.Enabled = false;
                    dgDatos.Enabled = false;
                    bsEvaluacionGoteros.DataSource = null;
                    currentEvaluacion = null;
                    //lbResp.Visible = false;
                    //cbResp.Visible = false;
                    //btnDetalles.Visible = false;
                    Grafico01();
                    Grafico02();
                }
            }
        }
        private void ActualizarDatos()
        {
            listEvaluacion = EvaluacionGoterosBL.Instancia.List((int)txtAnio.Value, cbArea.SelectedValue.ToString());
            listEvaluacionFiltrado = listEvaluacion;            
            bsEvaluacionGoteros.DataSource = listEvaluacionFiltrado;

            CargarDato();
            PintarGrid();
            Grafico01();
            Grafico02();
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
                    }
                }
                catch (Exception ex)
                {
                    Log.FailRegister("frmHistoricoPorLote: " + ex.Message);
                }
            }
        }

        private void dgDatos_SelectionChanged(object sender, EventArgs e)
        {
            CargarDato();
        }
        private void Grafico01()
        {
            chart01.Series.Clear();
            if (bsEvaluacionGoteros.DataSource != null)
            {
                chart01.Series.Add("Cu");

                foreach (Series serie in chart01.Series)
                {
                    serie.ChartType = SeriesChartType.Line;
                    serie.Font = new Font("Arial", 8, FontStyle.Regular);
                    serie.MarkerStyle = MarkerStyle.Circle;
                    serie.MarkerBorderColor = Color.Gray;
                    serie.BorderWidth = 2;
                    serie.MarkerSize = 6;
                }

                chart01.Series["Cu"].Points.DataBindXY(listEvaluacionFiltrado, "Fecha", listEvaluacionFiltrado, "CoeficienteUniformidad");

                Int32 i = 0;
                foreach (var item in listEvaluacionFiltrado)
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
            }
        }

        private void Grafico02()
        {
            chart02.Series.Clear();
            if (bsEvaluacionGoteros.DataSource != null)
            {
                chart02.Series.Add("Cv");
                chart02.Series.Add("Cd");

                foreach (Series serie in chart02.Series)
                {
                    serie.ChartType = SeriesChartType.Line;
                    serie.Font = new Font("Arial", 8, FontStyle.Regular);
                    serie.MarkerStyle = MarkerStyle.Circle;
                    serie.MarkerBorderColor = Color.Gray;
                    serie.BorderWidth = 2;
                    serie.MarkerSize = 6;
                }

                chart02.Series["Cv"].Points.DataBindXY(listEvaluacionFiltrado, "Fecha", listEvaluacionFiltrado, "CoeficienteVariacion");
                chart02.Series["Cd"].Points.DataBindXY(listEvaluacionFiltrado, "Fecha", listEvaluacionFiltrado, "CoeficienteDesviacion");

                Int32 i = 0;
                foreach (var item in listEvaluacionFiltrado)
                {
                    if (item.CoeficienteVariacion.HasValue)
                    {
                        if (item.CoeficienteVariacion < 7)
                        {
                            chart02.Series["Cv"].Points[i].MarkerColor = Color.Green;
                            chart02.Series["Cv"].Points[i].MarkerSize = 8;
                        }
                        else
                        {
                            if (item.CoeficienteVariacion < 10)
                            {
                                chart02.Series["Cv"].Points[i].MarkerColor = Color.Yellow;
                                chart02.Series["Cv"].Points[i].MarkerSize = 8;
                            }
                            else
                            {
                                chart02.Series["Cv"].Points[i].MarkerColor = Color.Red;
                                chart02.Series["Cv"].Points[i].MarkerSize = 10;
                            }
                        }
                    }

                    if (true)
                    {
                        if (item.CoeficienteDesviacion < 7)
                        {
                            chart02.Series["Cd"].Points[i].MarkerColor = Color.Green;
                            chart02.Series["Cd"].Points[i].MarkerSize = 8;
                        }
                        else
                        {
                            if (item.CoeficienteDesviacion < 10)
                            {
                                chart02.Series["Cd"].Points[i].MarkerColor = Color.Yellow;
                                chart02.Series["Cd"].Points[i].MarkerSize = 8;
                            }
                            else
                            {
                                chart02.Series["Cd"].Points[i].MarkerColor = Color.Red;
                                chart02.Series["Cd"].Points[i].MarkerSize = 10;
                            }
                        }
                    }
                    i++;
                }
            }
        }

        private void frmPorArea_Shown(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Maximized;
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

        private void chart02_GetToolTipText(object sender, ToolTipEventArgs e)
        {
            switch (e.HitTestResult.ChartElementType)
            {
                case ChartElementType.DataPoint:
                    e.Text = e.HitTestResult.Series.Name + ": " +
                        e.HitTestResult.Series.Points[e.HitTestResult.PointIndex].GetValueByName("Y").ToString("N1") + "%";
                    break;
            }
        }
    }
}
